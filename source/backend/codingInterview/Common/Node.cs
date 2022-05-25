namespace CodingInterview.Common
{
    public class Node
    {
        public int Data;
        public Node Left;
        public Node Right;
        public Node Parent;

        public Node()
        {

        }

        public Node(int value)
        {
            Data = value;
            Left = Right = Parent = null;
        }
    }
}
