namespace Recruitment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Candidate[] candidates = 
            {
            new Candidate("John", 0.5, new DateTime(1995, 1, 1)),
            new Candidate("Sally", 3.2, new DateTime(2005, 1, 1)),
            new Candidate("Dastin", 2.7, new DateTime(1990, 1, 1))
            };

            foreach (var candidate in candidates)
            {
                try
                {
                    MailSender.SendMail(candidate);
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

            Candidate candidate1 = new Candidate("Vill", 1.7, new DateTime(1995, 1, 1));
            Candidate candidate2 = new Candidate("Tomas", 3.2, new DateTime(2000, 1, 1));
            Candidate candidate3 = new Candidate("Martin", 3.7, new DateTime(1990, 1, 1));

            Candidate favoriteCandidate = EmploeeDepartment.FilterCandidate(candidate1, candidate2);
            favoriteCandidate = EmploeeDepartment.FilterCandidate(favoriteCandidate, candidate3);

            try
            {
                MailSender.SendMail(favoriteCandidate);
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