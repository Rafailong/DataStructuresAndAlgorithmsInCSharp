namespace Module4
{
    using AutoFixture.NUnit3;
    using NUnit.Framework;
    using System.Collections.Generic;
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

        [Test, AutoData]
        public void PopAndPush(List<int> src)
        {
            src.ForEach(i => _sut.Push(i));
            Assert.AreEqual(src.Count, _sut.Count);
            for (int i = src.Count; i > 0; i--)
            {
                var expected = src.ElementAt(i-1);
                Assert.AreEqual(expected, _sut.Pop().Value);
                Assert.AreEqual(i-1, _sut.Count);
            }
            Assert.AreEqual(0, _sut.Count);
        }
    }
}