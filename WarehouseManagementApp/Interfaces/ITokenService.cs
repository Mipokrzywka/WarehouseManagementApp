using WarehouseManagementApp.Models;

namespace WarehouseManagementApp.Interfaces
{
    public interface ITokenService
    {
        public string GenerateToken(User user);
    }
}
