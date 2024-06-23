using AutoMapper;
using CrudWebApp.DataAccess.Entities;
using CrudWebApp.Models;

namespace CrudWebApp.Profiles;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<ProductEntity, ProductModel>().ReverseMap();
    }
}