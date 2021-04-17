using System.Collections;
using System.Collections.Generic;

namespace Module3 {

    public class DoublyLinkedList<T> : ICollection<T>
    {
        public DoublyLinkedNode<T> Head { get; private set; }

        public DoublyLinkedNode<T> Tail { get; private set; }

        #region Adding
        // Adds a value at the begining of the list
        // BogO = O(1) = constant time
        public void AddHead(T t) {
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

        // Adds a value to the end of the list
        // BogO = O(1) = constant time
        public void AddTail(T t) {
            if (this.Count == 0) //  when list empty defer to AddHead
            {
                this.AddHead(t);
            }
            else
            {
                var newTail = new DoublyLinkedNode<T>(t);
                newTail.Prev = this.Tail;
                this.Tail.Next = newTail;;
                this.Tail = newTail;
                this.Count++;
            }
        }
        #endregion

        public DoublyLinkedNode<T> Find(T t) {
            if (this.Count <= 0) return null;
            var tmp = this.Head;
            do
            {
                if (tmp.Value.Equals(t))
                {
                    return tmp;
                }
                else {
                    tmp = tmp.Next;
                }
            } while (tmp != null);
            return tmp;
        }

        #region ICollection
        public int Count { get; private set; }

        public bool IsReadOnly => throw new System.NotImplementedException();

        public void Add(T item)
        {
            throw new System.NotImplementedException();
        }

        public void Clear()
        {
            throw new System.NotImplementedException();
        }

        public bool Contains(T item)
        {
            throw new System.NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new System.NotImplementedException();
        }

        public bool Remove(T item)
        {
            throw new System.NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new System.NotImplementedException();
        }
        #endregion
    }
}