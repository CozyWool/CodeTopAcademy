using System;
using System.Linq;
using System.Text;
using System.Windows;

namespace LinqToSqlFrameworkWpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            var dbContext = new DataClassesDataContext();
            var query = from b in dbContext.Books
                where b.PublishDate > DateTime.Parse("2011-01-01")
                select b;
            var sb = new StringBuilder();
            foreach (var book in query)
            {
                sb.AppendLine($"{book.Id}-{book.Name}-{book.PublishDate}-{book.PageCount}");
            }
            MessageBox.Show( sb.ToString() );
        }
    }
}