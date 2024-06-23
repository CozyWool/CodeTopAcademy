using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void CloseApp(object sender, EventArgs e)
        {
            
            MessageBox.Show("Прощай мир настольных приложений");
            Close();
        }

        private void ShowMessage(object sender, EventArgs e)
        {
            MessageBox.Show("Привет мир настольных приложений");
        }
    }
}
