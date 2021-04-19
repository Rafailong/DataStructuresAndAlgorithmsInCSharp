using System;
using NUnit.Framework;

namespace Module3
{
    [TestFixture]
    public class NodeTest
    {
        [Test]
        public void BuildLinkedList() {
            var n1 = new Node(1);
            var n2 = new Node(2, n1);
            var n3 = new Node(3, n2);

            var list = n3;
            var nodeNumber = 1;
            do
            {
                Console.WriteLine($"Node.Value={list.Value}");
                nodeNumber++;
                list = list.Next;
            } while (list != null);
        }
    }
}