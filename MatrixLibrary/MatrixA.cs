namespace MatrixLibrary;

/// <summary>Демонстрационная матрица A. Автор: ветка student1.</summary>
public static class MatrixA
{
    public static int[,] Create() => new int[,]
    {
        { 1, 2, 3 },
        { 4, 5, 6 },       // 15
        { 1, 1, 1 },
        { 10, 20, 30 }     // 60 => 15 < 60
    };
}
