using ShopDemoWebApp.DataAccess.Entities;

namespace ShopDemoWebApp.DataAccess.Repositories;

public class FakeCarsRepository : ICarsRepository
{
    private readonly ICarCategoryRepository _carCategoryRepository;

    public FakeCarsRepository(ICarCategoryRepository carCategoryRepository)
    {
        _carCategoryRepository = carCategoryRepository;
    }
    public CarEntity[] GetAll()
    {
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
                Category = _carCategoryRepository.GetAll().Last()
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
                Category = _carCategoryRepository.GetAll().Last()
            },
            new()
            {
                Id = 3,
                Name = "Lada Vesta",
                ShortDescription = "Семейство российских автомобилей среднего класса, выпускаемых АвтоВАЗом с 25 сентября 2015 года в кузове седан, и с 2017 года в кузове универсал.",
                LongDescription = "Автомобиль Lada Vesta I, 2021 года выпуска, в отличном состоянии, 1 хозяин. Весь в заводском окрасе, с пробегом всего 49500 км. Это надежный и экономичный седан, оснащенный 1.6-литровым бензиновым двигателем мощностью 106 лошадиных сил. Коробка передач - механика.",
                Image = "/img/lada-vesta.jpg",
                Price = 1_210_000,
                IsFavourite = false,
                Available = true,
                Category = _carCategoryRepository.GetAll().Last()
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
                Category = _carCategoryRepository.GetAll().Last()
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
                Category = _carCategoryRepository.GetAll().Last()
            },
            new()
            {
                Id = 6,
                Name = "Toyota",
                ShortDescription = "Тойота",
                LongDescription = "В хорошем состоянии. Родной пробег. Привезен из Америки.",
                Image = "/img/237f500bc15d4a3ea9acafc717a69199.jpg",
                Price = 3_000_000,
                IsFavourite = false,
                Available = true,
                Category = _carCategoryRepository.GetAll().Last()
            },
        };
    }

    public CarEntity[] GetFavouriteCars()
    {
        throw new NotImplementedException();
    }

    public CarEntity GetCarById(int id)
    {
        throw new NotImplementedException();
    }
}