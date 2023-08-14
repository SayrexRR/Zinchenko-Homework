using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhetherTemperatureInfo
{
    class Hydromecenter
    {
        private TemperatureInfo[] temperatureArray;
        private int temperatureIndex;

        public Hydromecenter()
        {
            temperatureArray = new TemperatureInfo[20];
            temperatureIndex = 0;
        }

        public void AddWeather(TemperatureInfo temperatureInfo)
        {
            if (temperatureIndex < temperatureArray.Length)
            {
                temperatureArray[temperatureIndex] = temperatureInfo;
                temperatureIndex++;
                return;
            }

            if (temperatureIndex > temperatureArray.Length)
            {
                Array.Resize(ref temperatureArray, temperatureArray.Length + 20);
                AddWeather(temperatureInfo);
            }
        }

        private TemperatureInfo GetTemperatureByDate(string date)
        {
            foreach (var temperature in temperatureArray)
            {
                if (temperature.Date == date)
                {
                    return temperature;
                }
            }

            return new TemperatureInfo("00.00.0000", 0);
        }

        private TemperatureInfo[] GetTemperatureByPeriod(string start, string end)
        {
            TemperatureInfo[] result = new TemperatureInfo[temperatureArray.Length]; ;
            int i = 0;

            foreach (var temp in temperatureArray)
            {
                if (string.Compare(temp.Date, start) >= 0 && string.Compare(temp.Date, end) <= 0)
                {
                    result[i++] = temp;
                }
            }

            var period = result.Where(t => t.Date != null).ToArray();

            return period;
        }

        public TemperatureInfo this[string date]
        {
            get { return GetTemperatureByDate(date); }
        }

        public TemperatureInfo[] this[string start, string end]
        {
            get { return GetTemperatureByPeriod(start, end); }
        }
    }
}
