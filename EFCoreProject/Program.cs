using EFCoreProject.DBRepositories;

namespace EFCoreProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string productName = "Phone";
            int month = 10;

            var salesInfo = DBRepository.GetProductSales(productName, month);

            Console.WriteLine($"Product: {productName}, quontity: {salesInfo.Item1}, total price: {salesInfo.Item2:C}");
        }
    }
}