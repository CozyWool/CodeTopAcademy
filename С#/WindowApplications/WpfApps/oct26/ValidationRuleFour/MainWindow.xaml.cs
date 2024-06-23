using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ValidationRuleFour
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new Person();
        }

        private void Grid_Error(object? sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
            {
                MessageBox.Show(e.Error.ErrorContent.ToString());
            }
        }

        private void ShowErrorsButton_Click(object sender, RoutedEventArgs e)
        {
            var sb = new StringBuilder();
            var dp = Content as DependencyObject;
            Errors(sb, dp);
            MessageBox.Show(sb.Length != 0 ? sb.ToString() : "Ошибок не обнаружено");
        }

        private static void Errors(StringBuilder sb, DependencyObject dp)
        {
            foreach(var child in LogicalTreeHelper.GetChildren(dp))
            {
                if (child is not TextBox element) continue;
                if (Validation.GetHasError(element))
                {
                    sb.AppendLine($"{element.Text} ошибки:");
                    foreach (var validationError in Validation.GetErrors(element))
                    {
                        sb.AppendLine($"{validationError.ErrorContent}");
                    }
                }
                
                Errors(sb, element);
            }
        }
    }
}