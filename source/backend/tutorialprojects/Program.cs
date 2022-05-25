using System;
using System.Collections.Generic;
using System.Collections;
using TutorialProjects.binaryTree;
using TutorialProjects.topoligicalSort;

namespace TutorialProjects
{
    public class Program
    {

        static void Main(string[] args)
        {
            var A = new Movie(0, 1.2f);
            var B = new Movie(1, 2.4f);
            var C = new Movie(2, 3.6f);

            A.AddSimilarMovie(B);
            A.AddSimilarMovie(C);

            //B.AddSimilarMovie (C);

            var D = new Movie(3, 4.8f);

            D.AddSimilarMovie(B);
            D.AddSimilarMovie(C);
            //D.addSimilarMovie (A);

            MovieFilter mf = new MovieFilter();

            var result = mf.GetTopRatedMovieList(A, 2);
            var result2 = mf.GetTopRatedMovieList(A, 4);
            var result3 = mf.GetTopRatedMovieList(A, 1);

            Random rating = new Random();
            var movieId = 0;
            var X = new Movie(movieId, (float)rating.NextDouble() * 5);

            var currentMovie = X;
            while (movieId < 1000000)
            {
                movieId++;
                var newMovie = new Movie(movieId, (float)rating.NextDouble() * 5);
                currentMovie.AddSimilarMovie(newMovie);
                currentMovie = newMovie;
            }
            Console.WriteLine(DateTime.Now.ToString());
            try
            {
                var result4 = mf.GetTopRatedMovieList(X, 20);
                Console.WriteLine(DateTime.Now.ToString());
            }
            catch (StackOverflowException e)
            {
                Console.WriteLine(e.Message);
            }



            //BinaryTree tree = new BinaryTree();
            //tree.root = new Node(20);

            //tree.root.left = new Node(8);
            //tree.root.right = new Node(22);
            //tree.root.right.left = new Node(21);

            //tree.root.left.left = new Node(4);
            //tree.root.left.right = new Node(12);
            //tree.root.left.right.left = new Node(10);
            //tree.root.left.right.right = new Node(14);


            //PetrolPump p = new PetrolPump();
            //p.Test();

            //tree.root.left.left.left = new Node(15);
            //tree.root.left.left.right = new Node(14);
            //tree.root.left.right.left = new Node(13);
            //tree.root.left.right.right = new Node(12);
            //tree.root.right.left.left = new Node(11);
            //tree.root.right.left.right = new Node(10);
            //tree.root.right.right.left = new Node(9);
            //tree.root.right.right.right = new Node(8);

            //BinaryTree tree = new BinaryTree();
            //tree.root = new Node(10);
            //tree.root.left = new Node(8);
            //tree.root.right = new Node(12);
            //tree.root.left.left = new Node(3);

            // Populates nextRight pointer in all nodes
            //var t= tree.inOrderSuccessor(tree.root, tree.root.left.right.left);

            //Console.WriteLine("Travers ");
            //tree.PrintPostOrderTraverse(tree.root);
            //Console.WriteLine("");

            //Console.WriteLine("Post Order ");
            //tree.PrintPostOrder(tree.root);
            //Console.WriteLine("");

            //Console.WriteLine("In Order ");
            //tree.PrintInOrder(tree.root);
            //Console.WriteLine("");

            //Console.WriteLine("Post Order ");
            //tree.PrintPostOrder(tree.root);
            //Console.WriteLine("");

            //// Let us see the populated values
            //Node ptr = tree.root.left.left;
            //while (ptr != null)
            //{
            //    // -1 is printed if there is no successor
            //    int print = ptr.next != null ? ptr.next.data : -1;
            //    Console.Write("Next of " + ptr.data + " is: " + print + ", ");
            //    ptr = ptr.next;
            //}

            //// tree.printPaths(tree.root);
            //int g = tree.GetMinVal(tree.root);
            //var node = tree.inOrderSuccessor(tree.root, tree.root);
            //// tree.recursive(1);
            //// tree.printSpiralIteration(tree.root);
            //int f = tree.GetMaxValAtGivenLevel(tree.root, 3);
            //TestSample ts = new TestSample();
            //ts.Call();

            //List<int> mice = new List<int>();
            //mice.Add(4);
            //mice.Add(-4);
            //mice.Add(2);
            //List<int> holes = new List<int>();
            //holes.Add(4);
            //holes.Add(0);
            //holes.Add(5);

            //int result = Mice(mice, holes);

            int[] arr = { 900, 940, 950, 1100, 1500, 1800 };
            int[] dep = { 910, 1200, 1120, 1130, 1900, 2000 };

            int f = findPlatform(arr, dep, arr.Length);
        }

        static int Mice(List<int> mice, List<int> holes)
        {
            if (mice.Count != holes.Count)
                return -1;

            /* Sort the lists */
            mice.Sort();
            holes.Sort();

            int size = mice.Count;

            /* finding max difference between ith mice and hole */
            int max = 0;
            for (int i = 0; i < size; i++)
                if (max < Math.Abs(mice[i] - holes[i]))
                    max = Math.Abs(mice[i] - holes[i]);

            return Math.Abs(max);
        }

        static int minCoins(int[] coins, int m, int V)
        {
            // base case
            if (V == 0) return 0;

            // Initialize result
            int res = int.MaxValue;

            // Try every coin that has smaller value than V
            for (int i = 0; i < m; i++)
            {
                if (coins[i] <= V)
                {
                    int sub_res = minCoins(coins, m, V - coins[i]);

                    // Check for INT_MAX to avoid overflow and see if
                    // result can minimized
                    if (sub_res != int.MaxValue && sub_res + 1 < res)
                    {
                        res = sub_res + 1;
                    }
                }
            }
            return res;
        }

        private static int findMinCoins(int[] coins, int sum)
        {
            int[] calculationsCache = new int[sum + 1];
            for (int i = 0; i <= sum; i++)
            {
                calculationsCache[i] = int.MaxValue;
            }
            calculationsCache[0] = 0;/*sum 0 , can be made with 0 coins*/
            for (int i = 1; i <= sum; i++)
            {
                for (int j = 0; j < coins.Length; j++)
                {
                    if (i >= coins[j] && i - coins[j] >= 0 && calculationsCache[i - coins[j]] + 1 < calculationsCache[i])
                    {
                        calculationsCache[i] = calculationsCache[i - coins[j]] + 1;
                    }
                }
            }
            return calculationsCache[sum];
        }

        static int findPlatform(int[] arr, int[] dep, int n)
        {
            // Sort arrival and departure arrays
            Array.Sort(arr);
            Array.Sort(dep);

            // plat_needed indicates number of platforms needed at a time
            int plat_needed = 1, result = 1;
            int i = 1, j = 0;

            // Similar to merge in merge sort to process all events in sorted order
            while (i < n && j < n)
            {
                // If next event in sorted order is arrival, increment count of
                // platforms needed
                if (arr[i] < dep[j])
                {
                    plat_needed++;
                    i++;
                    if (plat_needed > result)  // Update result if needed
                        result = plat_needed;
                }
                else // Else decrement count of platforms needed
                {
                    plat_needed--;
                    j++;
                }
            }

            return result;
        }
    }




}
