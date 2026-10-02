using MatrixLibrary;

namespace ConsoleApp;

public static class TestRunner
{
    public static int RunAll()
    {
        var tests = new (string Name, Func<bool> Test)[]
        {
            ("RowSum", () => MatrixAnalyzer.RowSum(new[] { 1, -2, 5 }) == 4),
            ("MatrixA", () => MatrixAnalyzer.CheckEvenRowsIncreasing(MatrixA.Create())),
            ("MatrixB", () => !MatrixAnalyzer.CheckEvenRowsIncreasing(MatrixB.Create())),
            ("EvenRowSumsA", () => MatrixAnalyzer.EvenRowSums(MatrixA.Create()).SequenceEqual(new long[] { 15, 60 })),
            ("EvenRowSumsB", () => MatrixAnalyzer.EvenRowSums(MatrixB.Create()).SequenceEqual(new long[] { 5, 2 })),
            ("EqualIsNotIncreasing", () => !MatrixAnalyzer.IsIncreasing(new long[] { 1, 1, 2 })),
            ("DecreasingIsNotIncreasing", () => !MatrixAnalyzer.IsIncreasing(new long[] { 5, 2 })),
            ("SingleRowMatrix", () => MatrixAnalyzer.CheckEvenRowsIncreasing(new int[,] { { 1, 2, 3 } }))
        };

        int failed = 0;
        Console.WriteLine("\nМодульные тесты:");
        foreach (var (name, test) in tests)
        {
            bool passed;
            try { passed = test(); }
            catch { passed = false; }
            Console.WriteLine($"[{(passed ? "PASS" : "FAIL")}] {name}");
            if (!passed) failed++;
        }
        Console.WriteLine($"Итог: {tests.Length - failed} PASS, {failed} FAIL.");
        return failed == 0 ? 0 : 1;
    }
}
