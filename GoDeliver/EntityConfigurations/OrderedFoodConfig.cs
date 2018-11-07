using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GoDeliver.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace GoDeliver.EntityConfigurations
{
    public class OrderedFoodConfig : EntityTypeConfiguration<OrderedFood>
    {
        public OrderedFoodConfig()
        {
            Property(a => a.OrderId).IsRequired();
            HasKey(a => a.OrderId);
            HasKey(a => a.FoodId);
            Property(a => a.FoodId).IsRequired();
            Property(a => a.CreatedAtDate).HasColumnType("DateTime").IsRequired();
            Property(a => a.UpdatedAtDate).HasColumnType("DateTime").IsRequired();
        }
    }
}
