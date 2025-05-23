using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4._3
{
    internal class CreditCard
    {
        public readonly long cardNumber;
        public readonly string cardHolderName;
        public int balance = 1000;
        public CreditCard(long cardNumber, string cardHolderName, int balance)
        {
            this.cardNumber = cardNumber;
            this.cardHolderName = cardHolderName;
            this.balance = balance;
        }
        public CreditCard(long cardNumber, string cardHolderName) 
        {
            this.cardNumber = cardNumber;
            this.cardHolderName = cardHolderName;
        }
        public static CreditCard operator +(CreditCard yourCard, int amount)
        {
            yourCard.balance += amount;
            return yourCard;
        }
        public static CreditCard operator -(CreditCard yourCard, int amount)
        {
            yourCard.balance -= amount;
            return yourCard;
        }
        public static bool operator ==(CreditCard yourCard, CreditCard otherCard)
        {
            if (ReferenceEquals(otherCard, otherCard))
                return true;
            if (yourCard is null || otherCard is null)
                return false;
            return yourCard.balance == otherCard.balance; ;
        }
        public static bool operator !=(CreditCard yourCard, CreditCard otherCard)
        {
            return !(otherCard == yourCard);
        }
        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public static bool operator >(CreditCard yourCard, CreditCard otherCard)
        {
            return yourCard.balance > otherCard.balance;
        }
        public static bool operator <(CreditCard yourCard, CreditCard otherCard)
        {
            return yourCard.balance < otherCard.balance;
        }
    }
}
