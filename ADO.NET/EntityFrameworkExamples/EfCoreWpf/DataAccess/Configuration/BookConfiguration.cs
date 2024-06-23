using EfCoreWpf.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfCoreWpf.DataAccess.Configuration;

public class BookConfiguration : IEntityTypeConfiguration<BookEntity>
{
    public void Configure(EntityTypeBuilder<BookEntity> builder)
    {
        builder.HasKey(e => e.Id).HasName("Book_pkey");

        builder.ToTable("Book");

        builder.Property(e => e.AuthorId).ValueGeneratedOnAdd();
        builder.Property(e => e.PublisherId).ValueGeneratedOnAdd();
        builder.Property(e => e.Title).HasMaxLength(100);   
        builder.Property(e => e.Printing).IsRequired().HasDefaultValue(0);   

        builder.HasOne(d => d.AuthorEntity).WithMany(p => p.Books)
            .HasForeignKey(d => d.AuthorId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("Book_AuthorId_fkey");

        builder.HasOne(d => d.PublisherEntity).WithMany(p => p.Books)
            .HasForeignKey(d => d.PublisherId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("Book_PublisherId_fkey");
    }
}