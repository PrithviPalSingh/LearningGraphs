using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    /// <summary>
    /// Create a Auxilliary queue and repeat the following until queue is empty
    /// 1. Remove vertes v from queue
    /// 2. Add to queue all unmarked veritices adjacent to v and mark them.
    /// 
    /// Properties:
    /// 1. BFS computes shortest path (fewer # of edges) from s 
    ///    to all other vertices in a graph in time proportional to E+V.
    /// 2. BFS keep unmarked vertices in QUEUE while DFS keep them in STACK.
    /// 3. Correctness:
    ///         Queue always consists of zero or more vertices of distance
    ///         k from s, followed by zero or more vertices of distance k+1 from s.
    /// </summary>
    class BreadthFirstSearch
    {
        private bool[] Marked;

        private int[] EdgeTo;

        /// <summary>
        /// Not used need to understand while revision
        /// </summary>
        private int[] DistTo;

        private int S;

        public BreadthFirstSearch(GraphAPI gapi, int s)
        {
            Marked = new bool[gapi.V];
            EdgeTo = new int[gapi.V];
            DistTo = new int[gapi.V];
            this.S = s;
            BFS(gapi, s);
        }

        private void BFS(GraphAPI gapi, int s)
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
