using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingInterview.Interview
{
    public class Array
    {
        // Reverese the Array -- O(n)
        public int[] RevereArray(int[] arr)
        {
            if (arr == null || arr.Length < 2)
            {
                throw new InvalidOperationException();
            }
            for (int i = 0; i < arr.Length / 2; i++)
            {
                int lastIndex = arr.Length - i - 1;
                int temp = arr[lastIndex];
                arr[lastIndex] = arr[i];
                arr[i] = temp;
            }

            return arr;
        }
        //find the missing number in integer array
        public long MissingNumber(int[] arr)
        {
            long sum = 0;
            int missingIndex = -1;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == 0)
                {
                    missingIndex = i;
                }
                else
                {
                    sum = sum + arr[i];
                }
            }

            long computeSum = ((arr.Length + 1) * arr.Length) / 2;
            long missingNumber = computeSum - sum;
            return missingNumber;
        }

        //find the missing number in integer array
        public long MissingNumberEfficient(int[] arr)
        {
            long missingNumber = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] != 0)
                    missingNumber ^= arr[i];

                missingNumber ^= (i + 1);

            }
            return missingNumber;
        }

        //find the multiple missing number in integer array
        public List<int> MissingMultipleMissingNumberInArray(int[] arr)
        {
            List<int> missingNumber = new List<int>();
            int tempVal = arr[0];
            for (int i = 0; i < arr.Length; i++)
            {
                if (tempVal == arr[i])
                {
                    tempVal++;
                    continue;
                }
                else
                {
                    missingNumber.Add(tempVal);
                    i--;
                    tempVal++;
                }
            }

            return missingNumber;
        }

        public List<int> MissingMultipleMissingNumberInArrayTemp(int[] arr)
        {
            int arrSum = 0;
            for (int i = 0; i < arr.Length - 2; i++)
            {
                arrSum = arrSum + arr[i];
            }

            int sum = (((arr.Length + 1) * arr.Length) / 2) - arrSum;
            int avg = sum / 2;
            int sumSmallerHalf = 0, sumGreaterHalf = 0;

            for (int i = 0; i < arr.Length - 2; i++)
            {
                if (arr[i] <= avg)
                    sumSmallerHalf = sumSmallerHalf + arr[i];
                else
                    sumGreaterHalf = sumGreaterHalf + arr[i];
            }

            List<int> missingNumber = new List<int>();
            int firstMissing = (((avg + 1) * avg) / 2) - sumSmallerHalf;
            int secondMissing = ((((arr.Length + 1) * arr.Length) / 2) - sumSmallerHalf) - sumGreaterHalf;
            missingNumber.Add(firstMissing);
            missingNumber.Add(secondMissing);
            return missingNumber;

        }


        //Find element with Linear Binary Search
        //Time complexity =  T(n)=T(n/2)+1 => O(log n)
        public int BinarySearchLinear(int[] arr, int num)
        {
            int left = 0, right = arr.Length - 1;
            while (left <= right)
            {
                int m = left + (right - left) / 2;

                // Check if x is present at mid
                if (arr[m] == num)
                    return m;

                // If x greater, ignore left half
                if (arr[m] < num)
                    left = m + 1;

                // If x is smaller, ignore right half
                else
                    right = m - 1;
            }

            // if we reach here, then element was not present
            return -1;
        }


        //Find element with Recursive Binary Search
        //Time complexity =  T(n)=T(n/2)+1 => O(log n)
        public int BinarySearchRecursive(int[] arr, int left, int right, int num)
        {
            if (right >= left)
            {
                int mid = left + (right - left) / 2;

                // If the element is present at the middle itself
                if (arr[mid] == num)
                    return mid;

                // If element is smaller than mid, then it can only be present
                // in left subarray
                if (arr[mid] > num) return BinarySearchRecursive(arr, left, mid - 1, num);

                // Else the element can only be present in right subarray
                return BinarySearchRecursive(arr, mid + 1, right, num);
            }

            // We reach here when element is not present in array
            return -1;
        }


        // Sum of two minimum value in Array
        public int SumTwoMinimumValueInArray(int[] arr)
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

        // Quick Sort with Recursive

        public int[] QuickSortRecursive(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int pivot = Partition(arr, left, right);

                if (pivot > 1)
                {
                    QuickSortRecursive(arr, left, pivot - 1);
                }
                if ((pivot + 1) < right)
                {
                    QuickSortRecursive(arr, pivot + 1, right);
                }
            }

            return arr;
        }


        //Helper Method for Quick Sort to get Partition
        public int Partition(int[] arr, int left, int right)
        {
            int pivot = arr[left + (right - left) / 2];
            while (true)
            {
                while (arr[left].CompareTo(pivot) < 0)
                {
                    left++;
                }
                while (arr[right].CompareTo(pivot) > 0)
                {
                    right--;
                }

                if (left < right)
                {
                    int temp = arr[right];
                    arr[right] = arr[left];
                    arr[left] = temp;
                }
                else
                {
                    return right;
                }
            }
        }



        // Merge Sort

        public int[] MergeSort(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int midValue = (left + right) / 2;
                MergeSort(arr, left, midValue);
                MergeSort(arr, midValue + 1, right);
                MergeSort(arr, left, midValue + 1, right);
            }

            return arr;
        }

        //Helper Method to get Pivot value of Merge Sort
        public void MergeSort(int[] arr, int left, int midVal, int right)
        {
            // Intialize divided array
            int[] tempArray = new int[arr.Length];
            int leftIndex = midVal - 1;
            int currentPosition = left;
            int newLenth = (right - left + 1);

            while (left <= leftIndex && midVal <= right)
            {
                if (arr[left] <= arr[midVal])
                    tempArray[currentPosition++] = arr[left++];
                else
                    tempArray[currentPosition++] = arr[midVal++];
            }

            while (left <= leftIndex)
            {
                tempArray[currentPosition++] = arr[left++];
            }

            while (midVal <= right)
            {
                tempArray[currentPosition++] = arr[midVal++];
            }

            for (int i = 0; i < newLenth; i++)
            {
                arr[right] = tempArray[right];
                right--;
            }


        }

        /**
 * Sorts input and returns inversions number
 * using classical divide and conquer approach
 *
 * @param input Input array
 * @param start Start index
 * @param end   End index
 * @return int
 */
        public long mergeSort(List<int> input, int start, int end)
        {
            if (end - start < 1)
            {
                return 0;
            }

            long inversionsNumber = 0;

            // 1. divide input into subtasks
            int pivot = start + (int)Math.Ceiling(((decimal)end - start) / 2);
            // int pivot = start + end / 2;
            if (end - start > 1)
            {
                inversionsNumber += mergeSort(input, start, pivot);
                inversionsNumber += mergeSort(input, pivot + 1, end);
            }

            // 2. Merge the results
            int offset = 0;
            int leftIndex = start;
            int rightIndex = pivot + 1;
            while (leftIndex <= pivot && rightIndex <= end)
            {
                if (input[(leftIndex + offset)] <= input[rightIndex])
                {
                    if (leftIndex < pivot)
                    {
                        leftIndex++;
                    }
                    else
                    {
                        rightIndex++;
                    }
                    continue;
                }

                moveElement(input, rightIndex, leftIndex + offset);
                inversionsNumber += rightIndex - leftIndex - offset;
                rightIndex++;
                offset++;
            }

            return inversionsNumber;
        }

        private void moveElement(List<int> input, int from, int to)
        {
            int temp = input[from];
            for (int i = from; i > to; i--)
            {
                input[i] = input[i - 1];
            }
            input[to] = temp;
        }

        //Get Duplicate Number
        public List<int> GetDuplicateNumber(int[] arr)
        {
            if (arr == null || arr.Length < 2)
            {
                throw new InvalidOperationException();
            }
            List<int> duplicateNum = new List<int>();
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[Math.Abs(arr[i])] >= 0)
                    arr[Math.Abs(arr[i])] = -arr[Math.Abs(arr[i])];
                else
                    duplicateNum.Add(Math.Abs(arr[i]));
            }

            return duplicateNum;
        }

        // Litte Jhool and World Tour

        public void WorldTour(long country, long range, List<WorldTour> rangeList)
        {
            if (country < 1 || country > 10000000000)
                throw new ArgumentOutOfRangeException();
            if (range < 1 || range > 1000000)
                throw new ArgumentOutOfRangeException();

            for (int rangeVal = 0; rangeVal < rangeList.Count; rangeVal++)
            {
                WorldTour data = rangeList[rangeVal];
                int x = data.StartRange;
                int y = data.EndRange;

                if (x < 0 || y >= country)
                    throw new ArgumentOutOfRangeException();
                long count = 0;
                if (x <= y)
                {
                    for (int i = x; i <= y; i++)
                    {
                        count = count + 1;
                    }
                    WorldTourOutputPrint(count, range);
                }
                else
                {
                    int i = x;
                    int j = 0;
                    while (i <= country - 1 || j <= y)
                    {
                        count = count + 1;

                        if (i <= country - 1)
                        {
                            i = i + 1;
                        }
                        else
                        {
                            j = j + 1;
                        }

                    }

                    WorldTourOutputPrint(count, range);
                }

            }

            Console.ReadLine();
        }

        private void WorldTourOutputPrint(long count, long range)
        {
            if (count >= range)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("No");
            }
        }

    }

    public class WorldTour
    {
        public int StartRange { get; set; }
        public int EndRange { get; set; }
    }
}
