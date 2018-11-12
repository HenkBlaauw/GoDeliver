using GoDeliverWebApp.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace GoDeliverWebApp.EntityConfigurations
{
    public class RestaurantConfigurations : EntityTypeConfiguration<Restaurant>
    {
        public RestaurantConfigurations()
        {
            HasKey(c => c.RestaurantId);
            Property(r => r.RestaurantId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).IsRequired();
            Property(n => n.Name).HasMaxLength(255).IsRequired();
            Property(a => a.Adress).HasMaxLength(255).IsRequired();
            Property(a => a.CreatedAtDate).IsRequired();
            Property(a => a.UpdatedAtDate).IsRequired();
            HasMany<Food>(t => t.Foods);
            Map(m => m.ToTable("Restaurants"));
        }
    }
}
  