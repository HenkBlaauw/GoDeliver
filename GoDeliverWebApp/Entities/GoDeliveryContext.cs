
using GoDeliverWeb.EntityConfigurations;
using GoDeliverWebApp.Configurations;
using GoDeliverWebApp.EntityConfigurations;
using System;
using System.Data.Entity;
using System.Web.Configuration;

namespace GoDeliverWebApp.Entities
{
    public class GoDeliveryContext : DbContext
    {

        
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Food> Foods { get; set; }
        // public DbSet<OrderedFood> OrderedFoods { get; set; }


        public GoDeliveryContext()
        {
            string databaseConnectionString = WebConfigurationManager.AppSettings.Get("DatabaseConnectionString");
            if (! String.IsNullOrEmpty(databaseConnectionString))
            {
                this.Database.Connection.ConnectionString = databaseConnectionString;
            } else
            {
                this.Database.Connection.ConnectionString = "Data Source=.;Initial Catalog=GoDelivery;Integrated Security=True;";
            }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CustomerConfigurations());
            modelBuilder.Configurations.Add(new DriverConfigurations());
            modelBuilder.Configurations.Add(new FoodConfigurations());
            modelBuilder.Configurations.Add(new RestaurantConfigurations());
            modelBuilder.Configurations.Add(new OrderConfigurations());
            //  modelBuilder.Configurations.Add(new OrderedFoodsConfigurations());
        }
        
        
    }
}
