using Microsoft.EntityFrameworkCore;
using WarehouseManagementApp.Data;
using WarehouseManagementApp.Interfaces;
using WarehouseManagementApp.Models;

namespace WarehouseManagementApp.Repository
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(ApplicationDbContext context) : base(context)
        {
        }
        public bool ChangeStatus(int id, int status, int? reviewerId = null)
        {
            var order = GetById(id);
            if (order == null)
                return false;
            order.StatusId = status;
            if (reviewerId.HasValue)
                order.ReviewerId = reviewerId.Value;
            return Update(order);
        }

        public ICollection<Order> GetAllOrdersWithDetails(string getBy = "", int id = 0)
        {
            var query = _dbSet
                         .Include(o => o.CreatedBy)
                         .Include(o => o.Reviewer)
                         .Include(o => o.Status)
                         .Include(o => o.OrderProducts)
                             .ThenInclude(op => op.Product)
                             .ThenInclude(p => p.Category);

            if (getBy == "creator")
            {
                return query
                           .Where(o => o.CreatorId == id)
                           .ToList();
            }
            if (getBy == "reviewer")
            {
                return query
                           .Where(o => o.ReviewerId == id)
                           .ToList();
            }
            if (getBy == "status")
            {
                return query
                           .Where(o => o.StatusId == id)
                           .ToList();
            }
            return query
                        .ToList();
        }

        public Order? GetOrderWithDetails(int id)
        {
            return _dbSet
                         .Include(o => o.CreatedBy)
                         .Include(o => o.Reviewer)
                         .Include(o => o.Status)
                         .Include(o => o.OrderProducts)
                                .ThenInclude(op => op.Product)
                                .ThenInclude(p => p.Category)
                         .FirstOrDefault(o => o.Id == id);
        }

        public bool SoftDelete(int id)
        {
            var order = GetOrderWithDetails(id);
            if (order == null)
                return false;
            order.DeletedAt = DateTime.UtcNow;
            return Update(order);
        }
    }
}
