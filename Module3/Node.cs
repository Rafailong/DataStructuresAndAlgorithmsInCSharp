namespace Module3
{
    class Node
    {
        public Node(int value)
        {
            this.Value = value;
            this.Next = null;
        }

        public Node(int value, Node next)
        {
            this.Value = value;
            this.Next = next;
        }

        public int Value;

        public Node Next;
    }
}