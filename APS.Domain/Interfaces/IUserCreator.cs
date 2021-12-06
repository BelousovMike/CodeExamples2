using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace APS.Domain.Interfaces
{
    public interface IUserCreator
    {
        Task<IdentityUser> AddNewUserAsync(string login, string password);
    }
}
