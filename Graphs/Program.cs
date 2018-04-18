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

            TestConnectedComponents();
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
    }
}
