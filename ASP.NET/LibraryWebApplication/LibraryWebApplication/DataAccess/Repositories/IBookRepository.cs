using LibraryWebApplication.DataAccess.Entities;
using LibraryWebApplication.DataAccess.Filters;

namespace LibraryWebApplication.DataAccess.Repositories;

public interface IBookRepository
{
    BookEntity[] GetAll();
    BookEntity? GetById(int id);
    void Create(BookEntity entity);
    void Update(BookEntity entity);
    void Delete(int id);
    BookEntity[] GetBooksByFilter(BookFilter bookFilter);
}