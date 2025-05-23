namespace _4._2
{
    internal class Program
    {
        static void Main()
        {
            City myCity = new City(10000, "New York");
            int initial = myCity.cityPopulation;
            Console.WriteLine($"{myCity.cityName} initial population: {initial}");
            myCity = myCity + 1000;
            Console.WriteLine($"{myCity.cityName} population after immigration: {myCity.cityPopulation}");
            myCity = myCity - 500;
            Console.WriteLine($"{myCity.cityName} population after emigration: {myCity.cityPopulation}");
            City myCity2 = new City(20000, "Berlin");
            Console.WriteLine($"{myCity.cityName} is more populate then {myCity2.cityName}: {myCity > myCity2}");
            Console.WriteLine(myCity2.GetHashCode() == myCity.GetHashCode());
            Console.WriteLine($"Population of {myCity.cityName} is same as {myCity2.cityName}: {myCity.Equals(myCity2)}");
        }
    }
}
