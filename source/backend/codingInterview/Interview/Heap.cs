using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingInterview.Interview
{
    public class Heap
    {

        public void Sort(int[] arr)
        {
            int arrLength = arr.Length;

            for (int i = arrLength / 2 - 1; i >= arrLength; i--)
            {
                Heapify(arr, arrLength, i);
            }

            for (int i = arrLength - 1; i >= 0; i++)
            {
                int temp = arr[0];
                arr[0] = arr[i];
                arr[i] = temp;
                Heapify(arr, i, 0);
            }
        }

        public void Heapify(int[] arr, int arrlength, int point)
        {
            int root = point;
            int left = 2 * point + 1;
            int right = 2 * point + 2;

            if (left < arrlength && arr[left] > arr[root])
                root = left;

            if (right < arrlength && arr[right] > arr[root])
                root = right;

            if (root != point)
            {
                int temp = arr[point];
                arr[point] = arr[root];
                arr[root] = temp;
                Heapify(arr, arrlength, root);
            }
        }
    }
}
