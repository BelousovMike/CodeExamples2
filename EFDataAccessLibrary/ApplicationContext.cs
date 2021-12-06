using APS.EFDataAccessLibrary.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace APS.EFDataAccessLibrary
{
    public class ApplicationContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationContext(DbContextOptions options) : base(options) { }

        #region Default Data
        public DbSet<Usage> Usages { get; set; }
        public DbSet<ActivityType> ActivityTypes { get; set; }
        public DbSet<Discipline> Disciplines { get; set; }
        public DbSet<Resource> Resourcing { get; set; }
        public DbSet<Compliance> Compliances { get; set; }
        public DbSet<SystemCondition> SystemConditions { get; set; }
        public DbSet<TacticsTypesOfWork> TacticsTypes { get; set; }
        public DbSet<TaskTypesOfWork> TaskTypes { get; set; }
        public DbSet<AdditionalDisciplineCode> AdditionalDisciplineCodes { get; set; }
        #endregion

        public DbSet<APSTask> Tasks { get; set; }
    }
}
