using CrudWeb.DataAccess.Entities;

namespace CrudWeb.DataAccess.Repositories;

public interface ICategoryRepository
{
    CategoryEntity[] GetAll();
}