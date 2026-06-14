using WarehouseManagementApp.Models;

namespace WarehouseManagementApp.Interfaces
{
    public interface IActivityLogRepository : IRepository<ActivityLog>
    {
        void LogActivity(ActivityLog log);
        public IEnumerable<ActivityLog> GetActivityLogs(string moduleName, int moduleId);
    }
}
