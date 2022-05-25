using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodingInterview.ChapterOne;
using CodingInterview.Helper.BinaryTree;
using CodingInterview.Interview;
using CodingInterview.LinkedList;
using CodingInterview.MongoDataAccess;
using CodingInterview.TechGig;
using TutorialProjects;

namespace CodingInterview
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<object> edata = new List<string>();

            char[] a = new char[] { 'a' };
            object obj = new string(a);
            int[] tempArr = new int[] { 1, 2, 4, 6, 8, 9, 2, 3, 5, 7 };
            int duplicate = -1;
            for (int i = 0; i < tempArr.Length; i++)
            {
                int j=Math.Abs(tempArr[i]);
                int k = tempArr[j];
                if (k >= 0)
                    tempArr[j] = -tempArr[j];
                else
                    duplicate = j;
                    

            }
            MST mst = new MST();
            List<int> result = new List<int>();
            mst.FindAllPossiblePath(0, 4, result);

            TopologicalSort<char> tp = new TopologicalSort<char>();
            List<char> topresult = new List<char>();
            tp.CreateNode();
            tp.BuildDependency(topresult);


            BinaryTree BTree = new BinaryTree();
            BTree.Root = new Node(31);
            BTree.Root.Left = new Node(16);
            BTree.Root.Right = new Node(45);
            BTree.Root.Left.Left = new Node(7);
            BTree.Root.Left.Right = new Node(24);
            BTree.Root.Left.Right.Left = new Node(19);
            BTree.Root.Left.Right.Right = new Node(29);
            // Console.WriteLine("***************** InOrder Traversal ********************");
            // BTree.InOrderTraversal(BTree.Root);
            // Console.WriteLine("***************** PreeOrder Traversal ********************");
            // BTree.PreOrderTraversal(BTree.Root);
            // Console.WriteLine("***************** PostOrder Traversal ********************");
            // BTree.PostOrderTraversal(BTree.Root);

            // BTree.BinaryTreeMirror(BTree.Root);
            // Console.WriteLine("***************** Mirror Traversal ********************");
            // BTree.InOrderTraversal(BTree.Root);

            Node source = new Node(31);
            Node target = new Node(31);
            source.Left = new Node(16);
            source.Right = new Node(45);
            // source.Right.Left = new Node(40);
            // source.Right.Left = new Node(32);
            // source.Right.Right = new Node(57);
            source.Left.Left = new Node(7);
            source.Left.Right = new Node(24);
            source.Left.Right.Left = new Node(19);
            source.Left.Right.Right = new Node(29);

            target.Left = new Node(45);
            target.Right = new Node(16);
            target.Right.Left = new Node(24);
            target.Right.Right = new Node(7);
            target.Right.Left.Left = new Node(29);
            target.Right.Left.Right = new Node(19);

            //Console.WriteLine("***************** Verify Mirror ********************");
            //if (BTree.AreBinaryMirror(source, target))
            //    Console.WriteLine("YES");
            //else
            //    Console.WriteLine("NO");

            Console.WriteLine("***************** Boundry Traversal ********************");
            Node leftNode = null;
            List<Node> getValue = new List<Node>();
            //BTree.PrintNextLeftNode(source, 16, getValue);
            if (getValue.Count > 0)
                leftNode = getValue[0];
            int n = BTree.GetMaxWidthOfBinaryTree(target);

            // var tempNode = BTree.PrintNextRightNode(source, 16);
            //  BTree.temp(source);
            Dictionary<int, Node> temp = new Dictionary<int, Node>();
            //BTree.InOrderPredecessor(source, temp);
            //BTree.successorPredecessor(source, 31);

            int[] inOrder = new int[] { 4, 8, 2, 5, 1, 6, 3, 7 };
            int[] postOrder = new int[] { 8, 4, 5, 2, 6, 7, 3, 1 };
            int l = inOrder.Length;
            Node root = BTree.BuildBinaryTree(inOrder, postOrder, l);
            // BTree.PreOrderTraversal(root);
            // BTree.PrintRootToLeafPath(source);
            //GraphTree GTree = new GraphTree();
            //var d = GTree.GetAllSteps(0, 6);
            //foreach (var item in d)
            //{
            //    var res = item.Value;
            //    foreach (var r in res)
            //    {
            //        Console.Write(r + " ");
            //    }
            //    Console.WriteLine();

            //}

            Graph graph = new Graph(8);
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
            // graph.FindAllPossiblePath(s, d);
            //var d = g.DetectCyclic();
            Dictionary<string, string> dataSet = new Dictionary<string, string>();
            dataSet.Add("Chennai", "Banglore");
            dataSet.Add("Bombay", "Delhi");
            dataSet.Add("Goa", "Chennai");
            dataSet.Add("Delhi", "Goa");
            // g.TopologicalSort(dataSet);
            Trie trie = new Trie();
            string[] keys = { "the", "a", "there", "answer", "any", "by", "bye", "their" };
            for (int i = 0; i < keys.Length; i++)
                trie.Insert(keys[i]);

            if (trie.Search("the"))
                Console.WriteLine("Present in Dictionary");
            if (trie.Search("thaw"))
                Console.WriteLine("the is Present in Dictionary");
            else
                Console.WriteLine("thaw is Not Present in Dictionary");

            Trie dict = new Trie();
            dict.TrieInsert("are");
            dict.TrieInsert("area");
            dict.TrieInsert("base");
            dict.TrieInsert("cat");
            dict.TrieInsert("cater");
            dict.TrieInsert("basement");

            var res = dict.GetMatchingPrefix("caterer");

            string s1 = "orchestra";
            string s2 = "carthorse";

            var isanagram = IsAnagram(s1, s2);

            string str = "cat dog tac god act";

            GroupAnagram(str);

            Console.ReadLine();
        }


        static bool IsAnagram(string s1, string s2)
        {
            Dictionary<char, int> s1Data = new Dictionary<char, int>();
            Dictionary<char, int> s2Data = new Dictionary<char, int>();
            int nLength = s2.Length;

            for (int i = 0; i < s1.Length; i++)
            {
                SetHashSet(s1Data, s1[i]);
                if (i < nLength)
                    SetHashSet(s2Data, s2[i]);
            }


            for (int i = 0; i < s1.Length; i++)
            {
                if (s1Data[s1[i]] != s2Data[s1[i]])
                    return false;
            }
            return true;
        }


        static void GroupAnagram(string sentence)
        {
            string[] words = sentence.Split(' ');
            Dictionary<int, string> hashSet = new Dictionary<int, string>();
            Dictionary<int, string> sortedHashSet = new Dictionary<int, string>();

            for (int i = 0; i < words.Length; i++)
            {
                hashSet.Add(i, words[i]);
                sortedHashSet.Add(i, new string(words[i].OrderBy(a => a).ToArray()));
            }

            foreach (KeyValuePair<int, string> item in sortedHashSet.OrderBy(key => key.Value))
            {
                Console.WriteLine(hashSet[item.Key]);
            }
        }


        static void SetHashSet(Dictionary<char, int> hashset, char c)
        {
            if (hashset.ContainsKey(c))
            {
                hashset[c]++;
            }
            else
            {
                hashset.Add(c, 1);
            }

        }
        static void Main_Old(string[] args)
        {
            //B testB = new A();

            // A testA = new B();
            // testA.doSomething();

            DataAccess ds = new DataAccess();

            BigOSample sample = new BigOSample();
            // int[] arrA = new int[] { 2,8,4,4,5 };
            // int[] arrA = new int[] { 2,9,3,3,5,2,7 };
            int[] arrA = new int[] { -2, -3, 4, -1, -2, 1, 5, -3 };
            int[] arrB = new int[] { 8, 5, 9, 5, 1 };
            string t = "abac";
            List<string> sortValue = new List<string>();
            // sample.PrintStringPermutations(t,0,t.Length-1, sortValue);
            sortValue.Sort();

            // Console.WriteLine(sample.calcAngle(9, 60) + " degree");
            // Console.WriteLine(sample.calcAngle(3, 27) + " degree");
            // Console.WriteLine(sample.AllFib(40));
            //sample.AllFib(10);

            // var d = StringSample.BinaryPossibleCombination("00?1001?0");

            LinkedListSample linkedlist = new LinkedListSample();
            linkedlist.Add(7);
            linkedlist.Add(3);
            linkedlist.Add(9);
            linkedlist.Add(2);
            linkedlist.Add(7);
            linkedlist.Add(4);
            linkedlist.Add(12);
            linkedlist.Add(9);
            linkedlist.Add(8);
            // linkedlist.Add(12);
            // linkedlist.PrintList();
            //linkedlist.DeleteNodeSpecificPosition(ref linkedlist.head, 4);
            // var d = linkedlist.GetIterativeCount();
            // Console.WriteLine("My Count >> "+ d);
            // var e = linkedlist.GetCount();
            // Console.WriteLine("My Recursive Count >> " + e);
            // var cNode = linkedlist.GetNode(7);
            // linkedlist.DeleteMiddleNode();
            SampleArray.GetSumSubArray(arrB);
            var a = StringSample.GetBinaryFormat(10);
            var b = StringSample.GetBinaryFormat(20);
            var c = 10 ^ 20;
            int count = 0;
            var f = StringSample.GetDecimalFormat("11110");
            while (c != 0)
            {
                c = c & (c - 1);
                count++;
            }

            int[] arr = { 10, 2, -2, -20, 10 };
            int sum = -20;

            SampleArray.MaximumSumSubArray(arr, sum);
            Console.ReadLine();
        }
    }

    public class A
    {
        public void doSomething()
        {
            Console.WriteLine("I am A");

        }
    }

    public class B : A
    {
        public void doSomething()
        {
            Console.WriteLine("I am B");

        }
    }
}
