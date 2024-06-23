using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using EfCoreWpf.DataAccess.Contexts;
using EfCoreWpf.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EfCoreWpf
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var configuration = BuildConfiguration();
            LoadData(configuration);
        }

        private IConfiguration BuildConfiguration()
        {
            return new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
        }

        private void AddBookButton_Click(object sender, RoutedEventArgs e)
        {
            var bookWindow = new BookWindow();
            bookWindow.ShowDialog();
        }

        private void LoadData(IConfiguration configuration)
        {
            
            // var connectionString = ConfigurationManager.ConnectionStrings["BooksConnectionString"].ConnectionString;
            /*using var bookDbProvider = new BookDbProvider(connectionString);
            BooksDataGrid.ItemsSource = bookDbProvider.GetBooks();*/
            //"select \"Title\", a.\"FirstName\", \"PageCount\", \"Price\", p.\"PublisherName\"
            //from \"Book\" b\r\n
            //join \"Author\" a on b.\"AuthorId\" = a.\"Id\"\r\n
            //join \"Publisher\" p on b.\"PublisherId\" = p.\"Id\"";
            var context = new BooksContext(configuration);
            var items = context.Books.Include(x => x.AuthorEntity)
                .Include(x => x.PublisherEntity)
                .Select(book => new BookModel
                {
                    Title = book.Title,
                    FirstName = book.AuthorEntity.FirstName,
                    PageCount = book.PageCount,
                    Price = book.Price,
                    PublisherName = book.PublisherEntity.PublisherName
                })
                .ToList();
            BooksDataGrid.ItemsSource = items;
        }
    }
}
