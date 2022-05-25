using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorialProjects.binaryTree
{
    public class BinaryTree
    {
        public Node root;
        public int height(Node node)
        {
            if (node == null)
                return 0;
            else
            {

                /* compute the height of each subtree */
                int lheight = height(node.left);
                int rheight = height(node.right);

                /* use the larger one */
                if (lheight > rheight)
                    return (lheight + 1);
                else
                    return (rheight + 1);
            }
        }
        public void PrintBinaryNode(Node node)
        {
            int h = height(node);
            int i;
            for (i = 1; i <= h; i++)
            {
                PrintRightBinaryTree(node, i);


            }

        }

        public int GetMaxVal(Node node)
        {
            int h = height(node);
            int i;
            int val = 0;
            for (i = 1; i <= h; i++)
            {
                int temp = GetMaxValAtGivenLevel(node, i);
                val = val < temp ? temp : val;
            }

            return val;
        }

        public int GetMinVal(Node node)
        {
            int h = height(node);
            int i;
            int val = node.data;
            for (i = 1; i <= h; i++)
            {
                int temp = GetMinValAtGivenLevel(node, i);
                val = val > temp ? temp : val;
            }

            return val;
        }
        public void printSpiral(Node node)
        {
            int h = height(node);
            int i;

            /* ltr -> left to right. If this variable is set then the
               given label is transversed from left to right */
            bool ltr = true;
            for (i = 1; i <= h; i++)
            {
                printGivenLevel(node, i, ltr);

                /*Revert ltr to traverse next level in opposite order*/
                ltr = i == h - 1 ? false : ltr;
                // ltr = !ltr;
            }

        }
        public void PrintBinaryTree(Node node, int level)
        {
            if (node == null)
                return;
            if (level == 1)
                Console.Write(node.data);
            else if (level > 1)
            {
                PrintBinaryTree(node.left, level - 1);
                PrintBinaryTree(node.right, level - 1);
            }


        }
        public void PrintLeftBinaryTree(Node node, int level)
        {
            if (node == null)
                return;
            if (level == 1)
                Console.Write(node.data);
            else if (level > 1)
            {
                PrintLeftBinaryTree(node.left, level - 1);
            }


        }
        public void PrintRightBinaryTree(Node node, int level)
        {
            if (node == null)
                return;
            if (level == 1)
                Console.Write(node.data);
            else if (level > 1)
            {
                PrintRightBinaryTree(node.right, level - 1);
            }


        }
        public void printGivenLevel(Node node, int level, bool ltr = true)
        {
            if (node == null)
                return;
            if (level == 1)
                Console.Write(node.data + " ");
            else if (level > 1)
            {
                if (ltr != false)
                {
                    printGivenLevel(node.left, level - 1, ltr);
                    printGivenLevel(node.right, level - 1, ltr);
                }
                else
                {
                    printGivenLevel(node.right, level - 1, ltr);
                    printGivenLevel(node.left, level - 1, ltr);
                }
            }
        }
        public int GetMaxValAtGivenLevel(Node node, int level)
        {

            if (node == null)
                return 0;
            int res = level == 1 ? node.data : 0;
            int lres = GetMaxValAtGivenLevel(node.left, level - 1);
            int rres = GetMaxValAtGivenLevel(node.right, level - 1);
            if (lres > res)
                res = lres;
            if (rres > res)
                res = rres;
            return res;
        }

        public int GetMinValAtGivenLevel(Node node, int level)
        {

            if (node == null)
                return 0;
            int res = node.data;
            int lres = GetMinValAtGivenLevel(node.left, level - 1);
            int rres = GetMinValAtGivenLevel(node.right, level - 1);
            if (lres < res)
                res = lres;
            if (rres < res)
                res = rres;
            return res;
        }
        public void recursive(int i)
        {
            Console.WriteLine(i.ToString());
            if (i < 10)
                recursive(i + 1);
            Console.WriteLine(i.ToString());
        }
        public void printSpiralIteration(Node node)
        {
            if (node == null)
                return;   // NULL check

            // Create two stacks to store alternate levels
            Stack<Node> s1 = new Stack<Node>();// For levels to be printed from right to left
            Stack<Node> s2 = new Stack<Node>();// For levels to be printed from left to right

            // Push first level to first stack 's1'
            s1.Push(node);

            // Keep ptinting while any of the stacks has some nodes
            while (s1.Count != 0 || s2.Count != 0)
            {
                // Print nodes of current level from s1 and push nodes of
                // next level to s2
                while (s1.Count != 0)
                {
                    Node temp = s1.Peek();
                    s1.Pop();
                    Console.Write(temp.data + " ");

                    // Note that is right is pushed before left
                    if (temp.right != null)
                        s1.Push(temp.right);

                    if (temp.left != null)
                        s1.Push(temp.left);

                }

                // Print nodes of current level from s2 and push nodes of
                // next level to s1
                //while (s2.Count != 0)
                //{
                //    Node temp = s2.Peek();
                //    s2.Pop();
                //    Console.Write(temp.data + " ");
                //    // Note that is left is pushed before right
                //    if (temp.left != null)
                //        s1.Push(temp.left);
                //    if (temp.right != null)
                //        s1.Push(temp.right);
                //}
            }
        }
        public void printPaths(Node node)
        {
            Dictionary<int, int> nodeList = new Dictionary<int, int>();
            printPaths(node, nodeList, 0);
        }
        public void printPathNode(Dictionary<int, int> nodeList)
        {
            foreach (var item in nodeList)
            {
                Console.Write(item.Value + " ");

            }
            Console.WriteLine();
        }
        public void printPaths(Node node, Dictionary<int, int> nodeList, int len)
        {
            if (node == null)
                return;

            /* append this node to the path array */
            nodeList[len] = node.data;
            len++;

            /* it's a leaf, so print the path that led to here  */
            if (node.left == null && node.right == null)
                printPathNode(nodeList);
            else
            {
                /* otherwise try both subtrees */
                printPaths(node.left, nodeList, len);
                printPaths(node.right, nodeList, len);
            }
        }
        public void printPathsArray(Node node)
        {
            int[] path = new int[1000];
            printPaths(node, path, 0);
        }
        public void printPaths(Node node, int[] path, int pathLen)
        {
            if (node == null)
                return;

            /* append this node to the path array */
            path[pathLen] = node.data;
            pathLen++;

            /* it's a leaf, so print the path that led to here  */
            if (node.left == null && node.right == null)
                printArray(path, pathLen);
            else
            {
                /* otherwise try both subtrees */
                printPaths(node.left, path, pathLen);
                printPaths(node.right, path, pathLen);
            }
        }
        public void printArray(int[] ints, int len)
        {
            int i;
            for (i = 0; i < len; i++)
            {
                Console.Write(ints[i] + " ");
            }
            Console.WriteLine("");
        }

        //O(n)
        public Node FindNextRightNode(Node node, int baseVaue)
        {
            if (node == null)
                return null;

            Queue<Node> nodeStack = new Queue<Node>();
            Queue<int> level = new Queue<int>();

            nodeStack.Enqueue(node);
            level.Enqueue(0);
            int baseLevel = 0;

            while (nodeStack.Count != 0)
            {
                Node n = nodeStack.Peek();
                baseLevel = level.Peek();

                nodeStack.Dequeue();
                level.Dequeue();

                if (n.data == baseVaue)
                {
                    if (level.Count == 0 || level.Peek() != baseLevel)
                    {
                        return null;
                    }

                    return nodeStack.Peek();
                }



                if (n.left != null)
                {
                    nodeStack.Enqueue(n.left);
                    level.Enqueue(baseLevel + 1);
                }
                if (n.right != null)
                {
                    nodeStack.Enqueue(n.right);
                    level.Enqueue(baseLevel + 1);
                }




            }


            return null;
        }

        //O(n)
        public Node FindNextLeftNode(Node node, int baseVaue)
        {
            if (node == null)
                return null;

            Queue<Node> nodeStack = new Queue<Node>();
            Queue<int> level = new Queue<int>();

            nodeStack.Enqueue(node);
            level.Enqueue(0);
            int baseLevel = 0;

            while (nodeStack.Count != 0)
            {
                Node n = nodeStack.Peek();
                baseLevel = level.Peek();

                nodeStack.Dequeue();
                level.Dequeue();

                if (n.data == baseVaue)
                {
                    if (level.Count == 0 || level.Peek() != baseLevel)
                    {
                        return null;
                    }

                    return nodeStack.Peek();
                }


                if (n.right != null)
                {
                    nodeStack.Enqueue(n.right);
                    level.Enqueue(baseLevel + 1);
                }
                if (n.left != null)
                {
                    nodeStack.Enqueue(n.left);
                    level.Enqueue(baseLevel + 1);
                }



            }


            return null;
        }

        //O(h)
        public Node inOrderSuccessor(Node rootNode, Node node)
        {
            if (node.right != null)
            {
                return minValue(node.right);
            }

            Node temp = null;

            while (rootNode != null)
            {
                if (node.data < rootNode.data)
                {
                    temp = rootNode;
                    rootNode = rootNode.left;
                }
                else if (node.data > rootNode.data)
                    rootNode = rootNode.right;
                else
                    break;
            }
            return temp;
        }

        /* Given a non-empty binary search tree, return the minimum data  
         value found in that tree. Note that the entire tree does not need
         to be searched. */
        Node minValue(Node node)
        {
            Node current = node;

            /* loop down to find the leftmost leaf */
            while (current.left != null)
            {
                current = current.left;
            }
            return current;
        }


        public Node PopulateNext(Node node, Node next)
        {
            if (node == null)
                return next;
            node.next = PopulateNext(node.right, next);

            return PopulateNext(node.left, node);

        }

        public void PrintPostOrder(Node n)
        {
            if (n == null)
                return;

            PrintPostOrder(n.left);
            PrintPostOrder(n.right);
            Console.Write(n.data + ", ");

        }

        public void PrintInOrder(Node n)
        {
            if (n == null)
                return;

            PrintInOrder(n.left);
            Console.Write(n.data + ", ");
            PrintInOrder(n.right);
        }

        public void PrintPreOrder(Node n)
        {
            if (n == null)
                return;
            Console.Write(n.data + ", ");
            PrintPreOrder(n.left);
            PrintPreOrder(n.right);
        }


        public void PrintBFS(Node root)
        {
            Queue<Node> nodeQueue = new Queue<Node>();
            nodeQueue.Enqueue(root);

            while (nodeQueue.Count != 0)
            {
                Node temp = nodeQueue.Peek();
                nodeQueue.Dequeue();
                Console.Write(temp.data + ",");

                if (temp.left != null)
                {
                    nodeQueue.Enqueue(temp.left);
                }
                if (temp.right != null)
                {
                    nodeQueue.Enqueue(temp.right);
                }
            }
        }

        public void PrintInorderTraverse(Node root)
        {
            Stack<Node> nodeStack = new Stack<Node>();
            Node temp = root;
            while (temp != null)
            {
                nodeStack.Push(temp);
                temp = temp.left;
            }

            // traverse the tree
            while (nodeStack.Count > 0)
            {

                // visit the top node
                temp = nodeStack.Pop();
                Console.Write(temp.data + " ");
                if (temp.right != null)
                {
                    temp = temp.right;

                    // the next node to be visited is the leftmost
                    while (temp != null)
                    {
                        nodeStack.Push(temp);
                        temp = temp.left;
                    }
                }
            }
        }

        public void PrintPreOrderTraverse(Node root)
        {
            Stack<Node> nodeStack = new Stack<Node>();
            nodeStack.Push(root);

            while (nodeStack.Count != 0)
            {

                // Pop the top item from stack and print it
                Node mynode = nodeStack.Peek();
                Console.Write(mynode.data + ", ");
                nodeStack.Pop();

                // Push right and left children of the popped node to stack
                if (mynode.right != null)
                {
                    nodeStack.Push(mynode.right);
                }
                if (mynode.left != null)
                {
                    nodeStack.Push(mynode.left);
                }
            }
        }

        public void PrintPostOrderTraverse(Node root)
        {
            if (root == null)
            {
                return;
            }
            Stack<Node> stack = new Stack<Node>();
            stack.Push(root);

            while (stack.Count != 0)
            {
                Node next = stack.Peek();

                bool finishedSubtrees = (next.right == root || next.left == root);
                bool isLeaf = (next.left == null && next.right == null);
                if (finishedSubtrees || isLeaf)
                {
                    stack.Pop();
                    Console.Write(next.data + ", ");
                    root = next;
                }
                else
                {
                    if (next.right != null)
                    {
                        stack.Push(next.right);
                    }
                    if (next.left != null)
                    {
                        stack.Push(next.left);
                    }
                }
            }
        }
    }
}
