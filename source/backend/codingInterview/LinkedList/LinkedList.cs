using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodingInterview.LinkedList.Helper;

namespace CodingInterview.LinkedList
{
    public class LinkedListSample
    {
        public Node head;

        public LinkedListSample()
        {
            head = null;
        }

        public void Add(int d)
        {
            Node newNode = new Node() { data = d };
            if (head == null)
            {
                head = newNode;
                head.next = null;
            }
            else
            {
                newNode.next = head;
                head = newNode;
            }
        }

        public void Append(int d)
        {
            Node newNode = new Node() { data = d };
            newNode.next = null;
            if (head == null)
            {
                head = newNode;
            }
            else
            {
                Node last = head;

                while (last.next != null)
                {
                    last = last.next;
                }

                last.next = newNode;
            }
        }

        public void InsertAfter(Node prevNode, int d)
        {
            if (prevNode == null)
            {
                throw new Exception();
            }

            Node newNode = new Node() { data = d };
            newNode.next = prevNode.next;
            prevNode.next = newNode;


        }

        public void PrintList()
        {
            Node current = head;

            while (current != null)
            {
                Console.WriteLine(current.data);
                current = current.next;
            }
        }

        public Node GetSpecificNode(int d)
        {
            Node current = head;

            while (current != null)
            {
                if (current.data == d)
                {
                    return current;
                }
                current = current.next;

            }

            return null;
        }

        public Node GetNode(int d)
        {
            return GetNodeRecursive(head, d);
        }

        public Node GetNodeRecursive(Node node, int d)
        {
            if (node.data == d)
            {
                return node;
            }

            return GetNodeRecursive(node.next, d);
        }

        public void DeleteNode(ref Node node, int key)
        {
            Node current = node, preNode = head;

            if (node != null && node.data == key)
            {
                node = node.next;
                return;
            }

            while (current != null)
            {
                if (current.data == key)
                {
                    preNode.next = current.next;
                    return;

                }
                else
                {
                    preNode = current;
                    current = current.next;
                }

            }

            throw new KeyNotFoundException("Given key is not available in Linked list");

        }

        public void DeleteNodeSpecificPosition(ref Node node, int position)
        {
            if (node == null)
            {
                throw new Exception("Head is null");
            }
            Node current = node, preNode = null;
            int count = 1;

            if (position == 0)
            {
                node = current.next;
                return;
            }

            while (current != null)
            {
                if (position == count)
                {
                    preNode.next = current.next;
                    return;
                }
                else
                {
                    preNode = current;
                    current = current.next;
                    count++;
                }

            }

            throw new KeyNotFoundException("Given position is not available in Linked list");
        }

        public int GetIterativeCount()
        {
            if (head == null)
            {
                return 0;
            }

            Node current = head;
            int count = 0;
            while (current != null)
            {
                current = current.next;
                count++;
            }

            return count;
        }

        public int GetCount()
        {
            return GetRecurCount(head);
        }

        public int GetRecurCount(Node node)
        {
            if (node == null)
            {
                return 0;
            }

            return 1 + GetRecurCount(node.next);
        }

        public void SwapNodes(int x, int y)
        {
            if (x == y)
                return;
            if (head == null)
            {
                throw new Exception("Keys are not available");
            }

            Node currentX = head, prevX = null;
            Node currentY = head, prevY = null;

            while (currentX != null)
            {
                if (currentX.data == x)
                {
                    break;
                }
                else
                {
                    prevX = currentX;
                    currentX = currentX.next;
                }
            }

            while (currentY != null)
            {
                if (currentY.data == y)
                {
                    break;
                }
                else
                {
                    prevY = currentY;
                    currentY = currentY.next;
                }
            }

            prevX.next = currentY;
            Node temp = currentY.next;
            currentY.next = currentX.next;

            prevY.next = currentX;
            currentX.next = temp;
        }

        public void RemoveDuplicate()
        {
            List<int> dataList = new List<int>();
            if (head == null)
            {
                throw new Exception("Keys are not available");
            }
            Node current = head, prev = null;

            while (current != null)
            {
                if (dataList.Contains(current.data))
                {
                    prev.next = current.next;
                    current = current.next;

                }
                else
                {
                    prev = current;
                    dataList.Add(current.data);
                    current = current.next;
                }
            }

        }

        public Node GetMiddleNode()
        {
            if (head == null)
            {
                throw new Exception("LinkedList should not be empty");
            }
            Node slowPoint = head;
            Node fastPoint = head;

            while(fastPoint != null && fastPoint.next != null)
            {
                fastPoint = fastPoint.next.next;
                slowPoint = slowPoint.next;
            }

            return slowPoint;
        }
        public void DeleteMiddleNode()
        {
            if (head == null)
            {
                throw new Exception("LinkedList should not be empty");
            }
            Node slowPoint = head;
            Node fastPoint = head;
            Node prev = null;

            while (fastPoint != null && fastPoint.next != null)
            {
                fastPoint = fastPoint.next.next;
                prev = slowPoint;
                slowPoint = slowPoint.next;
            }

            prev.next = slowPoint.next;
        }
    }
}
