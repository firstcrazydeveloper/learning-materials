using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication4
{
    public class LinkedListNode
    {
        public int Data { get; set; }
        public LinkedListNode Next { get; set; }
        public LinkedListNode Previous { get; set; }

        public override string ToString()
        {
            return this.Data.ToString();
        }
    }

    public class LinkedList
    {
        private LinkedListNode startNode;
        private LinkedListNode endNode;
        public int Count = 0;

        public void Add(int d)
        {
            var newNode = new LinkedListNode() { Data = d };

            if (this.startNode == null)
            {
                this.startNode = newNode;
                this.endNode = newNode;
                return;
            }

            this.endNode.Next = newNode;
            this.endNode = newNode;
            this.Count++;
        }

        public void Reverse()
        {
            if (this.Count == 0)
            {
                return;
            }

            LinkedListNode reversedHead;
            var nextNode = this.startNode.Next;
            this.startNode.Next = null;
            reversedHead = this.startNode;
            this.endNode = reversedHead;
            while (nextNode != null)
            {
                var temp = nextNode.Next;
                nextNode.Next = reversedHead;
                reversedHead = nextNode;
                nextNode = temp;
            }

            this.startNode = reversedHead;
        }

        public override string ToString()
        {
            string result = string.Empty;
            this.TraverseList(node =>
            {
                result += " " + node.ToString();
            });

            return result;
        }

        private void TraverseList(Action<LinkedListNode> action)
        {
            if (this.Count == 0)
            {
                return;
            }

            var node = this.startNode;
            while (node != null)
            {
                action(node);
                node = node.Next;
            }
        }
    }
}
