using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhetherTemperatureInfo
{
    struct TemperatureInfo
    {
        string date;
        int temperature;
        double fTemperature;
        double kTemperature;

        public string Date
        {
            get { return date; }
        }

        public TemperatureInfo(string date, int temperature)
        {
            this.date = date;
            this.temperature = temperature;
            fTemperature = temperature * 1.8 + 32;
            kTemperature = temperature + 273.15;
        }

        public void GetInfo()
        {
            Console.WriteLine($"Date: {date}");
            Console.WriteLine($"Temperature in °C: {temperature} °C");
            Console.WriteLine($"Temperature in °F: {fTemperature} °F");
            Console.WriteLine($"Temperature in K: {kTemperature} K");
        }
    }
}
