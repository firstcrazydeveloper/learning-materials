using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingInterview.TechGig
{
    public class SampleArray
    {
        int findElement(int[] arr, int n)
        {
            // leftMax[i] stores maximum of arr[0..i-1]
            int[] leftMax = new int[n];
            leftMax[0] = Int32.MinValue;

            // Fill leftMax[]1..n-1]
            for (int i = 1; i < n; i++)
                leftMax[i] = Math.Max(leftMax[i - 1], arr[i - 1]);

            // Initialize minimum from right
            int rightMin = int.MaxValue;

            // Traverse array from right
            for (int i = n - 1; i >= 0; i--)
            {
                // Check if we found a required element
                if (leftMax[i] < arr[i] && rightMin > arr[i])
                    return i;

                // Update right minimum
                rightMin = Math.Min(rightMin, arr[i]);
            }

            // If there was no element matching criteria
            return -1;
        }

        public static int GetBiggerCount(int[] arr, int num)
        {
            int length = arr.Length;
            int mid = length / 2;
            int index = 0;
            int count = 0;
            Array.Sort(arr);
            if (arr[mid] < num)
                index = GetLowestIndex(arr, num, mid);
            else
                index = GetMaxIndex(arr, num, mid);

            for (int i = index; i < length; i++)
            {
                count++;
            }

            return count;
        }

        static int GetLowestIndex(int[] arr, int num, int index)
        {
            if (index < 0)
                return 0;

            if (arr[index] > num)
            {
                return GetLowestIndex(arr, num, index - 1);
            }
            else
            {
                return index;
            }
        }
        static int GetMaxIndex(int[] arr, int num, int index)
        {
            if (index == arr.Length - 1)
                return 0;

            if (arr[index] < num)
            {
                return GetMaxIndex(arr, num, index + 1);

            }
            else
            {
                return index;
            }
        }

        public static int[] GetSorted(int[] arr)
        {
            int max = 0, sMax = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (max < arr[i])
                {

                    sMax = max;
                    max = arr[i];
                }
                else if (sMax < arr[i])
                {

                    sMax = arr[i];
                }

            }

            for (int i = arr.Length - 1, j = arr.Length - 1; i >= 0; i--)
            {
                if (arr[i] != max && arr[i] != sMax)
                {
                    arr[j] = arr[i];
                    j--;
                }
            }

            arr[0] = max;
            arr[1] = sMax;

            return arr;
        }

        public static int SumPairs(int[] arr, int num)
        {
            Dictionary<int, int> data = new Dictionary<int, int>();
            for (int i = 0; i < arr.Length; i++)
            {
                if (!data.ContainsKey(arr[i]))
                    data.Add(arr[i], 0);

                data[arr[i]] = data[arr[i]] + 1;
            }

            int duplicate = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                if (data.ContainsKey(num - arr[i]))
                    duplicate += data[num - arr[i]];

                if (num - arr[i] == arr[i])
                    duplicate--;
            }

            return duplicate / 2;
        }

        public static int GetMajorNubmer(int[] arr)
        {
            Dictionary<int, int> CountData = new Dictionary<int, int>();
            int requiredNum = arr.Length / 2;
            int count = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (!CountData.ContainsKey(arr[i]))
                    CountData.Add(arr[i], 0);

                CountData[arr[i]] = CountData[arr[i]] + 1;

                if (count < CountData[arr[i]])
                    count = arr[i];

                if (count >= requiredNum)
                    return count;

                if ((count + arr.Length - i + 1) < requiredNum)
                    break;
            }

            return -1;
        }

        public static int ThirdLargest(int[] arr)
        {
            int max = int.MinValue, sMax = int.MinValue, tMax = int.MinValue;
            for (int i = 0; i < arr.Length; i++)
            {
                if (max < arr[i])
                {
                    tMax = sMax;
                    sMax = max;
                    max = arr[i];
                }
                else if (sMax < arr[i])
                {
                    tMax = sMax;
                    sMax = arr[i];
                }

                else if (tMax < arr[i])
                {
                    tMax = arr[i];
                }
            }

            return tMax;
        }

        public static int SmallCount(int[] arr)
        {
            if (arr.Length < 2)
                throw new Exception();
            int min = int.MaxValue, sMin = int.MaxValue;
            for (int i = 0; i < arr.Length; i++)
            {
                if (min > arr[i])
                {
                    sMin = min;
                    min = arr[i];
                }
                else if (sMin > arr[i] && arr[i] != min)
                {
                    sMin = arr[i];
                }
            }

            if (sMin == int.MaxValue)
                throw new Exception();

            return min + sMin;
        }

        public static string EqualZero(int[] arr)
        {
            Dictionary<int, int> hashData = new Dictionary<int, int>();
            int sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];

                if (sum == 0 || arr[i] == 0 || hashData.ContainsKey(sum))
                {
                    return "True";
                }

                hashData[sum] = i;
            }

            return "False";
        }

        public static int MaximumSumSubArray(int[] arr, int sum)
        {
            int currSum = arr[0], maxSum = 0, start = 0;


            for (int i = 0; i < arr.Length; i++)
            {
                while (currSum > sum && start < i)
                {
                    currSum = arr[start];
                    start++;
                }

                maxSum = Math.Max(maxSum, currSum);
                currSum += arr[i];

            }

            return maxSum;
        }

        public static int MaximumSumSubArrayTemp(int[] arr, int sum)
        {
            int currSum = 0, maxSum = 0;
            int startIndex = -1, temp = 0;

            Dictionary<int, int> index = new Dictionary<int, int>();
            for (int i = 0; i < arr.Length; i++)
            {
                currSum += arr[i];
                startIndex++;
                if (currSum > sum)
                {
                    if (startIndex > 1)
                        i = i - (startIndex - 1);
                    currSum = arr[i];
                    temp = i;
                    startIndex = 0;
                }


                if (maxSum <= currSum && currSum <= sum)
                {
                    if (temp != i)
                        index[temp] = i;
                    maxSum = currSum;
                }

            }

            return maxSum;
        }

        public static int MaximumSumSubArray(int[] arr)
        {
            int currMax = 0, maxSum = int.MinValue;
            for (int i = 0; i < arr.Length; i++)
            {
                currMax += arr[i];
                if (maxSum < currMax)
                    maxSum = currMax;
                if (currMax < 0)
                    currMax = 0;

            }

            return maxSum;
        }

        // { 8, 5, 9, 5, 1 }
        public static void GetSumSubArray(int[] arr)
        {
            Dictionary<string, int> hashMap = new Dictionary<string, int>();
            int countSum = 0;
            int startPoint = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                countSum += arr[i];
                hashMap.Add('0' + i.ToString(), countSum); // 0-8,1-13,2-22,3-27,4-28
                startPoint = 0;
                int tempcount = countSum;
                while (startPoint < i - 1 && i > 1)
                {
                    tempcount = tempcount - arr[startPoint];
                    hashMap.Add((startPoint + 1).ToString() + i.ToString(), tempcount);
                    startPoint++;
                }
            }
        }


        public static void subArraySum(int[] arr, int sum)
        {
            Dictionary<int, int> hashMap = new Dictionary<int, int>();

            int countSum = 0;
            int startIndex = 0, endIndex;
            bool getIndex = false;
            while (getIndex)
            {
                for (int i = startIndex; i < arr.Length; i++)
                {
                    countSum = countSum + arr[i];

                    ////if (countSum == sum)
                    ////{
                    ////    startIndex = 0;
                    ////    endIndex = i;
                    ////    break;
                    ////}

                    hashMap[i] = countSum;
                    if (hashMap.ContainsValue(sum))
                    {
                        endIndex = i;
                        break;
                    }

                }

            }
        }
    }
}


