﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
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
            return Id[v] ==Id[w];
        }
    }
}
