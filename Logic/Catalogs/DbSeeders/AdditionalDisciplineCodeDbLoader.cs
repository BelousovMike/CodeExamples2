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
    public class AdditionalDisciplineCodeDbLoader : IDataSeeder
    {
        private readonly IEnumerable<AdditionalDisciplineCode> _defaultAdditionalDisciplineCode;
        private readonly ApplicationContext _dbContext;

        public AdditionalDisciplineCodeDbLoader(IOptions<AdditionalDisciplineCodeCatalogModel> options, ApplicationContext dbContext)
        {
            _defaultAdditionalDisciplineCode = options.Value.AdditionalDisciplineCodes;
            _dbContext = dbContext;
        }

        public async Task SeedAsync()
        {
            if (_defaultAdditionalDisciplineCode is null) return;
            var newCodes = FindNewAdditionalDisciplineCodes();
            await WriteToDbAsync(newCodes);
        }

        private IEnumerable<AdditionalDisciplineCode> FindNewAdditionalDisciplineCodes()
        {
            return _defaultAdditionalDisciplineCode.Except(_dbContext.AdditionalDisciplineCodes)
                .ToList();
        }

        private async Task WriteToDbAsync(IEnumerable<AdditionalDisciplineCode> newCodes)
        {
            await _dbContext.AdditionalDisciplineCodes.AddRangeAsync(newCodes);
            await _dbContext.SaveChangesAsync();
        }
    }
}
