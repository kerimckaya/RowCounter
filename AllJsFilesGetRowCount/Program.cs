using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Dosya Uzantı : ");
        string targeteExtension= Console.ReadLine() ?? ""; // Aramak istediğiniz dizinin yolu
        Console.Write("PageJs Yolu : ");

        string targetDirectory = Console.ReadLine() ?? ""; // Aramak istediğiniz dizinin yolu

        long totalLineCount = CountLinesInJsFiles(targetDirectory,targeteExtension);

        Console.WriteLine($"Toplam satır sayısı: {totalLineCount}");
        var key =  Console.ReadLine();
        if (key=="r")
        {
            Process.Start(Environment.ProcessPath);
            Environment.Exit(0);
        }
    }

    static long CountLinesInJsFiles(string directoryPath,string dosyaUzanti)
    {
        long totalLineCount = 0;

        // Belirtilen dizin ve altındaki tüm verdiğiniz dosya uzantısına ait  dosyalarını alır
        var jsFiles = Directory.GetFiles(directoryPath, "*."+dosyaUzanti, SearchOption.AllDirectories);

        foreach (var jsFile in jsFiles)
        {
            int fileLineCount = File.ReadLines(jsFile).Count();
            totalLineCount += fileLineCount;
            Console.WriteLine($"{jsFile}: {fileLineCount} satır");
        }

        return totalLineCount;
    }
}