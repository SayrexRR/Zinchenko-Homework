using CodeFirstTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstTest
{
    public static class Service
    {
        public static void PrintAllBooks()
        {
            var books = Repository.GetAllBooks();
            Console.WriteLine("Books:");
            foreach (var book in books)
            {
                var ganres = "";
                foreach (var item in book.Genres)
                    ganres += item.Name + " ";

                Console.WriteLine($"Name: {book.Name} | Author: {book.Author} | Genre: {ganres}| Price: {book.Price}");
            }
        }

        public static void PrintSales(int id, int month)
        {
            using var context = new BookStoreContext();
            var sales = Repository.GetProductSales(id, month);
            var bookName = context.Books?.FirstOrDefault(b => b.Id ==  id)?.Name;

            Console.WriteLine("Sales");
            Console.WriteLine($"Name: {bookName} | Month #: {month} | Total Qty: {sales.Item1} | Total price: {sales.Item2}");
        }

        public static void PrintSales(string bookName, int month)
        {
            var sales = Repository.GetProductSales(bookName, month);

            Console.WriteLine("Sales:");
            Console.WriteLine($"Name: {bookName} | Month #: {month} | Total Qty: {sales.Item1} | Total price: {sales.Item2}");
        }

        public static void PrintBookPrice(int id)
        {
            using var context = new BookStoreContext();
            var price = Repository.GetBookPrice(id);
            var bookName = context.Books?.FirstOrDefault(b => b.Id == id)?.Name;

            Console.WriteLine($"Name: {bookName} | Price: {price}");
        }

        public static void PrintBookPrice(string name)
        {
            var price = Repository.GetBookPrice(name);

            Console.WriteLine($"Name: {name} | Price: {price}");
        }
    }
}
