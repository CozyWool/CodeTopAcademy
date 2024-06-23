using System;
using System.Globalization;
using System.Windows.Controls;

namespace ValidationRuleFour.ValidationRules;

public class AgeRule : ValidationRule
{
    public int Min { get; set; }
    public int Max { get; set; }
    
    public override ValidationResult Validate(object value, CultureInfo cultureInfo)
    {
        int age;
        try
        {
            age = int.Parse(value.ToString());
        }
        catch (Exception e)
        {
            return new ValidationResult(false, $"Недопустимое значение {value} для возраста");
        }

        if (age < Min || age > Max)
        {
            return new ValidationResult(false, $"Значение возраста должно находиться в диапазоне от {Min} до {Max}");
        }

        return new ValidationResult(true, null);
    }
}