using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    class GraphAPI
    {
        private int v;

        private IList<int>[] adj;

        public GraphAPI(int v)
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
            adj[w].Add(v);
        }

        public IEnumerable<int> Adjacent(int v)
        {
            return adj[v];
        }
    }
}
