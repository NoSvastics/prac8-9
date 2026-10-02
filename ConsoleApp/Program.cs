using MatrixLibrary;

Logger.Info("Приложение запущено");
Console.WriteLine("Практическая работа №8-9 | Вариант 12");
Console.WriteLine("Проверка сумм элементов чётных строк двух матриц.\n");

while (true)
{
    Console.WriteLine("Меню:");
    Console.WriteLine("1 — Ввести две матрицы вручную");
    Console.WriteLine("2 — Использовать демонстрационные матрицы A и B");
    Console.WriteLine("3 — Запустить тесты");
    Console.WriteLine("0 — Выход");
    Console.Write("Выбор: ");

    switch (Console.ReadLine()?.Trim())
    {
        case "1":
            Process(InputValidator.ReadMatrix("A"), InputValidator.ReadMatrix("B"));
            break;
        case "2":
            Process(MatrixA.Create(), MatrixB.Create());
            break;
        case "3":
            Environment.ExitCode = TestRunner.RunAll();
            break;
        case "0":
            Logger.Info("Приложение завершено");
            return;
        default:
            Console.WriteLine("Нет такого пункта меню.\n");
            break;
    }
}

static void Process(int[,] matrixA, int[,] matrixB)
{
    PrintResult(matrixA, "A");
    PrintResult(matrixB, "B");
    Logger.Info("Выполнен анализ обеих матриц");
}

static void PrintResult(int[,] matrix, string name)
{
    Console.WriteLine($"\nМатрица {name}:");
    MatrixPrinter.Print(matrix);
    long[] sums = MatrixAnalyzer.EvenRowSums(matrix);
    Console.WriteLine(sums.Length == 0
        ? "Чётных строк нет; условие выполняется."
        : $"Суммы чётных строк: {string.Join(" < ", sums)}");
    Console.WriteLine(MatrixAnalyzer.CheckEvenRowsIncreasing(matrix)
        ? $"Матрица {name}: условие выполняется."
        : $"Матрица {name}: условие НЕ выполняется.");
}
