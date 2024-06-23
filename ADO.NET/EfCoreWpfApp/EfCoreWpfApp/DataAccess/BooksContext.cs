using Microsoft.EntityFrameworkCore;

namespace EfCoreWpfApp.DataAccess;

public class BooksContext : DbContext
{
    public BooksContext()
    {
    }

    public BooksContext(DbContextOptions<BooksContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Author> Authors { get; set; }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<Publisher> Publishers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Username=postgres;Password=d3k7f4l8b5r4;Database=Books;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Author_pkey");

            entity.ToTable("Author");

            entity.Property(e => e.FirstName).HasMaxLength(100);
            entity.Property(e => e.LastName).HasMaxLength(100);
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Book_pkey");

            entity.ToTable("Book");

            entity.Property(e => e.AuthorId).ValueGeneratedOnAdd();
            entity.Property(e => e.PublisherId).ValueGeneratedOnAdd();
            entity.Property(e => e.Title).HasMaxLength(100);

            entity.HasOne(d => d.Author).WithMany(p => p.Books)
                .HasForeignKey(d => d.AuthorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Book_AuthorId_fkey");

            entity.HasOne(d => d.Publisher).WithMany(p => p.Books)
                .HasForeignKey(d => d.PublisherId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Book_PublisherId_fkey");
        });

        modelBuilder.Entity<Publisher>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Publisher_pkey");

            entity.ToTable("Publisher");

            entity.Property(e => e.Address).HasMaxLength(100);
            entity.Property(e => e.PublisherName).HasMaxLength(100);
        });
        modelBuilder.HasSequence("Book_AuthorId_seq");
        modelBuilder.HasSequence("Book_Id_seq");
        modelBuilder.HasSequence("Book_PublisherId_seq");
        modelBuilder.HasSequence("Publisher_Id_seq");

    }
}
