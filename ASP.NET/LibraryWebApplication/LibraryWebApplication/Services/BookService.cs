using System.Security.Claims;
using AutoMapper;
using LibraryWebApplication.DataAccess.Entities;
using LibraryWebApplication.DataAccess.Filters;
using LibraryWebApplication.DataAccess.Repositories;
using LibraryWebApplication.Enums;
using LibraryWebApplication.Models;

namespace LibraryWebApplication.Services;

public class BookService : IBookService
{
    private readonly IBookRepository _bookRepository;
    private readonly IMapper _mapper;
    private IHttpContextAccessor _httpContextAccessor;
    private ClaimsPrincipal User => _httpContextAccessor.HttpContext.User;
    private bool IsAdult => User.HasClaim("IsAdult", true.ToString());

    public BookService(IBookRepository bookRepository, IMapper mapper, IHttpContextAccessor httpContextAccessor)
    {
        _bookRepository = bookRepository;
        _mapper = mapper;
        _httpContextAccessor = httpContextAccessor;
    }

    public BookModel[] GetAll()
    {
        return _mapper.Map<BookModel[]>(_bookRepository.GetAll());
    }

    public BookModel? GetById(int id)
    {
        return _mapper.Map<BookModel>(_bookRepository.GetById(id));
    }

    public void Create(BookModel model)
    {
        _bookRepository.Create(_mapper.Map<BookEntity>(model));
    }

    public void Update(BookModel model)
    {
        var oldEntity = _bookRepository.GetById(model.Id);
        if (oldEntity == null) return;
        oldEntity.Name = model.Name;
        oldEntity.Author = model.Author;
        oldEntity.Style = model.Style;
        oldEntity.Publisher = model.Publisher;
        oldEntity.PublishingDate = model.PublishingDate;
        _bookRepository.Update(oldEntity);
    }

    public void Delete(int id)
    {
        _bookRepository.Delete(id);
    }

    public BookModel[] GetBooksByFilter(BookFilter bookFilter)
    {
        return _mapper.Map<BookModel[]>(_bookRepository.GetBooksByFilter(bookFilter, IsAdult));
    }

    public async Task<IndexViewModel> GetSortedPaged(int currentPage, int pageSize, SortState sortOrder)
    {
        var (bookEntities, count) = await _bookRepository.GetSortedPaged(currentPage, pageSize, sortOrder, IsAdult);

        var items = _mapper.Map<List<BookModel>>(bookEntities);
        var pagedModel = new PagedModel<BookModel>(count, currentPage, pageSize, items);
        var indexViewModel = new IndexViewModel
        {
            PagedModel = pagedModel,
            SortViewModel = new SortViewModel(sortOrder)
        };
        return indexViewModel;
    }

}