using System.ComponentModel.DataAnnotations;

namespace DelegateBasicExample;

class Program
{
    delegate void LogDel(string text);
    static void Main(string[] args)
    {
        Log log = new Log();
        LogDel logTextToScreenDel, logTextToFileDel;
        
        logTextToScreenDel = new LogDel(log.LogTextToScreen);
        logTextToFileDel = new LogDel(log.LogTextToFile);
        
        // Multicast Delegates
        LogDel multiLogDel = logTextToScreenDel + logTextToFileDel;

        Console.WriteLine("Please Enter your name");
        string name = Console.ReadLine()!;

        // implementing delegate passed as a parameterc
        LogText(multiLogDel, name);
    }

    // delegate passed as a functional parameter
    static void LogText (LogDel logDel, string text)
    {
        logDel(text);
    }
}

public class Log
{
    public void LogTextToScreen(string text) 
    {
        Console.WriteLine($"{DateTime.Now}: {text}");
    }

    public void LogTextToFile(string text)
    {
        using (StreamWriter sw = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Log.txt"), true))
        {
            sw.WriteLine($"{DateTime.Now}: {text}");
        }

        Console.WriteLine("Written on log file.");
    }
}
