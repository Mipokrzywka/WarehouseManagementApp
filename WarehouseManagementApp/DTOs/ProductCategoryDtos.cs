namespace WarehouseManagementApp.DTOs
{
    public class ProductCategoryReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
    public class ProductCategoryUpdateDto
    {
        public string Name { get; set; } = string.Empty;
    }
    public class ProductCategoryCreateDto
    {
        public string Name { get; set; } = string.Empty;
    }
}
