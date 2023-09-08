using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruitment
{
    class Candidate : IComparable
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

        public int CompareTo(object? obj)
        {
            if (obj == null)
                return 1;

            Candidate otherCandidate = obj as Candidate;

            if (otherCandidate == null)
                throw new ArgumentException("Об'єкт не є кандидатом");

            int thisExpirience = (int)Expiriance;
            int otherExpirience = (int)otherCandidate.Expiriance;

            return thisExpirience.CompareTo(otherExpirience);
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType()) 
                return false;

            Candidate otherCandidate = (Candidate)obj;
            return (int)Expiriance == (int)otherCandidate.Expiriance;
        }

        public override int GetHashCode()
        {
            return ((int)Expiriance).GetHashCode();
        }

        public static bool operator ==(Candidate c1, Candidate c2)
        {
            if (c1.Expiriance == c2.Expiriance)
                return true;

            if (c1 is null || c2 is null)
                return false;

            return c1.Equals(c2);
        }

        public static bool operator !=(Candidate c1, Candidate c2)
        {
            return !(c1.Expiriance == c2.Expiriance);
        }
    }
}
