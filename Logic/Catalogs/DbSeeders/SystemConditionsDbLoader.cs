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
    public class SystemConditionsDbLoader : IDataSeeder
    {
        private readonly IEnumerable<SystemCondition> _defaultSystemConditions;
        private readonly ApplicationContext _dbContext;

        public SystemConditionsDbLoader(IOptions<SystemConditionCatalogModel> options, ApplicationContext dbContext)
        {
            _defaultSystemConditions = options.Value.SystemConditions;
            _dbContext = dbContext;
        }

        public async Task SeedAsync()
        {
            if (_defaultSystemConditions is null) return;
            var newSystemConditions = FindNewSystemConditions();
            await WriteToDbAsync(newSystemConditions);
        }

        private IEnumerable<SystemCondition> FindNewSystemConditions()
        {
            return
                _defaultSystemConditions.Except(_dbContext.SystemConditions)
                .ToList();
        }

        private async Task WriteToDbAsync(IEnumerable<SystemCondition> newSystemConditions)
        {
            await _dbContext.SystemConditions.AddRangeAsync(newSystemConditions);
            await _dbContext.SaveChangesAsync();
        }
    }
}
