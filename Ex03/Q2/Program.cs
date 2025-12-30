namespace Q2
{
    public class ArrayProcessor
    {
        public delegate void UnaryAction(double a);

        public static void ProcessArray(double[] array, UnaryAction processor)
        {
            foreach (double item in array)
            {
                processor(item);
            }
        }
    }
    public class SumCalculator
    {
        public double Sum { get; private set; } = 0;
        public void AddToSum(double a) => Sum += a;
    }

    public class MaxCalculator
    {
        public double Max { get; private set; } = double.MinValue;
        public void CheckMax(double a)
        {
            if (a > Max) Max = a;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            double[] numbers = new double[10];
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = rnd.NextDouble() * 100;
                Console.WriteLine($"Generated: {numbers[i]:F2}");
            }

            SumCalculator sc = new SumCalculator();
            MaxCalculator mc = new MaxCalculator();

            ArrayProcessor.ProcessArray(numbers, sc.AddToSum);
            ArrayProcessor.ProcessArray(numbers, mc.CheckMax);

            Console.WriteLine("----------------");
            Console.WriteLine($"Total Sum: {sc.Sum:F2}");
            Console.WriteLine($"Max Value: {mc.Max:F2}");

            double lambdaSum = 0; 
            double lambdaMax = double.MinValue;

            ArrayProcessor.ProcessArray(numbers, x => lambdaSum += x);

            ArrayProcessor.ProcessArray(numbers, x =>
            {
                if (x > lambdaMax) lambdaMax = x;
            });

            Console.WriteLine($"Lambda Sum: {lambdaSum:F2}");
            Console.WriteLine($"Lambda Max: {lambdaMax:F2}");
        }
    }
}
