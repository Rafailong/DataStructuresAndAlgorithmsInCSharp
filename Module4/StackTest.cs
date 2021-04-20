namespace Module4
{
    using NUnit.Framework;
    using System.Linq;

    [TestFixture]
    public class StackTest
    {

        private Stack<int> _sut;

        [SetUp]
        public void Setup()
        {
            _sut = new Stack<int>();
        }

        [Test]
        public void PopAndPush()
        {
            Enumerable.Range(1, 10).ToList().ForEach(i => _sut.Push(i));
            Assert.AreEqual(10, _sut.Count);
            for (int i = 10; i > 0; i--)
            {
                Assert.AreEqual(i, _sut.Pop().Value);
                Assert.AreEqual(i-1, _sut.Count);
            }
        }
    }
}