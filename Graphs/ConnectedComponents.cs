using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    /// <summary>
    /// Vertices v and w are connected if there is a path between them.
    /// Goal: Pre process graph to answer queries of the for "v is connected to w".
    ///       in constant time.
    /// Algorithm:
    ///     (Partition vertices into connected components)
    ///     1. Initialize all the vertices as unmarked
    ///     2. For each unmarked vertices, run DFS to identify all the 
    ///        vertices discovered as part of the same components
    ///        
    /// DFS for normal DFS and connected components is same with one difference, to 
    /// EDGETO for DFS and ID(root node) array in case of connected components.
    /// </summary>
    class ConnectedComponents
    {
        private bool[] Marked;

        private int[] Id;

        private int count;

        public ConnectedComponents(GraphAPI gapi)
        {
            Marked = new bool[gapi.V];
            Id = new int[gapi.V];

            for (int i = 0; i < gapi.V; i++)
            {
                if (!Marked[i])
                {
                    DFS(gapi, i);
                    count++;
                }
            }

        }

        private void DFS(GraphAPI gapi, int v)
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
