using ConsoleApplication4;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
namespace GeneratedTest
{
    class SiddQueue
    {
        int[] arr = new int[10];
        int headIndex = 5;
        int tailIndex = 5;

        void Enqueue(int x)
        {
            this.arr[tailIndex] = x;

            if (tailIndex == 0)
            {
                tailIndex = this.arr.Length - 1;
            }
        }
    }

    class BSTNode
    {
        public BSTNode Left;
        public BSTNode Right;
        public BSTNode Parent;
        public int Data;

        public BSTNode()
        {
        }

        public BSTNode(int data)
        {
            this.Data = data;
        }

        public override string ToString()
        {
            return Data.ToString();
        }
    }

    class GraphNode
    {
        public string NodeName;
        public GraphNode Next;
    }

    enum Color : int
    {
        White = 0,
        Gray = 1,
        Black = 2
    }

    class Graph
    {
        private int V;
        private List<int>[] adj;

        public Graph(int v)
        {
            this.V = v;
            adj = new List<int>[v];
            for (int i = 0; i < v; i++)
            {
                adj[i] = new List<int>();
            }
        }

        public void AddEdge(int v, int w)
        {
            this.adj[v].Add(w);
        }

        public void TopologicalSort()
        {
            Stack<int> stack = new Stack<int>();

            bool[] visited = new bool[this.V];

            for (int i = 0; i < V; i++)
            {
                visited[i] = false;
            }

            for (int i = 0; i < V; i++)
            {
                if (visited[i] == false)
                {
                    TopologicalSortPrivate(i, visited, stack);
                }
            }

            while (stack.Count != 0)
            {
                Console.Write(stack.Pop() + " ");
            }
        }

        private void TopologicalSortPrivate(int v, bool[] visited, Stack<int> stack)
        {
            visited[v] = true;
            int i;

            foreach (var item in this.adj[v])
            {
                i = item;
                if (!visited[i])
                {
                    TopologicalSortPrivate(i, visited, stack);
                }
            }

            stack.Push(v);
        }
    }


    class Point
    {
        public int x;
        public int y;
        public bool isVisited;
        public Point parent;
        public int Data;

        public Point(int _x, int _y)
        {
            this.x = _x;
            this.y = _y;
            this.isVisited = false;
        }

        public bool IsEqual(Point p)
        {
            return this.x == p.x && this.y == p.y;
        }

        public override string ToString()
        {
            return string.Format("({0}, {1})", this.x, this.y);
        }

        public string GetParentPath()
        {
            string s = string.Empty;
            var point = this;
            while (point != null)
            {
                s = point.ToString() + " || " + s;
                point = point.parent;
            }

            return s;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Heap testing
            var heap = new Heap();
            heap.AddItem(20);
            heap.AddItem(40);
            heap.AddItem(60);
            heap.AddItem(10);
            heap.AddItem(70);
            int maxValue = heap.ExtractMax();

            int[] heapArray = new int[] { 100, 90, 80, 95, 120, 110, 140, 130, 125 };
            var heap2 = new Heap(heapArray);
            var sortedHeapArray = heap2.GetSortedArray();

            int[] sortedArrayForLessThanEqual = new int[] { 10, 20, 30, 40, 50, 60, 70, 80, 90 };
            int lessThanEqualCount = FindCountOfLessThanInSortedArray(sortedArrayForLessThanEqual, 35);

            int[] preOrderArray = new int[] { 100, 90, 80, 95, 120, 110, 140, 130, 125 };
            var bstFromPreOrder = CreateBSTFromPreOrder(preOrderArray, 0, preOrderArray.Length - 1);

            LinkedList<int> ll = new LinkedList<int>(new int[] { 100, 5, 20, 200, 500, 50, 45, 60 });

            ////int[] pivotedBinarySearchArray = new int[] { 60, 70, 80, 90, 100, 2, 4, 5 };
            ////var pivotedBSResult = PivotedBinarySearch(pivotedBinarySearchArray, 4);

            ////int[] findOccuranceArray = new int[] { 10, 20, 20, 20, 20, 40, 50, 60, 60, 60, 100, 100, 120, 120, 120, 120, 500 };
            ////var count = FindCountOfElementInSortedArray(findOccuranceArray, 120);

            ////int[] quickSortArr = new int[] { 7, 100, 4, 90, 8, 5, 40, 10, 30, 56, 76, 33 };
            ////QuickSort(quickSortArr, 0, quickSortArr.Length - 1);

            ////int[][] matrix = new int[7][];
            ////matrix[0] = new int[] { 0, 1, 1, 0, 0 };
            ////matrix[1] = new int[] { 0, 1, 0, 1, 1 };
            ////matrix[2] = new int[] { 1, 0, 1, 0, 0 };
            ////matrix[3] = new int[] { 0, 1, 0, 0, 1 };
            ////matrix[4] = new int[] { 0, 0, 0, 0, 1 };
            ////matrix[5] = new int[] { 1, 0, 1, 1, 1 };
            ////matrix[6] = new int[] { 1, 0, 0, 0, 0 };
            ////var connectedNeighbors = FindConnectedNeighbors(matrix);
            ////Console.Write("");
            ////var tc = int.Parse(Console.ReadLine().Trim());
            ////for (int t = 1; t <= tc; t++)
            ////{

            ////    var n = int.Parse(Console.ReadLine().Trim());
            ////    var m = int.Parse(Console.ReadLine().Trim());
            ////    var g = new Graph(n);

            ////    for (int i = 1; i <= m; i++)
            ////    {
            ////        var line = Console.ReadLine().Split(' ');
            ////        g.AddEdge(int.Parse(line[1]) - 1, int.Parse(line[0]) - 1);
            ////    }

            ////    g.TopologicalSort();
            ////}

            ////// int[][] matrix = new int[4][];
            ////Stack<int> st = new Stack<int>();
            //////
            ////List<int>[] a;
            ////var numberOfTestCases = int.Parse(Console.ReadLine().Trim());
            ////for (int i = 1; i <= numberOfTestCases; i++)
            ////{
            ////    var line2 = Console.ReadLine().Trim().Split(' ');
            ////    int m = int.Parse(line2[0]);
            ////    int n = int.Parse(line2[1]);

            ////    var matrix = new int[m][];
            ////    for (int j = 0; j <= m - 1; j++)
            ////    {
            ////        matrix[j] = new int[n];
            ////        var line = Console.ReadLine().Trim().Split(' ');
            ////        for (int k = 0; k <= n - 1; k++)
            ////        {
            ////            matrix[j][k] = int.Parse(line[k]);
            ////        }
            ////    }

            ////    EncodeImageMatrix(matrix, 0, m - 1, 0, n - 1);
            ////}

            //////
            ////////int.Parse()
            ////////var arr1 = CreateIntArray(10000000);
            ////////var watch = Stopwatch.StartNew();
            ////////Array.Sort(arr1);
            ////////watch.Stop();
            ////////var elapsedMs = watch.ElapsedMilliseconds;
            ////////List<string> permutations = new List<string>();
            ////////CreatePermutations(" ABCDE", string.Empty, permutations);
            ////////var isValid = permutations.Distinct().Count() == permutations.Count();
            ////////Console.ReadLine();
            ////////LinkedList ll = new LinkedList();
            ////////ll.Add(5);
            ////////ll.Add(10);
            ////////ll.Add(100);
            ////////ll.Add(60);
            ////////ll.Add(30);
            ////////ll.Reverse();
            ////////var g = ll.ToString();
            ////////SortedDictionary<string, int> sd = new SortedDictionary<string, int>();
            ////////SortedList<string, int> sl = new SortedList<string, int>();

            ////////LinkedList<string> ll = new LinkedList<string>();
            ////////var t = ll.ElementAt(5);

            ////////var a1 = sd["as"];
            ////////var a2 = sl["as"];

            ////////List<string> al = new List<string>();
            ////////var tr = al[4];

            ////var r1 = FindMinimumStepsForHorse(0, 7, 5, 4);
            ////var p1 = new Point(1, 3);
            ////var p2 = new Point(1, 3);
            ////var b1 = p1.Equals(p2);
            ////var graph = CreateGraph();
            ////var bfsOutput = BreadthFirstTraversalOfGraph(graph, "1");
            ////var dfsOutput = DepthFirstTraversalOfGraph(graph, "1");
            ////Queue<int> qu = new Queue<int>();
            ////// qu.Dequeue();
            ////Stack<int> st = new Stack<int>();
            ////// st.Pop()
            ////// st.ToList()
            //////Heap

            var bst = CreateBST();
            var verticalTraversalResult = VerticalTraversal(bst);
            bst.Left.Left.Data = 600;
            var isBst = IsBST(bst);
            var mBst = CreateTreeMirror(bst);
            mBst.Right.Right.Left.Left = new BSTNode() { Data = 300 };
            var areMirrors = AreTreeMirrors(bst, mBst);
            var levelOrderResult = BSTLevelOrderTraversal(bst);
            ////BSTNode bstRoot = null;
            ////var r = new Random();
            ////for (int i = 0; i < 10; i++)
            ////{
            ////    var res = InsertInBST(bstRoot, r.Next(1, 100));
            ////    if (bstRoot == null)
            ////    {
            ////        bstRoot = res;
            ////    }
            ////}
            //////var bstRoot = CreateBST();
            ////InsertInBST(bstRoot, 50);
            ////InsertInBST(bstRoot, 55);
            ////InsertInBST(bstRoot, 57);
            ////var inorderResult = Inorder(bstRoot);

            ////var searchRes = SearchBST(bstRoot, 57);

            ////var minimum = FindMinimum(bstRoot);
            ////var maximum = FindMaximum(bstRoot);
            ////var succ = FindSuccessorBST(searchRes);
            ////var copiedTree = CopyBST(bstRoot);
            int[] arr = new int[] { 31, 41, 59, 26, 100, 58 };
            MergeSort(arr, 0, arr.Length - 1);
            //////InsertionSortDescending(arr);
            ////////InsertionSort(arr);

            int[] sortedArray = new int[] { 5, 10, 15, 16, 20, 50, 100, 200, 300 };
            var result = BinarySearch(sortedArray, 105, 0, 8);
            if (sortedArray[result] == 15)
            {
                // We found it
            }
            else
            {
                // result is the element which is just left to the element we want to find
                Console.Write(result);
            }

            ////////LinkedListNode a = new LinkedListNode();
            ////////LinkedListNode b = new LinkedListNode();

            ////////a.Right = b;
            ////////a.Data = "A";
            ////////LinkedListNode c = new LinkedListNode();
            ////////b.Right = c;
            ////////c.Data = "C";

            ////////a.Right.Data = "B";

            ////////int a = 64;
            ////////long b = 132412412412L;
            ////////decimal c = 1231233.4324321423m;

            ////////string a1 = a.ToString();
            ////////string b1 = b.ToString();
            ////////string c1 = c.ToString();
            //////var driver = new FirefoxDriver();
            ////////driver.Url = "http://www.youtube.com/";
            //////driver.Url = "http://ironspider.ca/forms/checkradio.htm";

            //////var list = driver.FindElementsByName("color");
            //////var redElement = list.First(a => a.GetAttribute("value") == "red");
            //////redElement.Click();
            ////////var searchBtn = driver.FindElementsByClassName("ci-tabs");
            ////////searchBtn.ElementAt(1).Click();
            //////driver.FindElementsByLinkText
            ////////var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            ////////driver.Manage().Timeouts().w(TimeSpan.FromSeconds(5));

            ////////var t1 = driver.FindElementByPartialLinkText("KKR v RCB, IPL 2017, Kolkata");
            ////////t1.Click();
            ////////driver.FindElements(By.)
            ////////WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromMinutes(1));
            ////////wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.ClassName("nav_grp_lvl1")));

            ////////var searchBox = driver.FindElementById("masthead-search-term");
            ////////searchBox.SendKeys("Sachin Tendulkar");
            ////////searchBox.SendKeys(Keys.Enter);

            ////////////var t1 = driver.FindElements(By.XPath("//li[@videoIds]"));
            ////////////t1.First().Click();

            ////////var t1 = driver.FindElement(By.CssSelector("#item-section-502373 > li:nth-child(1) > div:nth-child(1) > div:nth-child(1) > div:nth-child(2) > h3:nth-child(1) > a:nth-child(1)"));
            ////////t1.Click();
            ////// driver.FindElement()
            //////var searchButton = driver.FindElementByName("btnK");
            //////searchButton.Click();
            ////PrintPattern();
            Console.ReadLine();
        }
        static int FindCountOfLessThanInSortedArray(int[] arr, int toFind)
        {
            int result = BinarySearchForLessThanEqual(arr, 0, arr.Length - 1, toFind);

            if (result == -1)
            {
                return 0;
            }

            return result + 1;
        }

        static int BinarySearchForLessThanEqual(int[] arr, int start, int end, int toFind)
        {
            if (start > end)
            {
                return -1;
            }

            int mid = (start + end) / 2;

            if ((mid == end) || (arr[mid] <= toFind && arr[mid + 1] > toFind))
            {
                return mid;
            }

            if (toFind < arr[mid])
            {
                return BinarySearchForLessThanEqual(arr, start, mid - 1, toFind);
            }

            return BinarySearchForLessThanEqual(arr, mid + 1, end, toFind);
        }

        static int FindCountOfElementInSortedArray(int[] arr, int toFind)
        {
            // Find the left occurance
            var leftOccurance = FindLeftOccurance(arr, 0, arr.Length - 1, toFind);

            if (leftOccurance == -1)
            {
                // Element does not exist, count = 0
                return 0;
            }

            var rightOccurance = FindRightOccurance(arr, 0, arr.Length - 1, toFind);
            return rightOccurance - leftOccurance + 1;
        }

        static int FindLeftOccurance(int[] arr, int start, int end, int toFind)
        {
            if (start > end)
            {
                return -1;
            }

            int mid = (start + end) / 2;

            if (arr[mid] == toFind && (mid == 0 || arr[mid] > arr[mid - 1]))
            {
                return mid;
            }

            if (toFind <= arr[mid])
            {
                return FindLeftOccurance(arr, start, mid - 1, toFind);
            }

            return FindLeftOccurance(arr, mid + 1, end, toFind);
        }

        static int FindRightOccurance(int[] arr, int start, int end, int toFind)
        {
            if (start > end)
            {
                return -1;
            }

            int mid = (start + end) / 2;

            if (arr[mid] == toFind && (mid == arr.Length - 1 || arr[mid] < arr[mid + 1]))
            {
                return mid;
            }

            if (toFind < arr[mid])
            {
                return FindRightOccurance(arr, start, mid - 1, toFind);
            }

            return FindRightOccurance(arr, mid + 1, end, toFind);
        }

        static int PivotedBinarySearch(int[] arr, int toFind)
        {
            // We have to find the pivot first
            var pivot = FindPivot(arr, 0, arr.Length - 1);

            if (pivot == -1)
            {
                // Run normal binary search
                return BinarySearch(arr, toFind, 0, arr.Length - 1);
            }

            if (toFind <= arr[arr.Length - 1])
            {
                return BinarySearch(arr, toFind, pivot, arr.Length - 1);
            }

            return BinarySearch(arr, toFind, 0, pivot - 1);
        }

        static int FindPivot(int[] arr, int start, int end)
        {
            if (start > end)
            {
                return -1;
            }

            int mid = (start + end) / 2;

            if (mid == 0)
            {
                // Array is not rotated, it is properly rotated
                return -1;
            }

            if (arr[mid] < arr[mid - 1])
            {
                return mid;
            }

            if (arr[mid] >= arr[start])
            {
                // Pivot is on the right
                return FindPivot(arr, mid + 1, end);
            }

            return FindPivot(arr, start, mid - 1);
        }

        
        static void QuickSort(int[] arr, int start, int end)
        {
            if (start >= end)
            {
                return;
            }

            // Partition the array
            var p = PartitionArray(arr, start, end);
            QuickSort(arr, start, p - 1);
            QuickSort(arr, p + 1, end);
        }

        static int PartitionArray(int[] arr, int start, int end)
        {
            int pivot = arr[end];
            // Arrange according to pivot
            int pIndex = start;

            for (int i = start; i <= end; i++)
            {
                if (arr[i] <= pivot)
                {
                    // Swap i and pIndex
                    var temp = arr[i];
                    arr[i] = arr[pIndex];
                    arr[pIndex] = temp;
                    pIndex++;
                }
            }

            return pIndex - 1;
        }

        static List<List<Point>> FindConnectedNeighbors(int[][] matrix)
        {
            Point[][] board = new Point[matrix.Length][];
            for (int i = 0; i <= matrix.Length - 1; i++)
            {
                board[i] = new Point[matrix[i].Length];
                for (int j = 0; j <= board[i].Length - 1; j++)
                {
                    board[i][j] = new Point(i, j);
                    board[i][j].Data = matrix[i][j];
                }
            }

            List<List<Point>> allConnectedNeighbors = new List<List<Point>>();

            for (int i = 0; i <= board.Length - 1; i++)
            {
                for (int j = 0; j <= board[i].Length - 1; j++)
                {
                    var pt = board[i][j];
                    List<Point> connectedNeighbors = new List<Point>();
                    MovePointRecursively(pt, board, connectedNeighbors);

                    if (connectedNeighbors.Count > 0)
                    {
                        allConnectedNeighbors.Add(connectedNeighbors);
                    }
                }
            }

            return allConnectedNeighbors;
        }

        static void MovePointRecursively(Point p, Point[][] board, List<Point> connectedNeighbors)
        {
            if (p.isVisited == false && p.Data == 1)
            {
                connectedNeighbors.Add(p);
                p.isVisited = true;
            }
            else
            {
                return;
            }

            if (IsValidIndex(p.x - 1, p.y, board.Length, board[0].Length))
            {
                MovePointRecursively(board[p.x - 1][p.y], board, connectedNeighbors);
            }

            if (IsValidIndex(p.x - 1, p.y - 1, board.Length, board[0].Length))
            {
                MovePointRecursively(board[p.x - 1][p.y - 1], board, connectedNeighbors);
            }

            if (IsValidIndex(p.x, p.y - 1, board.Length, board[0].Length))
            {
                MovePointRecursively(board[p.x][p.y - 1], board, connectedNeighbors);
            }

            if (IsValidIndex(p.x + 1, p.y - 1, board.Length, board[0].Length))
            {
                MovePointRecursively(board[p.x + 1][p.y - 1], board, connectedNeighbors);
            }

            if (IsValidIndex(p.x + 1, p.y, board.Length, board[0].Length))
            {
                MovePointRecursively(board[p.x + 1][p.y], board, connectedNeighbors);
            }

            if (IsValidIndex(p.x + 1, p.y + 1, board.Length, board[0].Length))
            {
                MovePointRecursively(board[p.x + 1][p.y + 1], board, connectedNeighbors);
            }

            if (IsValidIndex(p.x, p.y + 1, board.Length, board[0].Length))
            {
                MovePointRecursively(board[p.x][p.y + 1], board, connectedNeighbors);
            }

            if (IsValidIndex(p.x - 1, p.y + 1, board.Length, board[0].Length))
            {
                MovePointRecursively(board[p.x - 1][p.y + 1], board, connectedNeighbors);
            }
        }

        static bool IsValidIndex(int i, int j, int n, int m)
        {
            return i >= 0 && i <= n - 1 && j >= 0 && j <= m - 1;
        }

        static int[] CreateIntArray(int size)
        {
            var arr = new int[size];
            var r = new Random();
            for (int i = 0; i <= size - 1; i++)
            {
                arr[i] = r.Next();
            }

            return arr;
        }

        static void EncodeImageMatrix(int[][] matrix, int mStart, int mEnd, int nStart, int nEnd)
        {
            // We need to print the border of the matrix
            for (int i = nStart; i <= nEnd; i++)
            {
                Console.Write(matrix[mStart][i] + " ");
            }

            for (int i = mStart + 1; i <= mEnd; i++)
            {
                Console.Write(matrix[i][nEnd] + " ");
            }

            if (nEnd > nStart)
            {
                for (int i = nEnd - 1; i >= nStart; i--)
                {
                    Console.Write(matrix[mEnd][i] + " ");
                }
            }

            if (mEnd > mStart)
            {
                for (int i = mEnd - 1; i >= mStart + 1; i--)
                {
                    Console.Write(matrix[i][nStart] + " ");
                }
            }

            if ((mStart >= mEnd) || (nStart >= nEnd))
            {
                return;
            }

            EncodeImageMatrix(matrix, mStart + 1, mEnd - 1, nStart + 1, nEnd - 1);
        }

        static string FindMinimumStepsForHorse(int sx, int sy, int dx, int dy)
        {
            Point[,] board = new Point[8, 8];
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    board[i, j] = new Point(i, j);
                }
            }

            bool solutionFound = false;
            Point sourcePoint = board[sx, sy];
            Point destinationPoint = board[dx, dy];
            Queue<Point> qu = new Queue<Point>();
            qu.Enqueue(sourcePoint);
            sourcePoint.isVisited = true;

            while (qu.Count > 0 && !solutionFound)
            {
                var currentPoint = qu.Dequeue();
                var neighbors = FindOutHorseNeighbors(board, currentPoint);

                foreach (var a in neighbors)
                {
                    if (a.isVisited == false)
                    {
                        a.isVisited = true;
                        qu.Enqueue(a);
                        a.parent = currentPoint;

                        if (a == destinationPoint)
                        {
                            // We have reached the solution Point, return
                            solutionFound = true;
                            break;
                        }
                    }
                }
            }

            var parentPath = destinationPoint.GetParentPath();
            return parentPath;
        }

        static List<Point> FindOutHorseNeighbors(Point[,] board, Point p)
        {
            List<Point> list = new List<Point>();
            if (IsValid(p.x + 2, p.y + 1))
            {
                list.Add(board[p.x + 2, p.y + 1]);
            }

            if (IsValid(p.x + 2, p.y - 1))
            {
                list.Add(board[p.x + 2, p.y - 1]);
            }

            if (IsValid(p.x - 2, p.y + 1))
            {
                list.Add(board[p.x - 2, p.y + 1]);
            }

            if (IsValid(p.x - 2, p.y - 1))
            {
                list.Add(board[p.x - 2, p.y - 1]);
            }

            if (IsValid(p.x + 1, p.y + 2))
            {
                list.Add(board[p.x + 1, p.y + 2]);
            }

            if (IsValid(p.x + 1, p.y - 2))
            {
                list.Add(board[p.x + 1, p.y - 2]);
            }

            if (IsValid(p.x - 1, p.y + 2))
            {
                list.Add(board[p.x - 1, p.y + 2]);
            }

            if (IsValid(p.x - 1, p.y - 2))
            {
                list.Add(board[p.x - 1, p.y - 2]);
            }

            return list;
        }

        static bool IsValid(int x, int y)
        {
            if (x < 0 || x > 7 || y < 0 || y > 7)
            {
                return false;
            }

            return true;
        }

        static string DepthFirstTraversalOfGraph(List<string>[] graph, string source)
        {
            string output = string.Empty;
            Stack<string> st = new Stack<string>();
            Dictionary<string, bool> visited = new Dictionary<string, bool>();
            for (int i = 0; i <= graph.Length - 1; i++)
            {
                visited[(i + 1).ToString()] = false;
            }

            st.Push(source);
            visited[source] = true;

            while (st.Count > 0)
            {
                var currentNode = st.Pop();
                visited[source] = true;
                output += " " + currentNode;

                // Loop through all connected nodes and add them to Stack if they haven't been visited yet
                int nodeNumber = Convert.ToInt32(currentNode) - 1;
                graph[nodeNumber].ForEach(a =>
                {
                    if (!visited[a])
                    {
                        visited[a] = true;
                        st.Push(a);
                    }
                });
            }

            return output.Trim();
        }

        static string BreadthFirstTraversalOfGraph(List<string>[] graph, string source)
        {
            string output = string.Empty;
            Queue<string> qu = new Queue<string>();
            Dictionary<string, bool> visited = new Dictionary<string, bool>();
            for (int i = 0; i <= graph.Length - 1; i++)
            {
                visited[(i + 1).ToString()] = false;
            }

            qu.Enqueue(source);
            visited[source] = true;

            while (qu.Count > 0)
            {
                var currentNode = qu.Dequeue();
                visited[currentNode] = true;
                output += " " + currentNode;

                // Loop through all connected nodes and add them to Queue if they haven't been visited yet
                int nodeNumber = Convert.ToInt32(currentNode) - 1;
                graph[nodeNumber].ForEach(a =>
                {
                    if (!visited[a])
                    {
                        visited[a] = true;
                        qu.Enqueue(a);
                    }
                });
            }

            return output.Trim();
        }

        static List<string>[] CreateGraph()
        {
            List<string>[] arr = new List<string>[6];

            arr[0] = new List<string>();
            arr[0].Add("2");
            arr[0].Add("3");

            arr[1] = new List<string>();
            arr[1].Add("4");
            arr[1].Add("5");

            arr[2] = new List<string>();
            arr[2].Add("1");
            arr[2].Add("5");

            arr[3] = new List<string>();
            arr[3].Add("2");
            arr[3].Add("5");
            arr[3].Add("6");

            arr[4] = new List<string>();
            arr[4].Add("2");
            arr[4].Add("3");
            arr[4].Add("4");
            arr[4].Add("6");

            arr[5] = new List<string>();
            arr[5].Add("4");
            arr[5].Add("5");

            return arr;
        }

        static List<List<BSTNode>> BSTLevelOrderTraversal(BSTNode node)
        {
            List<List<BSTNode>> levelByLevelNodes = new List<List<BSTNode>>();

            if (node == null)
            {
                return levelByLevelNodes;
            }

            int level = 0;
            levelByLevelNodes.Add(new List<BSTNode>());
            levelByLevelNodes[level] = new List<BSTNode>();
            levelByLevelNodes[level].Add(node);


            while (true)
            {
                var levelList = new List<BSTNode>();

                // Pick children of each node at current level and insert into next level
                foreach (var n in levelByLevelNodes[level])
                {
                    if (n.Left != null)
                    {
                        levelList.Add(n.Left);
                    }

                    if (n.Right != null)
                    {
                        levelList.Add(n.Right);
                    }
                }

                if (levelList.Count() == 0)
                {
                    break;
                }

                levelByLevelNodes.Add(levelList);
                level++;

            }

            return levelByLevelNodes;
        }

        static bool IsBST(BSTNode node)
        {
            BSTNode currentValue = new BSTNode() { Data = -1 };
            return IsBSTInternal(node, currentValue);

        }

        static bool IsBSTInternal(BSTNode node, BSTNode currentValue)
        {
            if (node == null)
            {
                return true;
            }

            if (!IsBSTInternal(node.Left, currentValue))
            {
                return false;
            }

            if (currentValue.Data != -1 && node.Data < currentValue.Data)
            {
                return false;
            }

            currentValue.Data = node.Data;

            if (!IsBSTInternal(node.Right, currentValue))
            {
                return false;
            }

            return true;
        }

        static Dictionary<int, List<int>> VerticalTraversal(BSTNode node)
        {
            Dictionary<int, List<int>> result = new Dictionary<int, List<int>>();
            VerticalTraversalInternal(node, result, 0);
            return result;
        }

        static void VerticalTraversalInternal(BSTNode node, Dictionary<int, List<int>> result, int vLevel)
        {
            if (node == null)
            {
                return;
            }

            if (!result.ContainsKey(vLevel))
            {
                result[vLevel] = new List<int>();
            }

            result[vLevel].Add(node.Data);

            VerticalTraversalInternal(node.Left, result, vLevel - 1);
            VerticalTraversalInternal(node.Right, result, vLevel + 1);
        }

        static BSTNode CreateBST()
        {
            BSTNode root = new BSTNode()
            {
                Data = 100,
                Left = new BSTNode
                {
                    Data = 20,
                    Left = new BSTNode
                    {
                        Data = 4,
                        Left = new BSTNode
                        {
                            Data = 1
                        },
                        Right = new BSTNode()
                        {
                            Data = 10,
                            Left = new BSTNode()
                            {
                                Data = 9
                            }
                        }
                    },
                    Right = new BSTNode
                    {
                        Data = 60
                    }
                },
                Right = new BSTNode
                {
                    Data = 300
                }
            };
            return root;
        }

        static BSTNode CreateBSTFromPreOrder(int[] arr, int rIndex, int end)
        {
            BSTNode root = new BSTNode(arr[rIndex]);

            int smaller = -1, greater = -1, i = rIndex + 1;

            while (i <= end)
            {
                if (arr[i] < root.Data && smaller == -1)
                {
                    smaller = i;
                }

                if (arr[i] > root.Data)
                {
                    greater = i;
                    break;
                }

                i++;
            }

            if (smaller != -1)
            {
                root.Left = CreateBSTFromPreOrder(arr, smaller, greater == -1 ? end : greater - 1);
            }

            if (greater != -1)
            {
                root.Right = CreateBSTFromPreOrder(arr, greater, end);
            }

            return root;
        }

        static BSTNode InsertInBST(BSTNode node, int numberToInsert)
        {
            if (node == null)
            {
                return new BSTNode { Data = numberToInsert };
            }

            if (numberToInsert < node.Data)
            {
                if (node.Left == null)
                {
                    node.Left = new BSTNode { Data = numberToInsert, Parent = node };
                    return node.Left;
                }

                return InsertInBST(node.Left, numberToInsert);
            }

            if (numberToInsert > node.Data)
            {
                if (node.Right == null)
                {
                    node.Right = new BSTNode { Data = numberToInsert, Parent = node };
                    return node.Right;
                }

                return InsertInBST(node.Right, numberToInsert);
            }

            return null;
        }

        static BSTNode SearchBST(BSTNode node, int value)
        {
            if (node.Data == value)
            {
                return node;
            }

            if (value < node.Data)
            {
                return SearchBST(node.Left, value);
            }

            return SearchBST(node.Right, value);
        }

        static BSTNode FindSuccessorBST(BSTNode node)
        {
            if (node.Right != null)
            {
                return FindMinimum(node.Right);
            }

            BSTNode parent = node.Parent;
            while (true)
            {
                if (parent == null)
                {
                    return null;
                }

                if (node == parent.Left)
                {
                    return parent;
                }

                node = parent;
                parent = parent.Parent;
            }
        }

        static BSTNode CopyBST(BSTNode rootNode)
        {
            if (rootNode == null)
            {
                return null;
            }

            BSTNode copyNode = new BSTNode { Data = rootNode.Data };
            copyNode.Left = CopyBST(rootNode.Left);
            copyNode.Right = CopyBST(rootNode.Right);
            return copyNode;
        }

        static BSTNode CreateTreeMirror(BSTNode node)
        {
            if (node == null)
            {
                return null;
            }

            var mNode = new BSTNode() { Data = node.Data }; ;
            mNode.Left = CreateTreeMirror(node.Right);
            mNode.Right = CreateTreeMirror(node.Left);
            return mNode;
        }

        static bool AreTreeMirrors(BSTNode nodeA, BSTNode nodeB)
        {
            if (nodeA == null && nodeB == null)
            {
                return true;
            }

            if (nodeA == null || nodeB == null)
            {
                return false;
            }

            if (nodeA.Data != nodeB.Data)
            {
                return false;
            }

            if (!AreTreeMirrors(nodeA.Right, nodeB.Left))
            {
                return false;
            }

            if (!AreTreeMirrors(nodeA.Left, nodeB.Right))
            {
                return false;
            }

            return true;
        }

        static string Inorder(BSTNode rootNode)
        {
            if (rootNode == null)
            {
                return string.Empty;
            }

            var leftResult = Inorder(rootNode.Left);
            var rightResult = Inorder(rootNode.Right);
            return leftResult + " " + rootNode.Data + " " + rightResult;
        }

        static BSTNode FindMinimum(BSTNode node)
        {
            var n = node;
            while (n.Left != null)
            {
                n = n.Left;
            }

            return n;
        }

        static BSTNode FindMaximum(BSTNode node)
        {
            var n = node;
            while (n.Right != null)
            {
                n = n.Right;
            }

            return n;
        }

        static void PrintPattern()
        {
            var i = 10;
            var j = 20;

            for (int i1 = 1; i1 < i; i1++)
            {
                for (int j1 = 0; j1 < i1; j1++)
                {
                    Console.Write("# ");
                }

                Console.WriteLine("");
            }
        }

        static void InsertionSort(int[] arr)
        {
            for (int i = 1; i <= arr.Length - 1; i++)
            {
                var key = arr[i];

                // Insert key into already sorted array on the left hand side
                var rightFlag = i - 1;
                while (true)
                {
                    if (rightFlag < 0 || arr[rightFlag] < key)
                    {
                        break;
                    }

                    var temp = arr[rightFlag];
                    arr[rightFlag] = arr[rightFlag + 1];
                    arr[rightFlag + 1] = temp;
                    rightFlag--;
                }
            }
        }

        static void InsertionSortDescending(int[] arr)
        {
            for (int i = 1; i <= arr.Length - 1; i++)
            {
                var key = arr[i];

                // Insert key into already sorted array on the left hand side
                var rightFlag = i - 1;
                while (true)
                {
                    if (rightFlag < 0 || arr[rightFlag] > key)
                    {
                        break;
                    }

                    var temp = arr[rightFlag];
                    arr[rightFlag] = arr[rightFlag + 1];
                    arr[rightFlag + 1] = temp;
                    rightFlag--;
                }
            }
        }

        static int BinarySearch(int[] arr, int toFind, int start, int end)
        {
            if (end - start == 1)
            {
                // Array of only 2 elements, do simple comparison
                if (arr[end] == toFind)
                {
                    return end;
                }

                if (arr[start] == toFind)
                {
                    return start;
                }

                return start;
            }

            // Divide the array into two
            int pivot = (end + start) / 2;

            if (arr[pivot] == toFind)
            {
                return pivot;
            }

            if (toFind < arr[pivot])
            {
                return BinarySearch(arr, toFind, start, pivot - 1);
            }

            if (toFind > arr[pivot])
            {
                return BinarySearch(arr, toFind, pivot + 1, end);
            }

            return -1;
        }

        static int[] CopyArray(int[] arr, int start, int end)
        {
            var newArr = new int[end - start + 1];
            int j = 0;
            for (int i = start; i <= end; i++)
            {
                newArr[j] = arr[i];
                j++;
            }

            return newArr;
        }

        static void MergeSort(int[] arr, int start, int end)
        {
            if (start >= end)
            {
                return;
            }

            int mid = (end + start) / 2;

            // Sort Left
            MergeSort(arr, start, mid);
            // Sort Right
            MergeSort(arr, mid + 1, end);
            // Merge the two sorted arrays

            MergeArrays(arr, start, mid, end);
        }

        static void MergeArrays(int[] arr, int start, int mid, int end)
        {
            var leftArray = CopyArray(arr, start, mid);
            var rightArray = CopyArray(arr, mid + 1, end);
            int leftIndex = 0;
            int rightIndex = 0;
            int mergedIndex = start;

            while (leftIndex <= leftArray.Length - 1 && rightIndex <= rightArray.Length - 1)
            {
                if (leftArray[leftIndex] > rightArray[rightIndex])
                {
                    arr[mergedIndex] = leftArray[leftIndex];
                    leftIndex++;
                }
                else
                {
                    arr[mergedIndex] = rightArray[rightIndex];
                    rightIndex++;
                }

                mergedIndex++;
            }

            while (leftIndex <= leftArray.Length - 1)
            {
                arr[mergedIndex] = leftArray[leftIndex];
                leftIndex++;
                mergedIndex++;
            }

            while (rightIndex <= rightArray.Length - 1)
            {
                arr[mergedIndex] = rightArray[rightIndex];
                rightIndex++;
                mergedIndex++;
            }
        }

        static void CreatePermutations(string str, string prefix, List<string> permutations)
        {
            var firstLetter = str[0].ToString();
            var newString = str.Substring(1);

            if (newString.Length == 1)
            {
                firstLetter = string.IsNullOrWhiteSpace(firstLetter) ? string.Empty : firstLetter;
                permutations.Add(prefix + firstLetter + newString);
                return;
            }

            var combinations = FirstLetterReplacementOptions(newString);

            foreach (var item in combinations)
            {
                CreatePermutations(item, prefix + firstLetter, permutations);
            }
        }

        static List<string> FirstLetterReplacementOptions(string str)
        {
            var toReturn = new List<string>() { str };
            for (int i = 1; i <= str.Length - 1; i++)
            {
                var newString = str.ToCharArray();
                newString[0] = str[i];
                newString[i] = str[0];
                toReturn.Add(new String(newString));
            }

            return toReturn;
        }

    }

    public static class WebDriverExtensions
    {
        public static IWebElement FindElementWithWait(this IWebDriver driver, By by, int timeoutInSeconds)
        {
            if (timeoutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                return wait.Until(drv => drv.FindElement(by));
            }
            return driver.FindElement(by);
        }
    }
}
