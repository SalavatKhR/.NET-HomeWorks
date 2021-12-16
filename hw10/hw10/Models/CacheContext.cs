using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace hw10.Models
{
    public class CacheContext: DbContext
    {
        public DbSet<Cache> Cache { get; set; }

        public CacheContext(DbContextOptions<CacheContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}