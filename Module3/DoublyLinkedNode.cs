namespace Module3
{
    public class DoublyLinkedNode<T>
    {
        public T Value { get; set; }

        public DoublyLinkedNode<T> Prev { get; set; }

        public DoublyLinkedNode<T> Next { get; set; }

        public DoublyLinkedNode(T value)
        {
            this.Value = value;
        }

    }
}