using System.Runtime.ConstrainedExecution;

namespace EventHandler;

class Program
{
    static void Main(string[] args)
    {
        Button btn = new Button();

        btn.Click += OnButtonClickEvent;

        btn.SimulateClick(10, 20);
    }

    // handler methodk
    static void OnButtonClickEvent(Object? sender, ClickEventArgs e)
    {
        Console.WriteLine($"Handler: Click received at ({e.X}, {e.Y})");
        Console.WriteLine($"Sender type: {sender?.GetType().Name}");    }
}

class ClickEventArgs : EventArgs
{
    public int X {get;}
    public int Y {get;}

    public ClickEventArgs(int x, int y)
    {
        X = x;
        Y = y;
    }

}

class Button
{
    public delegate void ClickHandler(object? sender, ClickEventArgs e);

    public event ClickHandler? Click;

    public void SimulateClick(int x, int y)
    {
        System.Console.WriteLine("Btn clicked");

        Click?.Invoke(this, new ClickEventArgs(x, y));
    }
}
