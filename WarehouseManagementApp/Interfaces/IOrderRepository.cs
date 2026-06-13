using WarehouseManagementApp.Models;

namespace WarehouseManagementApp.Interfaces
{
    public interface IOrderRepository : IRepository<Order>
    {
        Order? GetOrderWithDetails(int id);
        ICollection<Order> GetAllOrdersWithDetails(string getBy = "", int id = 0);
        bool SoftDelete(int id);
        bool ChangeStatus(int id, int status, int? reviewerId = null);
    }
}
