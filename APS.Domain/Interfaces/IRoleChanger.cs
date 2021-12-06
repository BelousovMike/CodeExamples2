using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace APS.Domain.Interfaces
{
    public interface IRoleChanger
    {
        Task<IdentityResult> ChangeAsync(string login, string roleName);
    }
}
