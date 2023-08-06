namespace Vehicle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SportCar sportCar = new("Subaru", "BRZ", 2022);
            Truck truck = new("Renault Trucks", "T High", 2021);

            sportCar.Drive();
            sportCar.Stop();
            sportCar.RecycleToMetal();

            Console.WriteLine();

            truck.Drive();
            truck.Stop();
            truck.LoadCargo();
            truck.RecycleToMetal();
        }
    }
}