using APS.Core.Catalog.Models;
using APS.Domain.Interfaces;
using APS.EFDataAccessLibrary;
using APS.EFDataAccessLibrary.Models;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APS.Core.Catalog.DbSeeders
{
    public class TaskTypesOfWorkDbLoader : IDataSeeder
    {
        private readonly IEnumerable<TaskTypesOfWork> _defaultTaskTypes;
        private readonly ApplicationContext _dbContext;

        public TaskTypesOfWorkDbLoader(IOptions<TaskTypesOfWorkCatalogModel> options, ApplicationContext dbContext)
        {
            _defaultTaskTypes = options.Value.TaskTypes;
            _dbContext = dbContext;
        }

        public async Task SeedAsync()
        {
            if (_defaultTaskTypes is null) return;
            var newTypes = FindNewTaskTypes();
            await WriteToDbAsync(newTypes);
        }

        private IEnumerable<TaskTypesOfWork> FindNewTaskTypes()
        {
            return _defaultTaskTypes.Except(_dbContext.TaskTypes)
                .ToList();
        }

        private async Task WriteToDbAsync(IEnumerable<TaskTypesOfWork> newTypes)
        {
            await _dbContext.TaskTypes.AddRangeAsync(newTypes);
            await _dbContext.SaveChangesAsync();
        }
    }
}
