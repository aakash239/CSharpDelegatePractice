using System.Net;

namespace ThresholdEventReachedApplication;

class EventNoData
{
    public static void Main()
    {
        int threshold = 10;
        Counter c = new(threshold);
        c.ThresholdReached += c_thresholdReached; 
        
        Console.WriteLine("press 'a' key to increase total");

        while (Console.ReadKey(true).KeyChar == 'a')
        {
            Console.WriteLine("adding one");
            c.AddOne();
        }
    }

    static void c_thresholdReached(Object? sender, EventArgs e)
    {
        Console.WriteLine("The threshold was reached.");
        Environment.Exit(0);
    }
}

class Counter (int passedThreshold)
{
    public readonly int _threshold = passedThreshold;
    private int _total;

    public event EventHandler? ThresholdReached;
    public void AddOne()
    {
        _total += 1;
        if(_total >= _threshold)
        {
            OnThresholdReached(EventArgs.Empty);
        }
    }

    protected virtual void OnThresholdReached(EventArgs e)
    {
        ThresholdReached?.Invoke(this, e);
    }

}
