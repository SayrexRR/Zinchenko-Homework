using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReader
{
    class Page
    {
        public string Content { get; }
        public int Number { get; }

        public Page(string content, int number)
        {
            Content = content;
            Number = number;
        }
    }
}
