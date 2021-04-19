using System;
using NUnit.Framework;

namespace Module3 {

    [TestFixture]
    public class SinglyLinkedNodeTest {

        [Test]
        public void BuildSinglyLinkedList() {
            var list = new SinglyLinkedNode<int>(
                1,
                new SinglyLinkedNode<int>(
                    2, 
                    new SinglyLinkedNode<int>(3)
                    )
                );

            var nodeNumber = 1;
            do
            {
                Console.WriteLine($"SinglyLinkedList.Value={list.Value} Node.Index={nodeNumber}");
                nodeNumber++;
                list = list.Next;
            } while (list != null);
        }
    }
}