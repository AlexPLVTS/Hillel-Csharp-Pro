namespace _4._3
{
    internal class Program
    {
        static void Main()
        {
            CreditCard myCard = new CreditCard(123454322345, "Alex");
            Console.WriteLine($"Name: {myCard.cardHolderName}\nCard Number: {myCard.cardNumber}\nInitial balance: {myCard.balance}");
            myCard = myCard + 100;
            Console.WriteLine($"Your balance after receiving funds: {myCard.balance} USD");
            myCard = myCard - 50;
            Console.WriteLine($"Your balance after payment: {myCard.balance}");
            CreditCard otherCard = new CreditCard(298745674896, "Ben", 850);
            Console.WriteLine($"{otherCard.cardHolderName} has more funds on his card: {myCard < otherCard}");
        }
    }
}
