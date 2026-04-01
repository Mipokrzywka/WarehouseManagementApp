namespace WarehouseManagementApp.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime DeletedAt {  get; set; }
        public ICollection<UserRoles> UserRoles { get; set; }
    }
}
