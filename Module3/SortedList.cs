using System;
using System.Collections.Generic;

namespace Module3
{
    public class SortedList<T> : ICollection<T> where T : IComparable<T>
    {
        private DoublyLinkedNode<T> head { get; set; }

        private DoublyLinkedNode<T> tail { get; set; }

        public int Count { get; private set; }

        public bool IsReadOnly => false;

        public DoublyLinkedNode<T> Find(T t) {
            var tmp = this.head;
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

        public void Add(T item)
        {
            var newNode = new DoublyLinkedNode<T>(item);

            // when lis is empty: add newNode as head and tail
            if (this.Count == 0)
            {
                this.head = newNode;
                this.tail = this.head;
                this.Count++;
                return;
            }

            // preppend new head
            // newNode <=> head
            if (this.head.Value.CompareTo(item) >= 0)
            {
                newNode.Next = this.head;
                this.head.Prev = newNode;
                this.head = newNode;
                this.Count++;
                return;
            }

            // append new tail
            // tail <=> newNode
            if (this.tail.Value.CompareTo(item) <= 0)
            {
                this.tail.Next = newNode;
                newNode.Prev = this.tail;
                this.tail = newNode;
                this.Count++;
                return;
            }

            var tmp = this.head;
            do
            {
                if (tmp.Value.CompareTo(item) <= 0)
                {
                    if (tmp.Next == null || tmp.Next.Value.CompareTo(item) >= 0) {
                        // link to the next
                        tmp.Next.Prev = newNode;
                        newNode.Next = tmp.Next;
                        // link to the previous
                        tmp.Next = newNode;
                        newNode.Prev = tmp;
                        this.Count++;
                        break;
                    }
                    tmp = tmp.Next;
                }
            } while (tmp != null);
        }

        public void Clear()
        {
            this.head = null;
            this.tail = null;
            this.Count = 0;
        }

        public bool Contains(T item)
        {
            return this.Find(item) != null;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = this.head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        public bool Remove(T item)
        {
            var found = this.Find(item);

            if (found == null) return false;

            var prev = found.Prev;
            var next = found.Next;
            
            // found was "in the middle"
            if (prev != null && next != null) {
                prev.Next = next;
                next.Prev = prev;
                this.Count--;
                return true;
            }
            // found was the only element
            else if (prev == null && next == null)
            {
                this.head = null;
                this.tail = null;
                this.Count--;
                return true;
            }
            // found was Head
            else if (prev == null && next != null)
            {
                next.Prev = null;
                this.head = next;
                this.Count--;
                return true;
            }
            // found was tail
            else if (prev != null && next == null)
            {
                prev.Next = null;
                this.tail = prev;
                this.Count--;
                return true;
            }
            // we should not make it here!
            else
            {
                return false;
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}