using System.Windows;
using System.Windows.Controls;
using FirstHomeWorkWpfApp.Class;

namespace FirstHomeWorkWpfApp;

public partial class Task2 : Window
{
    private readonly DataSource _dataSource = new DataSource();
    public Task2(Window owner)
    {
        InitializeComponent();
        Owner = owner;
        DataContext = _dataSource;
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        if (sender is not Button button)
            return;
        switch (button.Content)
        {
            case "CE":
                _dataSource.ClearResult();
                break;
            case "C":
                _dataSource.ClearExpression();
                _dataSource.ClearResult();
                break; 
            case "<":
                _dataSource.ClearLast();
                break;
            case "=":
                if (_dataSource.ExpressionText == string.Empty || !char.IsDigit(_dataSource.ExpressionText[^1]))
                {
                    MessageBox.Show("Допишите выражение!");
                    break;
                }

                _dataSource.CalculateResult();
                break;
            default:
                if(char.TryParse(button.Content.ToString(), out var symbol))
                    _dataSource.AddSymbol(symbol);
                break;

        }
    }
}