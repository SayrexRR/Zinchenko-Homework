using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvenCollection
{
    class EvenList : IEnumerable<int>, IEnumerator<int>
    {
        private int[] array = new int[16];

        private int position = -1;

        public object Current => Current;

        int IEnumerator<int>.Current => array[position];

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator(); ;
        }

        public bool MoveNext()
        {
            position++;
            do
            {
                position++;
            } while (position < array.Length && array[position] % 2 != 0);

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

        public IEnumerator<int> GetEnumerator()
        {
            return this;
        }

        public void Dispose()
        {
            
        }
    }
}
