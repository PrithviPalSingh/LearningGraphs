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

        public TopologicalSort(EdgeWeightedDiGraph ewdg)
        {
            ReversePostOrder = new Stack<int>();
            Marked = new bool[ewdg.V];
            for (int v = 0; v < ewdg.V; v++)
            {
                if (!Marked[v])
                    DFS(ewdg, v);
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

        private void DFS(EdgeWeightedDiGraph ewdg, int v)
        {
            Marked[v] = true;

            foreach (var item in ewdg.Adj(v))
            {
                Marked[v] = true;

                if (!Marked[item.W])
                    DFS(ewdg, item.W);
            }

            ReversePostOrder.Push(v);
        }

        public IEnumerable<int> IterateReversePO()
        {
            return ReversePostOrder;
        }
    }
}
