using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    /// <summary>
    /// Properties of shortes path:
    /// 1. Observe that SPT solution exists.
    /// 2. Can represent SPT with two vertex indexed array
    ///     2.1 distTo[v] - length of shortest path from s to v.
    ///     2.2 edgeTo[v] - last edge on shortest path from s to v.
    /// 3. Edge relaxation (Relax edge e = v->w):
    ///     3.1 distTo[v] is length of shortest known path from s to v.
    ///     3.2 distTo[w] is length of shortest known path from s to w.
    ///     3.3 edgeTo[w] is last edge on shortest known path from s to w.
    ///     3.4 edgeTo[v] is last edge on shortest known path from s to v.
    ///     3.5 Now if edge e=v->w gives us shorter path to w through v then-
    ///         Update distTo[w] and edgeTo[w].
    /// </summary>
    class ShortestPathTree
    {
        private EdgeWeightedDiGraph G;

        private int s;

        double[] distTo;

        DirectedEdgeAPI[] edgeTo;

        public ShortestPathTree(EdgeWeightedDiGraph G, int s)
        {
            this.G = G;
            this.s = s;
        }

        public double DistTo(int v)
        {
            return distTo[v];
        }

        public IEnumerable<DirectedEdgeAPI> PathTo(int v)
        {
            Stack<DirectedEdgeAPI> path = new Stack<DirectedEdgeAPI>();
            for (DirectedEdgeAPI e = edgeTo[v]; e != null; e = edgeTo[e.From()])
            {
                path.Push(e);
            }

            return path;
        }

        public void EdgeRelaxation(DirectedEdgeAPI e)
        {
            int v = e.From();
            int w = e.To();

            if (distTo[w] > (distTo[v] + e.Weight()))
            {
                distTo[w] = distTo[v] + e.Weight();
                edgeTo[w] = e;
            }
        }
    }
}
