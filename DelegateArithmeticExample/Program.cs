namespace DelegateArithmeticExample;

internal class Program
{
    private static void Main(string[] args)
    {
        // used to be: public delegate int MathOperator(int a, int b);
        // now just using Func instead of declaring my own delegate
        Func<int, int, int> op = BasicCalculator.Add;
        Console.WriteLine($"Add 3 and 4: {op(3, 4)}");

        op = BasicCalculator.Multiply;
        Console.WriteLine($"Multiply 3 and 4: {op(3, 4)}");

        // multicast still works same as before
        op = BasicCalculator.Add;
        op += BasicCalculator.Multiply;

        // only last one's return value actually comes through, rest get thrown away
        Console.WriteLine($"Multicast result (last method wins): {op(3, 4)}");

        // gotta cast back to Func to actually call these individually
        foreach (var d in op.GetInvocationList())
        {
            var typedDelegate = (Func<int, int, int>)d;
            Console.WriteLine($"{d.Method.Name}(3,4) = {typedDelegate(3, 4)}");
        }

        // Action is basically Func but void, no delegate needed here either
        Action<string> action = PrintUpper;
        action += PrintLower;
        action("tEst"); // prints TEST then test
    }

    public static void PrintUpper(string s) => Console.WriteLine(s.ToUpper());
    public static void PrintLower(string s) => Console.WriteLine(s.ToLower());
}

internal class BasicCalculator
{
    public static int Add(int a, int b) => a + b;
    public static int Multiply(int a, int b) => a * b;
}