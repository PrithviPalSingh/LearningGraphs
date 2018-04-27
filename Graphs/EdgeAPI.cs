using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    class EdgeAPI : IComparable<EdgeAPI>
    {
        private int v;

        private int w;

        private double weight;

        public EdgeAPI(int v, int w, double weight)
        {
            this.V = v;
            this.W = w;
            this.Weight = weight;
        }

        public int V { get => v; set => v = value; }
        public int W { get => w; set => w = value; }
        public double Weight { get => weight; set => weight = value; }

        public int CompareTo(EdgeAPI other)
        {
            if (this.Weight < other.Weight)
            {
                return -1;
            }
            else if (this.Weight > other.Weight)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public int Either()
        {
            return V;
        }

        public int Other(int vertex)
        {
            if (vertex == V)
                return W;

            return V;
        }


    }
}
