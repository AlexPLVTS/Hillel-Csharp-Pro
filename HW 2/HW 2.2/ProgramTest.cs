namespace HW_2._2
{
    internal class ProgramTest
    {
        static void Main(string[] args)
        {
            Violin myViolin = new Violin();
            myViolin.ShowName();
            myViolin.Description();
            Console.WriteLine();

            Ukulele myUkulele = new Ukulele();
            myUkulele.ShowName();
            myUkulele.MimickSound();
            Console.WriteLine();

            Trombone myTrombone = new Trombone();
            myTrombone.ShowName();
            myTrombone.MimickSound();
            myTrombone.Description();
            Console.WriteLine();

            Cello myCello = new Cello();
            myCello.ShowName();
            myCello.History();
            Console.WriteLine();
        }
    }
}
