using CodeFirstTest.Models;

namespace CodeFirstTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var bookStoreContext = new BookStoreContext();

            if (!bookStoreContext.Books.Any())
            {
                DbInitializer.Initialize(bookStoreContext);
            }

            Service.PrintAllBooks();
            Console.WriteLine();

            Service.PrintSales(3, 11);
            Console.WriteLine();

            Service.PrintSales("The Shining", 11);
            Console.WriteLine();

            Service.PrintBookPrice(4);
            Console.WriteLine();

            Service.PrintBookPrice("A Game of Thrones");
        }
    }
}