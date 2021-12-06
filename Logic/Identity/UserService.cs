using APS.Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace APS.Core.Identity
{
    public class UserService : IUserService
    {
        private readonly UserManager<IdentityUser> _userManager;

        public UserService(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<string> GetUserRoleAsync(string login)
        {
            var user = await _userManager.FindByNameAsync(login);
            return (await _userManager.GetRolesAsync(user)).First();
        }

        public async Task<bool> IsValidUserCredentialsAsync(string login, string password)
        {
            var user = await _userManager.FindByNameAsync(login);
            return await _userManager.CheckPasswordAsync(user, password);
        }
    }
}
