namespace Module4
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Module3;

    public class Deque<T> : IEnumerable<T>
    {
        public DoublyLinkedNode<T> Head { get; private set; }

        public DoublyLinkedNode<T> Tail { get; private set; }

        public int Count { get; private set; }

        public void EnqueueHead(T t)
        {
            var newHead = new DoublyLinkedNode<T>(t);
            var oldHead = this.Head;

            this.Head = newHead;
            this.Head.Next = oldHead;

            if (this.Count == 0)
            {
                this.Tail = this.Head;
            }
            else
            {
                oldHead.Prev = this.Head;
            }

            this.Count++;
        }

        public void EnqueueTail(T t)
        {
            if (this.Count == 0) //  when list empty defer to AddHead
            {
                this.EnqueueHead(t);
            }
            else
            {
                var newTail = new DoublyLinkedNode<T>(t)
                {
                    Prev = this.Tail
                };
                this.Tail.Next = newTail; ;
                this.Tail = newTail;
                this.Count++;
            }
        }

        public T DequeHead()
        {
            if (this.Count > 0)
            {
                var oldHead = this.Head;
                this.Head = oldHead.Next;
                this.Count--;
                return oldHead.Value;
            }

            throw new InvalidOperationException("Imposible to DequeHead from an empty Deque");
        }

        public T DequeTail()
        {
            if (this.Count > 0)
            {
                var oldTail = this.Tail;
                this.Tail = oldTail.Prev;
                this.Count--;
                return oldTail.Value;
            }

            throw new InvalidOperationException("Imposible to DequeTail from an empty Deque");
        }

        public IEnumerator<T> GetEnumerator()
        {
            var tmp = this.Head;
            while (tmp != null)
            {
                yield return tmp.Value;
                tmp = tmp.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
