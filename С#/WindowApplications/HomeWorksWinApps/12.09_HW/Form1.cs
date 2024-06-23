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
        string resume = @"������� ���������, 16 ���
���� ������:
���� ��� ���.

�����������:
�������� ����� �����������(2014 - 2023)

������:
����� ����������������: C++, C#, Python
���� ������ � ��������� �������� ������, ������ ��� Git
���������� ������������ �����������

����������:
������� Unity/Unreal Engine 4
���������� �� C++, C#

������ ��������:
������� ������� ������ ���
���������� � ������������ � �������� ����� ����������";

        int numMessageBoxes = 3;
        int averageCharsPerPage = resume.Length / numMessageBoxes;

        List<string> resumeChunks = SplitString(resume, averageCharsPerPage, numMessageBoxes);

        for (int i = 0; i < numMessageBoxes - 1; i++)
        {
            MessageBox.Show(resumeChunks[i], "������");
        }

        MessageBox.Show(resumeChunks[^1], "������ (������� ��������: " + averageCharsPerPage + ")");

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
                chunks[^1] += " " + currentChunk; // ^1 - ��������� ������� � �������
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

            DialogResult startGameDialogResult = MessageBox.Show("��������� ����� �� 1 �� 2000\n(��� ������ ������� \"������\")",
                                                            "������ �����",
                                                            MessageBoxButtons.OKCancel,
                                                            MessageBoxIcon.Information);
            if (startGameDialogResult == DialogResult.Cancel)
            {
                break;
            }

            while (right - left > 1)
            {
                int middle = (left + right) / 2;


                DialogResult AskDialogResult = MessageBox.Show($"���� ����� ������ {middle}?",
                                                    "������ �����",
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

            if (right != 2000) // ���� ���������� ����� = 2000, �� right �� ���������, ������ ��������� �� �����
                right--;

            string messageAfterGame = $"� ��������� ���������� ������� ����� �� {guessCount} �������!";
            DialogResult WinDialogResult = MessageBox.Show($"���� ����� {right}?",
                                                            "������ �����",
                                                            MessageBoxButtons.YesNo,
                                                            MessageBoxIcon.Information);
            if (WinDialogResult == DialogResult.No)
            {
                messageAfterGame = $"� ��������� �� ���������� ������� ����� �� {guessCount} �������..."; // ������ ���� �� ������, �� �����)
            }

            DialogResult playAgainDialogResult = MessageBox.Show($"{messageAfterGame}\n������ ������� ��� ���?",
                                                                       "������ �����",
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
