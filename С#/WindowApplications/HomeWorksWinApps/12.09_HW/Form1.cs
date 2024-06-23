using System.Diagnostics.Eventing.Reader;

namespace _12._09_HW;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void Task1Button_Click(object sender, EventArgs e)
    {
        string resume = @"Сергеев Владислав, 16 лет
Опыт работы:
Пока что нет.

Образование:
Основное общее образование(2014 - 2023)

Навыки:
Языки программирования: C++, C#, Python
Опыт работы с системами контроля версий, такими как Git
Разработка программного обеспечения

Достижения:
Немного Unity/Unreal Engine 4
Приложения на C++, C#

Личные качества:
Желание сделать чистый код
Стремление к саморазвитию и изучению новых технологий";

        int numMessageBoxes = 3;
        int averageCharsPerPage = resume.Length / numMessageBoxes;

        List<string> resumeChunks = SplitString(resume, averageCharsPerPage, numMessageBoxes);

        for (int i = 0; i < numMessageBoxes - 1; i++)
        {
            MessageBox.Show(resumeChunks[i], "Резюме");
        }

        MessageBox.Show(resumeChunks[^1], "Резюме (среднее символов: " + averageCharsPerPage + ")");

        static List<string> SplitString(string str, int chunkSize, int chunkCount)
        {
            string[] words = str.Split(' ');
            List<string> chunks = new List<string>();
            string currentChunk = "";

            foreach (string word in words)
            {
                if (currentChunk == "")
                {
                    currentChunk = word;
                }
                else if ((currentChunk + " " + word).Length <= chunkSize)
                {
                    currentChunk += " " + word;
                }
                else
                {
                    chunks.Add(currentChunk);
                    currentChunk = word;
                }
            }

            if (chunks.Count < chunkCount)
            {
                chunks.Add(currentChunk);
            }
            else
            {
                chunks[^1] += " " + currentChunk; // ^1 - последний элемент в массиве
            }

            return chunks;
        }
    }
    private void Task2Button_Click(object sender, EventArgs e)
    {
        bool playAgain = true;

        while (playAgain)
        {
            int guessCount = 0;
            int left = 1;
            int right = 2000;

            DialogResult startGameDialogResult = MessageBox.Show("Загадайте число от 1 до 2000\n(Для выхода нажмите \"Отмена\")",
                                                            "Угадай число",
                                                            MessageBoxButtons.OKCancel,
                                                            MessageBoxIcon.Information);
            if (startGameDialogResult == DialogResult.Cancel)
            {
                break;
            }

            while (right - left > 1)
            {
                int middle = (left + right) / 2;


                DialogResult AskDialogResult = MessageBox.Show($"Ваше число меньше {middle}?",
                                                    "Угадай число",
                                                    MessageBoxButtons.YesNo,
                                                    MessageBoxIcon.Question);
                if (AskDialogResult == DialogResult.Yes)
                {
                    right = middle;
                }
                else
                {
                    left = middle;
                }
                guessCount++;
            }

            if (right != 2000) // Если загаданное число = 2000, то right не сдвинется, значит уменьшать не нужно
                right--;

            string messageAfterGame = $"У программы получилось угадать число за {guessCount} попыток!";
            DialogResult WinDialogResult = MessageBox.Show($"Ваше число {right}?",
                                                            "Угадай число",
                                                            MessageBoxButtons.YesNo,
                                                            MessageBoxIcon.Information);
            if (WinDialogResult == DialogResult.No)
            {
                messageAfterGame = $"У программы не получилось угадать число за {guessCount} попыток..."; // Такого быть не должно, но вдруг)
            }

            DialogResult playAgainDialogResult = MessageBox.Show($"{messageAfterGame}\nХотите сыграть еще раз?",
                                                                       "Угадай число",
                                                                       MessageBoxButtons.YesNo,
                                                                       MessageBoxIcon.Question);
            if (playAgainDialogResult == DialogResult.No)
                playAgain = false;
        }
    }

    private void Task3Button_Click(object sender, EventArgs e)
    {
        var form = new Task3Form();
        form.Show();
    }
}
