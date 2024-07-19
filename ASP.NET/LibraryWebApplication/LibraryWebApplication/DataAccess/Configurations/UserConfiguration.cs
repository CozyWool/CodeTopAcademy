using LibraryWebApplication.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryWebApplication.DataAccess.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        builder.HasKey(e => e.Id).HasName("User_pkey");

        builder.ToTable("User");

        builder.Property(e => e.Id).ValueGeneratedNever();
        builder.Property(e => e.Email).HasMaxLength(100);
        builder.Property(e => e.Password).HasMaxLength(100);
    }
}