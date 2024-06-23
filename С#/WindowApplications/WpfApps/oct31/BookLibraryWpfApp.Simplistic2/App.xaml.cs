using System;
using System.Windows;

namespace BookLibraryWpfApp.Simplistics2
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            ShutdownMode = ShutdownMode.OnMainWindowClose;
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var book1 = new Book("The C++ Programming Language, 4th Edition", "Bjarne Stroustrup", new DateTime(2013, 5, 19));
            var book2 = new Book("Beginning Programming with Java For Dummies", "Barry A. Burd", new DateTime(2014, 6, 23));
            var book3 = new Book("Create Your Own App", "Muminul Hasan Khan", new DateTime(2017, 1, 21));
            var book4 = new Book("Mastering C# and .NET Programming", "Marino Posadas", new DateTime(2016, 12, 15));
            var book5 = new Book("WPF 3d: Three-Dimensional Graphics with WPF and C#", "Rod Stephens", new DateTime(2018, 2, 8));

            var library = new Library();
            library.AddBook(book1);
            library.AddBook(book2);
            library.AddBook(book3);
            library.AddBook(book4);
            library.AddBook(book5);

            var mainWindow = new MainWindow(library);
            mainWindow.Show();
        }
    }
}