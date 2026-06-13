using Microsoft.EntityFrameworkCore;
using WarehouseManagementApp.Data;
using WarehouseManagementApp.Interfaces;
using WarehouseManagementApp.Models;

namespace WarehouseManagementApp.Repository
{
    public class ProductCategoryRepository : Repository<ProductCategory>, IProductCategoryRepository
    {
        public ProductCategoryRepository(ApplicationDbContext context) : base(context)
        {
        }
        public ProductCategory? GetByName(string name)
        {
            return _dbSet.FirstOrDefault(pc => pc.Name.ToLower() == name.ToLower());
        }

        public bool NameExists(string name, int categoryId = 0)
        {
            return _dbSet.Any(pc => pc.Name.ToLower() == name.ToLower() && categoryId != pc.Id && pc.DeletedAt == null);
        }

        public bool SoftDelete(int id)
        {
            var category = GetById(id);
            if (category == null)
                return false;
            category.DeletedAt = DateTime.UtcNow;
            _dbSet.Update(category);
            return Save();
        }
    }
}
