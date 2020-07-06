using Data.DbContexts;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class LocationsRepository : BaseRepository, ILocationsRepository
    {
        public LocationsRepository()
        { 
        }

        public async Task<IEnumerable<Location>> GetLocationsAsync()
        {
            try
            {
                using (DatabaseContext context = _databaseContext)
                {
                    var Locations = await context.Locations.ToListAsync();

                    return Locations;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<bool> AddLocationAsync(Location location)
        {
            try
            {
                using (DatabaseContext context = _databaseContext)
                {
                    var tracking = await context.Locations.AddAsync(location);

                    await _databaseContext.SaveChangesAsync();

                    var isAdded = tracking.State == EntityState.Added;

                    return isAdded;
                }
            }
            catch (Exception e)
            {
                
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
