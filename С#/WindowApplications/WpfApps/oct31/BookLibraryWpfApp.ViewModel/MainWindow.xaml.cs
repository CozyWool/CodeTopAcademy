using System.Windows;
using System.Windows.Controls;
using BookLibraryWpfApp.ViewModel.Models;
using BookLibraryWpfApp.ViewModel.View;

namespace BookLibraryWpfApp.ViewModel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Library _library;

        public MainWindow(Library library)
        {
            InitializeComponent();
            _library = library;
        }

        private void NameTextBox_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateAddButtonState();
        }

        private void AuthorTextBox_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateAddButtonState();
        }

        private void PublishDatePicker_OnSelectedDateChanged(object? sender, SelectionChangedEventArgs e)
        {
            UpdateAddButtonState();
        }

        private void AddButton_OnClick(object sender, RoutedEventArgs e)
        {
            var book = new Book(NameTextBox.Text,
                AuthorTextBox.Text,
                PublishDatePicker.SelectedDate.Value);
            _library.AddBook(book);
        }

        private void BookListButton_OnClick(object sender, RoutedEventArgs e)
        {
            var view = new ListBookView(_library);
            view.Show();
        }

        private void SingleBookButton_OnClick(object sender, RoutedEventArgs e)
        {
            var view = new SingleBookView(_library);
            view.Show();
        }

        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            UpdateAddButtonState();
        }

        private void UpdateAddButtonState()
        {
            AddButton.IsEnabled = NameTextBox.Text.Length > 0 &&
                                  AuthorTextBox.Text.Length > 0 &&
                                  PublishDatePicker.SelectedDate.HasValue;
        }
    }
}