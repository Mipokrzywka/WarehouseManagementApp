using WarehouseManagementApp.Models;

namespace WarehouseManagementApp.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        Product? GetByName(string productName);
        Product? GetByQrCode(string qrCode);
        ICollection<Product> GetByCategory(int categoryId);
        bool QrCodeExists(string qrCode, int productId = 0);
        public bool NameCategoryExists(string name, int categoryId, int productId = 0);
        bool SoftDelete(Product product);
        IEnumerable<Product> GetAllProductsWithIds(IEnumerable<int> ids);
        public DateTime? CalculateForecastDate(int produdctId, int daysHistory);
        public bool UpdateForecastDate(int productId, int daysHistory);
    }
}
