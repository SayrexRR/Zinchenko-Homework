using CodeFirstTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstTest
{
    public static class BookService
    {
        public static List<Book> GetAllBooks()
        {
            return Repository.GetAllBooks();
        }

        public static string GetSales(int id, int month)
        {
            var sales = Repository.GetProductSales(id, month);
            var bookName = Repository.GetBookNameById(id);

            return $"Name: {bookName} | Month #: {month} | Total Qty: {sales.Item1} | Total price: {sales.Item2}";
        }

        public static string GetSales(string bookName, int month)
        {
            var sales = Repository.GetProductSales(bookName, month);

            return $"Name: {bookName} | Month #: {month} | Total Qty: {sales.Item1} | Total price: {sales.Item2}";
        }

        public static decimal? GetBookPrice(int id)
        {
            var book = Repository.GetBook(id);

            return book?.Price;
        }

        public static decimal? GetBookPrice(string name)
        {
            var book = Repository.GetBook(name);

            return book?.Price;
        }

        public static string GetBookNameById(int id)
        {
            return Repository.GetBookNameById(id);
        }

        public static string GetBookGenres(Book book)
        {
            var genres = string.Empty;

            foreach (var item in book.Genres)
            {
                genres += item.Name + " ";
            }

            return genres;
        }
    }
}
