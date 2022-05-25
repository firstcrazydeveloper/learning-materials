using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingInterview.Interview
{
    public class MST
    {
        public Dictionary<int, Dictionary<int, int>> MSTData;
        public int Vertex;
        public int minValue = int.MaxValue;
        public MST()
        {
            MSTData = new Dictionary<int, Dictionary<int, int>>();
            this.Vertex = 5;
            for (int i = 0; i < Vertex; i++)
            {
                MSTData[i] = new Dictionary<int, int>();
            }

            var t= new Dictionary<int, int>();
            t.Add(1, 2);
            t.Add(3, 6);
            MSTData[0] = t;

            t = new Dictionary<int, int>();
            t.Add(0, 2);
            t.Add(2, 3);
            t.Add(3, 8);
            t.Add(4, 5);
            MSTData[1] = t;

            t = new Dictionary<int, int>();
            t.Add(1, 3);
            t.Add(4, 7);
            MSTData[2] = t;

            t = new Dictionary<int, int>();
            t.Add(0, 6);
            t.Add(1, 8);
            t.Add(4, 9);
            MSTData[3] = t;

            t = new Dictionary<int, int>();
            t.Add(1, 5);
            t.Add(2, 7);
            t.Add(3, 9);
            MSTData[4] = t;
        }

        public int MinimumKeyValue(int[] key, List<int> visitedVertex)
        {
            int minValue = int.MaxValue, resultIndex = -1;
            for (int i = 0; i < this.Vertex; i++)
            {
                if (!visitedVertex.Contains(i) && key[i] < minValue)
                {
                    minValue = key[i];
                    resultIndex = i;
                }
            }

            return resultIndex;
        }

        public void PrintMST(Dictionary<int, Dictionary<int, int>> MSTData)
        {
            // Array to add Construct Values
            int[] parent = new int[this.Vertex];

            // Add minimum weight value
            int[] key = new int[this.Vertex];

            List<int> visitedVertex = new List<int>();

            for (int i = 0; i < this.Vertex; i++)
            {
                key[i] = int.MaxValue;
            }

            key[0] = 0;
            parent[0] = -1;

            for (int count = 0; count < this.Vertex - 1; count++)
            {
                int current = MinimumKeyValue(key, visitedVertex);
                visitedVertex.Add(current);
                for (int i = 0; i < this.Vertex; i++)
                {
                    if (current >= 0)
                    {
                        var tempDict = MSTData[current];
                        if (tempDict.ContainsKey(i) && visitedVertex.Contains(i) && tempDict[i] < key[i])
                        {
                            parent[i] = current;
                            key[i] = tempDict[i];
                        }
                    }
                }
            }

        }

        public void PrintMST(int[] parent, Dictionary<int, Dictionary<int, int>> data)
        {
            for (int i = 0; i < this.Vertex; i++)
            {
                var temp = data[i];
                Console.WriteLine(parent[i] + " - " + i + "    " + temp[parent[i]]);
            }
        }

        public void FindAllPossiblePathUtil(int source, int dest, List<int> visited, int[] path, Index index, List<int> result)
        {
            visited.Add(source);
            path[index.index] = source;
            index.index++;
            if (source == dest)
            {
                int count = 0;
                List<int> tempResult = new List<int>();
                for (int i = 0; i < index.index; i++)
                {
                    if (i < index.index - 1)
                    {
                        var f = this.MSTData[path[i]];
                        var k = f[path[i + 1]];
                        count = count + k;
                    }
                    tempResult.Add(path[i]);

                    Console.Write("{0} ", path[i]);
                }
                if (count < this.minValue)
                {
                    result.Clear();
                    this.minValue = count;
                    result.AddRange(tempResult);
                }

                Console.WriteLine();
            }
            else
            {
                var child = this.MSTData[source];
                foreach (var item in child)
                {
                    if (!visited.Contains(item.Key))
                        {
                            FindAllPossiblePathUtil(item.Key, dest, visited, path, index, result);
                        }
                }
               
            }

            index.index--;
            visited.Remove(source);

        }

        public void FindAllPossiblePath(int source, int dest, List<int> result)
        {
            Index index = new Index();
            index.index = 0;
            List<int> visited = new List<int>();
            int[] path = new int[this.Vertex];

            FindAllPossiblePathUtil(source, dest, visited, path, index, result);

        }
    }
}
