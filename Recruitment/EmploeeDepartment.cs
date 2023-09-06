using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruitment
{
    class EmploeeDepartment
    {
        public static bool isApprove(Candidate candidate)
        {
            if (candidate.Expiriance >= 2) return true;

            return false;
        }

        public static decimal Salary(Candidate candidate)
        {
            return (candidate.Expiriance * 0.5M) * 20000M;
        }
    }
}
