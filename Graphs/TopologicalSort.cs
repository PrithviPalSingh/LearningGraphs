using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    /// <summary>
    /// DAG - Dirceted acyclic graph
    /// </summary>
    class TopologicalSort
    {
        private bool[] Marked;

        private Stack<int> ReversePostOrder;

        public TopologicalSort(DiaGraphAPI dgapi)
        {
            ReversePostOrder = new Stack<int>();
            Marked = new bool[dgapi.V];
            for (int v = 0; v < dgapi.V; v++)
            {
                if (!Marked[v])
                    DFS(dgapi, v);
            }
        }

        private void DFS(DiaGraphAPI dgapi, int v)
        {
            Marked[v] = true;

            foreach (var item in dgapi.Adjacent(v))
            {
                Marked[v] = true;

                if (!Marked[item])
                    DFS(dgapi, item);               
            }

            ReversePostOrder.Push(v);
        }

        public IEnumerable<int> IterateReversePO()
        {
            return ReversePostOrder;
        }
    }
}
