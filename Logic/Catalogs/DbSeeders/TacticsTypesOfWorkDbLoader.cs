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
    public class TacticsTypesOfWorkDbLoader : IDataSeeder
    {
        private readonly IEnumerable<TacticsTypesOfWork> _defaultTacticsTypes;
        private readonly ApplicationContext _dbContext;

        public TacticsTypesOfWorkDbLoader(IOptions<TacticsTypesOfWorkCatalogModel> options, ApplicationContext dbContext)
        {
            _defaultTacticsTypes = options.Value.TacticsTypes;
            _dbContext = dbContext;
        }

        public async Task SeedAsync()
        {
            if (_defaultTacticsTypes is null) return;
            var newTypes = FindNewTacticsTypes();
            await WriteToDbAsync(newTypes);
        }

        private IEnumerable<TacticsTypesOfWork> FindNewTacticsTypes()
        {
            return _defaultTacticsTypes.Except(_dbContext.TacticsTypes)
                .ToList();
        }

        private async Task WriteToDbAsync(IEnumerable<TacticsTypesOfWork> newTypes)
        {
            await _dbContext.TacticsTypes.AddRangeAsync(newTypes);
            await _dbContext.SaveChangesAsync();
        }
    }
}
