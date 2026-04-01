namespace WarehouseManagementApp.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? DeletedAt { get; set;}
        public bool IsActive { get; set; }
        public ICollection<Order> DecidedOrders { get; set; }
        public ICollection<Order> CreatedOrders { get; set; }
        public Role Role { get; set; }
    }
}
