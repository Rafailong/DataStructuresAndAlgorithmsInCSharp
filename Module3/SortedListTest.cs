using System.Text;
using NUnit.Framework;

namespace Module3 {

    [TestFixture]
    public class SortedListTest {

        private SortedList<int> _sut;

        [SetUp]
        public void SetUp() {
            _sut = new SortedList<int>();
        }

        [Test]
        public void Add() {
            _sut.Add(2);
            _sut.Add(1);
            _sut.Add(4);
            _sut.Add(3);

            var sb = new StringBuilder();
            System.Collections.Generic.IEnumerator<int> enumerator = _sut.GetEnumerator();
            while (enumerator.MoveNext())
            {
                sb.Append($"{enumerator.Current},");
            }
            Assert.AreEqual("1,2,3,4,", sb.ToString());
        }
    }
}