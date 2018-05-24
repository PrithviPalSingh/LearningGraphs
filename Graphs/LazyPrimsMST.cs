using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    /// <summary>
    /// Running time is ELogE. Can put all edges in priority queue.
    /// Extra space E.
    /// Algo: Start with vertex 0 and greedily grow tree
    ///       Add to T the min weight edge with exactly one endpoint in T
    ///       Repeat until v-1 edges
    /// Mantain a priority queue of edges with at least one endpoint in T
    ///     - Key = Edge; Priority =  Weight of edge
    ///     - Delete min to determine next edge v-w to add to T
    ///     - Disregard ab edge if both endpoints v and w are in T
    ///     - Otherwise, let w be the vertes not in T
    ///         a. add to PQ any edge incident to w (assuming other endpoint not in T)
    ///         b. add w to T
    /// </summary>
    class LazyPrimsMST
    {
        private bool[] marked;

        private Queue<EdgeAPI> mst;

        private UnOrderedPriorityQueue<EdgeAPI> pq;

        public LazyPrimsMST(EdgeWeightedGraph ewg)
        {
            pq = new UnOrderedPriorityQueue<EdgeAPI>(ewg.Edges.Count);
            mst = new Queue<EdgeAPI>();
            marked = new bool[ewg.V];
            Visit(ewg, 0);

            while (!pq.IsEmpty())
            {
                EdgeAPI e = pq.DeleteMin();
                int v = e.Either();
                int w = e.Other(v);

                if (marked[v] && marked[w])
                {
                    continue;
                }

                mst.Enqueue(e);

                if (!marked[v])
                {
                    Visit(ewg, v);
                }

                if (!marked[w])
                {
                    Visit(ewg, w);
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

        private void Visit(EdgeWeightedGraph G, int v)
        {
            marked[v] = true;

            foreach (var item in G.Adjacent(v))
            {
                if (!marked[item.Other(v)])
                {
                    pq.Insert(item);
                }
            }
        }
    }
}
