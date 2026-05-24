using WarehouseManagementApp.Models;

namespace WarehouseManagementApp.Interfaces
{
    public interface IProductRepository
    {
        ICollection<Product> GetAllProducts();
    }
}
