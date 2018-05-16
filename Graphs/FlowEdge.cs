using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    class FlowEdge
    {
        private int v;

        private int w;

        private double capacity;

        private double flow;

        public FlowEdge(int v, int w, double capacity)
        {
            this.v = v;
            this.w = w;
            this.capacity = capacity;
        }

        public int From()
        {
            return v;
        }

        public int To()
        {
            return w;
        }

        public double Capacity()
        {
            return capacity;
        }

        public double Flow()
        {
            return flow;
        }

        public int Other(int vertex)
        {
            if (vertex == v)
                return w;
            else
                return v;
        }

        public double ResidualCapacityTo(int vertex)
        {
            if (vertex == v)
            {
                return flow;
            }
            else
            {
                return capacity - flow;
            }
        }

        public void AddResidualFlowTo(int vertex, double delta)
        {
            if (vertex == v)
                flow -= delta;
            else
                flow += delta;
        }

    }
}
