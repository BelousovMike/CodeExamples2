using APS.Core.Identity;
using APS.Domain.Interfaces;
using Serilog;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Core.Authorization
{
    public interface IAuthorizeService
    {
        Task<JwtAuthResult> LoginAsync(string username, string password);
    }

    public class AuthorizeService : IAuthorizeService
    {
        private readonly IUserService _userService;
        private readonly IJwtTokenGenerator _jwtAuthManager;
        private readonly ILogger _logger;

        public AuthorizeService(IUserService userService, IJwtTokenGenerator jwtAuthManager, ILogger logger)
        {     
            _userService = userService;
            _jwtAuthManager = jwtAuthManager;
            _logger = logger;
        }

        public async Task<JwtAuthResult> LoginAsync(string username, string password)
        {
            if (await _userService.IsValidUserCredentialsAsync(username, password))
            {
                var role = await _userService.GetUserRoleAsync(username);
                var claims = GetUserClaims(username, role);
                var token = _jwtAuthManager.GenerateTokens(username, claims, DateTime.Now);
                _logger.Information($"User [{username}] logged in the system.");

                return new JwtAuthResult()
                {
                    UserName = username,
                    Role = role,
                    AccessToken = token
                };
            }
            else
            {
                throw new ArgumentException("Username or password incorrect");
            }
        }

        private Claim[] GetUserClaims(string username, string role)
        {
            return new Claim[]
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, username),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, role)
            };
        }
    }
}
