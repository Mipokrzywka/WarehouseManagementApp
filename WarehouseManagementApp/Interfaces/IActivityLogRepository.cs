using WarehouseManagementApp.Models;

namespace WarehouseManagementApp.Interfaces
{
    public interface IActivityLogRepository : IRepository<ActivityLog>
    {
        public IEnumerable<ActivityLog> GetActivityLogs(string moduleName, int moduleId);
    }
}
