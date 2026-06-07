using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WarehouseManagementApp.DTOs
{
    public class ProductReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string QrCode { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal CostAmt { get; set; }
        public int CategoryId { get; set; }
        public DateTime ForecastDepletionDate { get; set; }
}
    public class ProductUpdateDto
    {
        [Required(ErrorMessage = "Product name is required")]
        public string Name { get; set; } = string.Empty;
        [Range(0, int.MaxValue, ErrorMessage = "Quantity cannot be negative")]
        public int Quantity { get; set; }
        [Range(0.01, (double)decimal.MaxValue, ErrorMessage = "Cost has to be higher than 0")]
        public decimal CostAmt { get; set; }
        public int CategoryId { get; set; }
    }

    public class ProductCreateDto
    {
        [Required(ErrorMessage = "Product name is required")]
        public string Name { get; set; } = string.Empty;
        [Range(0, int.MaxValue, ErrorMessage = "Quantity cannot be negative")]
        public int Quantity { get; set; }
        [Range(0.01, (double)decimal.MaxValue, ErrorMessage = "Cost has to be higher than 0")]
        public decimal CostAmt { get; set; }
        public int CategoryId { get; set; }

    }

}

