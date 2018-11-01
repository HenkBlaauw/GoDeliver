using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GoDeliver.Entities;
using System.Data.Entity.ModelConfiguration;

namespace GoDeliver.EntityConfigurations
{
    public class CustomerConfigurations : EntityTypeConfiguration<Customer>
    {
        public CustomerConfigurations()
        {
            HasKey(a => a.CustomerId);
            Property(a => a.Name).HasMaxLength(255).IsRequired();
            Property(a => a.CreatedAtDate).HasColumnType("DateTime").IsRequired();
            Property(a => a.UpdatedAtDate).HasColumnType("DateTime").IsRequired();

            ToTable("Customers");
        }
    }
}
