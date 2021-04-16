using NUnit.Framework;

namespace Module3
{
    [TestFixture]
    public class DoublyLinkedListTest {

        private DoublyLinkedList<int> _sut;

        [SetUp]
        public void SetUp()
        {
            _sut = new DoublyLinkedList<int>();

            _sut.AddHead(1);
            Assert.AreEqual(1, _sut.Count);
            Assert.AreEqual(1, _sut.Head.Value);
            Assert.AreEqual(1, _sut.Tail.Value);
        }

        [Test]
        public void AddHead() {
            _sut.AddHead(2);
            Assert.AreEqual(2, _sut.Count);
            Assert.AreEqual(2, _sut.Head.Value);
            Assert.AreEqual(1, _sut.Tail.Value);

            _sut.AddHead(3);
            Assert.AreEqual(3, _sut.Count);
            Assert.AreEqual(3, _sut.Head.Value);
            Assert.AreEqual(2, _sut.Head.Next.Value);
            Assert.AreEqual(1, _sut.Tail.Value);
        }

        [Test]
        public void AddTail() {
            _sut.AddTail(2);

            Assert.AreEqual(1, _sut.Head.Value);
            Assert.AreEqual(2, _sut.Tail.Value);
            Assert.AreEqual(2, _sut.Count);

            _sut.AddTail(3);
            Assert.AreEqual(1, _sut.Head.Value);
            Assert.AreEqual(2, _sut.Head.Next.Value);
            Assert.AreEqual(3, _sut.Tail.Value);
            Assert.AreEqual(_sut.Head.Next.Next.Value, _sut.Tail.Value);
            Assert.AreEqual(3, _sut.Count);
        }
    }
}