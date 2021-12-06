using APS.Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APS.Core.Identity
{
    public class RoleChanger : IRoleChanger
    {
        private readonly UserManager<IdentityUser> _userManager;

        public RoleChanger(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IdentityResult> ChangeAsync(string login, string roleName)
        {
            var user = await _userManager.FindByNameAsync(login);
            await RemoveLastRoles(user);
            return await AddNewRole(user, roleName);
        }

        private async Task RemoveLastRoles(IdentityUser user)
        {
            var oldRoles = await _userManager.GetRolesAsync(user);
            oldRoles.ToList()
                .ForEach(r => RemoveRoleForUser(user, r).Wait());
        }

        private async Task RemoveRoleForUser(IdentityUser user, string oldRole)
        {
            await _userManager.RemoveFromRoleAsync(user, oldRole);
        }

        private async Task<IdentityResult> AddNewRole(IdentityUser user, string newRole)
        {
            var roles = new List<string>() { newRole };
            return await _userManager.AddToRolesAsync(user, roles);
        }
    }
}
