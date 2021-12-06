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
    public class ActivityTypesDbLoader : IDataSeeder
    {
        private readonly IEnumerable<ActivityType> _defaultActivityTypes;
        private readonly ApplicationContext _dbContext;

        public ActivityTypesDbLoader(IOptions<ActivityTypeCatalogModel> options, ApplicationContext dbContext)
        {
            _defaultActivityTypes = options.Value.ActivityTypes;
            _dbContext = dbContext;
        }

        public async Task SeedAsync()
        {
            if (_defaultActivityTypes is null) return;
            var newActivityTypes = FindNewActivityTypes();
            await WriteToDbAsync(newActivityTypes);
        }

        private IEnumerable<ActivityType> FindNewActivityTypes()
        {
            return 
                _defaultActivityTypes.Except(_dbContext.ActivityTypes)
                .ToList();
        }

        private async Task WriteToDbAsync(IEnumerable<ActivityType> newActivityTypes)
        {
            await _dbContext.ActivityTypes.AddRangeAsync(newActivityTypes);
            await _dbContext.SaveChangesAsync();
        }
    }
}
