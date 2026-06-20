namespace WarehouseManagementApp.DTOs
{
    public class ReportFilterDto
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public int? CategoryId { get; set; }
        public string? Brand { get; set; }

    }
}
