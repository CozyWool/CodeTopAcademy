using System.Windows;
using BookLibraryWpfApp.ViewModel.Models;
using BookLibraryWpfApp.ViewModel.ViewModels;

namespace BookLibraryWpfApp.ViewModel.View;

public partial class SingleBookView : Window
{ 
    public SingleBookView(Library library)
    {
        InitializeComponent();
        DataContext = new SingleBookViewModel(library);
    }
}