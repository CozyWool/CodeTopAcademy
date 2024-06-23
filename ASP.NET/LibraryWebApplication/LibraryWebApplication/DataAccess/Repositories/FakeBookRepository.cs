using LibraryWebApplication.DataAccess.Entities;
using LibraryWebApplication.DataAccess.Filters;

namespace LibraryWebApplication.DataAccess.Repositories;

public class FakeBookRepository : IBookRepository
{
    private readonly BookEntity[] _fakeBookArr;

    public FakeBookRepository()
    {
        _fakeBookArr = [
            new BookEntity
            {
                Id = 0,
                Name = "Преступление и наказание",
                Author = "Достоевский Ф.М.",
                Style = "Роман",
                Publisher = "Просвещение",
                PublishingDate = new DateTime(1900, 1, 1)
            },
            new BookEntity
            {
                Id = 1,
                Name = "Капитанская дочка",
                Author = "Пушкин А.С.",
                Style = "Роман",
                Publisher = "Издательство",
                PublishingDate = new DateTime(1840, 1, 1)
            },
            new BookEntity
            {
                Id = 2,
                Name = "Мастер и Маргарита",
                Author = "Булгаков М.А.",
                Style = "Роман",
                Publisher = "Азбука",
                PublishingDate = new DateTime(1940, 1, 1)
            },
        ];
    }

    public BookEntity[] GetAll()
    {
        return _fakeBookArr;
    }

    public BookEntity? GetById(int id)
    {
        return _fakeBookArr.FirstOrDefault(entity => entity.Id == id);
    }

    public void Create(BookEntity entity)
    {
        throw new NotImplementedException();
    }

    public void Update(BookEntity model)
    {
        throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public BookEntity[] GetBooksByFilter(BookFilter bookFilter)
    {
        throw new NotImplementedException();
    }
}