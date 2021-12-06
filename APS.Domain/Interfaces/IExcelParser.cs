using System.Collections.Generic;
using System.IO;

namespace APS.Domain.Interfaces
{
    public interface IExcelParser
    {
        IEnumerable<T> Parse<T>(Stream stream);
    }
}
