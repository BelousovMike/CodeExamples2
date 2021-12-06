using APS.Core.Catalog.Models;
using APS.Domain.Interfaces;
using APS.EFDataAccessLibrary.Models;
using APS.EFDataAccessLibrary;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APS.Core.Catalog.DbSeeders
{
    public class DisciplineDbLoader : IDataSeeder
    {
        private readonly IEnumerable<Discipline> _defaultDisciplines;
        private readonly ApplicationContext _dbContext;

        public DisciplineDbLoader(IOptions<DisciplineCatalogModel> options, ApplicationContext dbContext)
        {
            _defaultDisciplines = options.Value.Disciplines;
            _dbContext = dbContext;
        }

        public async Task SeedAsync()
        {
            if (_defaultDisciplines is null) return;
            var newDisciplines = FindNewDisciplines();
            await WriteToDbAsync(newDisciplines);
        }

        private IEnumerable<Discipline> FindNewDisciplines()
        {
            return _defaultDisciplines.Except(_dbContext.Disciplines)
                .ToList();
        }

        private async Task WriteToDbAsync(IEnumerable<Discipline> newDisciplines)
        {
            await _dbContext.Disciplines.AddRangeAsync(newDisciplines);
            await _dbContext.SaveChangesAsync();
        }
    }
}
