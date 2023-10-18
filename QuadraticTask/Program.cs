using System;
using System.Threading.Tasks;

namespace QuadraticTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<QuadraticEquation> equations = new List<QuadraticEquation>()
            {
                new QuadraticEquation(1, 3, -2),
                new QuadraticEquation(1, 1, 4),
                new QuadraticEquation(1, -3, 2),
                new QuadraticEquation(1, 3, 4),
                new QuadraticEquation(1, -2, -4)
            };

            foreach (var equation in equations)
            {
                Task<(double, double)> task1 = new Task<(double, double)>(() => QuadraticEquationSolver.CalculateStandart(equation));

                Task<(double, double)> task2 = new Task<(double, double)>(() => QuadraticEquationSolver.CalculateVietas(equation));

                task1.Start();
                task2.Start();

                Task<(double, double)> completedTask = Task.WhenAny(task1, task2).Result;

                Console.WriteLine($"Roots: {completedTask.Result.Item1:N2}, {completedTask.Result.Item2:N2}");
            }
        }
    }
}