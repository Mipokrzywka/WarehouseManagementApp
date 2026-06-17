using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WarehouseManagementApp.Controllers
{
    [ApiController]
    public class BaseApiController : ControllerBase
    {
        protected int CurrentUserID { get
            {
                var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (string.IsNullOrEmpty(userIdClaim) || !int.TryParse(userIdClaim, out int userId))
                    return 0;
                return userId;
            }
        }
    }
}
