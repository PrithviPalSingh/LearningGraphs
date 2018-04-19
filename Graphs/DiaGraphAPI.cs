using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    class DiaGraphAPI
    {
        private int v;

        private IList<int>[] adj;

        public DiaGraphAPI(int v)
        {
            this.V = v;
            adj = new IList<int>[v];

            for (int i = 0; i < this.V; i++)
            {
                adj[i] = new List<int>();
            }
        }

        public int V { get => v; set => v = value; }

        public void AddEdge(int v, int w)
        {
            adj[v].Add(w);
            ////adj[w].Add(v); --- This is the major change b/w undirected graph and di graph
        }

        public IEnumerable<int> Adjacent(int v)
        {
            return adj[v];
        }
    }
}
