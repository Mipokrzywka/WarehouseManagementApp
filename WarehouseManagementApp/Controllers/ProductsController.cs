using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WarehouseManagementApp.Models;
using WarehouseManagementApp.Data;
using WarehouseManagementApp.Interfaces;


namespace WarehouseManagementApp.Controllers 
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Product>))]

        public IActionResult GetProducts()
        {
            var products = _productRepository.GetAllProducts();

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(products);
        }
    }
}

