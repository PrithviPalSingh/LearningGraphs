using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    /// <summary>
    /// 1. If there is no negative cycle, there is a SPT and vice-versa
    /// 2. Repeat V times
    ///     - Relax each edge
    /// 3. Detect a negative cycle using Bellman-ford algo
    ///     - If a vertex v is updated in phase v, there exisits a ngative cycle
    ///       and can trace back edgeTo[v] entries to find it
    /// 4. Arbitrage detection
    /// </summary>
    class BellmanFordShortestPath
    {
        private DirectedEdgeAPI[] edgeTo;

        private double[] distTo;

        public BellmanFordShortestPath(EdgeWeightedDiGraph DG, int s)
        {
            EdgeTo = new DirectedEdgeAPI[DG.V];
            DistTo = new double[DG.V];

            for (int i = 0; i < DG.V; i++)
            {
                DistTo[i] = double.PositiveInfinity;
            }

            DistTo[s] = 0;

            for (int i = 0; i < DG.V; i++)
            {
                for (int v = 0; v < DG.V; v++)
                {
                    foreach (var e in DG.Adj(v))
                    {
                        EdgeRelaxation(e);
                    }
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
            }
        }
    }
}
