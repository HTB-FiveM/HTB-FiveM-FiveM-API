namespace FiveM.Api.Entities.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Perigee.Framework.EntityFramework;

    public class UserLicenseConfiguration : BaseEntityTypeConfiguration<UserLicense>
    {
        public override void ConfigureEntity(EntityTypeBuilder<UserLicense> builder)
        {
            builder.ToTable("user_licenses");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnType("int(11)").HasColumnName("id").IsRequired();
            builder.Property(p => p.Type).HasColumnType("varchar(60)").HasMaxLength(60).HasColumnName("type").IsRequired();
            builder.Property(p => p.Owner).HasColumnType("varchar(100)").HasMaxLength(100).HasColumnName("owner").IsRequired();


        }
    }
}
