namespace Q2
{
    using System;
    using System.Diagnostics; 
    using System.Linq;      

    public class Program
    {
        public static void Main(string[] args)
        {
   
            const int ARRAY_SIZE = 100_000_000; 
            int[] data = new int[ARRAY_SIZE];
            for (int i = 0; i < ARRAY_SIZE; i++)
            {
                data[i] = i;
            }

            Console.WriteLine($"Starting Access Test on Array of {ARRAY_SIZE} elements...");

            MeasureAccessTime(data, 1, "Sequential Access (Stride 1)"); 
            MeasureAccessTime(data, 1024, "Strided Access (Stride 1024)"); 

            Console.WriteLine("Test Complete.");
        }


        private static void MeasureAccessTime(int[] data, int stride, string testName)
        {
            const int NUM_ACCESSES = 10_000_000;
            long index = 0;
            Stopwatch stopwatch = Stopwatch.StartNew();
            long sum = 0;

            for (int j = 0; j < NUM_ACCESSES; j++)
            {
  
                sum += data[index];

                index += stride;

                if (index >= data.Length)
                {
                    index = index % data.Length; 
                }
            }

            stopwatch.Stop();

            Console.WriteLine($"--- {testName} (Accesses: {NUM_ACCESSES}) ---");
            Console.WriteLine($"Time Elapsed: {stopwatch.Elapsed.TotalMilliseconds:F2} ms");
            Console.WriteLine("------------------------------");
        }
    }
}
