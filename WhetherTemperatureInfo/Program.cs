namespace WhetherTemperatureInfo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Hydromecenter hydromecenter = new Hydromecenter();

            hydromecenter.AddWeather(new TemperatureInfo("14.08.2023", 27));
            hydromecenter.AddWeather(new TemperatureInfo("15.08.2023", 29));
            hydromecenter.AddWeather(new TemperatureInfo("16.08.2023", 28));
            hydromecenter.AddWeather(new TemperatureInfo("17.08.2023", 27));
            hydromecenter.AddWeather(new TemperatureInfo("18.08.2023", 29));
            hydromecenter.AddWeather(new TemperatureInfo("19.08.2023", 30));
            hydromecenter.AddWeather(new TemperatureInfo("20.08.2023", 28));


            hydromecenter["15.08.2023"].GetInfo();

            Console.WriteLine();

            TemperatureInfo[] tempPeriod = hydromecenter["16.08.2023", "19.08.2023"];

            foreach (var temp in tempPeriod)
            {
                temp.GetInfo();
            }
        }
    }
}