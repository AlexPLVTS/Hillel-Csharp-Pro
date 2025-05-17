namespace HW_2._1
{
    internal class ProgramTest
    {
        static void Main()
        {
            Product myProduct = new Product
            {
                UserName = "JohnDoe",
                BalanceUSD = 100,
                BalanceCents = 10
            };
            myProduct.FillBasket("Tomato", 500, "g");
            myProduct.FillBasket("Potato", 2, "kg");
            myProduct.FillBasket("Carrot", 300, "g");


            myProduct.PrintState();

            double totalPrice = myProduct.GetTotalPrice();
            Console.WriteLine($"\nTotal price (with discount if applicable): {totalPrice:F2} USD");

            if (myProduct.TotalBalance >= totalPrice)
            {
                myProduct.DeductAmount(totalPrice);
                Console.WriteLine("\nPurchase successful!");
                myProduct.PrintState();
            }
            else
            {
                Console.WriteLine("\nInsufficient funds to complete the purchase.");
            }
        }

    }
}
