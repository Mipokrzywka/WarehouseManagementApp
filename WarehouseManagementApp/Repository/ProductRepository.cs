using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Linq.Expressions;
using WarehouseManagementApp.Data;
using WarehouseManagementApp.Interfaces;
using WarehouseManagementApp.Models;

namespace WarehouseManagementApp.Repository
{
    
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext context) : base(context)
        {
        }
        public override ICollection<Product> GetAll()
        {
            return _dbSet
                         .Include(p => p.Category)
                         .ToList();
        }
        public Product? GetByName(string name)
        {
            return _dbSet.FirstOrDefault(p => p.Name == name && p.DeletedAt == null);
        }

        public Product? GetByQrCode(string qrCode)
        {
            return _dbSet.FirstOrDefault(p => p.QrCode == qrCode && p.DeletedAt == null);
        }

        public ICollection<Product> GetByCategory(int categoryId)
        {
            return _dbSet
                         .Where(p => p.CategoryId == categoryId && p.DeletedAt == null)
                         .OrderBy(p => p.Id)
                         .ToList();
        }


        public bool QrCodeExists(string qrCode, int productId = 0)
        {
            return _dbSet.Any(p => p.QrCode == qrCode && p.Id != productId && p.DeletedAt == null);
        }

        public bool NameCategoryExists(string name, int categoryId, int productId = 0)
        {
            return _dbSet.Any(p => p.Name == name && p.CategoryId == categoryId && p.Id != productId && p.DeletedAt == null);
        }
        public bool SoftDelete(int id)
        {
            var product = GetById(id);
            if (product == null)
                return false;
            product.DeletedAt = DateTime.UtcNow;
            return Update(product);
        }

        public IEnumerable<Product> GetAllProductsWithIds(IEnumerable<int> ids)
        {
            return _dbSet
                         .Where(p => ids.Contains(p.Id))
                         .ToList();
        }
    }
}
