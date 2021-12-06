using APS.Domain.Interfaces;
using APS.EFDataAccessLibrary;
using Serilog;
using System.IO;
using System.Threading.Tasks;

namespace APS.Core.LoadExcelData
{
    public class DataLoader : IDataLoader
    {
        private readonly IDataReader _dataReader;
        private readonly ApplicationContext _dbContext;
        private readonly ILogger _logger;

        public DataLoader(IDataReader dataReader, ApplicationContext dbContext, ILogger logger)
        {
            _dataReader = dataReader;
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task LoadAsync<T>(byte[] document)
        {
            _logger.Information("Start loading data from Excel file.");
            using var stream = new MemoryStream(document);
            var data = await _dataReader.ReadAsync<T>(stream);
            await _dbContext.AddRangeAsync(data);
            await _dbContext.SaveChangesAsync();
            _logger.Information("Loading success");
        }
    }
}
