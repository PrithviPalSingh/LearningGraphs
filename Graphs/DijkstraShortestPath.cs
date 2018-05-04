using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
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
