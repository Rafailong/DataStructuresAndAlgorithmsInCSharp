namespace aspnetapp.Module4
{
    using System.Collections;
    using System.Collections.Generic;
    using Module3;

    public class Queue<T> : IEnumerable<T>
    {
        public DoublyLinkedNode<T> Head { get; private set; }

        public DoublyLinkedNode<T> Tail  { get; private set; }

        public int Count { get; private set; }

        public void QueueUp(T t)
        {
            var newNode = new DoublyLinkedNode<T>(t);
            if (this.Count == 0)
            {
                this.Head = newNode;
                this.Tail = this.Head;
            }
            else
            {
                newNode.Prev = this.Tail;
                this.Tail.Next = newNode;
                this.Tail = newNode;
                
            }
            this.Count++;
        }

        public DoublyLinkedNode<T> Dequeue()
        {
            DoublyLinkedNode<T> dequeued = null;
            if (this.Count > 0)
            {
                dequeued = this.Head;
                this.Head = dequeued.Next;

                if (this.Head == null) this.Tail = null;
                if (this.Head != null) this.Head.Prev = null;

                this.Count--;

                dequeued.Next = null;
                dequeued.Prev = null;
                return dequeued;
            }


            return dequeued;
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            var tmp = this.Head;
            while (true)
            {
                yield return tmp.Value;
                tmp = tmp.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            foreach (var i in this) yield return i;
        }
    }
}
