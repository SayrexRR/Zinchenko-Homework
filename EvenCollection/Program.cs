namespace EvenCollection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var array = new[] { 0, 1, 2, 3, 4, 5, 6,
                7, 8, 9, 10, 11, 12, 13, 14, 15 };

            EvenList list = new(array);


            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine(new string('-', 50));
            EvenListWithYield list2 = new(array);

            foreach (var item in list2)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine(new string('-', 50));

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine(new string('-', 50));

            foreach (var item in list2)
            {
                Console.WriteLine(item);
            }
        }
    }
}