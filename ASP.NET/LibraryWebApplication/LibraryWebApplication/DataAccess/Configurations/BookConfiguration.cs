using LibraryWebApplication.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryWebApplication.DataAccess.Configurations;

public class BookConfiguration : IEntityTypeConfiguration<BookEntity>
{
    public void Configure(EntityTypeBuilder<BookEntity> builder)
    {
        builder.HasKey(e => e.Id).HasName("Book_pkey");

        builder.ToTable("Book");

        builder.Property(e => e.Id).ValueGeneratedNever();
        builder.Property(e => e.Author).HasMaxLength(70);
        builder.Property(e => e.Name).HasMaxLength(50);
        builder.Property(e => e.Publisher).HasMaxLength(50);
        builder.Property(e => e.Style).HasMaxLength(50);
    }
}