using Microsoft.VisualBasic;

namespace Tumakov
{

    class Program
    {
        static (uint, uint) Task1(string filePath)
        {
            string vowels = "aeiouyаеиоуыэюя";
            string consonants = "bcdfghjklmnpqrstvwxzбвгджзйклмнпрстфхцчшщ";
            string textParse = File.ReadAllText(filePath).ToLower();
            uint vowelCount = 0;
            uint consonantCount = 0;

            foreach (char c in textParse)
            {
                if (vowels.Contains(c))
                {
                    vowelCount++;
                }
                else if (consonants.Contains(c))
                {
                    consonantCount++;
                }
            }
            Console.WriteLine($"Количество гласных в тексте: {vowelCount} \nКоличество согласных: {consonantCount}");
            return (vowelCount, consonantCount);
        }

        static (uint, uint) Task1(char[] inputText)
        {
            string vowels = "aeiouyаеиоуыэюя";
            string consonants = "bcdfghjklmnpqrstvwxzбвгджзйклмнпрстфхцчшщ";
            uint vowelCount = 0;
            uint consonantCount = 0;
            foreach (char c in inputText)
            {
                if (vowels.Contains(c))
                {
                    vowelCount++;
                }
                else if (consonants.Contains(c))
                {
                    consonantCount++;
                }
            }
            Console.WriteLine($"Количество гласных в тексте: {vowelCount} \nКоличество согласных: {consonantCount}");
            return (vowelCount, consonantCount);
        }

        static void Task2()
        {
            Console.Write("Введите размер матриц: ");
            int size = int.TryParse(Console.ReadLine(), out int s) ? s : 2;
            int[,] matrix1 = new int[size, size];
            int[,] matrix2 = new int[size, size];
            int[,] resultMatrix = new int[size, size];

            Random rand = new Random();
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    matrix1[i, j] = rand.Next(-100, 101);
                    matrix2[i, j] = rand.Next(-100, 101);
                }
            }
            Console.WriteLine("\nМатрица 1:");
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write($"{matrix1[i, j],5} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("\nМатрица 2:");
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write($"{matrix2[i, j],5} ");
                }
                Console.WriteLine();
            }

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    resultMatrix[i, j] = 0;
                    for (int k = 0; k < size; k++)
                    {
                        resultMatrix[i, j] += matrix1[i, k] * matrix2[k, j];
                    }
                }
            }

            Console.WriteLine("\nРезультат умножения матриц:");
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write($"{resultMatrix[i, j],5} ");
                }
                Console.WriteLine();
            }
        }

        static int[] Task3()
        {
            int[,] tempArray = new int[12, 30];
            Random rand = new Random();
            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < 30; j++)
                {
                    if (3 <= i && i <= 9)
                    {
                        tempArray[i, j] = rand.Next(10, 31);
                    }
                    else if ((0 <= i && i < 2) || i == 11)
                    {
                        tempArray[i, j] = rand.Next(-20, -5);
                    }
                    else
                    {
                        tempArray[i, j] = rand.Next(-10, 10);
                    }
                }
            }

            int[] midTemp = new int[12];
            for (int i = 0; i < 12; i++)
            {
                int temperature = 0;
                for (int j = 0; j < 30; j++)
                {
                    temperature += tempArray[i, j];
                }
                midTemp[i] = temperature / 30;
                Console.WriteLine($"Средняя температура за {(Months)i}: {midTemp[i]}");
            }
            Array.Sort(midTemp);
            return midTemp;
        }

        static (uint, uint) HomeTask1(string filePath)
        {
            List<char> charArray = new List<char>();
            charArray.AddRange(File.ReadAllText(filePath).ToLower());
            string vowels = "aeiouyаеиоуыэюя";
            string consonants = "bcdfghjklmnpqrstvwxzбвгджзйклмнпрстфхцчшщ";
            uint vowelCount = 0;
            uint consonantCount = 0;

            foreach (char c in charArray)
            {
                if (vowels.Contains(c))
                {
                    vowelCount++;
                }
                else if (consonants.Contains(c))
                {
                    consonantCount++;
                }
            }
            Console.WriteLine($"Количество гласных в тексте: {vowelCount} \nКоличество согласных: {consonantCount}");
            return (vowelCount, consonantCount);
        }

        static void HomeTask2()
        {
            Console.Write("Введите размер матриц: ");
            int size = int.TryParse(Console.ReadLine(), out int s) ? s : 3;
            LinkedList<LinkedList<int>> matrix1 = new LinkedList<LinkedList<int>>();
            LinkedList<LinkedList<int>> matrix2 = new LinkedList<LinkedList<int>>();
            LinkedList<LinkedList<int>> resultMatrix = new LinkedList<LinkedList<int>>();

            Random rand = new Random();
            for (int i = 0; i < size; i++)
            {
                var row1 = new LinkedList<int>();
                var row2 = new LinkedList<int>();
                for (int j = 0; j < size; j++)
                {
                    row1.AddLast(rand.Next(-100, 101));
                    row2.AddLast(rand.Next(-100, 101));
                }
                matrix1.AddLast(row1);
                matrix2.AddLast(row2);
            }

            Console.WriteLine("\nМатрица 1:");
            foreach (LinkedList<int> row in matrix1)
            {
                foreach (int value in row)
                {
                    Console.Write($"{value,5} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("\nМатрица 2:");
            foreach (LinkedList<int> row in matrix2)
            {
                foreach (int value in row)
                {
                    Console.Write($"{value,5} ");
                }
                Console.WriteLine();
            }

            for (int i = 0; i < size; i++)
            {
                var resultRow = new LinkedList<int>();

                for (int j = 0; j < size; j++)
                {
                    int sum = 0;
                    for (int k = 0; k < size; k++)
                    {
                        int val1 = matrix1.ElementAt(i).ElementAt(k);
                        int val2 = matrix2.ElementAt(k).ElementAt(j);

                        sum += val1 * val2;
                    }
                    resultRow.AddLast(sum);
                }
                resultMatrix.AddLast(resultRow);
            }
            Console.WriteLine("\nРезультат умножения матриц:");
            foreach (LinkedList<int> row in resultMatrix)
            {
                foreach (int value in row)
                {
                    Console.Write($"{value,5} ");
                }
                Console.WriteLine();
            }
            return;
        }

        static int[] HomeTask3()
        {
            Dictionary<Months, int[]> tempArray = new Dictionary<Months, int[]>();
            Random rand = new Random();
            for (int i = 0; i < 12; i++)
            {
                int[] tempDays = new int[30];
                for (int j = 0; j < 30; j++)
                {
                    if (3 <= i && i <= 9)
                    {
                        tempDays[j] = rand.Next(10, 31);
                    }
                    else if ((0 <= i && i < 2) || i == 11)
                    {
                        tempDays[j] = rand.Next(-20, -5);
                    }
                    else
                    {
                        tempDays[j] = rand.Next(-10, 10);
                    }
                }
                tempArray.Add((Months)i, tempDays);
            }
            int[] midTemp = new int[12];
            for (int i = 0; i < 12; i++)
            {
                int temperature = 0;
                for (int j = 0; j < 30; j++)
                {
                    temperature += tempArray.TryGetValue((Months)i, out int[] days) ? days[j] : 0;
                }
                midTemp[i] = temperature / 30;
                Console.WriteLine($"Средняя температура за {(Months)i}: {midTemp[i]}");
            }
            Array.Sort(midTemp);
            return midTemp;
        }

        static void Main(string[] args)
        {
            string filePath = args[0];
            bool isRunning = true;
            while (isRunning)
            {
                Console.Write("Выберите задачу для выполнения (от 1 до 6) или введите 0 для выхода:");
                string inputTaskNum = Console.ReadLine();
                switch (inputTaskNum)
                {
                    case "0":
                        Environment.Exit(0);
                        break;
                    case "1":
                        Task1(filePath);
                        break;
                    case "2":
                        Task2();
                        break;
                    case "3":
                        Task3();
                        break;
                    case "4":
                        HomeTask1(filePath);
                        break;
                    case "5":
                        HomeTask2();
                        break;
                    case "6":
                        HomeTask3();
                        break;
                    default:
                        Console.WriteLine("Неверный номер задачи. Пожалуйста, введите значение от 1 до 6.");
                        break;
                }
            }
        }
    }
}