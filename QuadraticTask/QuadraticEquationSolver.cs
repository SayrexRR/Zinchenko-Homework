using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuadraticTask
{
    public class QuadraticEquationSolver
    {
        private static Random random = new Random();

        public static (double, double) CalculateStandart(QuadraticEquation equation)
        {
            double Disc = Math.Pow(equation.B, 2) - 4 * equation.A * equation.C;

            Thread.Sleep(random.Next(1, 4) * 1000);

            if (Disc < 0)
            {
                return (double.NaN, double.NaN);
            }
            else
            {
                double sqrtDisc = Math.Sqrt(Disc);

                double x1 = (-equation.B + sqrtDisc) / (2 * equation.A);
                double x2 = (-equation.B - sqrtDisc) / (2 * equation.A);

                return (x1, x2); ;
            }
        }

        public static (double, double) CalculateVietas(QuadraticEquation equation)
        {
            double sumOfRoots = -equation.B / equation.A;
            double productOfRoots = equation.C / equation.A;

            Thread.Sleep(random.Next(1, 4) * 1000);

            double x1 = (sumOfRoots + Math.Sqrt(sumOfRoots * sumOfRoots - 4 * productOfRoots)) / 2;
            double x2 = (sumOfRoots - Math.Sqrt(sumOfRoots * sumOfRoots - 4 * productOfRoots)) / 2;

            return (x1, x2);
        }
    }
}
