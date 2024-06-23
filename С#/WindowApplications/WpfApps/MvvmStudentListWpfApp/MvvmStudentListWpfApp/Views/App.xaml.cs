using System.Windows;
using MvvmStudentListWpfApp.Models;
using MvvmStudentListWpfApp.ViewModels;

namespace MvvmStudentListWpfApp.Views
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

            var student1 = new Student(0, "Petr", "Petrov", "P12");
            var student2 = new Student(1, "Sergey", "Sergeev", "P13");
            var student3 = new Student(2, "Alexey", "Alexeev", "P14");

            var mainWindow = new MainWindow();

            var studentList = new StudentList();
            var mainWindowViewModel = new MainWindowViewModel(studentList, mainWindow);
            mainWindowViewModel.Students.AddStudent(student1);
            mainWindowViewModel.Students.AddStudent(student2);
            mainWindowViewModel.Students.AddStudent(student3);

            mainWindow.DataContext = mainWindowViewModel;
            mainWindow.Show();
        }
    }
}