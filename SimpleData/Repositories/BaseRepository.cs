using Entities;
using SimpleData;

namespace Data.Repositories
{
    public class BaseRepository
    {
        protected internal readonly DataStorage<Location> _storage;

        public BaseRepository()
        {
            _storage = new DataStorage<Location>();
        }
    }
}
