﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    class TopologicalSortAcyclicGraphShortestPath
    {
        private DirectedEdgeAPI[] edgeTo;

        private double[] distTo;

        public TopologicalSortAcyclicGraphShortestPath(EdgeWeightedDiGraph DG, int s)
        {
            EdgeTo = new DirectedEdgeAPI[DG.V];
            DistTo = new double[DG.V];

            for (int i = 0; i < DG.V; i++)
            {
                DistTo[i] = double.PositiveInfinity;
            }

            DistTo[s] = 0;

            TopologicalSort ts = new TopologicalSort(DG);

            foreach (var item in ts.IterateReversePO())
            {
                foreach (var e in DG.Adj(item))
                {
                    EdgeRelaxation(e);
                }
            }
        }

        public double[] DistTo { get => distTo; set => distTo = value; }
        internal DirectedEdgeAPI[] EdgeTo { get => edgeTo; set => edgeTo = value; }

        public void EdgeRelaxation(DirectedEdgeAPI e)
        {
            int v = e.From();
            int w = e.To();

            if (DistTo[w] > (DistTo[v] + e.Weight()))
            {
                DistTo[w] = DistTo[v] + e.Weight();
                EdgeTo[w] = e;                
            }
        }
    }
}
