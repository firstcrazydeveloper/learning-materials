using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingInterview
{
    public class Index
    {
        public int index { get; set; }

    }
    public class BinaryTreeGraph
    {
        public int Vertex;
        Dictionary<int, List<int>> adjacent;

        public BinaryTreeGraph(int vertex)
        {
            this.Vertex = vertex;
            this.adjacent = new Dictionary<int, List<int>>();
        }

        public void AddEdge(int parent, int source)
        {
            if (!this.adjacent.ContainsKey(parent))
                this.adjacent.Add(parent, new List<int>());

            this.adjacent[parent].Add(source);
        }

        public void PrintAllPaths(int source, int dest)
        {
            bool[] visited = new bool[this.Vertex];
            int[] path = new int[this.Vertex];
            Index index = new Index();
            index.index = 0;

            for (int i = 0; i < this.Vertex; i++)
                visited[i] = false;

            PrintAllPathsUtil(source, dest, visited, path, index);

        }

        public void PrintAllPathsUtil(int u, int d, bool[] visited, int[] path, Index index)
        {
            visited[u] = true;
            path[index.index] = u;
            index.index++;

            if (u == d)
            {
                for (int i = 0; i < index.index; i++)
                    Console.Write("{0} ", path[i]);
                Console.WriteLine();
            }
            else
            {
                List<int> list = new List<int>();
                list = this.adjacent[u];
                for (int i = 0; i < list.Count; i++)
                {
                    if (!visited[list[i]])
                    {
                        PrintAllPathsUtil(list[i], d, visited, path, index);
                    }

                }
            }

            index.index--;
            visited[u] = false;
        }
    }
}
