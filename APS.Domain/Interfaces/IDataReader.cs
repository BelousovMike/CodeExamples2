using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace APS.Domain.Interfaces
{
    public interface IDataReader
    {
        Task<IEnumerable<T>> ReadAsync<T>(Stream stream);
    }
}
