using WarehouseManagementApp.Models;

namespace WarehouseManagementApp.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        IEnumerable<User> GetAllUsersWithRoles();
        User? GetUserWithRolesAndPermissions(int  id = 0, string email = "");
        bool SoftDelete(User user);
    }
}
