
namespace Q3
{
    public class GenericOperationTable<T>
    {
        public delegate T OpFunc(T x, T y);

        private List<T> rowValues;
        private List<T> colValues;
        private OpFunc operation;

        public GenericOperationTable(List<T> _row_values, List<T> _col_values, OpFunc _op)
        {
            rowValues = _row_values;
            colValues = _col_values;
            operation = _op;
        }

        public void Print()
        {
            foreach (var row in rowValues)
            {
                foreach (var col in colValues)
                {
                    Console.Write(operation(row, col) + "\t");
                }
                Console.WriteLine(); 
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<double> row_values = new List<double>();
            List<double> col_values = new List<double>();

            for (double i = 1; i <= 4; i++)
            {
                row_values.Add(1.0 / i); 
                col_values.Add(1.0 / i); 
            }

            GenericOperationTable<double> t1 = new GenericOperationTable<double>(row_values, col_values, (x, y) => x + y);

            t1.Print();
        }
    }
}