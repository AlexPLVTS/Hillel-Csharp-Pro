using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_2._1
{
    internal class Product : Money
    {
        private Dictionary<string, double> _productPrice;
        private Dictionary<string, double> _basket;
        private const int Discount = 25;
        private const int AmountForDC = 80;
        public Product()
        {
            _productPrice = new Dictionary<string, double>
            {
                { "Tomato", 10.49 },
                { "Potato", 8.59 },
                { "Carrot", 5.69 },
                { "Cabbage", 11.79 },
                { "Garlic", 20.89 }
            };
            _basket = new Dictionary<string, double>();
        }
        public void FillBasket(string name, double amount, string unit)
        {
            if (!_productPrice.ContainsKey(name))
            {
                Console.WriteLine($"Product {name} not available.");
                return;
            }
            double amountInKg;
            if (unit == "g")
            {
                amountInKg = amount / 1000.0;
            }
            else
            {
                amountInKg = amount;
            }
            if (_basket.ContainsKey(name))
                _basket[name] += amountInKg;
            else
                _basket[name] = amountInKg;
        }
        public override void PrintState()
        {
            Console.WriteLine($"Basket of {UserName} content kg:");
            foreach (var item in _basket)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
            Console.WriteLine($"Total balance: {TotalBalance:F2} USD");
        }
        public double GetTotalPrice()
        {
            double total = 0;
            foreach (var item in _basket)
            {
                double pricePerKg = _productPrice[item.Key];
                total += pricePerKg * item.Value;
            }
            total = total > AmountForDC ? total - (total * (Discount / 100)) : total;
            return total;
        }
        public bool DeductAmount(double amount)
        {
            double totalInUSD = TotalBalance;
            if (totalInUSD < amount)
            {
                return false;
            }
            BalanceUSD = (int)Math.Floor(totalInUSD - amount);
            BalanceCents = (int)((totalInUSD - amount - BalanceUSD) * 100);
            return true;
        }

    }
}
