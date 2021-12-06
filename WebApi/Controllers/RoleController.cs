using APS.Core.Catalog.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace APS.WebApi.Controllers
{
    [Authorize(Roles = DefaultRoles.Admin)]
    [ApiController]
    [Route("api/[controller]")]
    public class RoleController : Controller
    {
        [HttpGet("all")]
        public IQueryable<IdentityRole> GetRoles([FromServices] RoleManager<IdentityRole> roleManager)
        {
            return roleManager.Roles;
        }

        [HttpPost("add-role")]
        public async Task<IActionResult> AddRole([FromServices]RoleManager<IdentityRole> roleManager, string roleName)
        {
            var result = await roleManager.CreateAsync(new IdentityRole(roleName));
            return result == IdentityResult.Success ? Ok() : BadRequest(); 
        }
    }
}
