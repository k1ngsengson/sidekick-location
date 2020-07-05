using Data.DbContexts;

namespace Data.Repositories
{
    public class BaseRepository
    {
        protected internal readonly IDatabaseContext _databaseContext;
        protected internal readonly IGenerateDatabaseContext _generateDatabaseContext;

        public BaseRepository(IDatabaseContext databaseContext, IGenerateDatabaseContext generateDatabaseContext)
        {
            _databaseContext = databaseContext;
            _generateDatabaseContext = generateDatabaseContext;
        }
    }
}
