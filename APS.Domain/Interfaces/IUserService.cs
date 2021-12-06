using System.Threading.Tasks;

namespace APS.Domain.Interfaces
{
    public interface IUserService
    {
        Task<bool> IsValidUserCredentialsAsync(string login, string password);

        Task<string> GetUserRoleAsync(string login);
    }
}
