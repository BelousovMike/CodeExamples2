using System.Threading.Tasks;

namespace APS.Domain.Interfaces
{
    public interface IDataSeeder
    {
        Task SeedAsync();
    }
}
