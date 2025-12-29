using Q4;
using Q3;
namespace Q5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("לוח חיבור שברים (מ-1/12 עד 12/12):");
            Console.WriteLine("----------------------------------");

            List<Fraction> fractions = new List<Fraction>();

            for (int i = 1; i <= 12; i++)
            {
                fractions.Add(new Fraction(i, 12));
            }

            GenericOperationTable<Fraction> table = new GenericOperationTable<Fraction>(fractions,fractions,(f1, f2) => f1 + f2);
            table.Print();
        }
    }
}