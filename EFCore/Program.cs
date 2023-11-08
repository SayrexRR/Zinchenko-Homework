using EFCore.Controllers;

namespace EFCore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var salesInfo = DbController.GetProductSales("Phone", 10);

            Console.WriteLine(salesInfo);
        }
    }
}