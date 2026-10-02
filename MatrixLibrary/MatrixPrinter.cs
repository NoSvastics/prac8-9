namespace MatrixLibrary;

public static class MatrixPrinter
{
    public static void Print(int[,] matrix)
    {
        ArgumentNullException.ThrowIfNull(matrix);
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
                Console.Write($"{matrix[i, j],6}");
            Console.WriteLine();
        }
    }
}
