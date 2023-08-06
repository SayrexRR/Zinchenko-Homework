using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle
{
    internal class SportCar : Car, IRecycable
    {
        public SportCar(string make, string model, int year) : base(make, model, year) { }

        public override void Drive()
        {
            Console.WriteLine($"Driving a fast sports car {make} {model}");
        }

        public override void Stop()
        {
            Console.WriteLine($"Stop the sport car {make} {model}");
        }

        public void RecycleToMetal()
        {
            Console.WriteLine("This sports car has been converted to metal");
        }
    }
}
