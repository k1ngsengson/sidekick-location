using Data.DbContexts;

namespace Migration.Repositories
{
    public class BaseRepository
    {
        protected internal readonly DatabaseContext _databaseContext;

        public BaseRepository()
        {
            _databaseContext = new DatabaseContext();
        }
    }
}
