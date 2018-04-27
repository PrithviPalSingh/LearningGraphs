using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    class KruskalMST
    {
        private Queue<EdgeAPI> mst = new Queue<EdgeAPI>();

        public KruskalMST(EdgeWeightedGraph G)
        {
            UnOrderedPriorityQueue<EdgeAPI> pq = new UnOrderedPriorityQueue<EdgeAPI>(G.V);

            foreach (EdgeAPI item in G.Edges)
            {
                pq.Insert(item);
            }

            QuickUnionUF uf = new QuickUnionUF(G.V);

            while (!pq.IsEmpty() && (mst.Count < G.V - 1))
            {
                EdgeAPI e = pq.DeleteMin();
                int v = e.Either();
                int w = e.Other(v);

                if (!uf.Connected(v, w))
                {
                    uf.Union(v, w);
                    mst.Enqueue(e);
                }
            }
        }

        public IEnumerable<EdgeAPI> Edges()
        {
            return mst;
        }

        public double Weight()
        {
            var weight = 0.00;
            foreach (var item in mst)
            {
                weight += item.Weight;
            }

            return weight;
        }
    }
}
