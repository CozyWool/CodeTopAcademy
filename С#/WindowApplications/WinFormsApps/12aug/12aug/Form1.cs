using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _12aug
{
    public partial class Form1 : Form
    {
        private int value = 35;
        public Form1()
        {
            InitializeComponent();
            ShowMessageButton.Enabled = false;
        }

        private void CloseForm_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ShowMessage_Click(object sender, EventArgs e)
        {
            //MessageBox.Show($"Привет, мир!", "Заголовок MessageBox");
            MessageBox.Show(InputTextBox.Text, "Пользователь ввёл значение:");
        }

        private void InputTextBox_TextChanged(object sender, EventArgs e)
        {
            ShowMessageButton.Enabled = InputTextBox.Text.Length >= 8;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            MouseCoordsLabel.Text = $"X: {e.X}, Y: {e.Y}";
        }
    }
}
