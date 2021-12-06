using APS.Domain.Interfaces;
using System;
using System.IO;
using System.Threading.Tasks;

namespace APS.Core.Catalogs.DbSeeders
{
    public class LMIDbLoader : IDataSeeder
    {
        private const string _documentDirectory = "ExcelDocument";
        private const string _fileName = "APS MI Groups & Data.xlsx";
        private readonly ITaskReader _taskReader;

        public LMIDbLoader(ITaskReader taskReader)
        {
            _taskReader = taskReader;
        }

        public async Task SeedAsync()
        {
            var path = Path.Combine("../../", _documentDirectory, _fileName);
            var stream = File.Open(@"C:\Users\Mikhail\source\repos\backend\Logic\ExcelDocument\APS MI Groups & Data.xlsx", FileMode.Open, FileAccess.Read, FileShare.Read); 
            var data = await _taskReader.GetTasksAsync(stream);
        }
    }
}
