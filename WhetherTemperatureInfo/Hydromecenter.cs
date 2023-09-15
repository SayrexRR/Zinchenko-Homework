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

        private TemperatureInfo GetTemperatureByDate(DateTime date)
        {
            foreach (var temperature in temperatureArray)
            {
                if (temperature.Date == date)
                {
                    return temperature;
                }
            }

            return new TemperatureInfo(DateTime.MinValue, 0);
        }

        private TemperatureInfo[] GetTemperatureByPeriod(DateTime start, DateTime end)
        {
            var days = end.Day - start.Day;
            TemperatureInfo[] result = new TemperatureInfo[days+1];
            int i = 0;

            foreach (var temp in temperatureArray)
            {
                if (temp.Date >= start && temp.Date <= end)
                {
                    result[i++] = temp;
                }
            }

            return result;
        }

        public TemperatureInfo this[DateTime date]
        {
            get { return GetTemperatureByDate(date); }
        }

        public TemperatureInfo[] this[DateTime start, DateTime end]
        {
            get { return GetTemperatureByPeriod(start, end); }
        }
    }
}
