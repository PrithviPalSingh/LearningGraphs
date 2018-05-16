using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    class FlowNetwork
    {
        private int v;

        private ICollection<FlowEdge>[] adj;

        public FlowNetwork(int v)
        {
            this.V = v;
            adj = new List<FlowEdge>[v];

            for (int i = 0; i < v; i++)
            {           
                adj[i] = new List<FlowEdge>();
            }
        }

        public int V { get => v; set => v = value; }

        public void AddEdge(FlowEdge e)
        {
            int v = e.From();
            int w = e.To();
            adj[v].Add(e); // Add forward edge
            adj[w].Add(e); // Add backward edge
        }

        public IEnumerable<FlowEdge> Adjacent(int vertex)
        {
            return adj[vertex];
        }
    }
}
