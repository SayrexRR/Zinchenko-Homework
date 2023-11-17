using CodeFirstTest.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstTest
{
    public class Repository
    {
        public static Book? GetBook(int id)
        {
            using var context = new BookStoreContext();

            var book = context.Books.FirstOrDefault(b => b.Id == id);

            return book;
        }

        public static Book? GetBook(string name)
        {
            using var context = new BookStoreContext();

            var book = context.Books.FirstOrDefault(b => b.Name == name);

            return book;
        }

        public static string GetBookNameById(int id)
        {
            using var context = new BookStoreContext();

            var name = context.Books.SingleOrDefault(b => b.Id == id).Name;

            return name;
        }

        public static (int?, decimal?) GetProductSales(int id, int month)
        {
            using var context = new BookStoreContext();

            var productSales = from order in context.Orders
                               join orderPosition in context.OrderDetails on order.Id equals orderPosition.OrderId
                               join book in context.Books on orderPosition.BookId equals book.Id
                               where book.Id == id && order.Date.Month == month
                               select new { Qty = orderPosition.Quantity, Total = orderPosition.Quantity * book.Price };

            var totalQty = productSales.Sum(p => p.Qty);
            var totalSum = productSales.Sum(p => p.Total);

            return (totalQty, totalSum);
        }

        public static (int?, decimal?) GetProductSales(string name, int month)
        {
            using var context = new BookStoreContext();

            var productSales = from order in context.Orders
                               join orderPosition in context.OrderDetails on order.Id equals orderPosition.OrderId
                               join book in context.Books on orderPosition.BookId equals book.Id
                               where book.Name == name && order.Date.Month == month
                               select new { Qty = orderPosition.Quantity, Total = orderPosition.Quantity * book.Price };

            var totalQty = productSales.Sum(p => p.Qty);
            var totalSum = productSales.Sum(p => p.Total);

            return (totalQty, totalSum);
        }

        public static List<Book> GetAllBooks()
        {
            using var context = new BookStoreContext();

            return context.Books.Include(b => b.Genres).ToList();
        }
    }
}
