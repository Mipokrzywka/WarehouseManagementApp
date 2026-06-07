using WarehouseManagementApp.Models;

namespace WarehouseManagementApp.Interfaces
{
    public interface IProductCategoryRepository
    {
        ICollection<ProductCategory> GetAll();
        ProductCategory? GetById(int id);
        ProductCategory? GetByName(string name);
        bool Create(ProductCategory category);
        bool Update(ProductCategory category);
        bool SoftDelete(int id);
        bool Save();
        bool Exists(int id);
        bool NameExists(string name, int categoryId = 0);
    }
}
