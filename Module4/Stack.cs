namespace Module4
{
    using System.Collections;
    using System.Collections.Generic;
    using Module3;

    public class Stack<T> : IEnumerable<T>
    {
        private SinglyLinkedNode<T> top;

        public int Count { get; private set; }

        public void Push(T t) {
            if (this.Count == 0)
            {
                this.top = new SinglyLinkedNode<T>(t);
            }
            else
            {
                var newNode = new SinglyLinkedNode<T>(t, this.top);
                this.top = newNode;
            }
            this.Count++;
        }

        public SinglyLinkedNode<T> Pop() {
            if (this.Count > 0)
            {
                var tmp = this.top;
                this.top = this.top.Next;
                this.Count--;
                tmp.Next = null;
                return tmp;
            }
            return null;
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            var tmp = this.top;
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