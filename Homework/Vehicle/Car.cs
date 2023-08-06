using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle
{
    public abstract class Car
    {
        protected string make;
        protected string model;
        protected int year;

        public Car(string make, string model, int year)
        {
            this.make = make;
            this.model = model;
            this.year = year;
        }

        public abstract void Stop();

        public virtual void Drive()
        {
            Console.WriteLine($"Driving the {make} {model}");
        }
    }
}
