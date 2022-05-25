using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingInterview.Helper.BinaryTree
{
    public class Node
    {
        public int Data { get; set; }
        public Node Left, Right;

        public Node(int data)
        {
            this.Data = data;
            this.Left = null;
            this.Right = null;
        }

        public Node()
        {

        }
    }
}
