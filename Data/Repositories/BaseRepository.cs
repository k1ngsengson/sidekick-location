using System.IO;

namespace Data.Repositories
{
    public class BaseRepository
    {
        internal readonly DatabaseContext _databaseContext;

        public BaseRepository()
        {
            var dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "productsDB.db");

            _databaseContext = new DatabaseContext(dbPath);
        }
    }
}
