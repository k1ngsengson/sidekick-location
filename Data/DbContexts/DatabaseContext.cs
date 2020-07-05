using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Threading.Tasks;

namespace Data.DbContexts
{
    public class DatabaseContext : DbContext, IDatabaseContext
    {
        public DbSet<Location> Locations { get; set; }

        private readonly string _databasePath;

        public DatabaseContext(string databasePath)
        {
            _databasePath = databasePath;

            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(string.Format("Filename={0}", _databasePath));
        }

        async Task<int> IDatabaseContext.SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
    }
}