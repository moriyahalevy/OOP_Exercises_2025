namespace Q4
{
    public class Fraction
    {
        public int Numerator { get; private set; }  
        public int Denominator { get; private set; } 

        public Fraction(int numerator, int denominator)
        {
            if (denominator == 0) throw new ArgumentException("Denominator cannot be zero");

            int common = GCD(Math.Abs(numerator), Math.Abs(denominator));
            Numerator = numerator / common;
            Denominator = denominator / common;
        }

        private static int GCD(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        public static Fraction operator +(Fraction f1, Fraction f2) =>
            new Fraction(f1.Numerator * f2.Denominator + f2.Numerator * f1.Denominator, f1.Denominator * f2.Denominator);
        public static Fraction operator -(Fraction f1, Fraction f2) =>
            new Fraction(f1.Numerator * f2.Denominator - f2.Numerator * f1.Denominator, f1.Denominator * f2.Denominator);

        public static Fraction operator *(Fraction f1, Fraction f2) =>
            new Fraction(f1.Numerator * f2.Numerator, f1.Denominator * f2.Denominator);
        public static Fraction operator /(Fraction f1, Fraction f2)
        {
            if (f2.Numerator == 0) throw new DivideByZeroException("לא ניתן לחלק בשבר שהמונה שלו הוא 0");
            return new Fraction(f1.Numerator * f2.Denominator, f1.Denominator * f2.Numerator);
        }
        public static bool operator >(Fraction f1, Fraction f2)
        {
            return f1.Numerator * f2.Denominator > f2.Numerator * f1.Denominator;
        }
        public static bool operator <(Fraction f1, Fraction f2)
        {
            return f1.Numerator * f2.Denominator < f2.Numerator * f1.Denominator;
        }
        public static bool operator ==(Fraction f1, Fraction f2)
        {
            if (ReferenceEquals(f1, null)) return ReferenceEquals(f2, null);
            if (ReferenceEquals(f2, null)) return false;

            return f1.Numerator == f2.Numerator && f1.Denominator == f2.Denominator;
        }

        public static bool operator !=(Fraction f1, Fraction f2)
        {
            return !(f1 == f2);
        }
        public override string ToString() => $"{Numerator}/{Denominator}";
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Fraction f1 = new Fraction(8, 12); 
            Fraction f2 = new Fraction(3, 4);
            Console.WriteLine($"{f1} + {f2} = {f1 + f2}"); 
            Console.WriteLine($"{f2} - {f1} = {f2 - f1}"); 
            Console.WriteLine($"{f1} * {f2} = {f1 * f2}"); 
            Console.WriteLine($"{f1} / {f2} = {f1 / f2}"); 
            Console.WriteLine($"{f1} > {f2} ? {f1 > f2}"); 
            Console.WriteLine($"{f1} < {f2} ? {f1 < f2}"); 
            Fraction f3 = new Fraction(4, 6); 
            Console.WriteLine($"{f1} == {f3} ? {f1 == f3}"); 
            Console.WriteLine($"{f1} != {f2} ? {f1 != f2}"); 

            try
            {
                Fraction fError = new Fraction(1, 0);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($" {ex.Message}");
            }
        }
    }
}
