using LibraryWebApplication.DataAccess.Contexts;
using LibraryWebApplication.DataAccess.Entities;
using LibraryWebApplication.DataAccess.Filters;
using LibraryWebApplication.Enums;
using Microsoft.EntityFrameworkCore;

namespace LibraryWebApplication.DataAccess.Repositories;

public class BookRepository : IBookRepository
{
    private readonly LibraryDbContext _libraryDbContext;

    public BookRepository(LibraryDbContext libraryDbContext)
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

    public BookEntity[] GetBooksByFilter(BookFilter bookFilter, bool isAdult)
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

        if (!isAdult)
        {
            query = query.Where(x => !EF.Functions.Like(x.Style, "%Взрослое%"));
        }
    
        return query.OrderBy(x => x.Id).ToArray();
    }

    public async Task<(BookEntity[] bookEntities, int count)> GetSortedPaged(int currentPage, int pageSize,
        SortState sortOrder, bool isAdult)
    {
        var query = _libraryDbContext.Books.AsQueryable();

        query = sortOrder switch
        {
            SortState.IdDesc => query.OrderByDescending(x => x.Id),
            SortState.IdAsc => query.OrderBy(x => x.Id),
            SortState.NameDesc => query.OrderByDescending(x => x.Name),
            SortState.NameAsc => query.OrderBy(x => x.Name),
            SortState.PublisherDesc => query.OrderByDescending(x => x.Publisher),
            SortState.PublisherAsc => query.OrderBy(x => x.Publisher),
            SortState.AuthorDesc => query.OrderByDescending(x => x.Author),
            SortState.AuthorAsc => query.OrderBy(x => x.Author),
            _ => query.OrderBy(x => x.Id)
        };
        
        query = query
            .Skip((currentPage - 1) * pageSize)
            .Take(pageSize);

        var countQuery = _libraryDbContext.Books.AsQueryable();
        if (!isAdult)
        {
            query = query.Where(x => !EF.Functions.Like(x.Style, "%Взрослое%"));
            countQuery = countQuery.Where(x => !EF.Functions.Like(x.Style, "%Взрослое%"));
        }

        var currentPageItems = await query.ToArrayAsync();
        var count = await countQuery.CountAsync();
        return (currentPageItems, count);
    }
}