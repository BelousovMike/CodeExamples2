using APS.EFDataAccessLibrary.Models;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace APS.Domain.Interfaces
{
    public interface ITaskReader
    {
        Task<IEnumerable<APSTask>> GetTasksAsync(Stream stream);
    }
}
