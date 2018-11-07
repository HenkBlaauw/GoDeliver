
using GoDeliverWeb.EntityConfigurations;
using GoDeliverWebApp.Configurations;
using GoDeliverWebApp.EntityConfigurations;
using System.Data.Entity;

namespace GoDeliverWebApp.Entities
{
    public class GoDeliveryContext : DbContext
    {
        

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<OrderedFood> OrderedFoods { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CustomerConfigurations());
            modelBuilder.Configurations.Add(new DriverConfigurations());
            modelBuilder.Configurations.Add(new FoodConfigurations());
            modelBuilder.Configurations.Add(new RestaurantConfigurations());
            modelBuilder.Configurations.Add(new OrderConfigurations());

        }


    }
}
