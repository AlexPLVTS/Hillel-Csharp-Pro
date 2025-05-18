namespace HW_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] ints = { 45, 5, 44, -28, -2, 59, -40, -30, 4, -54 };
            MyArray myArray = new MyArray(ints);

            myArray.Show("Original array");
            myArray.SortDesc();
            myArray.Show("Sorted by descending");
            myArray.Show($"Max element: {myArray.Max()}");
            myArray.Show($"Min element: {myArray.Min()}");
            int value = 5;
            myArray.Show($"Element {value} is in array: {myArray.Search(value)}");
            myArray.Show($"Average value in array: {myArray.Average()}");
            myArray.SortByParam(true);
            myArray.Show($"Array sorted by ascending");
        }
    }
}
