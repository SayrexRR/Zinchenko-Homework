using CodeFirstTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstTest
{
    public static class DbInitializer
    {
        public static void Initialize(BookStoreContext context)
        {

            var genre1 = new Genre { Name = "Novel" };
            var genre2 = new Genre { Name = "Mystery" };
            var genre3 = new Genre { Name = "Science Fiction" };
            var genre4 = new Genre { Name = "Adventure" };
            var genre5 = new Genre { Name = "Horror" };
            var genre6 = new Genre { Name = "Romance" };
            var genre7 = new Genre { Name = "Drama" };
            var genre8 = new Genre { Name = "Fanfiction" };
            var genre9 = new Genre { Name = "Biography" };
            var genre10 = new Genre { Name = "Fantasy" };
            var genre11 = new Genre { Name = "Detective" };

            var genres = new List<Genre> { genre1, genre2, genre3,
                                            genre4, genre5, genre6,
                                            genre7, genre8, genre9,
                                            genre10, genre11 };


            context.Genres.AddRange(genres);

            var books = new List<Book>()
            {
                new Book() { Name = "Pride and Prejudice", Author = "Jane Austen", Genres = new List<Genre>{genre6}, Price = 850 },
                new Book() { Name = "A Game of Thrones", Author = "George R.R. Martin", Genres = new List<Genre>{genre10, genre4}, Price = 1700 },
                new Book() { Name = "Harry Potter and the Philosopher's Stone", Author = "J.K. Rowling", Genres = new List<Genre>{genre10, genre2}, Price = 1500 },
                new Book() { Name = "Sherlock Holmes", Author = "Arthur Conan Doyle", Genres = new List<Genre>{genre11}, Price = 350 },
                new Book() { Name = "Ender's Game", Author = "Orson Scott Card", Genres = new List<Genre>{genre3}, Price = 900 },
                new Book() { Name = "Things Fall Apart", Author = "Chinua Achebe", Genres = new List<Genre>{genre6}, Price = 400 },
                new Book() { Name = "The Shining", Author = "Stephen King", Genres = new List<Genre>{genre5}, Price = 500 },
            };

            context.Books.AddRange(books);

            var clients = new List<Client>()
            {
                new Client() { FirstName = "John", LastName = "Smith" },
                new Client() { FirstName = "Sarah", LastName = "Johnson" },
                new Client() { FirstName = "David", LastName = "Williams" },
                new Client() { FirstName = "Emily", LastName = "Davis" },
                new Client() { FirstName = "Michael", LastName = "Brown" },
                new Client() { FirstName = "Robert", LastName = "Anderson" },
            };

            context.Clients.AddRange(clients);

            var emploees = new List<Employee>()
            {
                new Employee() { FirstName = "Elizabeth", LastName = "White" },
                new Employee() { FirstName = "Christopher", LastName = "Wilson" },
                new Employee() { FirstName = "Jennifer", LastName = "Martinez" },
                new Employee() { FirstName = "William", LastName = "Jones" },
            };

            var positions = new List<Position>()
            {
                new Position() { Name = "Manager" },
                new Position() { Name = "Seller" },
                new Position() { Name = "Consultant" },
                new Position() { Name = "Head" },
            };

            emploees[0].Position = positions[2];
            emploees[1].Position = positions[1];
            emploees[2].Position = positions[3];
            emploees[3].Position = positions[0];

            context.Positions.AddRange(positions);

            context.Employees.AddRange(emploees);

            var orders = new List<Order>()
            {
                new Order() { Employee = emploees[0], Client = clients[4] },
                new Order() { Employee = emploees[2], Client = clients[0] },
                new Order() { Employee = emploees[1], Client = clients[1] },
                new Order() { Employee = emploees[0], Client = clients[3] },
                new Order() { Employee = emploees[2], Client = clients[2] },
                new Order() { Employee = emploees[0], Client = clients[2] },
            };

            context.Orders.AddRange(orders);

            var orderDetails = new List<OrderDetail>()
            {
                new OrderDetail() { Book =  books[5], Order = orders[0], Quantity = 1, Position = 1 },
                new OrderDetail() { Book =  books[1], Order = orders[0], Quantity = 2, Position = 2 },
                new OrderDetail() { Book =  books[0], Order = orders[1], Quantity = 1, Position = 1 },
                new OrderDetail() { Book =  books[6], Order = orders[2], Quantity = 1, Position = 1 },
                new OrderDetail() { Book =  books[2], Order = orders[2], Quantity = 3, Position = 2 },
                new OrderDetail() { Book =  books[4], Order = orders[3], Quantity = 1, Position = 1 },
                new OrderDetail() { Book =  books[4], Order = orders[4], Quantity = 1, Position = 1 },
                new OrderDetail() { Book =  books[0], Order = orders[5], Quantity = 2, Position = 1 },
                new OrderDetail() { Book =  books[2], Order = orders[5], Quantity = 1, Position = 2 },
                new OrderDetail() { Book =  books[6], Order = orders[5], Quantity = 1, Position = 3 },
            };

            context.OrderDetails.AddRange(orderDetails);

            context.SaveChanges();
        }
    }
}
