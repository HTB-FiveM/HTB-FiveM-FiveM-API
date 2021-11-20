namespace FiveM.Api.Entities.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Perigee.Framework.EntityFramework;

    public class LicenseConfiguration : BaseEntityTypeConfiguration<License>
    {
        public override void ConfigureEntity(EntityTypeBuilder<License> builder)
        {
            builder.ToTable("licenses");
            builder.HasKey(p => p.Type);

            builder.Property(p => p.Type).HasColumnType("varchar(60)").HasMaxLength(60).HasColumnName("type").IsRequired();
            builder.Property(p => p.Label).HasColumnType("varchar(60)").HasMaxLength(60).HasColumnName("label").IsRequired();

        }
    }
}
