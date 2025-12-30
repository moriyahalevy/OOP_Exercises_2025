namespace Q6
{
    public delegate int OpFunc(int x, int y);

    public class OperationTable
    {
        private int _startRow, _endRow, _startCol, _endCol;
        private OpFunc _op;

        public OperationTable(int startRow, int endRow, int startCol, int endCol, OpFunc op)
        {
            _startRow = startRow;
            _endRow = endRow;
            _startCol = startCol;
            _endCol = endCol;
            _op = op;
        }
        public void Print()
        {
            for (int r = _startRow; r <= _endRow; r++)
            {
                for (int c = _startCol; c <= _endCol; c++)
                {
                     Console.Write(_op(r, c) + "\t"); 
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
