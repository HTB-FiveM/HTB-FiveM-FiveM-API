namespace FiveM.Api.Entities.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Perigee.Framework.EntityFramework;

    public class UserConfiguration : BaseEntityTypeConfiguration<User>
    {
        public override void ConfigureEntity(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("users");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnType("varchar(100)").HasMaxLength(100).HasColumnName("identifier").IsRequired();
            builder.Property(p => p.Accounts).HasColumnType("longtext").HasColumnName("accounts");
            builder.Property(p => p.Group).HasColumnType("varchar(50)").HasColumnName("group").HasMaxLength(50).HasDefaultValue("user");
            builder.Property(p => p.Inventory).HasColumnType("longtext").HasColumnName("inventory").HasDefaultValue(null);
            builder.Property(p => p.Job).HasColumnType("varchar(20)").HasColumnName("job").HasMaxLength(20).HasDefaultValue("unemployed");
            builder.Property(p => p.JobGrade).HasColumnType("int(11)").HasColumnName("job_grade").HasDefaultValue(0);
            builder.Property(p => p.Loadout).HasColumnType("longtext").HasColumnName("loadout").HasDefaultValue(null);
            builder.Property(p => p.Position).HasColumnType("varchar(255)").HasMaxLength(255).HasColumnName("position").HasDefaultValue("{\"x\":-269.4,\"y\":-955.3,\"z\":31.2,\"heading\":205.8}");
            builder.Property(p => p.Skin).HasColumnType("longtext").HasColumnName("skin").HasDefaultValue(null);
            builder.Property(p => p.FirstName).HasColumnType("varchar(50)").HasMaxLength(50).HasColumnName("firstname").HasDefaultValue(null);
            builder.Property(p => p.LastName).HasColumnType("varchar(50)").HasMaxLength(50).HasColumnName("lastname").HasDefaultValue(null);
            builder.Property(p => p.DateOfBirth).HasColumnType("varchar(10)").HasMaxLength(10).HasColumnName("dateofbirth").HasDefaultValue(null);
            builder.Property(p => p.Sex).HasColumnName("varchar(1)").HasMaxLength(1).HasColumnName("sex").HasDefaultValue(null);
            builder.Property(p => p.Height).HasColumnType("int(11)").HasColumnName("height").HasDefaultValue(null);
            builder.Property(p => p.LastProperty).HasColumnType("varchar(255)").HasMaxLength(255).HasColumnName("last_property").HasDefaultValue(null);
            builder.Property(p => p.PhoneNumber).HasColumnType("varchar(10)").HasMaxLength(10).HasColumnName("phone_number").HasDefaultValue(null);
            builder.Property(p => p.IsDead).HasColumnType("tinyint(1)").HasColumnName("is_dead").HasDefaultValue(0);
            builder.Property(p => p.Tattoos).HasColumnType("longtext").HasColumnType("tattoos").HasDefaultValue(null);
            builder.Property(p => p.JailTime).HasColumnType("int(11)").HasColumnName("jail_time").IsRequired().HasDefaultValue(0);


        }
    }
}
