using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodingInterview.Interview;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodingInterviewTest.Interview
{
    [TestClass]
    public class GraphTest
    {
        Graph graph;

        [TestMethod]
        public void FindAllpossiblePath()
        {
            graph = new Graph(8);
            graph.AddEdge(0, 4);
            graph.AddEdge(0, 2);
            graph.AddEdge(1, 3);
            graph.AddEdge(2, 7);
            graph.AddEdge(3, 6);
            graph.AddEdge(4, 5);
            graph.AddEdge(4, 7);
            graph.AddEdge(5, 4);
            graph.AddEdge(5, 7);
            graph.AddEdge(5, 1);
            graph.AddEdge(6, 2);
            graph.AddEdge(6, 0);
            graph.AddEdge(6, 4);
            graph.AddEdge(7, 5);
            graph.AddEdge(7, 3);
            int s = 0, d = 6;
            graph.FindAllPossiblePath(s, d);
        }

        [TestMethod]
        public void TopologicalSortingIternaryTicket()
        {
            graph = new Graph();
            Dictionary<string, string> dataSet = new Dictionary<string, string>();
            dataSet.Add("Chennai", "Banglore");
            dataSet.Add("Bombay", "Delhi");
            dataSet.Add("Goa", "Chennai");
            dataSet.Add("Delhi", "Goa");
            graph.TopologicalSort(dataSet);
        }
    }
}
