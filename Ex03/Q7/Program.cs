namespace Q7
{
    public class OperationTable<T>
    {
        public delegate T OpFunc(T x, T y);
        private List<T> _rowValues;
        private List<T> _colValues;
        private OpFunc _op;

        public OperationTable(List<T> rowValues, List<T> colValues, OpFunc op)
        {
            _rowValues = rowValues;
            _colValues = colValues;
            _op = op;
        }

        public void Print()
        {
            foreach (var row in _rowValues)
            {
                foreach (var col in _colValues)
                {
                   Console.Write(_op(row, col) + "\t"); 
            }
                Console.WriteLine();
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}
