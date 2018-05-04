using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    class EdgeWeightedDiGraph
    {
        private int v;

        private ICollection<DirectedEdgeAPI>[] adj;

        public EdgeWeightedDiGraph(int v)
        {
            this.V = v;
            adj = new ICollection<DirectedEdgeAPI>[v];
            for (int i = 0; i < v; i++)
            {
                adj[i] = new List<DirectedEdgeAPI>();
            }
        }

        public int V { get => v; set => v = value; }

        public void AddEdge(DirectedEdgeAPI e)
        {
            int v = e.From();
            adj[v].Add(e);
        }

        public IEnumerable<DirectedEdgeAPI> Adj(int v)
        {
            return adj[v];
        }
    }
}
