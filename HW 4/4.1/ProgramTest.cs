namespace _4._1
{
    internal class Program
    {
        static void Main()
        {
            Employee myEmployee = new Employee(1000);
            Console.WriteLine($"Starting salary: {myEmployee.baseSalary} USD");
            myEmployee = myEmployee + 150;
            Console.WriteLine($"Salary with bonus: {myEmployee.baseSalary} USD");
            myEmployee = myEmployee - 300;
            Console.WriteLine($"Salary after penalty: {myEmployee.baseSalary} USD");
            Employee myEmployee2 = new Employee(1100);
            if (myEmployee == myEmployee2)
                Console.WriteLine("Employees have equal salary");
            else
                Console.WriteLine("Employees salary is different");
            Console.WriteLine($"{myEmployee2.Name = "Steven"}'s salary is bigger then {myEmployee.Name = "Oscar"}: {myEmployee2 > myEmployee}");
        }
    }
}
