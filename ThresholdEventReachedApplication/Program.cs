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

    static void c_thresholdReached(Object? sender, ThresholdreachedEventArgs e)
    {
        Console.WriteLine($"The threshold of {e.Threshold} was reached on {e.dateTime}.");
        Environment.Exit(0);
    }
}

class Counter (int passedThreshold)
{
    public readonly int _threshold = passedThreshold;
    private int _total;

    public event EventHandler<ThresholdreachedEventArgs>? ThresholdReached;
    public void AddOne()
    {
        _total += 1;
        if(_total >= _threshold)
        {
            ThresholdreachedEventArgs args = new ThresholdreachedEventArgs(_threshold, DateTime.Now);
            OnThresholdReached(args);
        }
    }

    protected virtual void OnThresholdReached(ThresholdreachedEventArgs e)
    {
        ThresholdReached?.Invoke(this, e);
    }

}

public class ThresholdreachedEventArgs(int Threshold, DateTime dateTime) : EventArgs
{
    public int Threshold = Threshold;
    public DateTime dateTime = dateTime;

}
