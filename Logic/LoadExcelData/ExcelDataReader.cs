using APS.Domain.Interfaces;
using Ganss.Excel;
using Serilog;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace APS.Core.LoadExcelData
{
    public class ExcelDataReader : IDataReader
    {
        private readonly ILogger _logger;

        public ExcelDataReader(ILogger logger)
        {
            _logger = logger;
        }

        public async Task<IEnumerable<T>> ReadAsync<T>(Stream stream)
        {
            return await new ExcelMapper().FetchAsync<T>(stream);
        }
    }
}
