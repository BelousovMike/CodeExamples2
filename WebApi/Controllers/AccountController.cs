using APS.Domain.ResponseModels;
using Core.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace APS.WebApi.Controllers
{
    [ApiController]
    [Route("api/")]
    public class AccountController : ControllerBase
    {
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult> Login([FromServices] IAuthorizeService authorizationService, [FromBody] UserRequest request)
        {
            try
            {
                var authorizeUser = await authorizationService.LoginAsync(request.UserName, request.Password);
                return Ok(authorizeUser);
            }
            catch(ArgumentException ex)
            {
                return Unauthorized(ex.Message);
            }
        }

       
    }
}
