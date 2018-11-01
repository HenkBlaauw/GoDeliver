using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using GoDeliver.Entities;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoDeliver.EntityConfigurations
{
    public class OrderConfigurations : EntityTypeConfiguration<Order>
    {

        public OrderConfigurations()
        {
            HasKey(a => a.OrderId);
            Property(a => a.OrderId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(a => a.RestaurantId).IsRequired();
           // HasRequired(Foods)(s => s.Foods).WithMany(g => g.OrderedFoods).HasForeignKey<int>(s => s.FoodId);
        }


    }
}
