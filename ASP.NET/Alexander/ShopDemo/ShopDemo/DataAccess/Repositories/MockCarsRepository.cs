using ShopDemo.DataAccess.Entities;

namespace ShopDemo.DataAccess.Repositories;

public class MockCarsRepository : ICarsRepository
{
    private readonly ICarCategoryRepository _carCategoryRepository;

    public MockCarsRepository(ICarCategoryRepository carCategoryRepository)
    {
        _carCategoryRepository = carCategoryRepository;
    }

    public CarEntity[] GetAll()
    {
        var categoryEntity = _carCategoryRepository.GetAll().Last();
        return new CarEntity[]
        {
            new()
            {
                Id = 1,
                Name = "Corolla",
                ShortDescription = "Автомобиль, выпускаемый компанией Toyota",
                LongDescription = "НОВЫЙ АВТОМОБИЛЬ. Изготовлен 05.2023г. ПРИВЕЗЕН С КИТАЯ АВТОВОЗОМ.\nРастаможен в России. ЭПТС в наличии.",
                Image = "/img/corolla.jpg",
                Price = 2_190_000,
                IsFavourite = false,
                Available = true,
                CategoryId = categoryEntity.Id,
                Category = categoryEntity
            },
            new()
            {
                Id = 2,
                Name = "Ford Mustang",
                ShortDescription = "Легковой автомобиль класса Pony Car производства Ford Motor Company",
                LongDescription = "В хорошем состоянии. Родной пробег. Привезен из Америки.",
                Image = "/img/Ford-Mustang-gt-500.jpg",
                Price = 4_250_000,
                IsFavourite = false,
                Available = true,
                CategoryId = categoryEntity.Id,
                Category = categoryEntity
            },
            new()
            {
                Id = 3,
                Name = "Corolla",
                ShortDescription = "Семейство российских автомобилей среднего класса, выпускаемых АвтоВАЗом с 25 сентября 2015 года в кузове седан, и с 2017 года в кузове универсал.",
                LongDescription = "Автомобиль Lada Vesta I, 2021 года выпуска, в отличном состоянии, 1 хозяин. Весь в заводском окрасе, с пробегом всего 49500 км. Это надежный и экономичный седан, оснащенный 1.6-литровым бензиновым двигателем мощностью 106 лошадиных сил. Коробка передач - механика.",
                Image = "/img/lada-vesta.jpg",
                Price = 1_210_000,
                IsFavourite = false,
                Available = true,
                CategoryId = categoryEntity.Id,
                Category = categoryEntity
            },
            new()
            {
                Id = 4,
                Name = "Corolla",
                ShortDescription = "Автомобиль, выпускаемый компанией Toyota",
                LongDescription = "НОВЫЙ АВТОМОБИЛЬ. Изготовлен 05.2023г. ПРИВЕЗЕН С КИТАЯ АВТОВОЗОМ.\nРастаможен в России. ЭПТС в наличии.",
                Image = "/img/corolla.jpg",
                Price = 2_190_000,
                IsFavourite = false,
                Available = true,
                CategoryId = categoryEntity.Id,
                Category = categoryEntity
            },
            new()
            {
                Id = 5,
                Name = "Ford Mustang",
                ShortDescription = "Легковой автомобиль класса Pony Car производства Ford Motor Company",
                LongDescription = "В хорошем состоянии. Родной пробег. Привезен из Америки.",
                Image = "/img/Ford-Mustang-gt-500.jpg",
                Price = 4_250_000,
                IsFavourite = false,
                Available = true,
                CategoryId = categoryEntity.Id,
                Category = categoryEntity
            }
        };
    }

    public CarEntity[] GetFavouriteCars()
    {
        throw new System.NotImplementedException();
    }

    public CarEntity GetCarById(int carId)
    {
        return GetAll().SingleOrDefault(x => x.Id == carId);
    }

    public CarEntity[] GetCarByFilter(CarFilter carFilter)
    {
        throw new NotImplementedException();
    }
}