using System.Text;

namespace SecondHWWinFormsApp;

public class User
{
    public string? Surname { get; set; } = "-";
    public string? FatherName { get; set; } = "-";
    public string? Name { get; set; } = "-";
    public string? PhoneNumber { get; set; } = "-";
    public string? Email { get; set; } = "-";
    public Gender Gender { get; set; } = Gender.None;
    public DateTime BirthdayDate { get; set; } = DateTime.Now;

    public override string? ToString()
    {
        StringBuilder sb = new();
        sb.Append($"ФИО: {Surname} {Name} {FatherName} ");
        sb.Append($"Телефон: {PhoneNumber} Эл. почта: {Email} ");
        string genderStr = "";
        switch (Gender)
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
        sb.Append($"Пол: {genderStr} Дата рождения: {BirthdayDate.ToShortDateString()}");
        return sb.ToString();
    }
}
