using WarehouseManagementApp.Models;

namespace WarehouseManagementApp.Interfaces
{
    public interface IRoleRepository : IRepository<Role>
    {
        public bool SoftDelete(Role role);
        public IEnumerable<Role> GetAllRolesWithPermissions();
        public Role? GetRoleWithPermissions(int permissionId);
        public bool HasUsers(int id);
        public bool RoleExists(string Name);
    }
}
