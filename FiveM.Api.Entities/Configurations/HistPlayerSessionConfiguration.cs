namespace FiveM.Api.Entities.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Perigee.Framework.EntityFramework;

    public class HistPlayerSessionConfiguration : BaseEntityTypeConfiguration<HistPlayerSession>
    {
        public override void ConfigureEntity(EntityTypeBuilder<HistPlayerSession> builder)
        {
            builder.ToTable("hist_player_session");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnType("int(11)").HasColumnName("id").IsRequired();
            builder.Property(p => p.Identifier).HasColumnType("varchar(100)").HasMaxLength(100).HasColumnName("identifier").IsRequired();
            builder.Property(p => p.ServerId).HasColumnType("int(11)").HasColumnName("server_id").IsRequired();
            builder.Property(p => p.SteamHex).HasColumnType("varchar(50)").HasMaxLength(50).HasColumnName("steamHex").HasDefaultValue(null);
            builder.Property(p => p.SteamName).HasColumnType("varchar(100)").HasMaxLength(100).HasColumnName("steamName").HasDefaultValue(null);
            builder.Property(p => p.Discord).HasColumnType("varchar(100)").HasMaxLength(100).HasColumnName("discord_id").HasDefaultValue(null);
            builder.Property(p => p.ConnectTime).HasColumnType("datetime").HasColumnName("connect_time").IsRequired();
            builder.Property(p => p.DisconnectTime).HasColumnType("datetime").HasColumnName("disconnect_time").HasDefaultValue(null);
            builder.Property(p => p.ExitReason).HasColumnType("varchar(50)").HasMaxLength(50).HasColumnName("exit_reason").HasDefaultValue(null);

            builder.HasOne(hps => hps.User)
                .WithMany(u => u.Sessions)
                .HasForeignKey(hps => hps.Identifier);


        }
    }
}
