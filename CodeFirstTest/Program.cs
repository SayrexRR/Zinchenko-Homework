using CodeFirstTest.Models;

namespace CodeFirstTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var bookStoreContext = new BookStoreContext();

            DbInitializer.Initialize(bookStoreContext);
            
        }
    }
}