using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    class BreadthFirstSearch
    {
        private bool[] Marked;

        private int[] EdgeTo;

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
                foreach (var item in gapi.Adjacent(v))
                {
                    if (!Marked[item])
                    {
                        queue.Enqueue(item);
                        Marked[item] = true;
                        EdgeTo[item] = v;
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
