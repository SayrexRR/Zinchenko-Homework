namespace Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Calculator<double> calculator = new(14.5, 0);
            calculator.DivideByZero += HandleDivideByZero;

            Console.WriteLine(calculator.Div());
        }

        static void HandleDivideByZero(object sender, EventArgs e)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Error: Division by zero is not allowed!");
            Console.ResetColor();
        }
    }
}