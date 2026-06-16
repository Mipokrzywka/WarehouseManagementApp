using WarehouseManagementApp.Interfaces;
using BCrypt.Net;

namespace WarehouseManagementApp.Services
{
    public class PasswordHasher : IPasswordHasher
    {
        private const int workFactor = 11;
        public string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password, workFactor);
        }

        public bool VerifyPassword(string password, string hashedPassword)
        {
            try
            {
                return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
            }
            catch (Exception) 
            {
                return false;
            }
        }
    }
}
