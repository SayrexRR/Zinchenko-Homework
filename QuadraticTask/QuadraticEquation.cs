using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuadraticTask
{
    public struct QuadraticEquation
    {
        public int A {  get; set; }
        public int B { get; set; }
        public int C { get; set; }

        public QuadraticEquation(int a, int b, int c)
        {
            A = a;
            B = b;
            C = c;
        }
    }
}
