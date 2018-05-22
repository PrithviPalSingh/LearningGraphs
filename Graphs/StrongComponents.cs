using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Kosaraju-Sharir algorithm (Twice DFS)
/// </summary>
namespace Graphs
{
    /// <summary>
    /// Vertices v and w are strongly connected if there is a directed path from v->w 
    /// and a directed path from w->v
    /// Key property is EQUIVALENCE RELATION
    ///     1. v is strongly connected to v
    ///     2. if v is strongly connected to w, the w is strongly connected to v
    ///     3. if v is strongly connected to w and w to x, then v is strongly connected to x
    /// A STRONG COMPONENT is a maximal subset of strongly connected vertices
    /// </summary>
    class StrongComponents
    {
        private bool[] Marked;

        private int[] Id;

        private int count;

        /// <summary>
        /// Compute topological order (reverse post order) in kernel DAG
        /// Run DFS, considering vertices in reverse topological order
        /// </summary>
        /// <param name="gapi"></param>
        /// <param name="gapiReverse"></param>
        public StrongComponents(DiaGraphAPI gapi, DiaGraphAPI gapiReverse)
        {
            Marked = new bool[gapi.V];
            Id = new int[gapi.V];

            TopologicalSort ts = new TopologicalSort(gapiReverse);

            foreach (var item in ts.IterateReversePO())
            {

                if (!Marked[item])
                {
                    DFS(gapi, item);
                    count++;
                }
            }
        }

        private void DFS(DiaGraphAPI gapi, int v)
        {
            Marked[v] = true;
            Id[v] = count;
            foreach (var item in gapi.Adjacent(v))
            {
                if (!Marked[item])
                {
                    DFS(gapi, item);
                }
            }
        }

        private bool HasPathTo(int v)
        {
            return Marked[v];
        }

        public int Count()
        {
            return count;
        }

        public int ConnectedId(int v)
        {
            return Id[v];
        }

        public bool Connected(int v, int w)
        {
            return Id[v] == Id[w];
        }
    }
}