using Data.DbContexts;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class LocationsRepository : BaseRepository, ILocationsRepository
    {
        public LocationsRepository(): base()
        {
            _databaseContext.Database.EnsureCreated();
            _databaseContext.Database.Migrate();
        }

        public async Task<IEnumerable<Location>> GetLocationsAsync()
        {
            try
            {
                using (DatabaseContext context = _databaseContext)
                {                    
                    var locations = await context.Locations.ToListAsync();

                    return locations;
                }
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
                System.Diagnostics.Debug.WriteLine(e.Message);
                return false;
            }
        }
    }
}
