namespace _4._4
{
    internal class Program
    {
        static void Main()
        {
            int[,] matrix1 = { { 1, 45, 6 }, { 2, 8, 9 }, { 2, 7, 8 } };
            Matrix m1 = new Matrix(3, 3, matrix1);
            int[,] matrix2 = { { 234, 2, 3 }, { 4, 5, 54 }, { 56, 76, 12 } };
            Matrix m2 = new Matrix(3, 3, matrix2);
            Matrix sum = m1 + m2;
            Console.WriteLine($"Initial matrices: \n{m1}\n{m2}");
            Console.WriteLine($"Sum of matrices: \n{sum}");
            Console.WriteLine($"Given matrices are equal: {m1 == m2}");
            Console.WriteLine($"Matrix after multiplication:\n{m1 * m2}");
        }
    }
}
