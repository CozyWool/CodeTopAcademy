using System.Text;
using System.Windows;

namespace LinqWpfApp;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        var dbContext = new DataClassesDataContext();
        var query = from b in dbContext.Books
            select new
            {
                b.Id,
                b.Name,
                b.PublishDate,
                b.PageCount
            };
        var sb = new StringBuilder();
        foreach (var book in query)
        {
            sb.Append($"{book.Id}-{book.Name}-{book.PublishDate}-{book.PageCount}");
        }
    }
}