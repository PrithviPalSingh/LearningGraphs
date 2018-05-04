using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    class DirectedEdgeAPI
    {
        private int v;

        private int w;

        private double weight;

        public DirectedEdgeAPI(int v, int w, double weight)
        {
            this.V = v;
            this.W = w;
            this.Weight1 = weight;
        }

        public int V { get => v; set => v = value; }
        public int W { get => w; set => w = value; }
        public double Weight1 { get => weight; set => weight = value; }

        public int From()
        { return V; }

        public int To()
        { return W; }

        public double Weight()
        { return Weight1; }
    }
}
