using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Linq.Expressions;
using WarehouseManagementApp.Data;
using WarehouseManagementApp.Interfaces;
using WarehouseManagementApp.Models;

namespace WarehouseManagementApp.Repository
{
    
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public ICollection<Product> GetAll()
        {
            return _context.Products
                           .Where(p => p.DeletedAt == null)
                           .OrderBy(p => p.Id)
                           .ToList();
        }

        public Product? GetById(int id)
        {
            return _context.Products
                           .FirstOrDefault(p => p.Id == id && p.DeletedAt == null);
        }

        public Product? GetByName(string name)
        {
            return _context.Products
                           .FirstOrDefault(p => p.Name == name && p.DeletedAt == null);
        }

        public Product? GetByQrCode(string qrCode)
        {
            return _context.Products
                           .FirstOrDefault(p => p.QrCode == qrCode && p.DeletedAt == null);
        }

        public ICollection<Product> GetByCategory(int categoryId)
        {
            return _context.Products
                           .Where(p => p.CategoryId == categoryId && p.DeletedAt == null)
                           .OrderBy(p => p.Id)
                           .ToList();
        }

        public bool Create(Product product)
        {
            _context.Add(product);
            return Save();
        }

        public bool QrCodeExists(string qrCode, int productId = 0)
        {
            return _context.Products
                           .Any(p => p.QrCode == qrCode && p.Id != productId && p.DeletedAt == null);
        }

        public bool Exists(int id)
        {
            return _context.Products
                           .Any(p => p.Id == id && p.DeletedAt == null);
        }
        public bool NameCategoryExists(string name, int categoryId, int productId = 0)
        {
            return _context.Products
                           .Any(p => p.Name == name && p.CategoryId == categoryId && p.Id != productId && p.DeletedAt == null);
        }

        public bool SoftDelete(int id)
        {
            var product = GetById(id);

            if (product == null)
                return false;

            product.DeletedAt = DateTime.UtcNow;
            _context.Update(product);
            return Save();
        }

        public bool Update(Product product)
        {
            product.UpdatedAt = DateTime.UtcNow;
            _context.Update(product);
            return Save();
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
    }
}
