namespace MatrixLibrary;

/// <summary>Бизнес-логика варианта 12.</summary>
public static class MatrixAnalyzer
{
    public const int MaxSize = 10;

    /// <summary>Сумма всех элементов одной строки.</summary>
    public static long RowSum(int[] row)
    {
        ArgumentNullException.ThrowIfNull(row);
        long sum = 0;
        foreach (int value in row) sum += value;
        return sum;
    }

    /// <summary>Суммы элементов чётных строк (2, 4, 6, ...).</summary>
    public static long[] EvenRowSums(int[,] matrix)
    {
        ValidateMatrix(matrix);
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);
        var result = new long[rows / 2];

        for (int k = 0; k < result.Length; k++)
        {
            int rowIndex = 2 * k + 1;
            var row = new int[cols];
            for (int j = 0; j < cols; j++) row[j] = matrix[rowIndex, j];
            result[k] = RowSum(row);
        }

        return result;
    }

    /// <summary>Проверка на строго возрастающую последовательность.</summary>
    public static bool IsIncreasing(long[] sequence)
    {
        ArgumentNullException.ThrowIfNull(sequence);
        for (int i = 1; i < sequence.Length; i++)
            if (sequence[i] <= sequence[i - 1]) return false;
        return true;
    }

    public static bool CheckEvenRowsIncreasing(int[,] matrix)
        => IsIncreasing(EvenRowSums(matrix));

    private static void ValidateMatrix(int[,] matrix)
    {
        ArgumentNullException.ThrowIfNull(matrix);
        int rows = matrix.GetLength(0);
        int columns = matrix.GetLength(1);
        if (rows is < 1 or > MaxSize || columns is < 1 or > MaxSize)
            throw new ArgumentException($"Размер матрицы должен быть от 1x1 до {MaxSize}x{MaxSize}.", nameof(matrix));
    }
}
