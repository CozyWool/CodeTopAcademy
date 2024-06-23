using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace MorseCode
{
    public static class MorseCodeTranslator
    {
        private static List<char> russianCharacters = new() { 'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ж', 'З', 'И',
                                                        'Й', 'К', 'Л', 'М', 'Н', 'О', 'П', 'Р', 'С',
                                                        'Т', 'У', 'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Ы', 'Ь',
                                                        'Э', 'Ю', 'Я', '1', '2', '3', '4', '5', '6', '7',
                                                        '8', '9', '0','.',',','?','\'','!','/','(',')',
                                                        '&',':',';','=','+','-','_','"','$','@'};

        private static List<string> russianCodeMorse = new() { ".-", "-...", ".--", "--.",
                                                        "-..", ".", "...-", "--..",
                                                        "..", ".---", "-.-", ".-..",
                                                        "--", "-.", "---", ".--.",
                                                        ".-.", "...", "-", "..-",
                                                        "..-.", "....", "-.-.",
                                                        "---.", "----", "--.-",
                                                        "-.--", "-..-", "..-..",
                                                        "..--", ".-.-", ".----",
                                                        "..---", "...--", "....-",
                                                        ".....", "-....", "--...",
                                                        "---..", "----.", "-----",
                                                        ".-.-.-","--..--","..--..",".----.","-.-.--",
                                                        "-..-.","-.--.", "-.--.-",".-...",
                                                        "---...","-.-.-.","-...-",".-.-.","-....-",
                                                        "..--.-",".-..-.","...-..-",".--.-."};

        private static List<char> englishCharacters = new() { 'A','B','C','D','E','F','G','H',
                                                        'I','J','K','L','M','N','O','P','Q','R','S','T','U',
                                                        'V','W','X','Y','Z','1', '2', '3', '4', '5', '6', '7',
                                                        '8', '9', '0','.',',','?','\'','!','/','(',')',
                                                        '&',':',';','=','+','-','_','"','$','@'};

        private static List<string> englishCodeMorse = new() { ".-","-...","-.-.","-..",".","..-.",
                                                        "--.","....","..",".---","-.-",".-..",
                                                        "--","-.","---",".--.","--.-",".-.","...","-",
                                                        "..-","...-",".--","-..-","-.--","--..",".----",
                                                        "..---", "...--", "....-",
                                                        ".....", "-....", "--...",
                                                        "---..", "----.", "-----",
                                                        ".-.-.-","--..--","..--..",".----.","-.-.--",
                                                        "-..-.","-.--.", "-.--.-",".-...",
                                                        "---...","-.-.-.","-...-",".-.-.","-....-",
                                                        "..--.-",".-..-.","...-..-",".--.-."};

        //Сделал разделение букв и слов для однозначной расшифровки,
        //иначе было при ...---...(СОС) можно было бы расшифровать как ЕЕЕТТТЕЕЕ
        public static string TranslateToMorse(string? text, bool isRussian)
        {
            List<char> chars = isRussian ? russianCharacters : englishCharacters;
            List<string> morses = isRussian ? russianCodeMorse : englishCodeMorse;

            StringBuilder sb = new();
            for (int i = 0; i < text.Length - 1; i++)
            {
                if (text[i] == ' ')
                    continue;

                char s = char.ToUpper(text[i]);
                sb.Append($"{morses[chars.IndexOf(s)]} "); // Отделяем буквы одним пробелом
                if (text[i + 1] == ' ') // если слово закончилось, то отделить двумя пробелами
                    sb.Append(" ");
            }
            char lastChar = char.ToUpper(text[text.Length - 1]);
            sb.Append(morses[chars.IndexOf(lastChar)]); // Последний символ
            return sb.ToString();
        }

        //Сделал разделение букв и слов для однозначной расшифровки,
        //иначе было при ...---...(СОС) можно было бы расшифровать как ЕЕЕТТТЕЕЕ
        public static string TranslateToText(string? morseText, bool isRussian)
        {
            List<char> chars = isRussian ? russianCharacters : englishCharacters;
            List<string> morses = isRussian ? russianCodeMorse : englishCodeMorse;

            int length = morseText.Length;
            StringBuilder sb = new();
            StringBuilder morseLetter = new(); // В нем будет собираться буква

            for (int i = 0; i < length - 2; i++)
            {
                if (morseText[i] == ' ')
                    continue;
                morseLetter.Append(morseText[i]);
                if (morseText[i + 1] == ' ') // Следующий символ пробел = буква кончилась
                {
                    sb.Append($"{chars[morses.IndexOf(morseLetter.ToString())]}");
                    morseLetter.Clear();

                    if (morseText[i + 2] == ' ') // Следующие символы два пробела = слово кончилось
                        sb.Append(" ");
                }
            }

            string lastLetter = morseLetter.ToString() + (morseText[length - 2].ToString() == " " ? "" : morseText[length - 2].ToString()) + (morseText[length - 1].ToString() == " " ? "" : morseText[length - 1].ToString());

            sb.Append($"{chars[morses.IndexOf(lastLetter)]}");

            return sb.ToString();
        }

        public static void MakeFormattedList(bool Morse) // чтобы из таблицы из интернета перевести в формат массива
        {
            using StreamReader sr = new("Morse.txt", Encoding.UTF8);
            using StreamWriter sw = new("MorseFormatted.txt");
            while (!sr.EndOfStream)
            {
                if (Morse)
                {
                    sr.ReadLine();
                    sw.Write($"\"{sr.ReadLine()}\",");
                }
                else
                {
                    sw.Write($"\"{sr.ReadLine()}\",");
                    sr.ReadLine();
                }
            }
        }
    }
}
