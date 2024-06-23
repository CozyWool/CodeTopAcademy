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
using System.Windows.Shapes;

namespace StudentCollectionWpfApp
{
    /// <summary>
    /// Логика взаимодействия для AddStudent.xaml
    /// </summary>
    public partial class AddStudent : Window
    {
        public Student student { get; set; }
        public AddStudent()
        {
            InitializeComponent();
            student = new Student();
        }

        private void NameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            student.Name = NameTextBox.Text;
        }

        private void IdTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (int.TryParse(IdTextBox.Text, out int value))
            {
                student.Id = value;
            }
        }

        private void GroupNumberTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (int.TryParse(GroupNumberTextBox.Text, out int value))
            {
                student.GroupNumber = value;
            }
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }
    }
}
