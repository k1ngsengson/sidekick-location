using Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class LocationsRepository : ILocationsRepository
    {

        private readonly DatabaseContext _databaseContext;

        public LocationsRepository(string dbPath)
        {
            _databaseContext = new DatabaseContext(dbPath);
        }

        public async Task<IEnumerable<Location>> GetLocationsAsync()
        {
            try
            {
                var products = await _databaseContext.Locations.ToListAsync();

                return products;
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
                var tracking = await _databaseContext.Locations.AddAsync(location);

                await _databaseContext.SaveChangesAsync();

                var isAdded = tracking.State == EntityState.Added;

                return isAdded;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<bool> UpdateProductAsync(Location location)
        {
            try
            {
                var tracking = _databaseContext.Update(location);

                await _databaseContext.SaveChangesAsync();

                var isModified = tracking.State == EntityState.Modified;

                return isModified;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<bool> RemoveProductAsync(int id)
        {
            try
            {
                var product = await _databaseContext.Products.FindAsync(id);

                var tracking = _databaseContext.Remove(product);

                await _databaseContext.SaveChangesAsync();

                var isDeleted = tracking.State == EntityState.Deleted;

                return isDeleted;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<IEnumerable<Product>> QueryProductsAsync(Func<Product, bool> predicate)
        {
            try
            {
                var products = _databaseContext.Products.Where(predicate);

                return products.ToList();
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
