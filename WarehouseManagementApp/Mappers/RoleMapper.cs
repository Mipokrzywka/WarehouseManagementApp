using WarehouseManagementApp.DTOs;
using WarehouseManagementApp.Models;

namespace WarehouseManagementApp.Mappers
{
    public static class RoleMapper
    {
        public static RoleReadDto ToReadDto(this Role role)
        {
            return new RoleReadDto()
            {
                RoleId = role.Id,
                Name = role.Name,
                Permissions = role.RolePermissions
                                  .Where(rp => rp.Permission != null)
                                  .Select(rp => new PermissionReadDto
                                  {
                                      Id = rp.PermissionId,
                                      Name = rp.Permission.Name,
                                      Description = rp.Permission.Description
                                  }).ToList(),
                Emails = role.UserRoles
                             .Where(ur => ur.User != null)
                             .Select(ur => ur.User.Email)
                             .ToList()
            };
        }
    }
}
