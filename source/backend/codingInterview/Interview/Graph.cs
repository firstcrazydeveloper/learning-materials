using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingInterview.Interview
{
    public class Graph
    {
        public int Vertex { get; set; }
        public Dictionary<int, List<int>> Edges;

        public Graph()
        {

        }

        public Graph(int vertex)
        {
            this.Vertex = vertex;
            this.Edges = new Dictionary<int, List<int>>();
        }

        public void AddEdge(int parent, int edge)
        {
            if (!this.Edges.ContainsKey(parent))
                this.Edges.Add(parent, new List<int>());
            this.Edges[parent].Add(edge);
        }

        public void FindAllPossiblePath(int source, int dest)
        {
            Index index = new Index();
            index.index = 0;
            List<int> visited = new List<int>();
            int[] path = new int[this.Vertex];

            FindAllPossiblePathUtil(source, dest, visited, path, index);

        }

        public void FindAllPossiblePathUtil(int source, int dest, List<int> visited, int[] path, Index index)
        {
            visited.Add(source);
            path[index.index] = source;
            index.index++;
            if (source == dest)
            {
                for (int i = 0; i < index.index; i++)
                {
                    Console.Write("{0} ", path[i]);
                }

                Console.WriteLine();
            }
            else
            {
                List<int> child = this.Edges[source];
                for (int i = 0; i < child.Count; i++)
                {
                    if (!visited.Contains(child[i]))
                    {
                        FindAllPossiblePathUtil(child[i], dest, visited, path, index);
                    }

                }
            }

            index.index--;
            visited.Remove(source);

        }

        public void TopologicalSort(Dictionary<string, string> itenaryTicket)
        {
            Dictionary<string, string> reverseTravel = new Dictionary<string, string>();

            foreach (var item in itenaryTicket)
            {
                reverseTravel.Add(item.Value, item.Key);
            }

            string startPoint = string.Empty;

            foreach (var item in itenaryTicket)
            {
                if (!reverseTravel.ContainsKey(item.Key))
                    startPoint = item.Key;
            }

            if (String.IsNullOrEmpty(startPoint))
            {
                Console.WriteLine("Invalid Input");
                return;
            }

            string endPoint = itenaryTicket[startPoint];

            while (true)
            {
                Console.WriteLine("Start City <{0}> -> End City <{1}>", startPoint, endPoint);
                startPoint = endPoint;
                if (!itenaryTicket.ContainsKey(startPoint))
                    return;
                endPoint = itenaryTicket[startPoint];
            }

        }

        public bool DetectCyclic()
        {
            List<int> visited = new List<int>();
            List<int> result = new List<int>();
            for (int i = 0; i < this.Vertex; i++)
            {
                if (ISCyclicUtil(i, visited, result))
                    return true;
            }
            return false;
        }

        public bool ISCyclicUtil(int vertex, List<int> visited, List<int> result)
        {
            if(!visited.Contains(vertex))
            {
                visited.Add(vertex);
                result.Add(vertex);
                List<int> child = this.Edges[vertex];
                for (int i = 0; i < child.Count; i++)
                {
                    if (!visited.Contains(child[i]) && ISCyclicUtil(child[i], visited, result))
                        return true;
                    else if (result.Contains(child[i]))
                        return true;
                }
            }
            result.Remove(vertex);
            return false;
        }

        public void FindBridge()
        {
            List<int> visited = new List<int>();
            int[] disc = new int[this.Vertex];
            int[] lowData = new int[this.Vertex];
            int[] parent = new int[this.Vertex];
            Index index = new Index();
            for (int i = 0; i < this.Vertex; i++)
            {
                if (!visited.Contains(i))
                    FindBridgeUtil(i, visited, disc, lowData, parent, index);
            }
        }

        public void FindBridgeUtil(int value,List<int> visited, int[] disc, int[] lowData, int[] parent, Index index)
        {
            visited.Add(value);
            disc[value] = lowData[value] = ++index.index;
            List<int> child = this.Edges[value];
            while(child.Count>0)
            {
                int current = child.First();
                child.Remove(current);
                if (!visited.Contains(current))
                {
                    parent[current] = value;
                    FindBridgeUtil(current, visited, disc, lowData, parent, index);

                    lowData[value] = Math.Min(lowData[value], lowData[current]);

                    if (lowData[current] > disc[value])
                        Console.WriteLine(value + " >> " + current);

                }
                else if (current != parent[value])
                    lowData[value] = Math.Min(lowData[value], disc[current]);
            }

        }

        public void BuildOrder(Dictionary<char,char> order)
        {
            Dictionary<char, char> temp = new Dictionary<char, char>();

            foreach (var item in order)
            {
                temp.Add(item.Value, item.Key);

            }

            char? start = null;
            foreach (var item in order)
            {
                if (!temp.ContainsKey(item.Key))
                    start = item.Key;

            }
        }
    }
}
