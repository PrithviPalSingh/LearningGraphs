using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    /// <summary>
    /// An edge weighted digraph, source vertex s and target vertex t
    /// Cut: an st-Cut (cut) is a partition of vertices into two disjoint 
    /// sets, with s is in one set A nad t in the other set B.
    /// Capacity: Is the sum of capacities of the edges from A to B.
    /// 
    /// Min-Cut: Find the cut with minimum capacity.
    /// 
    /// st-Flow: is an assignment of values to the edges such that:
    ///          - Capacity constraint: 0 <= edge's flow <= edge's capacity
    ///          - Local equilibrium: inflow == outflow
    ///          - outflow of s == inflow of t
    /// Max-Flow: Value of a flow is the inflow at t
    /// 
    /// Augmenting Path: Find an undirected path from s to t such that:
    ///          - Can increase flow on the forward edges (not full)
    ///          - Can decrease flow in the backward edge (not empty)
    ///          - For a certain path bottle neck will be minimum capacity of edges 
    ///            building this path
    ///            
    /// Ford-Fulkerson algorithm:
    ///          - Start with 0 flow
    ///          - While there exists an augmenting path:
    ///             - Find an augmenting path
    ///             - Compute bottleneck capacity
    ///             - Increase flow on that path by bottleneck capacity
    /// </summary>
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
