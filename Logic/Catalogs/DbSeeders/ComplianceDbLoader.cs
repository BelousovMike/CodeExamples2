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
    public class ComplianceDbLoader : IDataSeeder
    {
        private readonly IEnumerable<Compliance> _defaultCompliance;
        private readonly ApplicationContext _dbContext;

        public ComplianceDbLoader(IOptions<ComplianceCatalogModel> options, ApplicationContext dbContext)
        {
            _defaultCompliance = options.Value.Compliances;
            _dbContext = dbContext;
        }

        public async Task SeedAsync()
        {
            if (_defaultCompliance is null) return;
            var newCompliances = FindNewCompliance();
            await WriteToDbAsync(newCompliances);
        }

        private IEnumerable<Compliance> FindNewCompliance()
        {
            return _defaultCompliance.Except(_dbContext.Compliances)
                .ToList();
        }

        private async Task WriteToDbAsync(IEnumerable<Compliance> newCompliances)
        {
            await _dbContext.Compliances.AddRangeAsync(newCompliances);
            await _dbContext.SaveChangesAsync();
        }
    }
}
