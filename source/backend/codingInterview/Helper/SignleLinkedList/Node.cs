namespace CodingInterview.Helper.SignleLinkedList
{
    public class Node
    {
        public object Data { get; set; }
        public Node Next { get; set; }
        public Node Random { get; set; }

        public Node()
        {
            this.Next = null;
            this.Random = null;
        }

        public Node(object data)
        {
            this.Data = data;
            this.Next = null;
            this.Random = null;
        }

    }
}
