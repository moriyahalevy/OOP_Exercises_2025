namespace Q1
{
    public delegate double BinaryOperation(double a, double b);

    internal class Program
    {
        public static double Add(double a, double b) => a + b;
        public static double Subtract(double a, double b) => a - b;
        public static double Multiply(double a, double b) => a * b;
        public static double ApplyOperation(BinaryOperation bOp, double a, double b)
        {
            return bOp(a, b); 
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}
