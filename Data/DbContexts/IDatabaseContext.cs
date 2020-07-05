using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Data.DbContexts
{
    public interface IDatabaseContext : IDisposable
    {
        DbSet<Location> Locations { get; set; }
        Task<int> SaveChangesAsync();
    }
}
