using System.Runtime.CompilerServices;
using WarehouseManagementApp.DTOs;
using WarehouseManagementApp.Models;

namespace WarehouseManagementApp.Mappers
{
    public static class UserMapper
    {
        public static UserReadDto ToReadDto(this User user)
        {
            return new UserReadDto{
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                Surname = user.Surname,
                Roles = user.UserRoles
                     .Where(ur => ur.Role != null)
                     .Select(ur => ur.Role.Name)
                     .ToList(),
                Permissions = user.UserRoles
                           .Where(ur => ur.Role != null)
                           .SelectMany(ur => ur.Role.RolePermissions)
                           .Where(rp => rp.Permission != null)
                           .Select(rp => rp.Permission.Name)
                           .Distinct()
                           .ToList()
            };
        }
    }
}
