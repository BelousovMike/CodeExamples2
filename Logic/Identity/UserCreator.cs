using APS.Core.Catalog.Models;
using APS.Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace APS.Core.Identity
{
    public class UserCreator : IUserCreator
    {
        private readonly UserManager<IdentityUser> _userManager;

        public UserCreator(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IdentityUser> AddNewUserAsync(string login, string password)
        {
            var user = new IdentityUser(login);
            var userResult = await _userManager.CreateAsync(user, password);
            CheckOperationResult(userResult, "User not created!");
            var roleResult = await _userManager.AddToRoleAsync(user, DefaultRoles.User);
            CheckOperationResult(roleResult, "Role User not applied");
            return user;
        }

        private void CheckOperationResult(IdentityResult result, string message)
        {
            if (!result.Succeeded)
            {
                throw new InvalidOperationException(message);
            }
        }
    }
}
