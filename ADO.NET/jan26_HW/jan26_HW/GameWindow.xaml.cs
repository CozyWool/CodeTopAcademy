using System.Windows;
using jan26_HW.DataAccess.Contexts;
using jan26_HW.DataAccess.Entities;

namespace jan26_HW;

public partial class GameWindow : Window
{
    public GameWindow(GamesContext context)
    {
        Game = new GameEntity
        {
            Id = context.Games.Any() ? context.Games.OrderBy(x => x.Id).Last().Id + 1 : 1
        };
        DataContext = Game;
        InitializeComponent();
    }

    public GameEntity Game { get; private set; }

    private void CreateButton_Click(object sender, RoutedEventArgs e)
    {
        DialogResult = true;
        Close();
    }

    private void CancelButton_Click(object sender, RoutedEventArgs e)
    {
        Close();
    }
}