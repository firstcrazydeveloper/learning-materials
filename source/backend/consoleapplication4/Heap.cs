using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication4
{
    public class Heap
    {
        private int capacity;
        private int size;

        private int[] arr;

        public Heap()
        {
            this.capacity = 10;
            this.size = 0;
            arr = new int[capacity];
        }

        public Heap(int[] unsortedArray)
        {
            this.arr = unsortedArray;
            this.capacity = this.arr.Length;
            this.size = this.arr.Length;
            this.createHeapFromUnsortedArray();
        }

        private void createHeapFromUnsortedArray()
        {
            for (int i = this.size / 2; i >= 0; i--)
            {
                this.heapifyDown(i);
            }
        }

        public int[] GetSortedArray()
        {
            int[] sorted = new int[this.size];
            int n = this.size;
            for (int i = 0; i <= n - 1; i++)
            {
                sorted[i] = this.ExtractMax();
            }

            return sorted;
        }

        private int getParentIndex(int i)
        {
            return (i - 1) / 2;
        }

        private int getLeftChildIndex(int i)
        {
            return 2 * i + 1;
        }

        private int getRightChildIndex(int i)
        {
            return 2 * i + 2;
        }

        private bool hasLeftChild(int i)
        {
            return this.getLeftChildIndex(i) < size;
        }

        private bool hasRightChild(int i)
        {
            return this.getRightChildIndex(i) < size;
        }

        private bool hasParent(int i)
        {
            return i > 0 && this.getParentIndex(i) >= 0;
        }

        private int getLeftChild(int i)
        {
            return this.arr[this.getLeftChildIndex(i)];
        }

        private int getRightChild(int i)
        {
            return this.arr[this.getRightChildIndex(i)];
        }

        private int getParent(int i)
        {
            return this.arr[this.getParentIndex(i)];
        }

        private void swap(int a, int b)
        {
            int temp = arr[a];
            arr[a] = arr[b];
            arr[b] = temp;
        }

        public void AddItem(int itemToAdd)
        {
            // add this item to end of the heap and perform heapify up
            this.arr[this.size] = itemToAdd;
            this.size++;
            this.heapifyUp(this.size - 1);
        }

        private void heapifyUp(int startIndex)
        {
            while (hasParent(startIndex))
            {
                if (getParent(startIndex) > arr[startIndex])
                {
                    return;
                }

                int parentIndex = getParentIndex(startIndex);
                swap(startIndex, parentIndex);
                startIndex = parentIndex;
            }
        }

        public int ExtractMax()
        {
            // swap the first element with the last
            int maxValue = arr[0];
            swap(0, size - 1);
            arr[size - 1] = 0;
            this.size--;

            // Heapify Down the top element
            heapifyDown(0);
            return maxValue;
        }

        private void heapifyDown(int startIndex)
        {
            while (hasLeftChild(startIndex))
            {
                int biggerChildIndex = getLeftChildIndex(startIndex);
                if (hasRightChild(startIndex) && getRightChild(startIndex) > getLeftChild(startIndex))
                {
                    biggerChildIndex = getRightChildIndex(startIndex);
                }

                if (arr[startIndex] >= arr[biggerChildIndex])
                {
                    return;
                }

                swap(startIndex, biggerChildIndex);
                startIndex = biggerChildIndex;
            }
        }
    }
}
