using System.ComponentModel.DataAnnotations;

namespace DelegateBasicExample;

class Program
{
    delegate void LogDel(string text);
    static void Main(string[] args)
    {
        LogDel logDel = new LogDel(LogTextToScreen);
        
        System.Console.WriteLine("Please Enter your name");
        string name = Console.ReadLine()!;
        
        logDel(name);
    }

    static void LogTextToScreen(string text) 
    {
        Console.WriteLine($"{DateTime.Now}: {text}");
    }
}
