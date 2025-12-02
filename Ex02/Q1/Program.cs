namespace Q1
{
    using System;
    using System.Diagnostics; // נדרש כדי להשתמש ב-Stopwatch, אבל ניתן להשתמש גם לניסוי זה

    public class Program
    {
        public static void Main(string[] args)
        {
            long arraySize = 100_000_000;
            long lastSuccessfulSize = 0;
            const int sizeOfIntInBytes = 4; 

            Console.WriteLine("--- Starting Array Allocation Test ---");

            while (true)
            {
                try
                {
                    double sizeInGB = (double)arraySize * sizeOfIntInBytes / (1024 * 1024 * 1024);
                    Console.WriteLine($"Attempting to allocate array of {arraySize} elements (~{sizeInGB:F2} GB)...");

                    int[] veryLargeArray = new int[arraySize];


                    for (long i = 0; i < arraySize; i += 1024) 
                    {
                        veryLargeArray[i] = 1;
                    }

                    lastSuccessfulSize = arraySize;

              
                    arraySize += 500_000_000; 

                    // אם עברנו את 2GB, עבר לצעדים קטנים יותר של 10 מיליון כדי לדייק
                    if (sizeInGB > 2.1)
                    {
                        arraySize = lastSuccessfulSize + 10_000_000; 
                    }

                }
                catch (OutOfMemoryException)
                {
                    Console.WriteLine("------------------------------------------");
                    Console.WriteLine($"ALLOCATION FAILED! (OutOfMemoryException caught)");
                    Console.WriteLine($"Maximum number of int elements successfully allocated: {lastSuccessfulSize}");
                    Console.WriteLine($"Corresponding memory size: {(double)lastSuccessfulSize * sizeOfIntInBytes / (1024 * 1024 * 1024):F2} GB");
                    Console.WriteLine("------------------------------------------");
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                    break;
                }
            }
        }
    }
}
