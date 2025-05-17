namespace HW_2._3
{
    internal class ProgramTest
    {
        static void Main(string[] args)
        {
            NumericSystems converter = new NumericSystems();

            int testNumber = 437;

            string binary = converter.ToBinarySystem(testNumber);
            string octal = converter.ToOctalSystem(testNumber);
            string hex = converter.ToHexSystem(testNumber);

            Console.WriteLine($"Number: {testNumber}");
            Console.WriteLine($"Binary: {binary}");
            Console.WriteLine($"Octal: {octal}");
            Console.WriteLine($"Hexadecimal: {hex}");
        }
    }
}
