using System.Security.Claims;
using LibraryWebApplication.DataAccess.Entities;
using LibraryWebApplication.DataAccess.Filters;
using LibraryWebApplication.Enums;

namespace LibraryWebApplication.DataAccess.Repositories;

public interface IBookRepository
{
    BookEntity[] GetAll();
    BookEntity? GetById(int id);
    void Create(BookEntity entity);
    void Update(BookEntity entity);
    void Delete(int id);
    BookEntity[] GetBooksByFilter(BookFilter bookFilter, bool isAdult);

    Task<(BookEntity[] bookEntities, int count)> GetSortedPaged(int currentPage, int pageSize, SortState sortOrder,
        bool isAdult);
}