namespace _6._2
{
    public enum MarketType
    {
        Product = 1,
        Domestic,
        Clothes,
        Shoes
    }
    public class Address
    {
        public string? CityName { get; set; }
        public string? StreetName { get; set; }
        public int StreetNum { get; set; }
        public int ZipCode { get; set; }
        public override string ToString()
        {
            return $"{CityName}, {StreetName} {StreetNum}, {ZipCode}";
        }
    }
    public class Market : IDisposable
    {
        public bool disposed = false;
        public MarketType Type { get; set; }
        public string? MarkeName { get; set; }
        public Address Address { get; set; }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    Console.WriteLine("Managed resources cleaned");
                }
                Console.WriteLine("Unmanaged resources cleaned");
                disposed = true;
            }
        }
        public void MarketInfo()
        {
            Console.WriteLine($"{Type} market {MarkeName} is located at the address: {Address}");
        }
        ~Market()
        {
            Dispose(false);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Market m = new Market { Type = MarketType.Product, MarkeName = "AAA" };
            m.Address = new Address { CityName = "B", StreetName = "C", StreetNum = 10, ZipCode = 123 };
            using (m)
            {
                m.MarketInfo();
            }
        }
    }
}
