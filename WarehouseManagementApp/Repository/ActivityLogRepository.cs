using Microsoft.EntityFrameworkCore;
using WarehouseManagementApp.Data;
using WarehouseManagementApp.Interfaces;
using WarehouseManagementApp.Models;

namespace WarehouseManagementApp.Repository
{
    public class ActivityLogRepository : Repository<ActivityLog>, IActivityLogRepository
    {
        public ActivityLogRepository(ApplicationDbContext context) : base(context) { }
        public IEnumerable<ActivityLog> GetActivityLogs(string moduleName, int moduleId)
        {
            return
            _dbSet.Include(a => a.User)
                  .Include(a => a.Module)
                  .Where(a => a.Module.Name == moduleName && a.ModuleId == moduleId)
                  .ToList();
        }

    }
}
