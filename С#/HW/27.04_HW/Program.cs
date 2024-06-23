using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _27._04_HW
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Введите номер задания(1 - 7, 0 - выход из программы): ");
                string t = Console.ReadLine();
                Console.Clear();
                switch (t)
                {
                    case "1":
                        FirstTask();
                        break;
                    case "2":
                        SecondTask();
                        break;
                    case "3":
                        ThirdTask();
                        break;
                    case "4":
                        FourthTask();
                        break;
                    case "5":
                        FifthTask();
                        break;
                    case "6":
                        SixthTask();
                        break;
                    case "7":
                        SeventhTask();
                        break;
                    case "0":
                        StopProgram();
                        return;
                    default:
                        break;
                }
            }
        }

        private static void FirstTask()
        {
            int[] A = new int[5];
            int[,] B = new int[3, 4];
            Console.Write("Введите 5 чисел массива A через пробел: ");
            string input = Console.ReadLine();
            while (input.Split().Length != 5) // Не знаю как сделать на буквы проверку, пытался через int.TryParse(), но не получается
            {
                Console.Clear();
                Console.WriteLine("Введите 5 чисел!");
                Console.Write("Введите 5 чисел массива A через пробел: ");
                input = Console.ReadLine();
            }
            A = input.Split().Select(int.Parse).ToArray();

            Random random = new Random();
            for (int i = 0; i < B.GetLength(0); i++)
                for (int j = 0; j < B.GetLength(1); j++)
                    B[i, j] = random.Next(-10, 10 + 1); // чтобы произведение не было таким большим

            int max = A[0];
            int min = A[0];
            int sum = A[0];
            int evenSumA = A[0];
            long product = A[0];
            for (int i = 1; i < A.Length; i++)
            {
                if (A[i] > max) max = A[i];
                if (A[i] < min) min = A[i];
                sum += A[i];
                product *= A[i];
                if (i % 2 == 0) evenSumA += A[i];
            }

            int oddColumnSumB = 0;
            for (int i = 0; i < B.GetLength(0); i++)
                for (int j = 0; j < B.GetLength(1); j++)
                {
                    if (B[i, j] > max) max = B[i, j];
                    if (B[i, j] < min) min = B[i, j];
                    sum += B[i, j];
                    product *= B[i, j];
                    if (j % 2 == 1) oddColumnSumB += B[i, j];
                }

            Console.WriteLine("Массив A:");
            for (int i = 0; i < A.Length; i++)
                Console.Write(A[i] + " ");
            Console.WriteLine();

            Console.WriteLine("Массив B:");
            for (int i = 0; i < B.GetLength(0); i++)
            {
                for (int j = 0; j < B.GetLength(1); j++)
                    Console.Write(B[i, j] + " ");
                Console.WriteLine();
            }

            Console.WriteLine($"Общий максимальный элемент: {max}");
            Console.WriteLine($"Общий минимальный элемент: {min}");
            Console.WriteLine($"Общая сумма элементов: {sum}");
            Console.WriteLine($"Общее произведение элементов: {product}");
            Console.WriteLine($"Сумма четных элементов массива A: {evenSumA}");
            Console.WriteLine($"Сумма элементов нечетных столбцов массива B: {oddColumnSumB}");
        }
        private static void SecondTask()
        {
            int[,] A = new int[5, 5];

            Random random = new Random();
            for (int i = 0; i < A.GetLength(0); i++)
                for (int j = 0; j < A.GetLength(1); j++)
                    A[i, j] = random.Next(-100, 100 + 1);

            int max = A[0, 0], min = A[0, 0], maxI = 0, maxJ = 0, minI = 0, minJ = 0;

            for (int i = 0; i < A.GetLength(0); i++)
                for (int j = 0; j < A.GetLength(1); j++)
                {
                    if (A[i, j] > max)
                    {
                        max = A[i, j];
                        maxI = i;
                        maxJ = j;
                    }
                    if (A[i, j] < min)
                    {
                        min = A[i, j];
                        minI = i;
                        minJ = j;
                    }
                }

            int sum = 0;
            int i1 = 0, i2 = 0, j1 = 0, j2 = 0;
            if (maxI == minI) // если на одной строке
            {
                for (int j = minJ; j <= maxJ; j++)
                    sum += A[maxI, j];
            }
            else if (minI < maxI)
            {
                i1 = minI; j1 = minJ;
                i2 = maxI; j2 = maxJ;
            }
            else
            {
                i1 = maxI; j1 = maxJ;
                i2 = minI; j2 = minJ;
            }

            if (i1 != i2 && i1 + 1 < A.GetLength(1))
            {
                for (int j = j1; j < A.GetLength(1); j++) // верхняя строка
                    sum += A[i1, j];

                for (int i = i1 + 1; i < i2; i++) // полные строки
                    for (int j = 0; j < A.GetLength(1); j++)
                        sum += A[i, j];


                for (int j = 0; j <= j2; j++) // нижняя строка
                    sum += A[i2, j];
            }


            Console.WriteLine("Массив A:");
            for (int i = 0; i < A.GetLength(0); i++)
            {
                for (int j = 0; j < A.GetLength(1); j++)
                    Console.Write(A[i, j] + " ");
                Console.WriteLine();
            }
            Console.WriteLine($"Максимальный элемент: {max}");
            Console.WriteLine($"Минимальный элемент: {min}");
            Console.WriteLine($"Сумма элементов: {sum}");
        }
        private static void ThirdTask()
        {
            Console.Write("Введите строку, которую необходимо зашифровать: ");
            string input = Console.ReadLine();

            Console.Write("Введите ключ: ");
            int step = int.Parse(Console.ReadLine());

            string encryptedString = Encrypt(input, step);
            string decryptedString = Decrypt(encryptedString, step);
            Console.WriteLine($"Зашифрованная строка: {encryptedString}");
            Console.WriteLine($"Расшифрованная строка: {decryptedString}");
        }
        private static void FourthTask()
        {
            Console.Write("Введите кол-во строк первой матрицы: ");
            int row1 = int.Parse(Console.ReadLine());
            Console.Write("Введите кол-во столбцов первой матрицы: ");
            int col1 = int.Parse(Console.ReadLine());
            int[][] A = CreateMatrix(row1, col1);

            Console.Write("\nВведите кол-во строк второй матрицы: ");
            int row2 = int.Parse(Console.ReadLine());
            Console.Write("Введите кол-во столбцов второй матрицы: ");
            int col2 = int.Parse(Console.ReadLine());
            int[][] B = CreateMatrix(row2, col2);



            bool flag = false;
            while (!flag)
            {
                Console.WriteLine("\n-----------------\n");
                Console.WriteLine("Матрица A: ");
                PrintMatrix(A);
                Console.WriteLine("\nМатрица B: ");
                PrintMatrix(B);

                Console.WriteLine("Что вы хотите сделать?");
                Console.WriteLine("1 - Умножить матрицу на число");
                Console.WriteLine("2 - Сложение матриц");
                Console.WriteLine("3 - Умножить матриц");
                Console.WriteLine("0 - Выйти");
                int t = int.Parse(Console.ReadLine());
                Console.Clear();
                switch (t)
                {
                    case 1:
                        Console.Write("Какую матрицу вы хотите умножить(A/B)?: ");
                        string answer = Console.ReadLine();
                        Console.Write("Введите число, на которое нужно умножить матрицу: ");
                        int number = int.Parse(Console.ReadLine());

                        if (answer == "A")
                        {
                            for (int i = 0; i < A.Length; i++)
                                for (int j = 0; j < A[i].Length; j++)
                                    A[i][j] *= number;
                            Console.WriteLine("Результат: ");
                            PrintMatrix(A);
                        }
                        else
                        {
                            for (int i = 0; i < B.Length; i++)
                                for (int j = 0; j < B[i].Length; j++)
                                    B[i][j] *= number;
                            Console.WriteLine("Результат: ");
                            PrintMatrix(B);
                        }
                        break;
                    case 2:
                        // https://ru.wikipedia.org/wiki/Сложение#Сложение_матриц
                        if (row1 != row2 || col1 != col2)
                        {
                            Console.WriteLine("Сложение невозможно из-за разных размеров матриц!");
                            break;
                        }

                        int[][] res = new int[row1][];
                        for (int i = 0; i < row1; i++)
                            res[i] = new int[col2];
                        

                        for (int i = 0; i < A.Length; i++)
                            for (int j = 0; j < A[i].Length; j++)
                                res[i][j] = A[i][j] + B[i][j];

                        Console.WriteLine("Результат: ");
                        PrintMatrix(res);
                        break;
                    case 3:
                        // https://ru.wikipedia.org/wiki/Умножение_матриц
                        if (col1 != row2)
                        {
                            Console.WriteLine("Умножение невозможно из-за размеров матриц!");
                            break;
                        }

                        int[][] result = new int[row1][];
                        for (int i = 0; i < row1; i++)
                            result[i] = new int[col2];

                        for (int i = 0; i < A.Length; i++)
                            for (int j = 0; j < B[0].Length; j++)
                                for (int k = 0; k < B.Length; k++)
                                    result[i][j] += A[i][k] * B[k][j];

                        Console.WriteLine("Результат: ");
                        PrintMatrix(result);
                        break;
                    case 0:
                        flag = true;
                        break;
                    default:
                        break;
                }
            }
        }
        private static void FifthTask()
        {
            Console.Write("Введите арифметическое выражение(строго в формате:число1 +/- число2): ");
            string[] expression = Console.ReadLine().Split();
            switch (expression[1])
            {
                case "+":
                    Console.WriteLine($"Результат: {int.Parse(expression[0]) + int.Parse(expression[2])}");
                    break;
                case "-":
                    Console.WriteLine($"Результат: {int.Parse(expression[0]) - int.Parse(expression[2])}");
                    break;
                default:
                    break;
            }
        }
        private static void SixthTask()
        {
            Console.Write("Введите текст: ");
            string text = Console.ReadLine();
            StringBuilder sb = new StringBuilder(text);
            sb[0] = char.ToUpper(sb[0]);
            for (int i = 0; i < text.Length - 2; i++)
                if (sb[i] == '.')
                    sb[i + 2] = char.ToUpper(sb[i + 2]);
            Console.WriteLine($"Отредактированный текст: {sb}");
        }
        private static void SeventhTask()
        {
            Console.WriteLine("\tВвод содержится в файле input.txt\n");
            List<List<string>> text = new List<List<string>>();

            var sr = new StreamReader("input.txt");
            while (!sr.EndOfStream)
            {
                text.Add(sr.ReadLine().Split().ToList());
            }

            Console.Write("\nВведите недопустимое слово: ");
            string banWord = Console.ReadLine();
            string replaceWord = "";
            for (int i = 0; i < banWord.Length; i++) // чтобы кол-во звездочек было равно кол-ву символов в недопустимом слове
                replaceWord += "*";

            int replaceCounter = 0;
            for (int i = 0; i < text.Count; i++)
                for (int j = 0; j < text[i].Count; j++)
                    if (text[i][j].Contains(banWord)) // с учётом регистра, потому что не разобрался, как поменять регистр конкретной части слова
                    {
                        text[i][j] = text[i][j].Replace(banWord, replaceWord);
                        replaceCounter++;
                    }

            Console.WriteLine("\n\tОтредактированный текст ");
            
            foreach (var sentence in text)
            {
                foreach (var word in sentence)
                    Console.Write(word + " ");

                Console.WriteLine();
            }

            Console.WriteLine($"\nСтатистика замен слова {banWord}: {replaceCounter} ");
        }
        private static void StopProgram()
        {
            Console.Clear();
            Console.WriteLine("\n\t\tДо свидания!\n");
            Console.ReadKey();
        }
        private static string CaesarCipher(string input, int step)
        {
            StringBuilder sb = new StringBuilder(input);
            for (int i = 0; i < sb.Length; i++)
                sb[i] = (char)(sb[i] + step);
            return sb.ToString();
        }
        private static string Encrypt(string input, int step)
        {
            return CaesarCipher(input, step);
        }
        private static string Decrypt(string input, int step)
        {
            return CaesarCipher(input, -step);
        }
        private static int[][] CreateMatrix(int row, int col)
        {
            int[][] matrix = new int[row][];
            for (int i = 0; i < row; i++)
                matrix[i] = new int[col];
            for (int i = 0;i < matrix.Length;i++)
            {
                Console.Write($"Введите {i + 1}-ую строку через пробел: ");
                matrix[i] = Console.ReadLine().Split().Select(int.Parse).ToArray();
            }
            return matrix;
        }
        private static void PrintMatrix(int[][] matrix)
        {
            for (int i = 0;i < matrix.Length;i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                    Console.Write(matrix[i][j] + " ");

                Console.WriteLine();
            }
        }
    }
}
