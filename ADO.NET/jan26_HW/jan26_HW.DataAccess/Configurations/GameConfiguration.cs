using jan26_HW.DataAccess.Entities;
using jan26_HW.DataAccess.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace jan26_HW.DataAccess.Configurations;

public class GameConfiguration : IEntityTypeConfiguration<GameEntity>
{
    public void Configure(EntityTypeBuilder<GameEntity> builder)
    {
        builder.HasKey(e => e.Id).HasName("Game_pkey");

        builder.ToTable("Game");

        builder.Property(e => e.Name).HasMaxLength(50).IsRequired();
        builder.Property(e => e.Developer).HasMaxLength(50).IsRequired();
        builder.Property(e => e.Genre)
            .IsRequired()
            .HasDefaultValue(GameGenre.None)
            .HasConversion(x => x.ToString(), x => Enum.Parse<GameGenre>(x));
        builder.Property(e => e.ReleaseDate).IsRequired();
        builder.Property(e => e.Mode)
            .IsRequired()
            .HasDefaultValue(GameMode.None)
            .HasConversion(x => x.ToString(), x => Enum.Parse<GameMode>(x));
        builder.Property(e => e.SoldCopies).IsRequired().HasDefaultValue(0);
    }
}