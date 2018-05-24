using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    /// <summary>
    /// Cut: A cut in a grap is a partition of its vertices into two non-empty sets
    /// Crossing Edges: Connects a vertex in one set to vertex in the other
    /// Cut property: Given any cut, the crossing edge of min weight in in MST
    /// Algo: Consider edges in ascending order of weight
    ///       Add next edge to tree T unless doing so would create a cycle
    /// SINGLE LINK CLUSTERING can be achieve using this
    /// </summary>
    class KruskalMST
    {
        private Queue<EdgeAPI> mst = new Queue<EdgeAPI>();

        public KruskalMST(EdgeWeightedGraph G)
        {
            UnOrderedPriorityQueue<EdgeAPI> pq = new UnOrderedPriorityQueue<EdgeAPI>(G.Edges.Count);

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
