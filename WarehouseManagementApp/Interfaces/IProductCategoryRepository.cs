using WarehouseManagementApp.Models;

namespace WarehouseManagementApp.Interfaces
{
    public interface IProductCategoryRepository : IRepository<ProductCategory>
    {
        ICollection<ProductCategory>? GetCategoriesWithProducts();
        ProductCategory? GetByName(string name);
        bool NameExists(string name, int categoryId = 0);
        bool SoftDelete(ProductCategory category);
        bool HasProducts(int id);
    }
}
