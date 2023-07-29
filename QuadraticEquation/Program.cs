namespace QuadraticEquation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input A");
            double a = double.Parse(Console.ReadLine());
            Console.WriteLine("Input B");
            double b = double.Parse(Console.ReadLine());
            Console.WriteLine("Input C");
            double c = double.Parse(Console.ReadLine());

            Equation equation = new(a, b, c);

            string result = equation.GetResult();

            Console.WriteLine(result);

            Console.WriteLine($"A = {equation.A}, B = {equation.B}, C = {equation.C}");
        }
    }
}