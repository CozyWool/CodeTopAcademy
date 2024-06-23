using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace SecondHWWinFormsApp;
public partial class Task2Form : Form
{

    private User user = new User();
    public Task2Form()
    {
        InitializeComponent();
    }

    private void SurnameTextBox_TextChanged(object sender, EventArgs e)
    {
        user.Surname = SurnameTextBox.Text;
    }

    private void NameTextBox_TextChanged(object sender, EventArgs e)
    {
        user.Name = NameTextBox.Text;
    }

    private void FatherNameTextBox_TextChanged(object sender, EventArgs e)
    {
        user.FatherName = FatherNameTextBox.Text;
    }

    private void PhoneNumberTextBox_TextChanged(object sender, EventArgs e)
    {
        user.PhoneNumber = PhoneNumberTextBox.Text;
    }

    private void EmailTextBox_TextChanged(object sender, EventArgs e)
    {
        user.Email = EmailTextBox.Text;
    }

    private void MaleRadioButton_CheckedChanged(object sender, EventArgs e)
    {
        user.Gender = Gender.Male;
    }

    private void FemaleRadioButton_CheckedChanged(object sender, EventArgs e)
    {
        user.Gender = Gender.Female;
    }

    private void BitrhdayDatePicker_ValueChanged(object sender, EventArgs e)
    {
        user.BirthdayDate = BirthdayDatePicker.Value;
    }

    private void AddInfoButton_Click(object sender, EventArgs e)
    {
        listBox.Items.Add(user);
    }

    private void SaveButton_Click(object sender, EventArgs e)
    {
        if (saveFileDialog.ShowDialog() == DialogResult.OK)
        {
            string path = saveFileDialog.FileName;
            if (path.EndsWith(".txt"))
            {
                using StreamWriter sw = new(path);
                foreach (var item in listBox.Items)
                {
                    if (item is User user)
                    {
                        StringBuilder sb = new();
                        sb.Append($"{user.Surname};");
                        sb.Append($"{user.Name};");
                        sb.Append($"{user.FatherName};");
                        sb.Append($"{user.PhoneNumber.Replace(" ", "")};");
                        sb.Append($"{user.Email};");
                        string genderStr = "";
                        switch (user.Gender)
                        {
                            case Gender.None:
                                genderStr = "Неизвестно";
                                break;
                            case Gender.Male:
                                genderStr = "Мужской";
                                break;
                            case Gender.Female:
                                genderStr = "Женский";
                                break;
                            default:
                                break;
                        }
                        sb.Append($"{genderStr};");
                        sb.Append($"{user.BirthdayDate.ToShortDateString()}");
                        sw.WriteLine(sb.ToString());
                    }
                    else
                    {
                        sw.WriteLine(item);
                    }
                }
            }
            if (path.EndsWith(".xml"))
            {
                var xmlSerializer = new XmlSerializer(typeof(List<User>));

                XmlWriterSettings settings = new();
                settings.Indent = true;
                settings.IndentChars = "\t";

                using FileStream fs = new(path, FileMode.OpenOrCreate, FileAccess.Write);
                XmlWriter writer = XmlWriter.Create(fs, settings);

                List<User> users = new();
                foreach (var item in listBox.Items)
                {
                    if (item is User user)
                        users.Add(user);
                }
                xmlSerializer.Serialize(writer, users);
            }
        }
    }

    private void LoadButton_Click(object sender, EventArgs e)
    {
        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
            string path = openFileDialog.FileName;
            if (path.EndsWith(".txt"))
            {
                using StreamReader sr = new(path);
                listBox.Items.Clear();
                while (!sr.EndOfStream)
                {
                    var data = sr.ReadLine().Split(";");
                    if (data == null)
                        continue;

                    User newUser = new()
                    {
                        Surname = data[0],
                        Name = data[1],
                        FatherName = data[2],
                        PhoneNumber = data[3],
                        Email = data[4],
                        BirthdayDate = DateTime.Parse(data[6]),
                    };
                    switch (data[5])
                    {
                        case "Неизвестно":
                            newUser.Gender = Gender.None;
                            break;
                        case "Мужской":
                            newUser.Gender = Gender.Male;
                            break;
                        case "Женский":
                            newUser.Gender = Gender.Female;
                            break;
                        default:
                            break;
                    }
                    listBox.Items.Add(newUser);
                }
            }
            if (path.EndsWith(".xml"))
            {

                using FileStream fs = new(path, FileMode.Open, FileAccess.Read);
                var xmlSerializer = new XmlSerializer(typeof(List<User>));

                List<User> newUsers = xmlSerializer.Deserialize(fs) as List<User>;

                listBox.Items.Clear();
                foreach (var user in newUsers)
                {
                    listBox.Items.Add(user);
                }
            }
        }

    }
    private void listBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (listBox.SelectedIndex == -1)
            return;

        user = listBox.Items[listBox.SelectedIndex] as User;
        UpdateUI(user);
    }

    private void DeleteButton_Click(object sender, EventArgs e)
    {
        listBox.Items.Remove(user);
    }


    private void UpdateUI(User changedUser)
    {
        SurnameTextBox.Text = changedUser.Surname;
        NameTextBox.Text = changedUser.Name;
        FatherNameTextBox.Text = changedUser.FatherName;
        PhoneNumberTextBox.Text = changedUser.PhoneNumber;
        EmailTextBox.Text = changedUser.Email;
        switch (changedUser.Gender)
        {
            case Gender.None:
                FemaleRadioButton.Checked = false;
                MaleRadioButton.Checked = false;
                break;
            case Gender.Male:
                MaleRadioButton.Checked = true;
                break;
            case Gender.Female:
                FemaleRadioButton.Checked = true;
                break;
            default:
                break;
        }
        BirthdayDatePicker.Value = changedUser.BirthdayDate;

    }

    private void UpdateRowListbox()
    {
        int index = listBox.SelectedIndex;
        if (index != -1)
        {
            listBox.Items.Remove(listBox.SelectedItem);
            listBox.Items.Insert(index, user);
        }
        listBox.SelectedIndex = index;
    }

    private void SaveChangesButton_Click(object sender, EventArgs e)
    {
        UpdateRowListbox();
    }
}
