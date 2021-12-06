using APS.Core.Catalog.Models;
using APS.Domain.Interfaces;
using APS.Domain.ResponseModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace APS.WebApi.Controllers
{
    [Authorize(Roles = DefaultRoles.Admin)]
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        [HttpGet("all")]
        public IQueryable<IdentityUser> GetUsers([FromServices] UserManager<IdentityUser> userManager)
        {
            return userManager.Users;
        }

        [HttpPost("set-admin")]
        public async Task<IActionResult> SetAdmin([FromServices] IRoleChanger roleChanger, [FromBody] string login)
        {
            var result = await roleChanger.ChangeAsync(login, DefaultRoles.Admin);
            return result == IdentityResult.Success ? Ok() : BadRequest();
        }

        [HttpPost("create-user")]
        public async Task<IActionResult> CreateUser([FromServices] IUserCreator userCreator, [FromBody] UserRequest model)
        {
            try
            {
                var user = await userCreator.AddNewUserAsync(model.UserName, model.Password);
                return Ok(user);
            }
            catch(InvalidOperationException)
            {
                return BadRequest();
            }
        }
    }
}
