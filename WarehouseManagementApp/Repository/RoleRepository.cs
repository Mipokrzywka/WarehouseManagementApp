using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using WarehouseManagementApp.Data;
using WarehouseManagementApp.Interfaces;
using WarehouseManagementApp.Models;

namespace WarehouseManagementApp.Repository
{
    public class RoleRepository : Repository<Role>, IRoleRepository
    {
        public RoleRepository(ApplicationDbContext context) : base(context)
        {
        }

        public IEnumerable<Role> GetAllRolesWithPermissions()
        {
            return _dbSet
                        .Include(r => r.RolePermissions)
                            .ThenInclude(rp => rp.Permission)
                        .Include(r => r.UserRoles)
                            .ThenInclude(ur => ur.User)
                        .ToList();
        }

        public Role? GetRoleWithPermissions(int id)
        {
            return _dbSet
                        .Include(r => r.RolePermissions)
                            .ThenInclude(rp => rp.Permission)
                        .Include(r => r.UserRoles)
                            .ThenInclude(ur => ur.User)
                        .FirstOrDefault(r => r.Id == id);
        }

        public bool HasUsers(int id)
        {
            return _dbSet
                    .Where(r => r.Id == id)
                    .Any(r => r.UserRoles.Any(ur => ur.User != null));
        }

        public bool RoleExists(string name)
        {
            return _dbSet.Any(r => r.Name.ToLower() == name.ToLower());
        }

        public bool SoftDelete(Role role)
        {
            role.DeletedAt = DateTime.UtcNow;
            return Update(role);
        }
        
    }
}
