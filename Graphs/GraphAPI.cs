using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    /// <summary>
    /// Degree - set of vertices adjacent to a vertex
    /// Average degree - 2 * (# of Edges) / (# of vertices)
    /// </summary>
    class GraphAPI
    {
        private int v;

        private IList<int>[] adj;

        /// <summary>
        /// Constructor to create an empty graph with v vertices
        /// </summary>
        /// <param name="v"></param>
        public GraphAPI(int v)
        {
            this.V = v;
            adj = new IList<int>[v];

            for (int i = 0; i < this.V; i++)
            {
                adj[i] = new List<int>();
            }
        }

        public int V { get => v; set => v = value; }

        /// <summary>
        /// Add an edge v-w
        /// </summary>
        /// <param name="v"></param>
        /// <param name="w"></param>
        public void AddEdge(int v, int w)
        {
            adj[v].Add(w);
            adj[w].Add(v);
        }

        /// <summary>
        /// Vertices adjacent to v
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public IEnumerable<int> Adjacent(int v)
        {
            return adj[v];
        }
    }
}
