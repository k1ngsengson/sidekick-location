using Common;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace SimpleData
{
    public class DataStorage<T>
    {
        private IEnumerable<T> _items;

        public Task<IEnumerable<T>> GetItems()
        {
            if (!Preferences.ContainsKey(StringConstants.STORAGE))
                Preferences.Set(StringConstants.STORAGE, null);

            var storage = Preferences.Get(StringConstants.STORAGE, null);

            if (storage != null)
            {
                _items = JsonConvert.DeserializeObject<IEnumerable<T>>(storage);
            }
            else
                _items = new List<T>();

            // just added task.run 
            return Task.Run(() => _items);
        }

        public async Task<bool> AddItem(T entity)
        {
            await GetItems();
            var list = _items.ToList();

            list.Add(entity);

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
