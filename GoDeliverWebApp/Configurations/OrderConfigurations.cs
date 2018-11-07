using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using GoDeliverWebApp.Entities;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoDeliverWebApp.EntityConfigurations
{
    public class OrderConfigurations : EntityTypeConfiguration<Order>
    {

        public OrderConfigurations()
        {
            HasKey(a => a.OrderId);
            Property(a => a.OrderId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(a => a.RestaurantId).IsRequired();
            Property(a => a.CustomerId).IsRequired();
            Property(a => a.DriverId).IsRequired();
            Property(a => a.CustomerAddress).HasMaxLength(255).IsRequired();
            Property(a => a.RestaurantAddress).HasMaxLength(255).IsRequired();
            Property(a => a.TimeAtRestaurant).IsRequired();
            // HasRequired(Foods)(s => s.Foods).WithMany(g => g.OrderedFoods).HasForeignKey<int>(s => s.FoodId);

            Map(a => a.ToTable("Orders"));
        }


    }
}
