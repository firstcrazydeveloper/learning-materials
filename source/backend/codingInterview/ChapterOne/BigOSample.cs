using System;
using CodingInterview.Common;
using System.Collections.Generic;

namespace CodingInterview.ChapterOne
{
    public class BigOSample
    {

        // O(N2)
        public void PrintPairs(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length; j++)
                {
                    Console.Write(array[i] + ">>" + array[j] + ", ");

                }
                Console.WriteLine();

            }
        }

        // O(N2)
        public void PrintUnorderdPairs(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    Console.Write(array[i] + ">>" + array[j] + ", ");

                }
                Console.WriteLine();

            }
        }

        // O(AB)
        public void PrintUnorderdPairs(int[] arrayA, int[] arrayB)
        {
            for (int i = 0; i < arrayA.Length; i++)
            {
                for (int j = i + 1; j < arrayB.Length; j++)
                {
                    if (arrayA[i] < arrayB[j])
                        Console.Write(arrayA[i] + ">>" + arrayB[j] + ", ");

                }
                Console.WriteLine();

            }
        }

        // O(AB)
        public void PrintUnorderdPairsB(int[] arrayA, int[] arrayB)
        {
            for (int i = 0; i < arrayA.Length; i++)
            {
                for (int j = i + 1; j < arrayB.Length; j++)
                {
                    for (int k = 0; k < 10000; k++)
                    {
                        Console.Write(arrayA[i] + ">>" + arrayB[j] + ", ");
                    }
                }

                Console.WriteLine();
            }
        }

        // O(N)
        public void Reverse(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + ",");
            }
            for (int i = 0; i < arr.Length / 2; i++)
            {
                int lastIndex = arr.Length - i - 1;
                int temp = arr[i];
                arr[i] = arr[lastIndex];
                arr[lastIndex] = temp;
            }
            Console.WriteLine();
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + ",");
            }
        }

        // O(N) -- where N is the numbers of Node
        public int Sum(Node node)
        {
            if (node == null)
                return 0;
            return Sum(node.Left) + node.Data + Sum(node.Right);
        }

        // O(V^N) 
        public bool IsPrime(int n)
        {
            for (int i = 2; i * i <= n; i++)
            {
                if (n % i == 0)
                    return false;
            }
            return true;
        }

        public string swap(string str, int first, int second)
        {
            char[] arr = str.ToCharArray();
            char temp = arr[first];
            arr[first] = arr[second];
            arr[second] = temp;
            return String.Concat(arr);

        }

        // O(N*N!) There are N! permutations and it requires O(N) times to print that
        // Algorithm Paradigm: Backtracking
        public void PrintStringPermutations(string str, int startIndex, int endIndex, List<string> sortValue)
        {
            if (startIndex == endIndex)
            {
                sortValue.Add(str);
                Console.WriteLine(str);
            }
            else
            {
                for (int i = startIndex; i <= endIndex; i++)
                {
                    str = swap(str, i, startIndex);
                    PrintStringPermutations(str, startIndex + 1, endIndex, sortValue);
                    str = swap(str, i, startIndex);

                }

            }
        }

        // The minute hand moves 360 degree in 60 minute(or 6 degree in one minute) and hour hand moves 360 degree in 12 hours(or 0.5 degree in 1 minute). 
        // In h hours and m minutes, the minute hand would move (h*60 + m)*6 and hour hand would move (h*60 + m)*0.5.
        public double calcAngle(double h, double m)
        {
            // validate the input
            if (h < 0 || m < 0 || h > 12 || m > 60)
                Console.WriteLine("Wrong input");

            if (h == 12)
                h = 0;
            if (m == 60)
                m = 0;

            // Calculate the angles moved by hour and minute hands
            // with reference to 12:00
            double hour_angle = (0.5 * (h * 60 + m));
            double minute_angle = (6 * m);

            // Find the difference between two angles           

            var angle = Math.Abs(hour_angle - minute_angle);
            // smaller angle of two possible angles
            // angle = Math.Min(360 - angle, angle);
            angle = Math.Min(360 - angle, angle);

            return angle;
        }

        // O(log N)
        public int Power2(int n)
        {
            Console.WriteLine("N>> " + n);
            if (n == 0)
                return 0;
            else if (n == 1)
                return 1;
            else
            {
                int pre = Power2(n / 2);

                Console.WriteLine("Pre>> " + pre);
                int curr = pre * 2;
                Console.WriteLine("curr>> " + curr);
                return curr;
            }
        }

        // O(2N)
        public long Fib(int n)
        {
            if (n <= 1)
                return n;
            return Fib(n - 1) + Fib(n - 2);

        }

        // O(N) --> This technique called Memoization
        public void AllFib(int n)
        {
            long[] num = new long[n + 1];
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(i + " >> " + Fib(i, num));
            }
        }

        public long Fib(int n, long[] num)
        {
            if (n <= 1)
                return n;
            else if (n == 1)
                return 1;
            else if (num[n] > 0)
                return num[n];
            num[n] = Fib(n - 1) + Fib(n - 2);

            return num[n];

        }

       

    }
}
