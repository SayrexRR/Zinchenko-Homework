using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruitment
{
    class Candidate
    {
        public int Expiriance { get; }
        public DateTime DateOfBirth { get; }
        public int Age
        {
            get
            {
                return DateTime.Now.Year - DateOfBirth.Year;
            }
        }

        public Candidate(int expiriance, DateTime dateOfBirth)
        {
            Expiriance = expiriance;
            DateOfBirth = dateOfBirth;
        }
    }
}
