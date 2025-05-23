using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4._2
{
    internal class City
    {
        public string cityName;
        public int cityPopulation;
        public City(int population, string name) 
        {
            if (population < 0)
                throw new ArgumentException("Population cannot be negative");
            cityPopulation = population;
            cityName = name;
        }
        public static City operator +(City a, int amount)
        {
            int newPopulation = a.cityPopulation + amount;
            return new City(newPopulation, a.cityName);
        }
        public static City operator -(City a, int amount)
        {
            int newPopulation = a.cityPopulation - amount;
            return new City(newPopulation, a.cityName);
        }
        public static bool operator ==(City a, City b)
        {
            if (ReferenceEquals(a, b))
                return true;
            if (a is null || b is null)
                return false;
            return a.cityPopulation == b.cityPopulation;
        }
        public static bool operator !=(City a, City b)
        {
            return !(a == b);
        }
        public static bool operator >(City a, City b)
        {
            return a.cityPopulation > b.cityPopulation;
        }
        public static bool operator <(City a, City b)
        {
            return a.cityPopulation < b.cityPopulation;
        }
        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
