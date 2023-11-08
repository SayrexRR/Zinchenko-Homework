using EFCore.Controlls;
using EFCore.Models;

namespace EFCore
{
    public class Program
    {
        static void Main(string[] args)
        {
            var productInfo = DbController.GetProductSales("Phone", 10);

            Console.WriteLine(productInfo);
        }
    }
}