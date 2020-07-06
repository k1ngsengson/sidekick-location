using Entities;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace Migration.DbContexts
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Location> Locations { get; set; }


        private string _databasePath;
        public DatabaseContext()
        {
            //uncomment only when you want to recreate the database
            //Database.EnsureDeleted();

            _databasePath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "LocationsDB.db");

            
        }

        public DatabaseContext(string databasePath)
        {
            //uncomment only when you want to recreate the database
            //Database.EnsureDeleted();

            _databasePath = databasePath;

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Specify that we will use sqlite and the path of the database here
            optionsBuilder.UseSqlite($"Filename={_databasePath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //creating tables according to UML
            modelBuilder.Entity<Location>();

            //add one for each table
        }
    }
}