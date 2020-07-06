using Common;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace Data.Repositories
{
    public class BaseRepository
    {
        protected internal IEnumerable<Entities.Location> _locations;

        public BaseRepository()
        {            
            //GetLocations();
        }

        protected Task<IEnumerable<Entities.Location>> GetLocations()
        {
            if (!Preferences.ContainsKey(StringConstants.STORAGE))
                Preferences.Set(StringConstants.STORAGE, null);

            var storage = Preferences.Get(StringConstants.STORAGE, null);

            if (storage != null)
            {
                _locations = JsonConvert.DeserializeObject<IEnumerable<Entities.Location>>(storage);
            }
            else
                _locations = new List<Entities.Location>();

            // just added task.run 
            return Task.Run(() => _locations);
        }

        protected async Task<bool> AddLocation(Entities.Location location)
        {
            await GetLocations();
            var list = _locations.ToList();

            list.Add(location);

            var json = JsonConvert.SerializeObject(list);

            Save(json);

            return true;
        }

        private void Save(string json)
        {
            Preferences.Set(StringConstants.STORAGE, json);
        }
    }
}
