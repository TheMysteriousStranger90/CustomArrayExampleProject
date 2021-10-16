using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CustomArrayExampleProject
{
    public class CustomArray<T> : IEnumerable<T>
    {
        private int first;

        public int First
        {
            get { return this.first; }
            private set { this.first = value; }
        }

        public int Last
        {
            get { return this.First + this.Length - 1; }
        }

        private int length;

        public int Length
        {
            get { return this.length; }
            private set { this.length = value; }
        }

        private T[] _array;

        public T[] Array
        {
            get { return this._array; }
            set { this._array = value; }
        }

        public CustomArray(int first, int length)
        {
            if (length <= 0)
                throw new ArgumentException(nameof(Length), "Error");
            else
            {
                this.first = first;
                this.length = length;
                this._array = new T[length];
            }
        }

        public CustomArray(int first, IEnumerable<T> list)
        {
            if (list is null)
            {
                NullReferenceException ex = new NullReferenceException("Error (list is null)");
                throw ex;
            }
            else
            {
                if (list.Count() <= 0) throw new ArgumentException(nameof(list), "Error");
                {
                    this._array = list.ToArray();
                    this.First = first;
                    this.Length = _array.Length;
                }
            }
        }

        public CustomArray(int first, params T[] list)
        {
            if (list is null) throw new ArgumentNullException(nameof(list), "Error");
            else
            {
                if (list.Count() == 0) throw new ArgumentException(nameof(list), "Error");
                this._array = list;
                this.First = first;
                this.Length = _array.Count();
            }
        }

        public T this[int item]
        {
            get
            {
                if (item < this.First || item > this.First + this.Length)
                    throw new ArgumentException(nameof(item), "Error");
                else
                {
                    return Array[item - this.First];
                }
            }
            set
            {
                if (value is null) throw new ArgumentNullException(nameof(value), "Error");
                else if (item >= this.First + this.Length || item < this.First)
                    throw new ArgumentException(nameof(value), "Error");
                else Array[item - this.First] = value;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>) _array).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Array.GetEnumerator();
        }
    }
}