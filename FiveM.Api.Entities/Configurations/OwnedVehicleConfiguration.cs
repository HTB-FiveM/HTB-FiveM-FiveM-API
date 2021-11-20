namespace FiveM.Api.Entities.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Perigee.Framework.EntityFramework;

    public class OwnedVehicleConfiguration : BaseEntityTypeConfiguration<OwnedVehicle>
    {
        public override void ConfigureEntity(EntityTypeBuilder<OwnedVehicle> builder)
        {
            builder.ToTable("owned_vehicles");
            builder.HasKey(p => p.Plate);

            builder.Property(p => p.Plate).HasColumnType("varchar(50)").HasMaxLength(50).HasColumnName("plate").IsRequired();
            builder.Property(p => p.Definition).HasColumnType("longtext").HasColumnName("vehicle").IsRequired();
            builder.Property(p => p.Owner).HasColumnType("varchar(100").HasMaxLength(100).HasColumnName("owner").IsRequired();
            builder.Property(p => p.Stored).HasColumnType("tinyint(1)").HasColumnName("stored").IsRequired();
            builder.Property(p => p.GarageName).HasColumnType("varchar(50)").HasMaxLength(50).HasColumnName("garage_name").IsRequired();
            builder.Property(p => p.Impounded).HasColumnType("tinyint(1)").HasColumnName("pound").IsRequired();
            builder.Property(p => p.Name).HasColumnType("varchar(50)").HasMaxLength(50).HasColumnName("vechiclename").HasDefaultValue(null);
            builder.Property(p => p.Type).HasColumnType("varchar(10)").HasMaxLength(10).HasColumnName("type").IsRequired();
            builder.Property(p => p.Job).HasColumnType("varchar(50)").HasMaxLength(50).HasColumnName("job").HasDefaultValue(null);

        }
    }
}
