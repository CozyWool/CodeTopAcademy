using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace FirstHomeWorkWpfApp.Class;

public class DataSource : INotifyPropertyChanged
{
    private double _result;
    private string? _expressionText;

    public double Result
    {
        get => _result;
        set
        {
            _result = value;
            OnPropertyChanged();
        }
    }

    public string? ExpressionText
    {
        get => _expressionText;
        private set
        {
            _expressionText = value;
            OnPropertyChanged();
        }
    }

    public DataSource()
    {
        _expressionText = "";
    }

    // Работу с отриц. числами не сделал, не придумал, как парсить правильно
    public void AddSymbol(char symbol)
    {
        switch (symbol)
        {
            case '0':
                if (ExpressionText == string.Empty || !char.IsDigit(ExpressionText[^1]))
                {
                    MessageBox.Show("Число не может начинаться с 0!");
                    break;
                }
                ExpressionText += '0';
                break;
            case '1' or '2' or '3' or '4' or '5' or '6' or '7' or '8' or '9':
                ExpressionText += symbol;
                break;
            case '+':
                if (ExpressionText == string.Empty || !char.IsDigit(ExpressionText[^1]))
                {
                    MessageBox.Show("Невозможно поставить знак в данную позицию!");
                    break;
                }
                ExpressionText += '+';
                break;
            case '-':
                if (ExpressionText == string.Empty || !char.IsDigit(ExpressionText[^1]))
                {
                    MessageBox.Show("Невозможно поставить знак в данную позицию!");
                    break;
                }
                ExpressionText += '-';
                break;
            case '/':
                if (ExpressionText == string.Empty || !char.IsDigit(ExpressionText[^1]))
                {
                    MessageBox.Show("Невозможно поставить знак в данную позицию!");
                    break;
                }
                ExpressionText += '/';
                break;
            case '*':
                if (ExpressionText == string.Empty || !char.IsDigit(ExpressionText[^1]))
                {
                    MessageBox.Show("Невозможно поставить знак в данную позицию!");
                    break;
                }
                ExpressionText += '*';
                break;
            case ',':
                if (ExpressionText == string.Empty)
                {
                    ExpressionText += "0,";
                    break;
                }
                if (!char.IsDigit(ExpressionText[^1]))
                {
                    MessageBox.Show("Невозможно поставить запятую в данную позицию!");
                    break;
                }
                ExpressionText += ',';
                break;
            
        }
    }


    public void ClearResult()
    {
        Result = 0;
    }
    public void ClearExpression()
    {
        ExpressionText = string.Empty;
    }

    public void ClearLast()
    {
        ExpressionText = ExpressionText[..(_expressionText.Length - 1)];
    }

    public double CalculateResult()
    {
        Result = Parser.Parse(_expressionText);
        return Result;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}