using LibraryWebApplication.DataAccess.Filters;
using LibraryWebApplication.DataAccess.Repositories;
using LibraryWebApplication.Enums;
using LibraryWebApplication.Models;

namespace LibraryWebApplication.Services;

public interface IBookService
{
    BookModel[] GetAll();
    BookModel? GetById(int id);
    void Create(BookModel model);
    void Update(BookModel model);
    void Delete(int id);
    BookModel[] GetBooksByFilter(BookFilter bookFilter);
    Task<IndexViewModel> GetSortedPaged(int currentPage, int pageSize, SortState sortOrder);
}   