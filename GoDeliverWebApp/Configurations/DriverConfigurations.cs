using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GoDeliverWebApp.Entities;
using System.Data.Entity.ModelConfiguration;

namespace GoDeliverWebApp.EntityConfigurations
{
    public class DriverConfigurations   : EntityTypeConfiguration<Driver>
    {
        public DriverConfigurations()
        {
            HasKey(a => a.DriverId);
            Property(a => a.Name).HasMaxLength(255).IsRequired();
            Property(a => a.CreatedAtDate).IsRequired();
            Property(a => a.UpdatedAtDate).IsRequired();

            Map(m=> m.ToTable("Drivers"));
        }




    }
}
