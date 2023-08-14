using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle
{
    internal class Truck : Car, IRecycable
    {
        public Truck(string make, string model, int year) : base(make, model, year) { }

        public override void Stop()
        {
            Console.WriteLine($"Stop the truck {make} {model}");
        }

        public void RecycleToMetal()
        {
            Console.WriteLine("This truck has been converted to metal");
        }

        public void LoadCargo()
        {
            Console.WriteLine($"Loading cargo into the {make} {model} truck.");
        }
    }
}
