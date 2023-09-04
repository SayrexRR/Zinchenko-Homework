using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvenCollection
{
    class EvenList : IEnumerable, IEnumerator
    {
        private int[] array = new int[16];

        private int position = -1;

        public object Current => array[position];

        public IEnumerator GetEnumerator()
        {
            return this;
        }

        public bool MoveNext()
        {
            position++;
            while (position < array.Length && array[position] % 2 != 0)
            {
                position++;
            }

            return position < array.Length;
        }

        public void Reset()
        {
            position = -1;
        }

        public void AddArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                this.array[i] = array[i];
            }
        }
    }
}
