using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvenCollection
{
    class EvenListWithYield : IEnumerable<int>
    {
        private int[] array = new int[16];

        public EvenListWithYield(int[] array)
        {
            this.array = array;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<int> GetEnumerator()
        {
            foreach (int number in array)
            {
                if (number % 2 == 0 && number != 0)
                {
                    yield return number;
                }
            }
        }
    }
}
