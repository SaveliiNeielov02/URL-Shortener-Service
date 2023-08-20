using Microsoft.EntityFrameworkCore;
using URLShortenerService.Models;

namespace URLShortenerService
{
    public class ModelDBContext : DbContext
    {
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Record> Records { get; set; }

        public ModelDBContext(DbContextOptions<ModelDBContext> options) : base(options)
        {
        }

    }
}
