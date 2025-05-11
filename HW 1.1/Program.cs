namespace HW_1._1
{
    internal class Program
    {
        static void Main()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Select Calculator Type:");
                Console.WriteLine("1. Ordinary Calculator");
                Console.WriteLine("2. Advanced Calculator");
                Console.WriteLine("0. Exit");
                Console.Write("Enter your choice: ");
                string calculatorChoice = Console.ReadLine();

                if (calculatorChoice == "0") break;

                switch (calculatorChoice)
                {
                    case "1":
                        UseOrdinaryCalculator();
                        break;
                    case "2":
                        UseAdvancedCalculator();
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        Console.ReadKey();
                        break;
                }
            }
        }
        static void UseOrdinaryCalculator()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Basic Operations:");
                Console.WriteLine("1. Add");
                Console.WriteLine("2. Subtract");
                Console.WriteLine("3. Multiply");
                Console.WriteLine("4. Divide");
                Console.WriteLine("0. Back");
                Console.Write("Select operation: ");
                string choice = Console.ReadLine();

                if (choice == "0") break;

                Console.WriteLine("Enter two numbers:");
                double a = double.Parse(Console.ReadLine());
                double b = double.Parse(Console.ReadLine());

                try
                {
                    switch (choice)
                    {
                        case "1":
                            Console.WriteLine("Result: " + OrdinaryCalculator.Sum(a, b));
                            break;
                        case "2":
                            Console.WriteLine("Result: " + OrdinaryCalculator.Deduct(a, b));
                            break;
                        case "3":
                            Console.WriteLine("Result: " + OrdinaryCalculator.Multiply(a, b));
                            break;
                        case "4":
                            Console.WriteLine("Result: " + OrdinaryCalculator.Divide(a, b));
                            break;
                        default:
                            Console.WriteLine("Invalid operation.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }
        static void UseAdvancedCalculator()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Advanced Operations:");
                Console.WriteLine("1. Power");
                Console.WriteLine("2. NRoot");
                Console.WriteLine("3. Logarithm");
                Console.WriteLine("4. Factorial");
                Console.WriteLine("5. Calculate Date Difference");
                Console.WriteLine("0. Back");
                Console.Write("Select operation: ");
                string choice = Console.ReadLine();

                if (choice == "0") break;
                try
                {
                    switch (choice)
                    {
                        case "1":
                            Console.WriteLine("Enter base and exponent:");
                            double baseNum = double.Parse(Console.ReadLine());
                            double exp = double.Parse(Console.ReadLine());
                            Console.WriteLine("Result: " + AdvancedCalculator.Power(baseNum, exp));
                            break;
                        case "2":
                            Console.WriteLine("Enter number and root");
                            double num = double.Parse(Console.ReadLine());
                            double root = double.Parse(Console.ReadLine());
                            Console.WriteLine("Result: " + AdvancedCalculator.NRoot(num, root));
                            break;
                        case "3":
                            Console.WriteLine("Enter a number:");
                            double numLog = double.Parse(Console.ReadLine());
                            Console.WriteLine("Result: " + AdvancedCalculator.Logarithm(numLog));
                            break;
                        case "4":
                            Console.WriteLine("Enter an integer:");
                            int nFact = int.Parse(Console.ReadLine());
                            Console.WriteLine("Result: " + AdvancedCalculator.Factorial(nFact));
                            break;
                        case "5":
                            Console.WriteLine("Enter first date (MM/DD/YYYY):");
                            DateTime date1 = DateTime.Parse(Console.ReadLine());
                            Console.WriteLine("Enter second date (MM/DD/YYYY):");
                            DateTime date2 = DateTime.Parse(Console.ReadLine());
                            Console.WriteLine($"Difference: {AdvancedCalculator.DateDifference(date1, date2)} days");
                            break;
                        default:
                            Console.WriteLine("Invalid choice.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }
    }
}
