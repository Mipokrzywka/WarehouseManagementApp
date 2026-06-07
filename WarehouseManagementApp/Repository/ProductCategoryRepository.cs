using Microsoft.EntityFrameworkCore;
using WarehouseManagementApp.Data;
using WarehouseManagementApp.Interfaces;
using WarehouseManagementApp.Models;

namespace WarehouseManagementApp.Repository
{
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductCategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool Create(ProductCategory category)
        {
            _context.Add(category);
            return Save();
        }

        public bool Exists(int id)
        {
            return _context.ProductCategories
                           .Any(c => c.Id == id && c.DeletedAt == null);
        }

        public ICollection<ProductCategory> GetAll()
        {
            return _context.ProductCategories
                           .Where(c => c.DeletedAt == null)
                           .OrderBy(c => c.Id)
                           .ToList();
        }

        public ProductCategory? GetById(int id)
        {
            return _context.ProductCategories
                           .FirstOrDefault(c => c.Id == id && c.DeletedAt == null);
        }

        public ProductCategory? GetByName(string name)
        {
            return _context.ProductCategories
                           .FirstOrDefault(c => c.Name == name && c.DeletedAt == null);
        }

        public bool NameExists(string name, int categoryId = 0)
        {
            return _context.ProductCategories
                           .Any(c => c.Name == name && c.Id != categoryId && c.DeletedAt == null);
        }

        public bool Save()
        {
            try
            {
                return _context.SaveChanges() > 0;
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine($"Data save failure: {ex.InnerException?.Message}");
                return false;
            }
        }

        public bool SoftDelete(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(ProductCategory category)
        {
            throw new NotImplementedException();
        }
    }
}
