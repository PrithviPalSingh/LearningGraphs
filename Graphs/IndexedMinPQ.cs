using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    class IndexedMinPQ<T> where T : IComparable<T>
    {
        int NMax;
        int N;
        int[] heap;
        int[] index;
        T[] keys;

        public IndexedMinPQ(int NMax)
        {
            this.NMax = NMax;
            N = 0;
            keys = new T[NMax + 1];
            heap = new int[NMax + 1];
            index = new int[NMax + 1];
            for (int i = 0; i <= NMax; i++)
                index[i] = -1;
        }

        void swap(int i, int j)
        {
            int t = heap[i]; heap[i] = heap[j]; heap[j] = t;
            index[heap[i]] = i; index[heap[j]] = j;
        }

        private bool greater(int i, int j)
        {
            return keys[i].CompareTo(keys[j]) > 0;
        }

        void bubbleUp(int k)
        {
            while (k > 1 && greater(heap[k / 2], heap[k]))
            {
                swap(k, k / 2);
                k = k / 2;
            }
        }

        void bubbleDown(int k)
        {
            int j;
            while (2 * k <= N)
            {
                j = 2 * k;
                if (j < N && greater(heap[j], heap[j + 1]))// keys[heap[j]] > keys[heap[j + 1]])
                    j++;

                if (!greater(heap[k], heap[j]))//keys[heap[k]] <= keys[heap[j]])
                    break;

                swap(k, j);
                k = j;
            }
        }
        // check if the PQ is empty
        public bool isEmpty()
        {
            return N == 0;
        }

        // check if i is an index on the PQ
        public bool contains(int i)
        {
            return index[i] != -1;
        }

        // return the number of elements in the PQ
        public int size()
        {
            return N;
        }

        // associate key with index i; 0 < i < NMAX
        public void insert(int i, T key)
        {
            N++;
            index[i] = N;
            heap[N] = i;
            keys[i] = key;
            bubbleUp(N);
        }

        // returns the index associated with the minimal key
        int minIndex()
        {
            return heap[1];
        }

        // returns the minimal key
        public T minKey()
        {
            return keys[heap[1]];
        }

        // delete the minimal key and return its associated index
        // Warning: Don't try to read from this index after calling this function
        public int deleteMin()
        {
            int min = heap[1];
            swap(1, N--);
            bubbleDown(1);
            index[min] = -1;
            heap[N + 1] = -1;
            return min;
        }

        // returns the key associated with index i
        T keyOf(int i)
        {
            return keys[i];
        }

        // change the key associated with index i to the specified value
        void changeKey(int i, T key)
        {
            keys[i] = key;
            bubbleUp(index[i]);
            bubbleDown(index[i]);
        }

        // decrease the key associated with index i to the specified value
        public void decreaseKey(int i, T key)
        {
            keys[i] = key;
            bubbleUp(index[i]);
        }

        // increase the key associated with index i to the specified value
        void increaseKey(int i, T key)
        {
            keys[i] = key;
            bubbleDown(index[i]);
        }

        // delete the key associated with index i
        public void deleteKey(int i)
        {
            int ind = index[i];
            swap(ind, N--);
            bubbleUp(ind);
            bubbleDown(ind);
            index[i] = -1;
        }
    }
}
