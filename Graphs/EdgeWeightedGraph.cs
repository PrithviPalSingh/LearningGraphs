using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    class EdgeWeightedGraph
    {
        private int v;

        private ICollection<EdgeAPI>[] collection;

        private ICollection<EdgeAPI> edges  = new List<EdgeAPI>();

        public EdgeWeightedGraph(int v)
        {
            this.V = v;
            Collection = new ICollection<EdgeAPI>[v];

            for (int i = 0; i < v; i++)
            {
                Collection[i] = new List<EdgeAPI>();
            }
        }

        public int V { get => v; set => v = value; }
        internal ICollection<EdgeAPI>[] Collection { get => collection; set => collection = value; }
        internal ICollection<EdgeAPI> Edges { get => edges; }

        public void Addedge(EdgeAPI e)
        {
            int v = e.Either();
            int w = e.Other(v);
            Collection[v].Add(e);
            Collection[w].Add(e);
            edges.Add(e);
        }

        public IEnumerable<EdgeAPI> Adjacent(int v)
        {
            return Collection[v];
        }
    }
}
