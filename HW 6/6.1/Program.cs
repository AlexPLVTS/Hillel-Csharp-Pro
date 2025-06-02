namespace _6._1
{
    public enum Genres
    {
        Drama = 1,
        Comedy,
        Tragedy,
    }
    public class ThePlay : IDisposable
    {
        public bool disposed = false;
        string? PlayName { get; set; }
        string? AuthorName { get; set; }
        Genres PlayGenre { get; set; }
        int PlayYOB { get; set; }
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
        ~ThePlay()
        {
            Console.WriteLine("Finalizer called");
            Dispose(false);
        }
        public void ShowInfo()
        {
            Console.WriteLine("---------------------------------------------------------------------------------------------------");
            Console.WriteLine($"|The play {PlayName} was written on {PlayYOB} by {AuthorName}, it represents {PlayGenre} genre|");
            Console.WriteLine("---------------------------------------------------------------------------------------------------");
        }
        internal class Program
        {
            static void Main(string[] args)
            {
                long mem = GC.GetTotalMemory(true);
                Console.WriteLine($"Memory before clean up: {mem}");
                ThePlay play = new ThePlay
                {
                    PlayName = "Romeo and Juliet",
                    PlayYOB = 1591,
                    AuthorName = "William Shakespeare",
                    PlayGenre = Genres.Tragedy
                };
                try
                {
                    play.ShowInfo();
                }
                finally
                {
                    play.Dispose();
                }
                long mem1 = GC.GetTotalMemory(true);
                Console.WriteLine($"Memory after clean up: {mem1}");
            }
        }
    }
}
