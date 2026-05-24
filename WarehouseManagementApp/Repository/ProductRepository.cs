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
            this._context = context;
        }

        public ICollection<Product> GetAllProducts()
        {
            return _context.Products.OrderBy(p => p.Id).Where(p => p.DeletedAt == null).ToList();
        }
    }
}
