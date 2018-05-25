using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    /// <summary>
    /// Net flow: A cut(A,B) is the sum of the flows on its edges from A to B
    ///           minus the sum of the flows on its edges from B to A.
    /// 
    /// Weak duality: Lef f be any flow and let (A, B) be any cut.
    ///               Then the value of the flow <= the capacity of the cut.
    ///               
    /// Maxflow-mincut theorem: 
    ///     Augmenting path theorem: A flow f is a maxflow if no augmenting paths.
    ///     Mf-Mc theorem: Value of the maxflow = capacity of mincut
    ///     
    /// 1. There is some cut whose capacity equals value of the flow
    /// 2. f is a maxflow
    /// 3. There is no augmenting path w.r.t f
    /// </summary>
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
