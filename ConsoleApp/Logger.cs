namespace ConsoleApp;

/// <summary>Простейшее файловое логирование событий приложения.</summary>
public static class Logger
{
    private static readonly string LogDirectory = Path.Combine(AppContext.BaseDirectory, "logs");
    private static readonly string LogFile = Path.Combine(LogDirectory, "app.log");

    public static void Info(string message)
    {
        Directory.CreateDirectory(LogDirectory);
        File.AppendAllText(
            LogFile,
            $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {message}{Environment.NewLine}");
    }
}
