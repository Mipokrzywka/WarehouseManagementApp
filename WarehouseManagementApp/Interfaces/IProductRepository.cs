using WarehouseManagementApp.Models;

namespace WarehouseManagementApp.Interfaces
{
    public interface IProductRepository
    {
        ICollection<Product> GetAll();
        Product? GetById(int id);
        Product? GetByName(string productName);
        Product? GetByQrCode(string qrCode);
        ICollection<Product> GetByCategory(int categoryId);
        bool Create(Product product);
        bool Update(Product product);
        bool SoftDelete(int id);
        bool Save();
        bool QrCodeExists(string qrCode, int productId = 0);
        bool Exists(int id);
        public bool NameCategoryExists(string name, int categoryId, int productId = 0);

    }
}
