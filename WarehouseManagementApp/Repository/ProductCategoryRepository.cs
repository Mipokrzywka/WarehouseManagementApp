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
        public ICollection<ProductCategory>? GetCategoriesWithProducts()
        {
            return _dbSet
                    .Include(pc => pc.Products)
                    .ToList();
        }
        public ProductCategory? GetByName(string name)
        {
            return _dbSet.FirstOrDefault(pc => pc.Name.ToLower() == name.ToLower());
        }

        public bool NameExists(string name, int categoryId = 0)
        {
            return _dbSet.Any(pc => pc.Name.ToLower() == name.ToLower() && categoryId != pc.Id && pc.DeletedAt == null);
        }

        public bool HasProducts(int id)
        {
            return _context.Products.Any(p => p.CategoryId == id);
        }
        public bool SoftDelete(ProductCategory category)
        {
            category.DeletedAt = DateTime.UtcNow;
            _dbSet.Update(category);
            return Save();
        }

        
    }
}
