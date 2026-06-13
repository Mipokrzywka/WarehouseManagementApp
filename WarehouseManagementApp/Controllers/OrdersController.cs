using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WarehouseManagementApp.Models;
using WarehouseManagementApp.Data;
using WarehouseManagementApp.Interfaces;
using WarehouseManagementApp.Mappers;
using WarehouseManagementApp.DTOs;
using WarehouseManagementApp.Enums;

[Route("api/[controller]")]
[ApiController]
public class OrdersController : ControllerBase
{
    private readonly IOrderRepository _orderRepository;
    private readonly IActivityLogRepository _activityLogRepository;
    private readonly IProductRepository _productRepository;
    public OrdersController(IOrderRepository orderRepository, IActivityLogRepository activityLogRepository, IProductRepository productRepository)
    {
        _orderRepository = orderRepository;
        _activityLogRepository = activityLogRepository;
        _productRepository = productRepository;
    }

    [HttpGet]
    [ProducesResponseType(200, Type = typeof(IEnumerable<OrderReadDto>))]
    public IActionResult GetOrders()
    {
        var orders = _orderRepository.GetAllOrdersWithDetails();

        var ordersDto = orders.Select(o => o.ToReadDto()).ToList();
        return Ok(ordersDto);
    }

    [HttpGet("{id:int}")]
    [ProducesResponseType(200, Type = typeof(OrderReadDto))]
    [ProducesResponseType(404)]
    public IActionResult GetOrderById(int id)
    {
        var order = _orderRepository.GetOrderWithDetails(id);
        if (order == null)
            return NotFound($"Order with id {id} does not exist");
        return Ok(order.ToReadDto());
    }
    [HttpGet("creator/{id:int}")]
    [ProducesResponseType(200, Type = typeof(IEnumerable<OrderReadDto>))]
    [ProducesResponseType(404)]

    public IActionResult GetOrdersByCreatorId(int id)
    {
        var orders = _orderRepository.GetAllOrdersWithDetails("creator", id);
        if (orders == null || !orders.Any())
            return NotFound($"No orders found for creator with id {id}");
        var ordersDto = orders.Select(o => o.ToReadDto()).ToList();
        return Ok(ordersDto);
    }
    [HttpGet("reviewer/{id:int}")]
    [ProducesResponseType(200, Type = typeof(IEnumerable<OrderReadDto>))]
    [ProducesResponseType(404)]

    public IActionResult GetOrdersByReviewerId(int id)
    {
        var orders = _orderRepository.GetAllOrdersWithDetails("reviewer", id);
        if (orders == null || !orders.Any())
            return NotFound($"No orders found for reviewer with id {id}");
        var ordersDto = orders.Select(o => o.ToReadDto()).ToList();
        return Ok(ordersDto);
    }
    [HttpGet("status/{id:int}")]
    [ProducesResponseType(200, Type = typeof(IEnumerable<OrderReadDto>))]
    [ProducesResponseType(404)]

    public IActionResult GetOrdersByStatusId(int id)
    {
        var orders = _orderRepository.GetAllOrdersWithDetails("status", id);
        if (orders == null || !orders.Any())
            return NotFound($"No orders found for status with id {id}");
        var ordersDto = orders.Select(o => o.ToReadDto()).ToList();
        return Ok(ordersDto);
    }

    [HttpPut("{id:int}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    public IActionResult UpdateOrder(int id, [FromBody] OrderUpdateDto orderDto)
    {
        if(orderDto == null)
            return BadRequest("Invalid order data");
        if (orderDto.OrderProducts == null || !orderDto.OrderProducts.Any())
            return BadRequest("Order must contain at least one product");
        var existingOrder = _orderRepository.GetOrderWithDetails(id);
        if (existingOrder == null)
            return NotFound($"Order with id {id} does not exist");       
        if(existingOrder.StatusId != (int)OrderStatusEnum.New && existingOrder.StatusId != (int)OrderStatusEnum.Processing)
            return BadRequest($"Orders with status other than New or Processing cannot be modified");
        var oldData = System.Text.Json.JsonSerializer.Serialize(existingOrder.ToReadDto());
        var productIds = orderDto.OrderProducts.Select(op => op.ProductId).Distinct().ToList();
        var productsFromDb = _productRepository.GetAllProductsWithIds(productIds).ToList();
        existingOrder.OrderProducts.Clear();

        decimal totalOrderCost = 0;
        
        foreach (var dtoProduct in orderDto.OrderProducts)
        {
            var dbProductInfo = productsFromDb.FirstOrDefault(p => p.Id == dtoProduct.ProductId);
            if (dbProductInfo == null)
                return BadRequest($"Product with id {dtoProduct.ProductId} does not exist");
            if (dtoProduct.Quantity <= 0)
                return BadRequest($"Product with id {dtoProduct.ProductId} has invalid quantity selected");
            decimal lineCost = dbProductInfo.CostAmt * dtoProduct.Quantity;
            totalOrderCost += lineCost;
            existingOrder.OrderProducts.Add(new OrderProduct
            {
                ProductId = dtoProduct.ProductId,
                Quantity = dtoProduct.Quantity,
                CostAmt = lineCost,
            });
        }

        existingOrder.CostAmt = totalOrderCost;
        var newData = System.Text.Json.JsonSerializer.Serialize(existingOrder.ToReadDto());
        if (!_orderRepository.Update(existingOrder)) 
            return BadRequest("Failed to update order");

        ActivityLog log = new ActivityLog()
        {
            ModuleId = (int)ModuleEnum.Orders,
            ComponentId = existingOrder.Id,
            Action = "Update",
            UserId = 1, // Add user that deleted the order
            CreatedAt = DateTime.UtcNow,
            OldData = oldData,
            NewData = newData
        };
        _activityLogRepository.Create(log);
        return NoContent();
    }

    [HttpPut("{id:int}/status/{statusId:int}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]

    public IActionResult UpdateOrderStatus(int id, int statusId) 
    {
        var existingOrder = _orderRepository.GetOrderWithDetails(id);
        if (existingOrder == null)
            return NotFound($"Order with id {id} does not exist");
        var oldData = System.Text.Json.JsonSerializer.Serialize(existingOrder.ToReadDto());
        var currentStatus = (OrderStatusEnum)existingOrder.StatusId;
        var targetStatus = (OrderStatusEnum)statusId;
        bool isTransitionAllowed = (currentStatus, targetStatus) switch
        {
            (OrderStatusEnum.New, OrderStatusEnum.Processing) => true,

            (OrderStatusEnum.Processing, OrderStatusEnum.Approved) => true,
            (OrderStatusEnum.Processing, OrderStatusEnum.Rejected) => true,

            (OrderStatusEnum.Approved, OrderStatusEnum.Completed) => true,
            _ => false
        };
        if (!isTransitionAllowed)
            return BadRequest($"Status {currentStatus} cannot be changed to {targetStatus}");
        if (targetStatus == (OrderStatusEnum.Processing))
            existingOrder.ReviewerId = 1; //TBD - current user
        if (targetStatus == (OrderStatusEnum.Approved))
        {
            var orderProducts = existingOrder.OrderProducts;
            foreach (var productDto in orderProducts)
            {
                var product = productDto.Product;
                if (product == null)
                    return NotFound($"Product not found");
                if (product.Quantity - productDto.Quantity < 0)
                    return BadRequest($"Not enough stock of product {product.Name}. Current stock: {product.Quantity}, requested: {productDto.Quantity}");
                product.Quantity -= productDto.Quantity;
            }
        }
        existingOrder.StatusId = statusId;
        var newData = System.Text.Json.JsonSerializer.Serialize(existingOrder.ToReadDto());
        if(!_orderRepository.Update(existingOrder))
            return BadRequest("Failed to update status");

        ActivityLog log = new ActivityLog()
        {
            ModuleId = (int)ModuleEnum.Orders,
            ComponentId = id,
            Action = "Update status",
            UserId = 1, //TBD
            CreatedAt = DateTime.UtcNow,
            OldData = oldData,
            NewData = newData,
        };
        _activityLogRepository.Create(log);
        return NoContent();
    }

    [HttpPost]
    [ProducesResponseType(201, Type = typeof(OrderReadDto))]
    [ProducesResponseType(400)]
    public IActionResult CreateOrder([FromBody] OrderCreateDto orderDto)
    {
        if(orderDto == null)
            return BadRequest("Invalid order data");
        if(orderDto.OrderProducts == null || !orderDto.OrderProducts.Any())
            return BadRequest("Order must contain at least one product");
        decimal totalOrderCost = 0;
        var productIds = orderDto.OrderProducts.Select(op => op.ProductId).Distinct().ToList();

        var products = _productRepository.GetAllProductsWithIds(productIds).ToList();
        var createdOrder = OrderMapper.CreateDtoToOrder(orderDto);
        foreach (var product in createdOrder.OrderProducts)
        {
            var existingProduct = products.FirstOrDefault(p => p.Id == product.ProductId);
            if(existingProduct == null)
                return BadRequest($"Product with id {product.ProductId} does not exist");
            if (product.Quantity <= 0)
                return BadRequest($"Product with id {product.ProductId} has invalid quantity selected");
            product.CostAmt = existingProduct.CostAmt * product.Quantity;
            totalOrderCost += product.CostAmt;
        }
        
        createdOrder.CostAmt = totalOrderCost;

        if (!_orderRepository.Create(createdOrder))
            return BadRequest("Failed to create order");

        var fetchedOrder = _orderRepository.GetOrderWithDetails(createdOrder.Id);
        
        if (fetchedOrder == null)
            return BadRequest("Order created, but failed to fetch details for response.");

        var orderReadDto = fetchedOrder.ToReadDto();

        ActivityLog log = new ActivityLog()
        {
            ModuleId = (int)ModuleEnum.Orders,
            ComponentId = createdOrder.Id,
            Action = "Create",
            UserId = createdOrder.CreatorId,
            CreatedAt = DateTime.UtcNow,
            OldData = "",
            NewData = System.Text.Json.JsonSerializer.Serialize(orderReadDto)
        };
        _activityLogRepository.Create(log);
        return CreatedAtAction(nameof(GetOrderById), new { id = createdOrder.Id }, orderReadDto);
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeleteOrder(int id)
    {
        var order = _orderRepository.GetOrderWithDetails(id);
        if (order == null)
            return NotFound($"Order with id {id} does not exist");
        
        if (order.StatusId != (int)OrderStatusEnum.New)
            return BadRequest("Only orders with status new can be deleted");
        var oldProductData = System.Text.Json.JsonSerializer.Serialize(order.ToReadDto());

        if (!_orderRepository.SoftDelete(order))
            return BadRequest("Failed to delete order");

        ActivityLog log = new ActivityLog()
        {
            ModuleId = (int)ModuleEnum.Orders,
            ComponentId = order.Id,
            Action = "Delete",
            UserId = 1, // Add user that deleted the order
            CreatedAt = DateTime.UtcNow,
            OldData = oldProductData,
            NewData = ""
        }; 
        _activityLogRepository.Create(log);
        return NoContent();
    }    
}
