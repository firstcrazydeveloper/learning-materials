using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingInterview.Interview
{
    public class GraphTree
    {
        public Dictionary<int, List<int>> SourceData;

        public GraphTree()
        {
            SourceData = new Dictionary<int, List<int>>();
            SourceData.Add(0, new List<int>() { 4, 2 });
            SourceData.Add(1, new List<int>() { 3 });
            SourceData.Add(2, new List<int>() { 7 });
            SourceData.Add(3, new List<int>() { 6 });
            SourceData.Add(4, new List<int>() { 5, 7 });
            SourceData.Add(5, new List<int>() { 4, 7, 1 });
            SourceData.Add(6, new List<int>() { 2, 0, 4 });
            SourceData.Add(7, new List<int>() { 5, 3 });
        }

        public List<int> GetChildren(int num)
        {
            var listData = this.SourceData[num];
            return listData;
        }

       

        public Dictionary<int, Queue<int>> GetAllSteps(int sourceStep, int targetStep)
        {
            Stack<int> visitStep = new Stack<int>();
            List<int> visitedStep = new List<int>();
            Queue<int> result = new Queue<int>();
            Dictionary<int, Queue<int>> allPath = new Dictionary<int, Queue<int>>();
            int i = 0;

            allPath[i] = new Queue<int>();
            visitStep.Push(sourceStep);
            while (visitStep.Count > 0)
            {
                int current = visitStep.Pop();
                if (!visitedStep.Contains(current))
                {
                    if (current != sourceStep)
                        allPath[i].Enqueue(current);
                    result.Enqueue(current);
                    visitedStep.Add(current);
                    List<int> child = GetChildren(current);
                    child.Reverse();
                    foreach (var c in child)
                    {
                        if (targetStep == c)
                        {
                            allPath[i].Enqueue(c);
                            visitedStep.Clear();
                            i++;
                            allPath[i] = new Queue<int>();

                        }
                        else if ( c != targetStep)
                        {
                            visitStep.Push(c);
                        }
                    }
                }
            }


            return allPath;
        }
    }
}
