using Microsoft.EntityFrameworkCore;
using WarehouseManagementApp.Data;
using WarehouseManagementApp.Interfaces;
using WarehouseManagementApp.Models;

namespace WarehouseManagementApp.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {
        }

        public bool EmailExists(string email)
        {
            return _dbSet
                   .Any(u => u.Email.ToLower() == email.ToLower());
        }

        public IEnumerable<User> GetAllUsersWithRoles()
        {
            return _dbSet
                   .Include(u => u.UserRoles)
                       .ThenInclude(ur => ur.Role)
                   .ToList();
        }

        public User? GetUserWithRolesAndPermissions(int id = 0, string email = "")
        {
            var users = _dbSet
                        .Include(u => u.UserRoles)
                            .ThenInclude(ur => ur.Role)
                                .ThenInclude(r => r.RolePermissions)
                                    .ThenInclude(rp => rp.Permission);
            if (id != 0)
                return users.FirstOrDefault(u => u.Id == id);
            if (!string.IsNullOrEmpty(email))
                return users.FirstOrDefault(u => u.Email == email);
            return null;
        }

        

        public bool SoftDelete(User user)
        {
            user.DeletedAt = DateTime.UtcNow;
            return Update(user);
        }
    }
}
