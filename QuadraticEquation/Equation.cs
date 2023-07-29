using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuadraticEquation
{
    public class Equation
    {
        public double A { get; private set; }
        public double B { get; private set; }
        public double C { get; private set; }

       
        public Equation(double a, double b, double c)
        {
            A = a;
            B = b;
            C = c;
        }

        public string GetResult()
        {
            double x1, x2;
            double discriminant = GetDiscriminant();

            if (discriminant > 0)
            {
                x1 = (-B + Math.Sqrt(discriminant)) / 2 * A;
                x2 = (-B - Math.Sqrt(discriminant)) / 2 * A;

                return $"x1 = {x1}; x2 = {x2}";
            }
            else if (discriminant == 0)
            {
                x1 = (-B + Math.Sqrt(discriminant)) / 2 * A;

                return $"x = {x1}";
            }

            return "Discriminant < 0. Equation has no real roots";
        }

        double GetDiscriminant()
        {
            return Math.Pow(B, 2) - 4 * A * C;
        }
    }
}
