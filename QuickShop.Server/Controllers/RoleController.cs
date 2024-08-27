using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuickShop.Server.Services;

namespace QuickShop.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly RoleServices roleServices;

        public RoleController(RoleServices roleServices)
        {
            this.roleServices = roleServices;
        }

        [HttpGet("GetUserRole/{emailId}")]
        public async Task<IActionResult> GetUserRole (string emailId)
        {
            var userRole = await roleServices.GetUserRolesAsync(emailId);
            return Ok(userRole);
        }
    }
}
