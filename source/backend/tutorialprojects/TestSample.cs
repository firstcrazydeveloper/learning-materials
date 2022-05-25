using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorialProjects
{
    public class TestSample
    {
        public int findSubArray(int[] arr, int n)
        {
            int maxSize = 0;
            int sum = 0;
            for (int i = 0; i < n; i++)
            {
                sum = sum + arr[i];
            }

            if (n % 2 == 0 && n / 2 == sum)
            {
                return n;
            }

            return maxSize;
        }

        // Returns largest subarray with equal number of 0s and 1s
        int maxLen(int[] arr, int n)
        {
            // Creates an empty hashMap hM
            Dictionary<int, int> hM = new Dictionary<int, int>();

            int sum = 0;     // Initialize sum of elements
            int max_len = 0; // Initialize result
            int ending_index = -1;

            for (int i = 0; i < n; i++)
            {
                arr[i] = (arr[i] == 0) ? -1 : 1;
            }

            // Traverse through the given array
            for (int i = 0; i < n; i++)
            {
                // Add current element to sum
                sum += arr[i];

                // To handle sum=0 at last index
                if (sum == 0)
                {
                    max_len = i + 1;
                    ending_index = i;
                }

                // If this sum is seen before, then update max_len
                // if required
                if (hM.ContainsKey(sum))
                {
                    if (max_len < i - hM[sum + n])
                    {
                        max_len = i - hM[sum + n];
                        ending_index = i;
                    }
                }
                else // Else put this sum in hash tableh
                    hM[sum + n] = i;
            }

            for (int i = 0; i < n; i++)
            {
                arr[i] = (arr[i] == -1) ? 0 : 1;
            }

            int end = ending_index - max_len + 1;
            Console.WriteLine(end + " to " + ending_index);

            return max_len;
        }

        void myCode(int[] myarr, int n)
        {
            int sum = 0;
            for (int i = 0; i < n; i++)
            {

            }

        }

        public void Call()
        {
            int[] arr = { 1, 0, 1, 1, 1, 0, 0 };// { 1, 4, -2, -2, 5, -4, 3 }; // { 4, 2, -3, 1, 6 };
            int n = arr.Length;

            printZeroSumSubarrayTemp(arr);
            //maxLen(arr, n);
        }

        static bool printZeroSumSubarray(int[] arr)
        {
            // Creates an empty hashMap hM
            Dictionary<int, int> hM =
                              new Dictionary<int, int>();

            // Initialize sum of elements
            int sum = 0;

            // Traverse through the given array
            for (int i = 0; i < arr.Length; i++)
            {
                // Add current element to sum
                sum += arr[i];

                // Return true in following cases
                // a) Current element is 0
                // b) sum of elements from 0 to i is 0
                // c) sum is already present in hash map
                if (arr[i] == 0 || sum == 0 || hM.ContainsKey(sum))
                {
                    int startIndex = hM[sum] + 1;
                    int endIndex = i;
                    return true;
                }

                // Add sum to hash map
                hM[sum] = i;
            }

            // We reach here only when there is no subarray with 0 sum
            return false;
        }


        public static void printZeroSumSubarrayTemp(int[] arr)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();
            map.Add(0, 0);
            map.Add(1, 0);
            int startIndex = 0, endIndex = 0;
            int sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = arr[i] == 0 ? -1 : 1;

            }
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
                if (sum == 0)
                    map[0] = map[0] + 1;
                else
                    map[1] = map[1] + 1;

                if(map[0] == map[1])
                {
                    startIndex = endIndex;
                    endIndex = i;

                }
            }
            
        }
    }
}
