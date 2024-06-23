using AutoMapper;
using LibraryWebApplication.DataAccess.Entities;
using LibraryWebApplication.Models;

namespace LibraryWebApplication.Profiles;

public class BookProfile : Profile
{
    public BookProfile()
    {
        CreateMap<BookModel, BookEntity>().ReverseMap();
    }
}