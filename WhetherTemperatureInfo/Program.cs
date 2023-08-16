namespace WhetherTemperatureInfo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Hydromecenter hydromecenter = new Hydromecenter();

            hydromecenter.AddWeather(new TemperatureInfo(new DateTime(2023, 08, 14), 27));
            hydromecenter.AddWeather(new TemperatureInfo(new DateTime(2023, 08, 15), 29));
            hydromecenter.AddWeather(new TemperatureInfo(new DateTime(2023, 08, 16), 28));
            hydromecenter.AddWeather(new TemperatureInfo(new DateTime(2023, 08, 17), 27));
            hydromecenter.AddWeather(new TemperatureInfo(new DateTime(2023, 08, 18), 29));
            hydromecenter.AddWeather(new TemperatureInfo(new DateTime(2023, 08, 19), 30));
            hydromecenter.AddWeather(new TemperatureInfo(new DateTime(2023, 08, 20), 28));


            hydromecenter[new DateTime(2023, 08, 15)].GetInfo();

            Console.WriteLine();

            TemperatureInfo[] tempPeriod = hydromecenter[new DateTime(2023, 08, 16), new DateTime(2023, 08, 19)];

            foreach (var temp in tempPeriod)
            {
                temp.GetInfo();
            }
        }
    }
}