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
            var tmp = this.Head;
            while (tmp != null)
            {
                if (tmp.Value.Equals(t))
                {
                    break;
                }
                tmp = tmp.Next;
            }
            return tmp;
        }

        public bool Delete(T t) {
            var found = this.Find(t);

            if (found == null) return false;

            var prev = found.Prev;
            var next = found.Next;
            
            // found was "in the middle"
            if (prev != null && next != null) {
                prev.Next = next;
                next.Prev = prev;
                return true;
            }
            // found was the only element
            else if (prev == null && next == null)
            {
                this.Head = null;
                this.Tail = null;
                return true;
            }
            // found was Head
            else if (prev == null && next != null)
            {
                next.Prev = null;
                this.Head = next;
                return true;
            }
            // found was tail
            else if (prev != null && next == null)
            {
                prev.Next = null;
                this.Tail = prev;
                return true;
            }
            // we should not make it here!
            else
            {
                return false;
            }
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