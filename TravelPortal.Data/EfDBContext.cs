using Microsoft.Data.Entity;
using TravelPortal.Data.Entities;
using TravelPortal.Data.Mappings;

namespace TravelPortal.Data
{
    public class EfDbContext : DbContext
    {
        private readonly string _connectionString;

        public EfDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(_connectionString);
            base.OnConfiguring(options);
        }

        #region tables

        public DbSet<Country> Country { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            CountryMapping.Map(modelBuilder.Entity<Country>());
        }
    }
}
