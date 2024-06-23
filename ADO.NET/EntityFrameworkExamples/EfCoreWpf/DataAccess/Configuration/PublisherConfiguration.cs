using EfCoreWpf.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfCoreWpf.DataAccess.Configuration;

public class PublisherConfiguration : IEntityTypeConfiguration<PublisherEntity>
{
    public void Configure(EntityTypeBuilder<PublisherEntity> builder)
    {
        builder.HasKey(e => e.Id).HasName("Publisher_pkey");

        builder.ToTable("Publisher");

        builder.Property(e => e.Address).HasMaxLength(100);
        builder.Property(e => e.PublisherName).HasMaxLength(100);
    }
}