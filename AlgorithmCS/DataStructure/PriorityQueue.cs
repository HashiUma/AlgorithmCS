using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmCS.DataStructure
{
    class PriorityQueue<T> where T : IComparable<T>
    {
        private T[] _array;
        private bool _greater;
        public int Count { get; private set; } = 0;

        public PriorityQueue(int capacity, bool greater = true)
        {
            this._array = new T[capacity];
            this._greater = greater;
        }

        public void Enqueue(T item)
        {
            this._array[this.Count] = item;
            this.Count += 1;
            this._upHeap();
        }

        public T Dequeue()
        {
            this._swap(0, this.Count - 1);
            this.Count -= 1;
            this._downHeap();
            return this._array[this.Count];
        }


        private void _upHeap()
        {
            var n = this.Count - 1;
            while (n != 0)
            {
                var parent = (n - 1) / 2;
                if (this._compare(this._array[n], this._array[parent]) > 0)
                {
                    this._swap(n, parent);
                    n = parent;
                }
                else
                {
                    break;
                }
            }
        }

        private void _downHeap()
        {
            var parent = 0;
            while (true)
            {
                var child = 2 * parent + 1;
                if (child > this.Count - 1) break;

                if (child < this.Count - 1 && this._compare(this._array[child], this._array[child + 1]) < 0)
                {
                    child += 1;
                }

                if (this._compare(this._array[parent], this._array[child]) < 0)
                {
                    this._swap(parent, child);
                    parent = child;
                }
                else
                {
                    break;
                }
            }
        }

        private int _compare(T a, T b) => (this._greater ? 1 : -1) * a.CompareTo(b);

        private void _swap(int a, int b)
        {
            var tmp = this._array[a];
            this._array[a] = this._array[b];
            this._array[b] = tmp;
        }
    }
}
