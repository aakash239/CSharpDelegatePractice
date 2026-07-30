namespace DelegateArithmeticExample;

internal class Program
{
    private static void Main(string[] args)
    {
        BasicCalculator.MathOperator op = BasicCalculator.Add;
        Console.WriteLine($"Add 3 and 4: {op(3,4)}");

        op = BasicCalculator.Multiply;
        Console.WriteLine($"Multiply 3 and 4: {op(3,4)}");

        op = BasicCalculator.Add; 
        op += BasicCalculator.Multiply;

        // If a multicast delegate has both Add and Multiply attached, and it has a non-void return type, what does invoking it actually return?
        Console.WriteLine($"Invoked both methods only last method is returned and others are discarded: {op(3,4)}");

        foreach (var d in op.GetInvocationList())
        {
            var typedDelegate = (BasicCalculator.MathOperator)d;
            Console.WriteLine($"{d.Method.Name}(3,4) = {typedDelegate(3,4)}");
        }       
    }
}

internal class BasicCalculator
{
    public delegate int MathOperator(int a, int b);
    
    public static int Add(int a, int b)
    {
        return a + b;
    }

    public static int Multiply(int a, int b)
    {
        return a * b;
    }
}
