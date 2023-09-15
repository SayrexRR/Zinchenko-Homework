using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyListCollection
{
    class MyList : IList<uint>
    {
        private uint[] elements;
        private int count;

        public MyList()
        {
            elements = new uint[10];
            count = 0;
        }

        public uint this[int index]
        {
            get
            {
                if (index < 0 || index >= count)
                    throw new ArgumentOutOfRangeException(nameof(index));

                return elements[index];
            }
            set
            {
                if (index < 0 || index >= count)
                    throw new ArgumentOutOfRangeException(nameof(index));

                elements[index] = value;
            }
        }

        public int Count => count;

        public bool IsReadOnly => false;

        public void Add(uint item)
        {
            if (count == elements.Length / 2)
            {
                uint[] newArray = new uint[elements.Length * 2];
                elements.CopyTo(newArray, 0);
                elements = newArray;
            }

            elements[count++] = item;
        }

        public void Clear()
        {
            elements = new uint[0];
            count = 0;
        }

        public bool Contains(uint item)
        {
            for (int i = 0; i < count; i++)
            {
                if (elements[i] == item)
                    return true;
            }

            return false;
        }

        public void CopyTo(uint[] array, int arrayIndex)
        {
            uint[] arr = array;

            for (int i = 0; i < elements.Length; i++)
            {
                arr[arrayIndex++] = elements[i];
            }
        }

        public IEnumerator<uint> GetEnumerator()
        {
            for (int i = 0; i < count; i++)
                yield return elements[i];
        }

        public int IndexOf(uint item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (elements[i] == item)
                    return i;
            }

            return -1;
        }

        public void Insert(int index, uint item)
        {
            if ((count + 1 <= elements.Length) && (index < Count) && (index >= 0))
            {
                count++;

                for (int i = Count - 1; i > index; i--)
                {
                    elements[i] = elements[i - 1];
                }

                elements[index] = item;
            }
        }

        public bool Remove(uint item)
        {
            int index = IndexOf(item);
            if (index >= 0)
            {
                RemoveAt(index);
                return true;
            }

            return false;
        }

        public void RemoveAt(int index)
        {
            if ((index >= 0) && (index < Count))
            {
                for (int i = index; i < Count - 1; i++)
                    elements[i] = elements[i + 1];

                count--;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
