using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    class Program
    {
        static void Main(string[] args)
        {
            //TestDFS();
            //TestBFS();

            #region -- hacker rank BFS
            //int q = Convert.ToInt32(Console.ReadLine());
            //for (int a0 = 0; a0 < q; a0++)
            //{
            //    string[] tokens_n = Console.ReadLine().Split(' ');
            //    int n = Convert.ToInt32(tokens_n[0]);
            //    int m = Convert.ToInt32(tokens_n[1]);
            //    int[][] edges = new int[m][];
            //    for (int edges_i = 0; edges_i < m; edges_i++)
            //    {
            //        string[] edges_temp = Console.ReadLine().Split(' ');
            //        edges[edges_i] = Array.ConvertAll(edges_temp, Int32.Parse);
            //    }
            //    int s = Convert.ToInt32(Console.ReadLine());
            //    HackerRankTestBFS(n, m, edges, s);
            //}
            #endregion

            //TestConnectedComponents();
            //TestDFSUsingDiGraphAPI();
            //TestBFSUsingDiGraphAPI();
            //TestTopologicalSort();

            //TestKosarajuSharirAlgo();

            TestKruskalMST();
            TestLazyPrimsMST();
            Console.Read();
        }

        private static void TestGraphAPI()
        {
            GraphAPI gapi = new GraphAPI(13);
            gapi.AddEdge(0, 5);
            gapi.AddEdge(4, 3);
            gapi.AddEdge(0, 1);
            gapi.AddEdge(9, 12);
            gapi.AddEdge(6, 4);
            gapi.AddEdge(5, 4);
            gapi.AddEdge(0, 2);
            gapi.AddEdge(11, 12);
            gapi.AddEdge(9, 10);
            gapi.AddEdge(0, 6);
            gapi.AddEdge(7, 8);
            gapi.AddEdge(9, 11);
            gapi.AddEdge(5, 3);
            foreach (var item in gapi.Adjacent(0))
            {
                Console.WriteLine(item);
            }

            Console.Read();
        }

        static void TestDFS()
        {
            GraphAPI gapi = new GraphAPI(13);
            gapi.AddEdge(0, 5);
            gapi.AddEdge(4, 3);
            gapi.AddEdge(0, 1);
            gapi.AddEdge(9, 12);
            gapi.AddEdge(6, 4);
            gapi.AddEdge(5, 4);
            gapi.AddEdge(0, 2);
            gapi.AddEdge(11, 12);
            gapi.AddEdge(9, 10);
            gapi.AddEdge(0, 6);
            gapi.AddEdge(7, 8);
            gapi.AddEdge(9, 11);
            gapi.AddEdge(5, 3);

            DepthFirstSearch dfs = new DepthFirstSearch(gapi, 6);

            foreach (var item in dfs.PathTo(3))
            {
                Console.WriteLine(item);
            }
        }

        static void TestBFS()
        {
            GraphAPI gapi = new GraphAPI(13);
            gapi.AddEdge(0, 5);
            gapi.AddEdge(4, 3);
            gapi.AddEdge(0, 1);
            gapi.AddEdge(9, 12);
            gapi.AddEdge(6, 4);
            gapi.AddEdge(5, 4);
            gapi.AddEdge(0, 2);
            gapi.AddEdge(11, 12);
            gapi.AddEdge(9, 10);
            gapi.AddEdge(0, 6);
            gapi.AddEdge(7, 8);
            gapi.AddEdge(9, 11);
            gapi.AddEdge(5, 3);

            BreadthFirstSearch bfs = new BreadthFirstSearch(gapi, 6);

            foreach (var item in bfs.PathTo(3))
            {
                Console.WriteLine(item);
            }
        }

        static void HackerRankTestBFS(int v, int e, int[][] edges, int s)
        {
            GraphAPI gpapi = new GraphAPI(v);
            for (int i = 0; i < edges.Length; i++)
            {
                gpapi.AddEdge(edges[i][0] - 1, edges[i][1] - 1);
            }

            BreadthFirstSearch bfs = new BreadthFirstSearch(gpapi, s - 1);

            for (int i = 0; i < v; i++)
            {
                if (i == s - 1)
                    continue;

                int count = 0;

                if (bfs.PathTo(i) == null)
                {
                    Console.Write("-1" + " ");
                    continue;
                }

                foreach (var item in bfs.PathTo(i))
                {
                    if (item == s - 1)
                        continue;

                    count = count + 6;
                }

                if (count > 0)
                {
                    Console.Write(count + " ");
                }
            }

            Console.WriteLine();
        }

        static void TestConnectedComponents()
        {
            GraphAPI gapi = new GraphAPI(13);
            gapi.AddEdge(0, 5);
            gapi.AddEdge(4, 3);
            gapi.AddEdge(0, 1);
            gapi.AddEdge(9, 12);
            gapi.AddEdge(6, 4);
            gapi.AddEdge(5, 4);
            gapi.AddEdge(0, 2);
            gapi.AddEdge(11, 12);
            gapi.AddEdge(9, 10);
            gapi.AddEdge(0, 6);
            gapi.AddEdge(7, 8);
            gapi.AddEdge(9, 11);
            gapi.AddEdge(5, 3);

            ConnectedComponents ccs = new ConnectedComponents(gapi);
            Console.WriteLine(ccs.Count());
            Console.WriteLine(ccs.ConnectedId(7));
        }

        static void TestDiGraphApi()
        {
            DiaGraphAPI dgapi = new DiaGraphAPI(13);
            dgapi.AddEdge(0, 1);
            dgapi.AddEdge(0, 5);
            dgapi.AddEdge(2, 3);
            dgapi.AddEdge(2, 0);
            dgapi.AddEdge(3, 2);
            dgapi.AddEdge(3, 5);
            dgapi.AddEdge(4, 2);
            dgapi.AddEdge(4, 3);
            dgapi.AddEdge(5, 4);
            dgapi.AddEdge(6, 0);
            dgapi.AddEdge(6, 4);
            dgapi.AddEdge(6, 8);
            dgapi.AddEdge(6, 9);
            dgapi.AddEdge(7, 6);
            dgapi.AddEdge(7, 9);
            dgapi.AddEdge(8, 6);
            dgapi.AddEdge(9, 10);
            dgapi.AddEdge(9, 11);
            dgapi.AddEdge(10, 12);
            dgapi.AddEdge(11, 4);
            dgapi.AddEdge(11, 12);
            dgapi.AddEdge(12, 9);

            for (int i = 0; i < 13; i++)
            {
                foreach (var item in dgapi.Adjacent(i))
                {
                    Console.WriteLine(i + "->" + item);
                }
            }

        }

        static void TestDFSUsingDiGraphAPI()
        {
            DiaGraphAPI dgapi = new DiaGraphAPI(13);
            dgapi.AddEdge(0, 1);
            dgapi.AddEdge(0, 5);
            dgapi.AddEdge(2, 3);
            dgapi.AddEdge(2, 0);
            dgapi.AddEdge(3, 2);
            dgapi.AddEdge(3, 5);
            dgapi.AddEdge(4, 2);
            dgapi.AddEdge(4, 3);
            dgapi.AddEdge(5, 4);
            dgapi.AddEdge(6, 0);
            dgapi.AddEdge(6, 4);
            dgapi.AddEdge(6, 8);
            dgapi.AddEdge(6, 9);
            dgapi.AddEdge(7, 6);
            dgapi.AddEdge(7, 9);
            dgapi.AddEdge(8, 6);
            dgapi.AddEdge(9, 10);
            dgapi.AddEdge(9, 11);
            dgapi.AddEdge(10, 12);
            dgapi.AddEdge(11, 4);
            dgapi.AddEdge(11, 12);
            dgapi.AddEdge(12, 9);

            DepthFirstSearch dfs = new DepthFirstSearch(dgapi, 6);

            foreach (var item in dfs.PathTo(1))
            {
                Console.WriteLine(item);
            }
        }

        static void TestBFSUsingDiGraphAPI()
        {
            DiaGraphAPI dgapi = new DiaGraphAPI(13);
            dgapi.AddEdge(0, 1);
            dgapi.AddEdge(0, 5);
            dgapi.AddEdge(2, 3);
            dgapi.AddEdge(2, 0);
            dgapi.AddEdge(3, 2);
            dgapi.AddEdge(3, 5);
            dgapi.AddEdge(4, 2);
            dgapi.AddEdge(4, 3);
            dgapi.AddEdge(5, 4);
            dgapi.AddEdge(6, 0);
            dgapi.AddEdge(6, 4);
            dgapi.AddEdge(6, 8);
            dgapi.AddEdge(6, 9);
            dgapi.AddEdge(7, 6);
            dgapi.AddEdge(7, 9);
            dgapi.AddEdge(8, 6);
            dgapi.AddEdge(9, 10);
            dgapi.AddEdge(9, 11);
            dgapi.AddEdge(10, 12);
            dgapi.AddEdge(11, 4);
            dgapi.AddEdge(11, 12);
            dgapi.AddEdge(12, 9);

            BFSDiGraphAPI dfs = new BFSDiGraphAPI(dgapi, 6);

            foreach (var item in dfs.PathTo(1))
            {
                Console.WriteLine(item);
            }
        }

        static void TestTopologicalSort()
        {
            DiaGraphAPI dgapi = new DiaGraphAPI(7);
            dgapi.AddEdge(0, 1);
            dgapi.AddEdge(0, 2);
            dgapi.AddEdge(0, 5);
            dgapi.AddEdge(1, 4);
            dgapi.AddEdge(3, 2);
            dgapi.AddEdge(3, 4);
            dgapi.AddEdge(3, 5);
            dgapi.AddEdge(3, 6);
            dgapi.AddEdge(5, 2);
            dgapi.AddEdge(6, 4);
            dgapi.AddEdge(6, 0);

            TopologicalSort dfs = new TopologicalSort(dgapi);

            foreach (var item in dfs.IterateReversePO())
            {
                Console.WriteLine(item);
            }
        }

        static void TestKosarajuSharirAlgo()
        {
            DiaGraphAPI dgapi1 = new DiaGraphAPI(13);
            dgapi1.AddEdge(0, 2);
            dgapi1.AddEdge(0, 6);
            dgapi1.AddEdge(1, 0);
            dgapi1.AddEdge(2, 3);
            dgapi1.AddEdge(2, 4);
            dgapi1.AddEdge(3, 2);
            dgapi1.AddEdge(3, 4);
            dgapi1.AddEdge(4, 5);
            dgapi1.AddEdge(4, 6);
            dgapi1.AddEdge(4, 11);
            dgapi1.AddEdge(5, 0);
            dgapi1.AddEdge(5, 3);
            dgapi1.AddEdge(6, 7);
            dgapi1.AddEdge(6, 8);
            dgapi1.AddEdge(8, 6);
            dgapi1.AddEdge(9, 6);
            dgapi1.AddEdge(9, 7);
            dgapi1.AddEdge(9, 12);
            dgapi1.AddEdge(10, 9);
            dgapi1.AddEdge(11, 9);
            dgapi1.AddEdge(12, 10);
            dgapi1.AddEdge(12, 11);

            DiaGraphAPI dgapi = new DiaGraphAPI(13);
            dgapi.AddEdge(0, 1);
            dgapi.AddEdge(0, 5);
            dgapi.AddEdge(2, 3);
            dgapi.AddEdge(2, 0);
            dgapi.AddEdge(3, 2);
            dgapi.AddEdge(3, 5);
            dgapi.AddEdge(4, 2);
            dgapi.AddEdge(4, 3);
            dgapi.AddEdge(5, 4);
            dgapi.AddEdge(6, 0);
            dgapi.AddEdge(6, 4);
            dgapi.AddEdge(6, 8);
            dgapi.AddEdge(6, 9);
            dgapi.AddEdge(7, 6);
            dgapi.AddEdge(7, 9);
            dgapi.AddEdge(8, 6);
            dgapi.AddEdge(9, 10);
            dgapi.AddEdge(9, 11);
            dgapi.AddEdge(10, 12);
            dgapi.AddEdge(11, 4);
            dgapi.AddEdge(11, 12);
            dgapi.AddEdge(12, 9);

            StrongComponents sc = new StrongComponents(dgapi, dgapi1);
            Console.WriteLine(sc.Count());
            Console.WriteLine(sc.ConnectedId(0));
            Console.WriteLine(sc.ConnectedId(1));
            Console.WriteLine(sc.ConnectedId(6));
            Console.WriteLine(sc.ConnectedId(7));
            Console.WriteLine(sc.ConnectedId(9));
        }

        static void TestKruskalMST()
        {
            EdgeWeightedGraph ewg = new EdgeWeightedGraph(16);
            ewg.Addedge(new EdgeAPI(4, 5, .35));
            ewg.Addedge(new EdgeAPI(4, 7, .37));
            ewg.Addedge(new EdgeAPI(5, 7, .28));
            ewg.Addedge(new EdgeAPI(0, 7, .16));
            ewg.Addedge(new EdgeAPI(1, 5, .32));
            ewg.Addedge(new EdgeAPI(0, 4, .38));
            ewg.Addedge(new EdgeAPI(2, 3, .17));
            ewg.Addedge(new EdgeAPI(1, 7, .19));
            ewg.Addedge(new EdgeAPI(0, 2, .26));
            ewg.Addedge(new EdgeAPI(1, 2, .36));
            ewg.Addedge(new EdgeAPI(1, 3, .29));
            ewg.Addedge(new EdgeAPI(2, 7, .34));
            ewg.Addedge(new EdgeAPI(6, 2, .40));
            ewg.Addedge(new EdgeAPI(3, 6, .52));
            ewg.Addedge(new EdgeAPI(6, 0, .58));
            ewg.Addedge(new EdgeAPI(6, 4, .93));

            KruskalMST mst = new KruskalMST(ewg);

            foreach (var item in mst.Edges())
            {
                Console.WriteLine(item.V + "-->" + item.W + ": " + item.Weight);
            }

            Console.WriteLine("Weight: " + mst.Weight());
        }

        static void TestLazyPrimsMST()
        {
            EdgeWeightedGraph ewg = new EdgeWeightedGraph(16);
            ewg.Addedge(new EdgeAPI(4, 5, .35));
            ewg.Addedge(new EdgeAPI(4, 7, .37));
            ewg.Addedge(new EdgeAPI(5, 7, .28));
            ewg.Addedge(new EdgeAPI(0, 7, .16));
            ewg.Addedge(new EdgeAPI(1, 5, .32));
            ewg.Addedge(new EdgeAPI(0, 4, .38));
            ewg.Addedge(new EdgeAPI(2, 3, .17));
            ewg.Addedge(new EdgeAPI(1, 7, .19));
            ewg.Addedge(new EdgeAPI(0, 2, .26));
            ewg.Addedge(new EdgeAPI(1, 2, .36));
            ewg.Addedge(new EdgeAPI(1, 3, .29));
            ewg.Addedge(new EdgeAPI(2, 7, .34));
            ewg.Addedge(new EdgeAPI(6, 2, .40));
            ewg.Addedge(new EdgeAPI(3, 6, .52));
            ewg.Addedge(new EdgeAPI(6, 0, .58));
            ewg.Addedge(new EdgeAPI(6, 4, .93));

            LazyPrimsMST mst = new LazyPrimsMST(ewg);

            foreach (var item in mst.Edges())
            {
                Console.WriteLine(item.V + "-->" + item.W + ": " + item.Weight);
            }

            Console.WriteLine("Weight: " + mst.Weight());
        }
    }
}
