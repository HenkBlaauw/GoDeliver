using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GoDeliverWebApp.Entities;
using System.Data.Entity.ModelConfiguration;

namespace GoDeliverWeb.EntityConfigurations
{
    public class CustomerConfigurations : EntityTypeConfiguration<Customer>
    {
        public CustomerConfigurations()
        {
            HasKey(a => a.CustomerId);
            Property(a => a.CustomerId).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(a => a.Name).HasMaxLength(255).IsRequired();
            Property(a => a.CreatedAtDate).IsRequired();
            Property(a => a.UpdatedAtDate).IsRequired();
            Map(m => m.ToTable("Customers"));
            // ToTable("Customers");
        }
    }
}
