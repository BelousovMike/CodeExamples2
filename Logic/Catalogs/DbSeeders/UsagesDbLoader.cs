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
    public class UsagesDbLoader : IDataSeeder
    {
        private readonly IEnumerable<Usage> _defaultUsages;
        private readonly ApplicationContext _dbContext;

        public UsagesDbLoader(IOptions<UsageCatalogModel> usagesModelOptions, ApplicationContext dbContext)
        {
            _defaultUsages = usagesModelOptions.Value.Usages;
            _dbContext = dbContext;
        }
        public async Task SeedAsync()
        {
            if (_defaultUsages is null) return;
            var newUsages = FindNewUsages();
            await WriteToDbAsync(newUsages);        
        }

        private IEnumerable<Usage> FindNewUsages()
        {
            return _defaultUsages.Except(_dbContext.Usages)
                .ToList();
        }

        private async Task WriteToDbAsync(IEnumerable<Usage> newUsages)
        {
            await _dbContext.Usages.AddRangeAsync(newUsages);
            await _dbContext.SaveChangesAsync();
        }
    }
}
