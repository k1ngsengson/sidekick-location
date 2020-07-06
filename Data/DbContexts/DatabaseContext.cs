using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Threading.Tasks;

namespace Data.DbContexts
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Location> Locations { get; set; }

        
        public DatabaseContext()
        {
            //uncomment only when you want to recreate the database
            //Database.EnsureDeleted();

            Database.EnsureCreated();
            Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string databasePath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "LocationsDB.db"); ;

            // Specify that we will use sqlite and the path of the database here
            optionsBuilder.UseSqlite($"Filename={databasePath}");
        }
    }
}