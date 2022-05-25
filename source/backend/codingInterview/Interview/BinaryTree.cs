using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodingInterview.Helper.BinaryTree;

namespace CodingInterview.Interview
{
    public class BinaryTree
    {
        public Node Root;
        public Node MirrorRoot;
        public int Predecessor, Successor;

        public int GetHeight(Node node)
        {
            if (node == null)
                return 0;
            else
            {

                int leftHeight = GetHeight(node.Left);
                int rightHeight = GetHeight(node.Right);

                if (leftHeight < rightHeight)
                    return (rightHeight + 1);
                else
                    return (leftHeight + 1);
            }
        }

        // O(n^2)
        // PrintGivenLevel
        private void BinaryTreeGivenLevel(Node node, int level)
        {
            if (node == null)
                return;
            if (level == 1)
                Console.WriteLine(node.Data);

            BinaryTreeGivenLevel(node.Left, level - 1);
            BinaryTreeGivenLevel(node.Right, level - 1);

        }

        // BFS
        public void BinaryTreeLevelOrderTraversal(Node node)
        {
            int height = GetHeight(node);
            for (int i = 1; i <= height; i++)
            {
                BinaryTreeGivenLevel(node, i);
            }
        }

        // DFS - InOrder
        public void InOrderTraversal(Node node)
        {
            if (node == null)
                return;

            InOrderTraversal(node.Left);
            Console.WriteLine(node.Data);
            InOrderTraversal(node.Right);

        }

        public void InOrderPre­de­ces­sor(Node node, Dictionary<int, Node> dict)
        {
            if (node == null)
                return;

            InOrderPre­de­ces­sor(node.Left, dict);
            Console.WriteLine(node.Data);
            dict.Add(node.Data, node);
            InOrderPre­de­ces­sor(node.Right, dict);

        }

        // DFS - PreOrder
        public void PreOrderTraversal(Node node)
        {
            if (node == null)
                return;

            Console.WriteLine(node.Data);
            PreOrderTraversal(node.Left);
            PreOrderTraversal(node.Right);
        }

        // DFS - PostOrder
        public void PostOrderTraversal(Node node)
        {
            if (node == null)
                return;
            PostOrderTraversal(node.Left);
            PostOrderTraversal(node.Right);
            Console.WriteLine(node.Data);
        }

        public Node BinaryTreeMirror(Node node)
        {
            if (node == null)
                return null;

            Node leftNode = BinaryTreeMirror(node.Left);
            Node rightNode = BinaryTreeMirror(node.Right);

            node.Left = rightNode;
            node.Right = leftNode;
            return node;
        }
        public bool AreBinaryMirror(Node source, Node target)
        {
            if (source == null && target == null)
                return true;

            if (source == null || target == null)
                return false;

            return source.Data == target.Data &&
                AreBinaryMirror(source.Left, target.Right) &&
                AreBinaryMirror(source.Right, target.Left);
        }


        public int GetMaxWidthOfBinaryTree(Node node)
        {
            int maxWidth = 0;
            int height = GetHeight(node);
            for (int i = 1; i <= height; i++)
            {
                int currentLevelWidth = GetMaxWidth(node, i);
                if (currentLevelWidth > maxWidth)
                    maxWidth = currentLevelWidth;
            }
            return maxWidth;

        }

        public int GetMaxWidth(Node node, int level)
        {
            if (node == null)
                return 0;
            if (level == 1)
                return 1;
            if (level > 1)
            {
                return GetMaxWidth(node.Left, level - 1) + GetMaxWidth(node.Right, level - 1);
            }

            return 0;
        }

        // Boundary Traversal of binary tree
        // O(n)

        public void PrintBoundryLeaf(Node node)
        {
            if (node != null)
            {
                Console.WriteLine(node.Data);
                PrintBoundryLeftLeaf(node.Left);

                PrintLeafNode(node.Left);
                PrintLeafNode(node.Right);

                PrintBoundryRightLeaf(node.Right);
            }
        }
        public void PrintLeafNode(Node node)
        {
            if (node != null)
            {
                PrintLeafNode(node.Left);

                if ((node.Left == null && node.Right == null))
                    Console.WriteLine(node.Data);

                PrintLeafNode(node.Right);
            }
        }

        public void PrintBoundryLeftLeaf(Node node)
        {
            if (node != null)
            {
                if (node.Left != null && node.Right != null)
                    Console.WriteLine(node.Data);
                PrintBoundryLeftLeaf(node.Left);
            }
        }

        public void PrintBoundryRightLeaf(Node node)
        {
            if (node != null)
            {
                if (node.Left != null && node.Right != null)
                    Console.WriteLine(node.Data);
                PrintBoundryRightLeaf(node.Right);
            }
        }

        // Print All root to Leaf
        // O(n^2)
        public void PrintRootToLeafPath(Node node)
        {
            int height = GetHeight(node);
            int[] leafNodeCollection = new int[height];
            PrintRootToLeafPath(node, leafNodeCollection, 0);

        }

        public void PrintRootToLeafPath(Node node, int[] leafCollection, int pathCount)
        {
            if (node == null)
                return;

            leafCollection[pathCount] = node.Data;
            pathCount++;

            if (node.Left == null && node.Right == null)
                PrintRootToLeafPath(leafCollection, pathCount);
            else
            {
                PrintRootToLeafPath(node.Left, leafCollection, pathCount);
                PrintRootToLeafPath(node.Right, leafCollection, pathCount);
            }
        }

        public void PrintRootToLeafPath(int[] leafCOllection, int pathCount)
        {
            for (int i = 0; i < pathCount; i++)
            {
                Console.Write(leafCOllection[i] + " ");
            }
            Console.WriteLine();
        }

        public void PrintNextLeftNode(Node rootNode, int data, List<Node> getValue)
        {
            if (rootNode == null)
                return;
            if (rootNode.Data == data && rootNode.Left != null)
            {
                Console.WriteLine(rootNode.Left.Data);
                getValue.Add(rootNode.Left);
            }
            else if (rootNode.Data == data && rootNode.Left == null)
            {
                Console.WriteLine("There is no any left node of this Parents");
            }
            else
            {
                PrintNextLeftNode(rootNode.Left, data, getValue);
                PrintNextLeftNode(rootNode.Right, data, getValue);
            }
        }

        public Node PrintNextRightNode(Node node, int data)
        {
            if (node == null)
                return null;

            Queue<Node> nodeQueue = new Queue<Node>();
            Queue<int> level = new Queue<int>();

            nodeQueue.Enqueue(node);
            level.Enqueue(0);

            while (nodeQueue.Count != 0)
            {
                Node n = nodeQueue.Peek();
                int tempLevel = level.Peek();

                nodeQueue.Dequeue();
                level.Dequeue();

                if (n.Data == data)
                {
                    if (n.Right == null)
                        return null;
                    return n.Right;
                }

                if (n.Right != null)
                {
                    nodeQueue.Enqueue(n.Right);
                    level.Enqueue(tempLevel + 1);
                }
                if (n.Left != null)
                {
                    nodeQueue.Enqueue(n.Left);
                    level.Enqueue(tempLevel + 1);
                }

            }

            return null;
        }

        public void temp(Node node)
        {
            if (node == null)
            {
                return;
            }
            int height = GetHeight(node);
            List<int> levelList = new List<int>();
            Queue<Node> nodeQueue = new Queue<Node>();
            Stack<Node> nodeStack = new Stack<Node>();
            Queue<int> level = new Queue<int>();
            level.Enqueue(1);
            nodeQueue.Enqueue(node);

            while (nodeQueue.Count != 0)
            {
                int temp = level.Peek();
                var n = nodeQueue.Peek();
                nodeStack.Push(n);
                levelList.Add(temp);
                level.Dequeue();
                nodeQueue.Dequeue();

                if (n.Left != null)
                {
                    nodeQueue.Enqueue(n.Left);
                    level.Enqueue(temp + 1);
                }
                if (n.Right != null)
                {
                    nodeQueue.Enqueue(n.Right);
                    level.Enqueue(temp + 1);
                }

            }
        }

        public void successorPredecessor(Node node, int val)
        {
            if (node != null)
            {
                if (node.Data == val)
                {
                    if (node.Left != null)
                    {
                        var temp = node.Left;
                        while (temp.Right != null)
                        {
                            temp = temp.Right;
                        }

                        Predecessor = temp.Data;
                    }
                    if (node.Right != null)
                    {
                        var temp = node.Right;
                        while (temp.Left != null)
                        {
                            temp = temp.Left;
                        }

                        Successor = temp.Data;
                    }
                }
                else if (val > node.Data)
                {
                    Successor = node.Data;
                    successorPredecessor(node.Left, val);

                }
                else if (val < node.Data)
                {
                    Predecessor = node.Data;
                    successorPredecessor(node.Right, val);
                }
            }
        }

        public Node BuildBinaryTree(int[] inOrder, int[] postOrder, int length)
        {
            Index index = new Index();
            index.index = length - 1;
            return BuildBinaryTree(inOrder, postOrder, 0, length - 1, index);
        }
        public Node BuildBinaryTree(int[] inOrder, int[] postOrder, int startPoint, int endPoint, Index index)
        {
            if (startPoint > endPoint)
                return null;

            Node node = new Node(postOrder[index.index]);
            index.index--;
            if (startPoint == endPoint)
                return node;

            int tempIndex = SearchValue(inOrder, startPoint, endPoint, node.Data);
            node.Right = BuildBinaryTree(inOrder, postOrder, tempIndex + 1, endPoint, index);
            node.Left = BuildBinaryTree(inOrder, postOrder, startPoint, tempIndex - 1, index);
            return node;
        }

        public int SearchValue(int[] inOrder, int startPoint, int endPoint, int val)
        {
            int i = startPoint;
            for (; i <= endPoint; i++)
            {
                if (inOrder[i] == val)
                    break;
            }
            return i;
        }

        public int GetMaxValue(Node node)
        {
            if (node == null)
                return 0;
            int result = 0;
            int height = GetHeight(node);
            for (int i = 0; i < height; i++)
            {
                int tempResult = GetMaxValueAtGivenLevel(node, i);
                if (tempResult > result)
                    result = tempResult;
            }

            return result;
        }

        public int GetMaxValueAtGivenLevel(Node node, int level)
        {
            if (node == null)
                return 0;
            int result = level == 1 ? node.Data : 0;
            int leftResult = GetMaxValueAtGivenLevel(node.Left, level - 1);
            int rightResult = GetMaxValueAtGivenLevel(node.Right, level - 1);
            if (leftResult > result)
                result = leftResult;
            if (rightResult > result)
                result = rightResult;
            return result;
        }


        public Node CreateMinimalTree(int[] arr, int start, int end)
        {
            int mid = (start + end) / 2;

            Node node = new Node(mid);
            node.Left = CreateMinimalTree(arr, start, mid - 1);
            node.Right = CreateMinimalTree(arr, mid + 1, end);
            return node;
        }


        public Node Commonancestor(int num1, int num2)
        {
            return CommonAncestorUtil(this.Root, num1, num2);

        }

        public Node CommonAncestorUtil(Node node, int num1, int num2)
        {
            if (node == null)
                return null;

            if (node.Data == num1 || node.Data == num2)
                return node;

            Node left = CommonAncestorUtil(node.Left, num1, num2);
            Node right = CommonAncestorUtil(node.Right, num1, num2);

            if (left != null && right != null)
                return node;

            return left != null ? left : right;

        }


    }
}
