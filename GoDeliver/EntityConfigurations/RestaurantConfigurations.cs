using GoDeliver.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace GoDeliver.EntityConfigurations
{
    public class RestaurantConfigurations : EntityTypeConfiguration<Restaurant>
    {
        public RestaurantConfigurations()
        {
            HasKey(c => c.RestaurantId);
            Property(r => r.RestaurantId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).IsRequired();
            Property(n => n.Name).HasMaxLength(255).IsRequired();
            Property(a => a.Adress).HasMaxLength(255).IsRequired();
            Property(a => a.CreatedAtDate).HasColumnType("DateTime").IsRequired();
            Property(a => a.UpdatedAtDate).HasColumnType("DateTime").IsRequired();
            //HasMany(t => t.foods).WithRequired(a => a.)
            //Map(m =>
            //{
            //    m.ToTable("Restaurants");
            //    m.MapLeftKey()


            //});
            ToTable("Restaurants");
        }
    }
}
