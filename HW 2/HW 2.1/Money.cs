using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_2._1
{
    class Money
    {
        private string _userName = "CurrentUser";
        private int _balanceUSD = 0;
        private int _balanceCents = 0;
        private const int centsToUSD = 100;
        private const string ERROR = "Error! Name is empty, or exceeds 15 characters!";
        public string UserName
        {
            get => _userName;
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length > 15)
                {
                    throw new ArgumentException(ERROR);
                }
                else
                {
                    _userName = value;
                }
            }
        }
        public int BalanceUSD
        {
            get => _balanceUSD;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("Balance", "Balance cannot be negative");
                _balanceUSD = value;
            }
        }
        public int BalanceCents
        {
            get => _balanceCents;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("Cents", "Cents cannot be negative");
                if (value >= 100)
                    throw new ArgumentOutOfRangeException("Cent", "Cents should be less than 100");
                _balanceCents = value;
            }
        }
        public double TotalBalance
        {
            get
            {
                return _balanceUSD + _balanceCents / (double)centsToUSD;
            }
        }
        public virtual void PrintState()
        {
            Console.WriteLine($"{UserName} balance: USD - {BalanceUSD}; Cents - {BalanceCents}");
            Console.WriteLine($"Total balance: {TotalBalance:F2} USD");
        }
    }
}
