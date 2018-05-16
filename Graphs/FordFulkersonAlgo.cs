using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    class FordFulkersonAlgo
    {
        private bool[] marked; // true if s->v path in residual n/w

        private FlowEdge[] edgeTo; // last edge on s->v path

        private double value; // value of flow

        public FordFulkersonAlgo(FlowNetwork G, int s, int t)
        {
            value = 0;

            while (HasAugmentingPath(G, s, t))
            {
                double bottleneck = double.PositiveInfinity;

                for (int v = t; v != s; v = edgeTo[v].Other(v))
                {
                    bottleneck = Math.Min(bottleneck, edgeTo[v].ResidualCapacityTo(v));
                }

                for (int v = t; v != s; v = edgeTo[v].Other(v))
                {
                    edgeTo[v].AddResidualFlowTo(v, bottleneck);
                }

                value += bottleneck;
            }
        }

        public double Value()
        {
            return value;
        }

        public bool inCut(int v)
        {
            return marked[v];
        }

        private bool HasAugmentingPath(FlowNetwork G, int s, int t)
        {
            edgeTo = new FlowEdge[G.V];
            marked = new bool[G.V];

            Queue<int> q = new Queue<int>();
            q.Enqueue(s);
            marked[s] = true;

            while (q.Count > 0)
            {
                int v = q.Dequeue();

                foreach (var e in G.Adjacent(v))
                {
                    int w = e.Other(v);

                    if (e.ResidualCapacityTo(w) > 0 && !marked[w])
                    {
                        edgeTo[w] = e;
                        marked[w] = true;
                        q.Enqueue(w);
                    }
                }
            }

            return marked[t];
        }
    }
}
