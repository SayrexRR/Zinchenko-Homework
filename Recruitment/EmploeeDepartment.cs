﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruitment
{
    class EmploeeDepartment
    {
        public static bool IsApproved(Candidate candidate)
        {
            if (candidate.Expiriance >= 2) 
                return true;

            return false;
        }

        public static decimal Salary(Candidate candidate)
        {
            return ((decimal)candidate.Expiriance * 0.5M) * 20000M;
        }

        public static Candidate FilterCandidate(Candidate c1, Candidate c2)
        {   
            if (c1.Expiriance > c2.Expiriance)
            {
                return c1;
            }
            if (c1 == c2)
            {
                int random = new Random().Next(1, 3);
                if (random == 1) return c1;
                if (random == 2) return c2;
            }

            return c2;
        }

        public static SortedDictionary<Candidate, bool> GetCandidates(int quote, IEnumerable<Candidate> candidates)
        {
            SortedDictionary<Candidate, bool> tryCandidates = new SortedDictionary<Candidate, bool>(new ExperienceComparer());
            Candidate candidate = null;

            foreach (Candidate item in candidates)
            {
                candidate = item;
                tryCandidates.Add(candidate, IsApproved(candidate));
            }



            return tryCandidates;
        }
    }
}
