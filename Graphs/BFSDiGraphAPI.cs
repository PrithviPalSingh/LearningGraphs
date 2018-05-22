using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    /// <summary>
    /// Web crawler can be implemented using BFS
    /// </summary>
    class BFSDiGraphAPI
    {
        private bool[] Marked;

        private int[] EdgeTo;

        /// <summary>
        /// Not used need to understand while revision
        /// </summary>
        private int[] DistTo;

        private int S;

        public BFSDiGraphAPI(DiaGraphAPI gapi, int s)
        {
            Marked = new bool[gapi.V];
            EdgeTo = new int[gapi.V];
            DistTo = new int[gapi.V];
            this.S = s;
            BFS(gapi, s);
        }

        private void BFS(DiaGraphAPI gapi, int s)
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(s);
            Marked[s] = true;

            while (queue.Count > 0)
            {
                int v = queue.Dequeue();
                foreach (var w in gapi.Adjacent(v))
                {
                    if (!Marked[w])
                    {
                        queue.Enqueue(w);
                        Marked[w] = true;
                        EdgeTo[w] = v;
                        DistTo[w] = DistTo[v] + 1;
                    }
                }
            }
        }

        public IEnumerable<int> PathTo(int v)
        {
            if (!HasPathTo(v))
            {
                return null;
            }

            Stack<int> path = new Stack<int>();
            for (int i = v; i != S; i = EdgeTo[i])
            {
                path.Push(i);
            }

            path.Push(S);
            return path;
        }

        private bool HasPathTo(int v)
        {
            return Marked[v];
        }
    }
}

