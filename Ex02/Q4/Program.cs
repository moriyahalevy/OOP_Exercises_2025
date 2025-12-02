namespace Q4
{
    using System;
    using System.Diagnostics;
    using System.Threading; 
    using System.Threading.Tasks;

    public class Program
    {
        const int NUM_ITERATIONS = 100_000_000;

        public static void Main(string[] args)
        {
            Console.WriteLine($"Starting False Sharing Test (Iterations: {NUM_ITERATIONS} per Thread)...");
            long[] falseSharingArray = new long[2];
            MeasureExecution("False Sharing (Close)", falseSharingArray, 0, 1);

            Console.WriteLine("\n------------------------------------------\n");
 
            long[] noFalseSharingArray = new long[10]; 
            MeasureExecution("No False Sharing (Separated)", noFalseSharingArray, 0, 9);
        }



        private static void MeasureExecution(string testName, long[] array, int index1, int index2)
        {

            array[index1] = 0;
            array[index2] = 0;
            Stopwatch stopwatch = Stopwatch.StartNew();

            Parallel.Invoke(

                () => {
                    for (int i = 0; i < NUM_ITERATIONS; i++)
                    {

                        Interlocked.Increment(ref array[index1]);
                    }
                },
                () => {
                    for (int i = 0; i < NUM_ITERATIONS; i++)
                    {
                        Interlocked.Increment(ref array[index2]);
                    }
                }
            );

            stopwatch.Stop();

            Console.WriteLine($"--- {testName} ---");
            Console.WriteLine($"Time Elapsed: {stopwatch.Elapsed.TotalMilliseconds:F2} ms");
            Console.WriteLine($"Final Values: Array[{index1}]={array[index1]}, Array[{index2}]={array[index2]}");
        }
    }
}
