using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruitment
{
    class Candidate : IComparable<Candidate>
    {
        public string Name { get; }
        public double Expiriance { get; set; }
        public DateTime DateOfBirth { get; }
        public int Age
        {
            get
            {
                return DateTime.Now.Year - DateOfBirth.Year;
            }
        }

        public Candidate(string name, double expiriance, DateTime dateOfBirth)
        {
            Name = name;
            Expiriance = expiriance;
            DateOfBirth = dateOfBirth;
        }


        public int CompareTo(Candidate? other)
        {
            if (other == null) return 1;

            double thisExpirience = Expiriance;
            double otherExpirience = other.Expiriance;

            if (thisExpirience < otherExpirience) return 1;
            if (thisExpirience == otherExpirience) return 0;

            if (thisExpirience > otherExpirience) return -1;

            return 0;
        }
    }
}
