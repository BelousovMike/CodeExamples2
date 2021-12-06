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
    public class ResourcingDbLoader : IDataSeeder
    {
        private readonly IEnumerable<Resource> _defaultResources;
        private readonly ApplicationContext _dbContext;

        public ResourcingDbLoader(IOptions<ResourcingCatalogModel> options, ApplicationContext dbContext)
        {
            _defaultResources = options.Value.Resources;
            _dbContext = dbContext;
        }

        public async Task SeedAsync()
        {
            if (_defaultResources is null) return;
            var newResourcing = FindNewResourcing();
            await WriteToDbAsync(newResourcing);
        }

        private IEnumerable<Resource> FindNewResourcing()
        {
            return _defaultResources.Except(_dbContext.Resourcing)
                .ToList();
        }

        private async Task WriteToDbAsync(IEnumerable<Resource> newResourcing)
        {
            await _dbContext.Resourcing.AddRangeAsync(newResourcing);
            await _dbContext.SaveChangesAsync();
        }
    }
}
