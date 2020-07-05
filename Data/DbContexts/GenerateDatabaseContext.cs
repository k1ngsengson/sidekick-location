using System.IO;

namespace Data.DbContexts
{
    public class GenerateDatabaseContext: IGenerateDatabaseContext
    {
        public IDatabaseContext NewContext()
        {
            var dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "LocationsDB.db");

            IDatabaseContext dbContext = new DatabaseContext(dbPath);

            return dbContext;
        }
    }
}
