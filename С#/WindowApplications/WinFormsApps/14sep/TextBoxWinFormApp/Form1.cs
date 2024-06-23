using System.Text;

namespace TextBoxWinFormApp
{
    public enum Gender
    {
        None = -1,
        Male,
        Female
    }
    public partial class Form1 : Form
    {
        private string surname = "-";
        private string name = "-";
        private string fatherName = "-";
        private string country = "-";
        private string city = "-";
        private Gender gender = Gender.None;
        private DateTime birthdayDate = DateTime.Now;
        public Form1()
        {
            InitializeComponent();
        }

        private void SurnameTextBox_TextChanged(object sender, EventArgs e) => surname = SurnameTextBox.Text;

        private void NameTextBox_TextChanged(object sender, EventArgs e) => name = NameTextBox.Text;

        private void FatherNameTextBox_TextChanged(object sender, EventArgs e) => fatherName = FatherNameTextBox.Text;

        private void CountryTextBox_TextChanged(object sender, EventArgs e) => country = CountryTextBox.Text;

        private void CityTextBox_TextChanged(object sender, EventArgs e) => city = CityTextBox.Text;

        private void MaleRadioButton_CheckedChanged(object sender, EventArgs e) => gender = Gender.Male;

        private void FemaleRadioButton_CheckedChanged(object sender, EventArgs e) => gender = Gender.Female;

        private void BitrhdayDatePicker_ValueChanged(object sender, EventArgs e) => birthdayDate = BitrhdayDatePicker.Value;

        private void ShowInfoButton_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new();
            sb.AppendLine($"���: {surname} {name} {fatherName}");
            sb.AppendLine($"������, �����: {country},{city}");
            string genderStr = "";
            switch (gender)
            {
                case Gender.None:
                    genderStr = "����������";
                    break;
                case Gender.Male:
                    genderStr = "�������";
                    break;
                case Gender.Female:
                    genderStr = "�������";
                    break;
                default:
                    break;
            }
            sb.AppendLine($"���, ���� ��������: {genderStr},{birthdayDate.ToShortDateString()}");
            MessageBox.Show(sb.ToString());
        }
    }
}