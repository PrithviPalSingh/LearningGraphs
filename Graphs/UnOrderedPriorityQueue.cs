using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    class UnOrderedPriorityQueue<T> where T : EdgeAPI
    {
        T[] Items = null;
        int N = 0;

        public UnOrderedPriorityQueue(int capacity)
        {
            Items = new T[capacity];
        }

        public void Insert(T item)
        {
            //BH implementation
            Items[N++] = item;
            Swim(N - 1);
        }

        public T DeleteMax()
        {
            ////BH Implementation
            T max = Items[0];
            Exchange(0, --N);
            Sink(0);
            Items[N] = default(T);
            return max;
        }

        public T DeleteMin()
        {
            //////BH Implementation
            //T min = Items[--N];
            ////Exchange(0, --N);
            ////Sink(0);
            //Items[N] = default(T);
            //return min;

            T min = Items[0];
            Exchange(0, --N);
            Sink(0);
            Items[N] = default(T);
            return min;
        }

        public T Max()
        {
            int MaxIndex = 0;
            for (int i = 1; i < N; i++)
            {
                if (Greater(Items[MaxIndex], Items[i]))
                {
                    MaxIndex = i;
                }
            }

            return Items[MaxIndex];
        }

        public bool IsEmpty()
        {
            return N == 0;
        }

        private void Swim(int k)
        {
            while (k > 0 && Greater(Items[k / 2], Items[k]))
            {
                Exchange(k, k / 2);
                k = k / 2;
            }
        }

        private bool Greater(int i, int j)
        {
            return Items[i].CompareTo(Items[j]) > 0;
        }

        private void Sink(int k)
        {
            while (2 * k < N)
            {
                int j = 2 * k;

                if (j < N - 1 && Greater(j, j + 1))
                    j++;

                if (!Greater(k, j))
                    break;

                Exchange(k, j);
                k = j;
            }
        }

        private bool Greater(T a, T b)
        {
            return a.CompareTo(b) > 0;
        }

        private void Exchange(int i, int j)
        {
            var swap = Items[i];
            Items[i] = Items[j];
            Items[j] = swap;
        }
    }
}
