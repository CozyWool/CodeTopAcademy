using System.Collections.ObjectModel;
using System.Windows;
using jan26_HW.DataAccess.Contexts;
using jan26_HW.DataAccess.Entities;
using Microsoft.Extensions.Configuration;

namespace jan26_HW;

public partial class MainWindow : Window
{
    private readonly GamesContext _context;
    public ObservableCollection<GameEntity> Games { get; set; }
    
    public MainWindow()
    {
        InitializeComponent();
        var configuration = BuildConfiguration();
        _context = new GamesContext(configuration);
        Games = GetData(configuration);
        DataContext = Games;
    }

    private ObservableCollection<GameEntity> GetData(IConfiguration configuration)
    {
        return new ObservableCollection<GameEntity>(_context.Games.Select(game => new GameEntity
        {
            Id = game.Id,
            Name = game.Name,
            Developer = game.Developer,
            Genre = game.Genre,
            ReleaseDate = game.ReleaseDate
        }).ToList());
    }

    private IConfiguration BuildConfiguration()
    {
        return new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();
    }

    private void AddGameButton_OnClick(object sender, RoutedEventArgs e)
    {
        var window = new GameWindow(_context);
        if (window.ShowDialog() != true) return;

        _context.Games.Add(window.Game);
        Games.Add(window.Game);
        _context.SaveChanges();
    }
}