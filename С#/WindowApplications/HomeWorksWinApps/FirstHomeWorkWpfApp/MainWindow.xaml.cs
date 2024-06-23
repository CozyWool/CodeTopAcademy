using System;
using System.Windows;

namespace FirstHomeWorkWpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Task1_Click(object sender, RoutedEventArgs e)
        {  
            var window = new Task1(this);
            window.ShowDialog();
        }

        private void Task2_Click(object sender, RoutedEventArgs e)
        {
            var window = new Task2(this);
            window.ShowDialog();
        }
    }
}