namespace LoggingMulticastExample;

public class Program
{
    private static void Main(string[] args)
    {
        Logger logger = new Logger("Log");
        Logger.Notify? notify = logger.LogToFile;

        notify += logger.LogToConsole;
        notify += logger.SendAlert;

        notify("Added logging");        
        notify -= logger.SendAlert; //Possible null reference assignment. shows this warning tell how to fix

        notify?.Invoke("removed Alerts");
    }
}

public class Logger
{
    public string messageInternal;
    public delegate void Notify(string message);
    public Logger(string messageGot)
    {
        this.messageInternal = messageGot;
    }

    public void LogToConsole(string message)
    {
        Console.WriteLine($"Console: {message}, {messageInternal}");
    }
    public void LogToFile(string message)
    {
        Console.WriteLine($"File: {message}, {messageInternal}");
    }
    public void SendAlert(string message)
    {
        Console.WriteLine($"Alert: {message}, {messageInternal}");
    }
}
