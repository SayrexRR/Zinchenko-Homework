namespace Recruitment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Candidate> candidates = new()
            {
                new Candidate("John", 0.5, new DateTime(1995, 1, 1)),
                new Candidate("Sally", 1.5, new DateTime(2005, 1, 1)),
                new Candidate("Dastin", 2.7, new DateTime(1990, 1, 1)),
                new Candidate("Kate", 4.1, new DateTime(1995, 1, 1)),
                new Candidate("Stiv", 2.5, new DateTime(1993, 1, 1)),
                new Candidate("Dina", 2.8, new DateTime(2000, 1, 1))
            };

            

            try
            {
                Console.WriteLine("Name     Aproved");

                foreach (var candidate in EmploeeDepartment.GetCandidates(candidates))
                {
                    Console.WriteLine($"{candidate.Key.Name, -10} {candidate.Value, 5}");
                }
                Console.WriteLine(new string('*', 50));
            }
            catch (TooYoungException ex)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(ex.Message);
                Console.ResetColor();
                Console.WriteLine(new string('*', 50));
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ResetColor();
                Console.WriteLine(new string('*', 50));
            }
        }
    }
}