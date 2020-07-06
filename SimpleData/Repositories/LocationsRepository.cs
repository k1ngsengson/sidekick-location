using Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class LocationsRepository : BaseRepository, ILocationsRepository
    {
        public LocationsRepository(): base()
        {
        }

        public async Task<IEnumerable<Location>> GetLocationsAsync()
        {
            try
            {                
                return await GetLocations();
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
                return null;
            }
        }

        public async Task<bool> AddLocationAsync(Location location)
        {
            try
            {
                return await AddLocation(location);                
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
                return false;
            }
        }

        //public async Task<bool> UpdateLocationAsync(Location location)
        //{
        //    try
        //    {
        //        var tracking = _databaseContext.Update(location);

        //        await _databaseContext.SaveChangesAsync();

        //        var isModified = tracking.State == EntityState.Modified;

        //        return isModified;
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }
        //}

        //public async Task<bool> RemoveLocationAsync(int id)
        //{
        //    try
        //    {
        //        var Location = await _databaseContext.Locations.FindAsync(id);

        //        var tracking = _databaseContext.Remove(Location);

        //        await _databaseContext.SaveChangesAsync();

        //        var isDeleted = tracking.State == EntityState.Deleted;

        //        return isDeleted;
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }
        //}        
    }
}
