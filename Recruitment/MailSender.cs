using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruitment
{
    class MailSender
    {
        public static void SendMail(Candidate candidate)
        {
            

            if (candidate.Age <= 18)
            {
                throw new TooYoungException(candidate.Age);
            }

            string message = EmploeeDepartment.isApprove(candidate)
                ? $"Вітаю, Вас прийнято на работу.\nВаша зарплатня становить {EmploeeDepartment.Salary(candidate):C}" 
                : "Вибачте, але Ви нам не підходите";

            Console.WriteLine(message);
        }
    }

    public class TooYoungException : Exception
    {
        public int Age { get; private set; }

        public TooYoungException(int age)
        {
            Age = age;
        }
    }
}
