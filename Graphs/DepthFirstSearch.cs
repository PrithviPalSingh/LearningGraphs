using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    class DepthFirstSearch
    {
        private bool[] Marked;

        private int[] EdgeTo;

        private int S;

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
