using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    /// <summary>
    /// Algo: Mantain a PQ of vertices connected by an edge to Y
    ///       where priority of vertex v = weight of shortest edge connecting v to T
    ///       <<PQ has at most one entry per vertex>>
    ///       - Delete min vertex v and add its associated edge e = v-w to T
    ///       - Update PQ by considering edege e = v-w incident to v
    ///         - Ignore if x in already added to T
    ///         - add x to PQ if not already added to T
    ///         - decrease priority of x if v-x becomes shortest edge connecting x to T
    /// </summary>
    class EagerPrimsMST
    {
        private EdgeAPI[] edgeTo;

        private double[] distTo;

        private Queue<EdgeAPI> mst;

        private MinIndexedPriorityQueue<double> pq;

        public EagerPrimsMST(EdgeWeightedGraph ewg)
        {
            edgeTo = new EdgeAPI[ewg.V];
            distTo = new double[ewg.V];
            pq = new MinIndexedPriorityQueue<double>(ewg.V);
            mst = new Queue<EdgeAPI>();

            for (int i = 0; i < ewg.V; i++)
            {
                distTo[i] = double.PositiveInfinity;
            }

            distTo[0] = 0.0;
            pq.insert(0, 0.0);

            while (!pq.IsEmpty())
            {
                int v = pq.DeleteMin();

                if (edgeTo[v] != null)
                    mst.Enqueue(edgeTo[v]);

                foreach (var item in ewg.Adjacent(v))
                {
                    EdgeRelaxation(item, v);
                }

            }
        }

        public void EdgeRelaxation(EdgeAPI e, int v)
        {
            if (!mst.Contains(e)) // No need to relax the edge if it is already a part of MST
            {
                int w = e.Other(v);

                if (distTo[w] > e.Weight)
                {
                    distTo[w] = e.Weight;
                    edgeTo[w] = e;

                    if (pq.contains(w))
                        pq.decreaseKey(w, distTo[w]);
                    else
                        pq.insert(w, distTo[w]);
                }
            }
        }

        public IEnumerable<EdgeAPI> Edges()
        {
            return edgeTo;
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