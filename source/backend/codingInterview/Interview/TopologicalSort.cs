using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingInterview.Interview
{
    public class Node<T>
    {
        public T Data { get; set; }
        public List<Node<T>> Edge;
        public Node(T data)
        {
            this.Data = data;
            this.Edge = new List<Node<T>>();
        }
    }
    public class TopologicalSort<T>
    {
        Node<char> a = new Node<char>('a');
       
        Node<char> b = new Node<char>('b');
        Node<char> c = new Node<char>('c');
        Node<char> d = new Node<char>('d');
        Node<char> e = new Node<char>('e');

        public void CreateNode()
        {
            a.Edge.Add(b);
            a.Edge.Add(d);
            b.Edge.Add(c);
            b.Edge.Add(e);
            c.Edge.Add(d);
            d.Edge.Add(e);
        }
        public void BuildDependency(List<char> result)
        {
            List<char> notVisitedNode = new List<char>();
            BuildDependency(a, result, notVisitedNode);
        }

        public void BuildDependency(Node<char> node, List<char> visitedNode, List<char> notVisited)
        {
            notVisited.Add(node.Data);
            foreach (var item in node.Edge)
            {
                if (!visitedNode.Contains(item.Data))
                {
                    if (notVisited.Contains(item.Data))
                        throw new Exception("Circular Reference Detected");
                    BuildDependency(item, visitedNode, notVisited);
                }
            }

            visitedNode.Add(node.Data);
            notVisited.Remove(node.Data);
        }
    }
}
