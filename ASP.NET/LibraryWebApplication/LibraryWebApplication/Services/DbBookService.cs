using AutoMapper;
using LibraryWebApplication.DataAccess.Entities;
using LibraryWebApplication.DataAccess.Filters;
using LibraryWebApplication.DataAccess.Repositories;
using LibraryWebApplication.Models;

namespace LibraryWebApplication.Services;

public class DbBookService : IBookService
{
    private readonly IBookRepository _bookRepository;
    private readonly IMapper _mapper;

    public DbBookService(IBookRepository bookRepository, IMapper mapper)
    {
        _bookRepository = bookRepository;
        _mapper = mapper;
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
        return _mapper.Map<BookModel[]>(_bookRepository.GetBooksByFilter(bookFilter));
    }
}