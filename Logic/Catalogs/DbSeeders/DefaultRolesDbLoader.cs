using APS.Core.Catalog.Models;
using APS.Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APS.Core.Catalog.DbSeeders
{
    public class DefaultRolesDbLoader : IDataSeeder
    {
        private readonly RoleManager<IdentityRole> _manager;

        public DefaultRolesDbLoader(RoleManager<IdentityRole> manager)
        {
            _manager = manager;
        }

        public async Task SeedAsync()
        {
            var newRoles = FindNewRoles();
            await WriteNewRoles(newRoles);
        }

        IEnumerable<string> FindNewRoles()
        {
            var existingRoles = _manager.Roles.Select(role => role.Name);
            return DefaultRoles.All().Except(existingRoles);
        }

        private async Task WriteNewRoles(IEnumerable<string> newRoles)
        {
            foreach (var role in newRoles)
            {
                await _manager.CreateAsync(new IdentityRole(role));
            }
        }
    }
}
