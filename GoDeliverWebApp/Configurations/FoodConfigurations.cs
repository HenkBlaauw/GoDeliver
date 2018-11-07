using GoDeliverWebApp.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace GoDeliverWebApp.Configurations
{
    public class FoodConfigurations : EntityTypeConfiguration<Food>
    {
        public FoodConfigurations()
        {
            HasKey(a => a.FoodId);
            Property(a => a.Name).HasMaxLength(255).IsRequired();
            Property(a => a.Description).HasMaxLength(255).IsRequired();
            Property(a => a.Cost).HasColumnType("Real").IsRequired();
            Property(a => a.CreatedAtDate).HasColumnType("DateTime").IsRequired();
            Property(a => a.UpdatedAtDate).HasColumnType("DateTime").IsRequired();

            Map(m => m.ToTable("Foods"));
        }
    }
}