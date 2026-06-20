using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Linq.Expressions;
using WarehouseManagementApp.Data;
using WarehouseManagementApp.Interfaces;
using WarehouseManagementApp.Models;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;

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
        public bool SoftDelete(Product product)
        {
            product.DeletedAt = DateTime.UtcNow;
            return Update(product);
        }

        public IEnumerable<Product> GetAllProductsWithIds(IEnumerable<int> ids)
        {
            return _dbSet
                         .Where(p => ids.Contains(p.Id))
                         .ToList();
        }

        public DateTime? CalculateForecastDate(int productId, int daysHistory)
        {
            var product = GetById(productId);
            if (product == null)    
                return null;

            var startDate = DateTime.UtcNow.AddDays(-daysHistory);

            var dailySales = _context.OrderProducts
                .Where(op => op.ProductId == product.Id &&
                             op.CreatedAt >= startDate &&
                             (op.Order.StatusId == (int) OrderStatusEnum.Completed ||
                             op.Order.StatusId == (int) OrderStatusEnum.Approved))
                .GroupBy(op => op.Order.CreatedAt.Date)
                .Select(g => new {Date = g.Key, Quantity = g.Sum(op => op.Quantity)})
                .ToList();

            var allDaysSales = Enumerable.Range(0, daysHistory)
                .Select(i => startDate.AddDays(i).Date)
                .Select(d => (decimal)(dailySales.FirstOrDefault(s => s.Date == d)?.Quantity ?? 0))
                .ToList();

            if (!allDaysSales.Any() || allDaysSales.Sum() == 0) return null;

            decimal avg = allDaysSales.Average();
            double squareSum = allDaysSales.Sum(val => Math.Pow((double)(val - avg), 2));
            decimal stdDev = (decimal)Math.Sqrt(squareSum / daysHistory);

            List<decimal> devSales;
            if(allDaysSales.Sum() < 10)
            {
                devSales = allDaysSales;
            }
            else 
            {
                devSales = allDaysSales
                .Select(val => (val > avg + (2.5m * stdDev)) ? avg : val)
                .ToList();
            }

            decimal alpha = 0.2m;
            decimal weightedDailySales = devSales.First();

            for(int i = 1; i < devSales.Count; ++i)
            {
                weightedDailySales = 2;
            }

            Debug.WriteLine($"WeightedDailySales: {weightedDailySales}");

            if (weightedDailySales > 0)
            {
                int daysRemaining = (int)Math.Floor(product.Quantity / weightedDailySales);
                return DateTime.UtcNow.AddDays(daysRemaining).Date;
            }
            return null;
        }

        public bool UpdateForecastDate(int productId, int daysHistory)
        {
            var product = GetById(productId);
            if(product == null) return false;

            product.ForecastDepletionDate = CalculateForecastDate(productId, daysHistory);
            product.ForecastUpdatedAt = DateTime.UtcNow;
            return Save();
        }
    }
}
