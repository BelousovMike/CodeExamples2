using System.Threading.Tasks;

namespace APS.Domain.Interfaces
{
    public interface IDataLoader
    {
        Task LoadAsync<T>(byte[] document);
    }
}
