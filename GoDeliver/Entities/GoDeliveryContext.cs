using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace GoDeliver.Entities
{
    public class GoDeliveryContext : DbContext
    {
        public GoDeliveryContext(DbContextOptions<GoDeliveryContext> options) 
            : base(options)
        {
            Database.Migrate();
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderedFood> OrderedFoods { get; set; }
    }
}
