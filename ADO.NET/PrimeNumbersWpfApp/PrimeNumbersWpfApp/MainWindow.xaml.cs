using System.Windows;

namespace PrimeNumbersWpfApp;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    // private async void MethodWithVoid() // не делать так!
    // {
    //
    // }
    //
    // private async Task SomeMethod()
    // {
    //     /// code
    //     // await GetResult(); // Ждём до последнего
    //     var t = GetResult();
    //     
    //     t.Wait(TimeSpan.FromSeconds(10));
    //     await t.WaitAsync(TimeSpan.FromSeconds(10));
    // }
    //
    // private Task<int> GetResult() => Task.FromResult<int>(42);

    private CancellationTokenSource _cancellationTokenSource;

    public MainWindow()
    {
        InitializeComponent();
    }

    private int CountPrimes(int from, int to)
    {
        var countNumbers = 0;

        for (var i = from; i <= to; i++)
        {
            var isPrime = true;
            for (var j = 2; j <= (int) Math.Sqrt(i); j++)
            {
                if (i % j == 0)
                {
                    isPrime = false;
                    break;
                }
            }

            if (isPrime) countNumbers++;
        }

        return countNumbers;
    }

    private int CountPrimes(int from, int to, CancellationToken cancellationToken, IProgress<double> progress)
    {
        var countNumbers = 0;
        var pCount = 0;
        var range = to - from;
        
        for (var i = from; i <= to; i++)
        {
            
            cancellationToken.ThrowIfCancellationRequested();
            var isPrime = true;
            for (var j = 2; j <= (int) Math.Sqrt(i); j++)
            {
                if (i % j == 0)
                {
                    isPrime = false;
                    break;
                }
            }

            if (isPrime) countNumbers++;
            
            if (pCount++ % 1000 == 0)
            {
                progress.Report(pCount * 100.0 / range);
            }
        }

        return countNumbers;
    }

    private async Task<int> CountPrimesAsync(int from, int to, CancellationToken cancellationToken,
        IProgress<double> progress)
    {
        var task = Task.Run(() => CountPrimes(from, to, cancellationToken, progress));

        return await task;
    }

    // private void CalcButton_OnClick(object sender, RoutedEventArgs e)
    // {
    //     var first = int.Parse(From.Text);
    //     var last = int.Parse(To.Text);
    //     var count = CountPrimes(first, last);
    //     Result.Text = $"Простых чисел от {first} до {last}: {count}";
    // }

    // private void CalcButton_OnClick(object sender, RoutedEventArgs e)
    // {
    //     var first = int.Parse(From.Text);
    //     var last = int.Parse(To.Text);
    //
    //     ThreadPool.QueueUserWorkItem(_ =>
    //     {
    //         var count = CountPrimes(first, last);
    //         Dispatcher.Invoke(() => { Result.Text = $"Простых чисел от {first} до {last}: {count}"; });
    //     });
    // }


    private async void CalcButton_OnClick(object sender, RoutedEventArgs e)
    {
        ProgressBar.Visibility = Visibility.Visible;
        _cancellationTokenSource = new CancellationTokenSource();
        CalcButton.IsEnabled = !CalcButton.IsEnabled;
        CancelButton.IsEnabled = !CancelButton.IsEnabled;

        var first = int.Parse(From.Text);
        var last = int.Parse(To.Text);
        var p = new Progress<double>(value => ProgressBar.Value = value);
        Result.Text = "Идут вычисления...";


        try
        {
            var count = await CountPrimesAsync(first, last, _cancellationTokenSource.Token, p);
            Result.Text = $"Простых чисел от {first} до {last}: {count}";
        }
        catch (OperationCanceledException ex)
        {
            Result.Text = "Операция была отменена";
        }
        finally
        {
            ProgressBar.Visibility = Visibility.Collapsed;
            _cancellationTokenSource?.Dispose();
            CalcButton.IsEnabled = !CalcButton.IsEnabled;
            CancelButton.IsEnabled = !CancelButton.IsEnabled;
        }
    }

    private void CancelButton_OnClick(object sender, RoutedEventArgs e)
    {
        _cancellationTokenSource.Cancel();
    }
}