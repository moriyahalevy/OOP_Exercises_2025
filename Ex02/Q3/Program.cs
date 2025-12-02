namespace Q3
{


    public class Program
    {
        public static void Main(string[] args)
        {
            int[] numbers = { 10, 20, 30, 40 };
            Console.WriteLine($"Array before Swap (Int Array): [{string.Join(", ", numbers)}]");
            SwapIntArray(numbers, 0, 3); 
            Console.WriteLine($"Array after Swap: [{string.Join(", ", numbers)}]");
            Console.WriteLine("------------------------------------------");

            Console.WriteLine($"Array before Swap (Q3c): [{string.Join(", ", numbers)}]");
            SwapGeneric<int>(ref numbers[1], ref numbers[2]);
            Console.WriteLine($"Array after Swap (Q3c): [{string.Join(", ", numbers)}]");
        }


        public static void SwapIntArray(int[] array, int index1, int index2)
        {
            int temp = array[index1];
            array[index1] = array[index2];
            array[index2] = temp;
        }
        public static void SwapGeneric<T>(ref T item1, ref T item2)
        {
            T temp = item1;
            item1 = item2;
            item2 = temp;
        }
    }
}
