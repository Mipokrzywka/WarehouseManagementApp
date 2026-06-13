using WarehouseManagementApp.Models;

namespace WarehouseManagementApp.Interfaces
{
    public interface IProductCategoryRepository : IRepository<ProductCategory>
    {
        ProductCategory? GetByName(string name);
        bool NameExists(string name, int categoryId = 0);
        bool SoftDelete(int id);
    }
}
