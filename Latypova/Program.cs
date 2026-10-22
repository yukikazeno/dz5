namespace Latypova
{
    class Program
    {
        static void Task1()
        {
            string folderPath = @"..\..\..\Latypova Files\Images for task1";
            List<string> imageFiles = new List<string>(Directory.GetFiles(folderPath, "*.jpg"));
           
            List<string> originalList = new List<string>();
            for (int i = 0; i < imageFiles.Count; i++)
            {
                originalList.Add(Path.GetFileName(imageFiles[i]));
                originalList.Add(Path.GetFileName(imageFiles[i]));
            }
            Console.WriteLine("Изначальный список:");
            Console.WriteLine(string.Join(", ", originalList));


            List<string> shuffledList = originalList;
            Random rand = new Random();
            for (int i = shuffledList.Count - 1; i > 0; i--)
            {
                int j = rand.Next(i + 1);
                string temp = shuffledList[i];
                shuffledList[i] = shuffledList[j];
                shuffledList[j] = temp;
            }

            Console.WriteLine("\nПеремешанный спсок:");
            Console.WriteLine(string.Join(", ", shuffledList));
        }
        static void Task2(string inputStudents)
        {
            Dictionary<string, StudentStruct> studentDict = new Dictionary<string, StudentStruct>();

            string[] lines = File.ReadAllLines(inputStudents);
            foreach (string line in lines)
            {
                string[] parts = line.Split(';');
                if (parts.Length == 5)
                {
                    string lastName = parts[0].Trim();
                    string firstName = parts[1].Trim();
                    int birthYear = int.Parse(parts[2].Trim());
                    string examName = parts[3].Trim();
                    int score = int.Parse(parts[4].Trim());

                    StudentStruct student = new StudentStruct(lastName, firstName, birthYear, examName, score);
                    string key = $"{lastName} {firstName}";

                    if (!studentDict.ContainsKey(key))
                    {
                        studentDict.Add(key, student);
                    }
                }
            }
            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("Доступные команды: [Новый студент], [Удалить], [Сортировать], [Выход]");
                Console.Write("Введите команду: ");
                string command = Console.ReadLine().Trim();

                switch (command)
                {
                    case "Новый студент":
                        Console.Write("Введите фамилию: ");
                        string lName = Console.ReadLine();
                        Console.Write("Введите имя: ");
                        string fName = Console.ReadLine();
                        Console.Write("Введите год рождения: ");
                        int year = int.TryParse(Console.ReadLine(), out int y) ? y : 0;
                        Console.Write("Введите вступительный экзамен: ");
                        string exam = Console.ReadLine();
                        Console.Write("Введите баллы: ");
                        int points = int.TryParse(Console.ReadLine(), out int p) ? p : 0;

                        StudentStruct newStudent = new StudentStruct(lName, fName, year, exam, points);
                        string newKey = $"{lName} {fName}";

                        if (!studentDict.ContainsKey(newKey))
                        {
                            studentDict.Add(newKey, newStudent);
                            Console.WriteLine("Студент успешно добавлен.");
                        }
                        else
                        {
                            Console.WriteLine("Такой студент уже есть в базе данных!");
                        }
                        break;

                    case "Удалить":
                        Console.Write("Введите фамилию удаляемого студента: ");
                        string deleteLName = Console.ReadLine().Trim();
                        Console.Write("Введите имя удаляемого студента: ");
                        string deleteFName = Console.ReadLine().Trim();

                        string searchKey = $"{deleteLName} {deleteFName}";

                        if (studentDict.Remove(searchKey))
                        {
                            Console.WriteLine($"Студент {searchKey} успешно удален.");
                        }
                        else
                        {
                            Console.WriteLine("Студент с такими данными не найден.");
                        }
                        break;

                    case "Сортировать":
                        Console.WriteLine("\nСписок студентов, отсортированный по баллам:");
                        List<StudentStruct> sortedStudents = studentDict.Values.OrderBy(s =>s.Score).ToList();

                        foreach (var student in sortedStudents)
                        {
                            Console.WriteLine(student);
                        }
                        break;

                    case "Выход":
                        isRunning = false;
                        break;

                    default:
                        Console.WriteLine("Неизвестная команда. Проверьте правильность написания (учитывайте регистр букв).");
                        break;
                }
            }
        }

        static void Task3()
        {
            Stack<HospitalStruct> hospitalStack = new Stack<HospitalStruct>();
            hospitalStack.Push(new HospitalStruct("Центральная клиника", 2, new[]{ "Грипп", "Радикулит", "Давление" }));
            hospitalStack.Push(new HospitalStruct("Городская больница No.2", 3, new[] { "Кашель", "Давление", "Артрит" }));
            hospitalStack.Push(new HospitalStruct("Частная клиника", 1, new[] { "Катаракта", "Мигрень" }));

            Queue<GrandmaStruct> grandmaQueue = new Queue<GrandmaStruct>();

            bool isInfoEnter = true;
            while (isInfoEnter)
            {
                Console.Write("\nВведите имя бабули (или '0' для выхода): ");
                string name = Console.ReadLine().Trim();
                if (name == "0" || string.IsNullOrEmpty(name)) break;

                Console.Write("Введите возраст: ");
                byte age = byte.TryParse(Console.ReadLine(), out byte a) ? a : (byte)75;

                Dictionary<string, string> grandmaDiseases = new Dictionary<string, string>();

                while (isInfoEnter)
                {
                    Console.Write("Введите болезнь (или Enter, если болезней нет): ");
                    string disease = Console.ReadLine().Trim();
                    if (string.IsNullOrEmpty(disease)) break;

                    Console.Write($"Какое лекарство она принимает от '{disease}'? ");
                    string medicine = Console.ReadLine().Trim();

                    if (!grandmaDiseases.ContainsKey(disease))
                    {
                        grandmaDiseases.Add(disease, medicine);
                    }
                }

                grandmaQueue.Enqueue(new GrandmaStruct(name, age, grandmaDiseases));
            }

            List<GrandmaStruct> cryingGrandmas = new List<GrandmaStruct>();

            while (grandmaQueue.Count > 0)
            {
                GrandmaStruct currentGrandma = grandmaQueue.Dequeue();
                bool accepted = false;

                foreach (HospitalStruct hospital in hospitalStack)
                {
                    if (hospital.Patients.Count >= hospital.Capacity)
                    {
                        continue;
                    }

                    if (currentGrandma.Diseases.Count == 0)
                    {
                        hospital.Patients.Add(currentGrandma);
                        accepted = true;
                        Console.WriteLine($"Бабуля {currentGrandma.Name} зашла спросить в '{hospital.Name}'");
                        break;
                    }

                    int matches = 0;
                    foreach (string disease in currentGrandma.Diseases.Keys)
                    {
                        if (hospital.TreatableDiseases.Contains(disease))
                        {
                            matches++;
                        }
                    }

                    double matchPercentage = (double)matches / currentGrandma.Diseases.Count * 100;

                    if (matchPercentage > 50)
                    {
                        hospital.Patients.Add(currentGrandma);
                        accepted = true;
                        Console.WriteLine($"Бабуля {currentGrandma.Name} госпитализирована в '{hospital.Name}' (лечат {matchPercentage:F0}% болезней)");
                        break;
                    }
                }

                if (!accepted)
                {
                    cryingGrandmas.Add(currentGrandma);
                    Console.WriteLine($"Бабуля {currentGrandma.Name} осталась плакать на улице...");
                }
            }

            foreach (HospitalStruct hospital in hospitalStack)
            {
                Console.WriteLine($"Больница: \"{hospital.Name}\"");
                Console.WriteLine($"Профиль: {string.Join(", ", hospital.TreatableDiseases)}");
                Console.WriteLine($"Заполненность: {hospital.Patients.Count} из {hospital.Capacity} чел. ({hospital.FullnessPercentage:F1}%)");
            }

            Console.WriteLine($"На улице плачут: {cryingGrandmas.Count} бабуль");
            foreach (var grandma in cryingGrandmas)
            {
                Console.WriteLine($"Бабуля {grandma.Name} ({grandma.Age} лет)");
            }
        }

        static void Task4()
        {
            Console.Write("Введите стартовую вершину: ");
            int start = int.TryParse(Console.ReadLine(), out int s) ? s : 0;
            Console.Write("Введите конечную вершину: ");
            int end = int.TryParse(Console.ReadLine(), out int e) ? e : 0;
            var adjacencyList = new Dictionary<int, List<int>>();

            void AddEdge(int src, int dest)
            {
                if (!adjacencyList.ContainsKey(src)) adjacencyList[src] = new List<int>();
                if (!adjacencyList.ContainsKey(dest)) adjacencyList[dest] = new List<int>();
                adjacencyList[src].Add(dest);
                adjacencyList[dest].Add(src);
            }

            AddEdge(0, 1);
            AddEdge(0, 2);
            AddEdge(1, 3);
            AddEdge(1, 4);
            AddEdge(2, 5);
            AddEdge(2, 6);

            if (!adjacencyList.ContainsKey(start) || !adjacencyList.ContainsKey(end))
            {
                Console.WriteLine("Стартовая или конечная вершина отсутствует в графе.");
                return;
            }

            Queue<int> queue = new Queue<int>();
            HashSet<int> visited = new HashSet<int>();
            Dictionary<int, int> parentMap = new Dictionary<int, int>();

            queue.Enqueue(start);
            visited.Add(start);
            bool isPathFound = false;

            while (queue.Count > 0)
            {
                int current = queue.Dequeue();

                if (current == end)
                {
                    isPathFound = true;
                    break;
                }

                foreach (int neighbor in adjacencyList[current])
                {
                    if (!visited.Contains(neighbor))
                    {
                        visited.Add(neighbor);
                        parentMap[neighbor] = current;
                        queue.Enqueue(neighbor);
                    }
                }
            }

            if (!isPathFound)
            {
                Console.WriteLine($"Пути между вершинами {start} и {end} не существует.");
            }
            else
            {
                List<int> path = new List<int>();
                int currentVertex = end;

                while (currentVertex != start)
                {
                    path.Add(currentVertex);
                    currentVertex = parentMap[currentVertex];
                }
                path.Add(start);
                path.Reverse();

                Console.WriteLine($"Кратчайший путь от {start} до {end}:");
                Console.WriteLine(string.Join(" -> ", path));
            }
        }

        static void Main(string[] args)
        {
            bool isRunning = true;
            while (isRunning)
            {
                string inputStudents = args[0];
                Console.Write("Выберите задачу для выполнения (от 1 до 4) или введите 0 для выхода:");
                string inputTaskNum = Console.ReadLine();
                switch (inputTaskNum)
                {
                    case "0":
                        Environment.Exit(0);
                        break;
                    case "1":
                        Task1();
                        break;
                    case "2":
                        Task2(inputStudents);
                        break;
                    case "3":
                        Task3();
                        break;
                    case "4":
                        Task4();
                        break;
                    default:
                        Console.WriteLine("Неверный номер задачи. Пожалуйста, введите значение от 1 до 4.");
                        break;
                }
            }
        }
    }
}
