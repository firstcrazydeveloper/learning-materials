using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication4
{
    public class Stack
    {
        private int[] arr = new int[50];
        private int topIndex = -1;

        void Push(int a)
        {
            if (this.topIndex == this.arr.Length - 1)
            {
                throw new Exception("Stack is full, cannot add more elements");
            }

            arr[this.topIndex] = a;
            this.topIndex++;
        }

        int Pop()
        {
            if (this.topIndex == -1)
            {
                throw new Exception();
            }

            int topElement = this.arr[this.topIndex];
            this.topIndex--;
            return topElement;
        }

        int Peek()
        {
            return arr[topIndex];
        }

        bool IsEmpty()
        {
            return this.topIndex == -1;
        }
    }
}
