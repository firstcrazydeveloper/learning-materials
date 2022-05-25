using System;
using System.Collections.Generic;
using CodingInterview.Helper.SignleLinkedList;

namespace CodingInterview.Interview
{
    public class SignleLinkedList<T>
    {
        public Node Head;
        public SignleLinkedList()
        {
            this.Head = null;
        }

        // Insert node front of Linked List
        public void Add(T data)
        {
            Node newNode = new Node();
            newNode.Data = data;
            if (this.Head == null)
            {
                this.Head = newNode;
                return;
            }

            newNode.Next = this.Head;
            this.Head = newNode;
        }

        // Insert node end of Linked List
        public void Append(T data)
        {
            Node newNode = new Node { Data = data };
            if (this.Head == null)
            {
                this.Head = newNode;
                return;
            }

            Node lastNode = this.Head;
            while (lastNode.Next != null)
            {
                lastNode = lastNode.Next;
            }

            lastNode.Next = newNode;
        }

        public void InsertAfter(Node prevNode, T data)
        {

        }

        public SignleLinkedList<int> CopyLinkedList()
        {
            if (this.Head == null)
            {
                throw new InvalidOperationException();
            }

            SignleLinkedList<int> copyList = new SignleLinkedList<int>();
            Node sourceNode = this.Head;
            Node targetNode = this.Head;
            copyList.Head = targetNode;
            while (sourceNode.Next != null)
            {
                targetNode.Next = sourceNode.Next;
                sourceNode = sourceNode.Next;
                targetNode = targetNode.Next;
            }

            return copyList;
        }

        public SignleLinkedList<int> CopyCircularLinkedList()
        {
            if (this.Head == null)
            {
                throw new InvalidOperationException();
            }
            Node current = this.Head;
            Node temp;
            while (current != null)
            {
                temp = current.Next;
                current.Next = new Node() { Data = current.Data };
                current.Next.Next = temp;
                current = temp;
            }
            current = this.Head;
            while (current != null)
            {
                current.Next.Random = current.Random.Next;
                current = current.Next != null ? current.Next.Next : current.Next;
            }

            Node source = this.Head;
            Node target = this.Head.Next;
            SignleLinkedList<int> result = new SignleLinkedList<int>();
            result.Head = target;

            while (source != null && target != null)
            {
                source.Next = source.Next != null ? source.Next.Next : source.Next;
                target.Next = target.Next != null ? target.Next.Next : target.Next;
                source = source.Next;
                target = target.Next;
            }

            return result;
        }

        public Node GetMidNode()
        {
            if (this.Head == null)
            {
                throw new InvalidOperationException();
            }

            Node slowPoint = this.Head;
            Node fastPoint = this.Head;

            while (fastPoint.Next != null && fastPoint.Next.Next != null)
            {
                fastPoint = fastPoint.Next.Next;
                slowPoint = slowPoint.Next;
            }

            return slowPoint;

        }

        public bool DetectLoop(Node node)
        {
            if (node == null && node.Next == null)
                return false;

            Node slowNode = node;
            Node fastNode = node.Next;

            while (fastNode != null && fastNode.Next != null)
            {
                if (slowNode == fastNode)
                    return true;
                slowNode = slowNode.Next;
                fastNode = fastNode.Next.Next;


            }
            return false;
        }

        public void RemoveLoop(Node node)
        {
            if (node == null && node.Next == null)
                return;

            Node slowNode = node;
            Node fastNode = node.Next;

            while (fastNode != null && fastNode.Next != null)
            {
                if (slowNode == fastNode)
                    break;
                slowNode = slowNode.Next;
                fastNode = fastNode.Next.Next;


            }

            if (slowNode == fastNode)
            {
                slowNode = node;
                while (slowNode.Next == fastNode.Next)
                {
                    slowNode = slowNode.Next;
                    fastNode = fastNode.Next;
                }

                fastNode.Next = null;
            }
        }

        public void MergeTwoList(Node first, Node second)
        {
            Node firstNode = first;
            Node secondNode = second;
            Node firstNodeNext, secondNodeNext = null;

            while (firstNode.Next != null && secondNode.Next != null)
            {
                secondNodeNext = secondNode.Next;
                firstNodeNext = firstNode.Next;
                secondNode.Next = firstNode.Next;
                firstNode.Next = secondNode;

                secondNode = secondNodeNext;
                firstNode = firstNodeNext;
            }
            firstNode.Next = secondNodeNext;
            first = secondNode;
        }

        public void RemoveDuplicate(Node node)
        {
            List<int> data = new List<int>();

            Node current = node;
            Node prev = null;
            while (current != null)
            {
                int d = (int)current.Data;
                if (data.Contains(d))
                {
                    prev.Next = current.Next;
                }
                else
                {
                    data.Add((int)current.Data);
                    prev = current;
                }
                current = current.Next;

            }
        }
    }
}
