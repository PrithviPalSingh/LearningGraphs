using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    /// <summary>
    /// 1. Mark vertex v as visited
    /// 2. Recursively visit all unmarked vertices w adjacent to v.
    /// </summary>
    class DepthFirstSearch
    {
        private bool[] Marked;

        private int[] EdgeTo;

        private int S;

        /// <summary>
        /// 1. DFS marks all the vertices connected to s in time proportional
        ///    to sum of their degrees.
        /// 2. If w is marked, then w is connected to s. 
        /// 3. If w is connected to s, then w is marked.
        /// 4. Visit each vertex once.
        /// </summary>
        /// <param name="gapi"></param>
        /// <param name="s"></param>
        public DepthFirstSearch(GraphAPI gapi, int s)
        {
            Marked = new bool[gapi.V];
            EdgeTo = new int[gapi.V];
            this.S = s;
            DFS(gapi, s);
        }

        public DepthFirstSearch(DiaGraphAPI gapi, int s)
        {
            Marked = new bool[gapi.V];
            EdgeTo = new int[gapi.V];
            this.S = s;
            DFS(gapi, s);
        }

        private void DFS(GraphAPI gapi, int v)
        {
            Marked[v] = true;

            foreach (var item in gapi.Adjacent(v))
            {
                if (!Marked[item])
                {
                    DFS(gapi, item);
                    EdgeTo[item] = v;
                }
            }
        }

        private void DFS(DiaGraphAPI gapi, int v)
        {
            Marked[v] = true;

            foreach (var item in gapi.Adjacent(v))
            {
                if (!Marked[item])
                {
                    DFS(gapi, item);
                    EdgeTo[item] = v;
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
