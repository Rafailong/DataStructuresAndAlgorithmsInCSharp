namespace Module3
{
    class SinglyLinkedNode<T>
    {
        public T Value { get; set; }

        public SinglyLinkedNode<T> Next { get; set; }

        public SinglyLinkedNode(T value, SinglyLinkedNode<T> next = null)
        {
            this.Value = value;
            this.Next = next;
        }
    }
}