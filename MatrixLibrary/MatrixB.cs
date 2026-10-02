namespace MatrixLibrary;

/// <summary>Демонстрационная матрица B. Автор: ветка collaborator.</summary>
public static class MatrixB
{
    public static int[,] Create() => new int[,]
    {
        { 5, 5 },
        { 3, 2 },          // 5
        { 7, 7 },
        { 1, 1 }           // 2 => 5 < 2 — ложь
    };
}
