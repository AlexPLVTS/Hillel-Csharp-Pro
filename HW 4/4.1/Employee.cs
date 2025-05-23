using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace _4._1
{

    internal class Employee
    {
        public readonly int baseSalary;
        public string? Name {  get; set; }
        public Employee(int baseSalary)
        {
            if (baseSalary >= 0)
            {
                this.baseSalary = baseSalary;
            }
            else
            {
                throw new ArgumentException("Salary cannot be negative");
            }
        } 
        public static Employee operator +(Employee a, int bonus)
        {
            if (bonus < 0)
                throw new ArgumentOutOfRangeException("Bonus cannot be negative");
            return new Employee(a.baseSalary + bonus);
        }
        public static Employee operator -(Employee a, int penalty)
        {
            return new Employee(a.baseSalary - penalty);
        }
        public static bool operator ==(Employee a, Employee b)
        {
            if (ReferenceEquals(a, b))
                return true;
            if (a is null || b is null)
                return false;
            return a.baseSalary == b.baseSalary;
        }
        public static bool operator !=(Employee a, Employee b)
        {
            return !(a == b);
        }
        public static bool operator >(Employee a, Employee b)
        {
            return a.baseSalary > b.baseSalary;
        }
        public static bool operator <(Employee a, Employee b)
        {
            return a.baseSalary < b.baseSalary;
        }
        public override bool Equals(object? obj)
        {
            if (obj is Employee other)
                return this == other;
            return false;
        }
        public override int GetHashCode()
        {
            return baseSalary.GetHashCode();
        }
    }
}
