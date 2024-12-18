using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace QQQQ
{
    public class RestoranDbContext : DbContext
    {
        public RestoranDbContext(DbContextOptions<RestoranDbContext> options) : base(options)
        {
            Database.Migrate();
        }

        public DbSet<ClientEntity> Client { get; set; }
        public DbSet<DishEntity> Dish { get; set; }
        public DbSet<OrderEntity> Order { get; set; }
    }
}
