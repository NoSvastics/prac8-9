using MatrixLibrary;

namespace ConsoleApp;

/// <summary>Проверка и безопасный ввод пользовательских данных.</summary>
public static class InputValidator
{
    public static int[,] ReadMatrix(string name)
    {
        Console.WriteLine($"\nВвод матрицы {name}");

        int rows = ReadInt($"Количество строк (1-{MatrixAnalyzer.MaxSize}): ", 1, MatrixAnalyzer.MaxSize);
        int columns = ReadInt($"Количество столбцов (1-{MatrixAnalyzer.MaxSize}): ", 1, MatrixAnalyzer.MaxSize);
        var matrix = new int[rows, columns];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
                matrix[i, j] = ReadInt($"Элемент [{i + 1},{j + 1}]: ");
        }

        return matrix;
    }

    public static int ReadInt(string prompt, int? min = null, int? max = null)
    {
        while (true)
        {
            Console.Write(prompt);

            if (int.TryParse(Console.ReadLine(), out int value)
                && (!min.HasValue || value >= min.Value)
                && (!max.HasValue || value <= max.Value))
            {
                return value;
            }

            Console.WriteLine("Ошибка: введите корректное целое число в допустимом диапазоне.");
        }
    }
}
