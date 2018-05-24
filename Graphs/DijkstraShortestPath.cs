using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    /// <summary>
    /// Consider vertices in increasing order of distance from s
    ///     (non-tree vertex with lowest distTo[] value)
    /// Add vertex to tree an relax all edges pointing from that vertex
    /// * Every edge v-w is relaxed only one (when v is relaxed)
    /// Prim's and Dijkstra's algo are essentially the same and distinction is:
    ///     * Prim's consider next vertex as closest vertex to the tree (via an undirected graph)
    ///     * While Dijkstra's algo consider closest vertex to the source (via a directed path)
    /// Basically Prim's, Dijkstra's, BFS and DFS are all in same family of algorithms
    ///     * All compute a graph's spanning tree
    /// </summary>
    class DijkstraShortestPath
    {
        private DirectedEdgeAPI[] edgeTo;

        private double[] distTo;

        private IndexedMinPQ<double> pq;

        public DijkstraShortestPath(EdgeWeightedDiGraph DG, int s)
        {
            EdgeTo = new DirectedEdgeAPI[DG.V];
            DistTo = new double[DG.V];
            pq = new IndexedMinPQ<double>(DG.V);

            for (int i = 0; i < DG.V; i++)
            {
                DistTo[i] = double.PositiveInfinity;
            }

            DistTo[s] = 0;

            pq.insert(s, 0.0);

            while (!pq.isEmpty())
            {
                int v = pq.deleteMin();

                foreach (DirectedEdgeAPI e in DG.Adj(v))
                {
                    EdgeRelaxation(e);
                }
            }
        }

        public double[] DistTo { get => distTo; set => distTo = value; }
        internal DirectedEdgeAPI[] EdgeTo { get => edgeTo; set => edgeTo = value; }

        public void EdgeRelaxation(DirectedEdgeAPI e)
        {
            int v = e.From();
            int w = e.To();

            if (DistTo[w] > (DistTo[v] + e.Weight()))
            {
                DistTo[w] = DistTo[v] + e.Weight();
                EdgeTo[w] = e;

                if (pq.contains(w))
                    pq.decreaseKey(w, DistTo[w]);
                else
                    pq.insert(w, DistTo[w]);
            }
        }
    }
}
