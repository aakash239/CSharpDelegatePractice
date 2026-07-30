namespace BasicEvents;

class Button
{
    // declare a delegate type
    public delegate void ClickHandler();

    // declare an event based on that delegate
    public event ClickHandler? Click;

    public void SimulateClick()
    {
        Console.WriteLine("Button was clicked!");
        Click?.Invoke(); // Invoke if only the subscriber list is not null
        // the invoke method runs all the methods that are pointed to by this delegate.
        // the methods here simulate actions that happen in response to that event.
    }
}

class Program
{
    static void Main()
    {
        Button btn = new Button();

        btn.Click += OnButtonClicked; // this is Button class delegate that is mapped to OnButtonClicked method of this class

        btn.Click += LogClickToConsole;

        // simulate the click
        btn.SimulateClick();

        btn.Click -= OnButtonClicked;

        btn.SimulateClick();
    }

    static void OnButtonClicked()
    {
        Console.WriteLine("Handler: the Button click was received!");
    }
    static void LogClickToConsole()
    {
        Console.WriteLine("Logging: click happened at " + DateTime.Now);
    }
}
