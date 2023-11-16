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

            PrintAllBooks();

            PrintSales(1, 11);

            PrintSales("The Shining", 11);

            PrintBookPrice(3);

            PrintBookPrice("A Game of Thrones");
        }

        public static void PrintAllBooks()
        {
            var books = BookService.GetAllBooks();

            Console.WriteLine();
            Console.WriteLine("Books:");
            foreach (var book in books)
            {
                Console.WriteLine($"Name: {book.Name} | Author: {book.Author} | Genre: {BookService.GetBookGenres(book)} | Price: {book.Price}");
            }
        }

        public static void PrintSales(int id, int month)
        {
            var sales = BookService.GetSales(id, month);

            Console.WriteLine();
            Console.WriteLine(sales);
        }

        public static void PrintSales(string bookName, int month)
        {
            var sales = BookService.GetSales(bookName, month);

            Console.WriteLine();
            Console.WriteLine(sales);
        }

        public static void PrintBookPrice(int id)
        {
            var price = BookService.GetBookPrice(id);
            var bookName = BookService.GetBookNameById(id);

            Console.WriteLine();
            Console.WriteLine($"Name: {bookName} - Price: {price}");
        }

        public static void PrintBookPrice(string bookName)
        {
            var price = BookService.GetBookPrice(bookName);

            Console.WriteLine();
            Console.WriteLine($"Name: {bookName} - Price: {price}");
        }
    }
}