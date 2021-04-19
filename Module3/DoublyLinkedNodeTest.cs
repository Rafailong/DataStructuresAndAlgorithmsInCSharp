using System;
using NUnit.Framework;

namespace Module3 {

    [TestFixture]
    public class DoublyLinkedNodeTest {

        [Test]
        public void BuildDoublyLinkedList() {
            var n1 = new DoublyLinkedNode<int>(1);
            var n2 = new DoublyLinkedNode<int>(2);
            var n3 = new DoublyLinkedNode<int>(3);

            n1.Next = n2;
            n2.Prev = n1;
            n2.Next = n3;
            n3.Prev = n2;

            var list = n1;
            var hasNext = n1.Next != null;

            do
            {
                Console.WriteLine($"--> DoulyLinkedNode.Value={list.Value}");
                hasNext = list.Next != null;
                if (hasNext) list = list.Next;
            } while (hasNext);

            do
            {
                Console.WriteLine($"<-- DoulyLinkedNode.Value={list.Value}");
                list = list.Prev;
            } while (list != null);
        }
    }
}