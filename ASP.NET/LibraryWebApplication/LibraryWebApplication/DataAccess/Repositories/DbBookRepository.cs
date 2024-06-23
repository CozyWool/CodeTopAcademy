using LibraryWebApplication.DataAccess.Contexts;
using LibraryWebApplication.DataAccess.Entities;
using LibraryWebApplication.DataAccess.Filters;
using Microsoft.EntityFrameworkCore;

namespace LibraryWebApplication.DataAccess.Repositories;

public class DbBookRepository : IBookRepository
{
    private readonly LibraryDbContext _libraryDbContext;

    public DbBookRepository(LibraryDbContext libraryDbContext)
    {
        _libraryDbContext = libraryDbContext;
    }

    public BookEntity[] GetAll()
    {
        return _libraryDbContext.Books.OrderBy(x => x.Id).ToArray();
    }

    public BookEntity? GetById(int id)
    {
        return _libraryDbContext.Books.FirstOrDefault(entity => entity.Id == id);
    }

    public void Create(BookEntity entity)
    {
        if (entity.Id <= 0)
        {
            entity.Id = GetAll().OrderBy(x => x.Id).Last().Id + 1;
        }
        
        if (entity.PublishingDate.Kind != DateTimeKind.Utc)
        {
            entity.PublishingDate = DateTime.SpecifyKind(entity.PublishingDate, DateTimeKind.Utc);
        }
        
        _libraryDbContext.Add(entity);
        _libraryDbContext.SaveChanges();
    }

    public void Update(BookEntity entity)
    {
        if (entity.PublishingDate.Kind != DateTimeKind.Utc)
        {
            entity.PublishingDate = DateTime.SpecifyKind(entity.PublishingDate, DateTimeKind.Utc);
        }
        
        _libraryDbContext.Update(entity);
        _libraryDbContext.SaveChanges();
    }

    public void Delete(int id)
    {
        var entity = GetById(id);
        if (entity == null)
            return;

        _libraryDbContext.Books.Remove(entity);
        _libraryDbContext.SaveChanges();
    }

    public BookEntity[] GetBooksByFilter(BookFilter bookFilter)
    {
        var query = _libraryDbContext.Books.AsQueryable();
        if (!string.IsNullOrEmpty(bookFilter.Name))
        {
            query = query.Where(x => EF.Functions.Like(x.Name, $"%{bookFilter.Name}%"));
        }
        if (!string.IsNullOrEmpty(bookFilter.Author))
        {
            query = query.Where(x => EF.Functions.Like(x.Author, $"%{bookFilter.Author}%"));
        }
        if (!string.IsNullOrEmpty(bookFilter.Style))
        {
            query = query.Where(x => EF.Functions.Like(x.Style, $"%{bookFilter.Style}%"));
        }
        if (!string.IsNullOrEmpty(bookFilter.Publisher))
        {
            query = query.Where(x => EF.Functions.Like(x.Publisher, $"%{bookFilter.Publisher}%"));
        }
        if (bookFilter.PublishingYear.HasValue)
        {
            query = query.Where(x => x.PublishingDate.Year == bookFilter.PublishingYear);
        }

        return query.OrderBy(x => x.Id).ToArray();
    }
}