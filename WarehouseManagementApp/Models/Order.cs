namespace WarehouseManagementApp.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int CreatedBy { get; set; }
        public string Status {  get; set; }

        public DateTime CreatedAt { get; set; }

        public User? DecidedBy { get; set; }
        public DateTime? DecidedAt { get; set; }
        public ICollection<OrderItem> Items { get; set; }
    }
}
