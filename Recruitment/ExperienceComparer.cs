using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruitment
{
    class ExperienceComparer : IComparer<Candidate>
    {
        public int Compare(Candidate? x, Candidate? y)
        {
            return x.CompareTo(y);
        }
    }
}
