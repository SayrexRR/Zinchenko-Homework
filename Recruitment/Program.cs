namespace Recruitment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Candidate[] candidates = 
            {
            new Candidate(0, new DateTime(1995, 1, 1)),
            new Candidate(3, new DateTime(2005, 1, 1)),
            new Candidate(2, new DateTime(1990, 1, 1))
            };

            foreach (var candidate in candidates)
            {
                try
                {
                    MailSender.SendMail(candidate);
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
}