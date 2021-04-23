namespace Module5
{
    using System;
    using System.Linq;
    using NUnit.Framework;

    [TestFixture]
    public class BinarySearchTreeTest
    {

        [Test]
        public void Always_Adds_Lesser_Values_To_The_Left()
        {
            var tree = new BinarySearchTree<int>();
            var src = Enumerable.Range(0, 100).Reverse();
            Console.WriteLine($"src=[{src.First()}..{src.Last()}]");

            src.ToList().ForEach(i => tree.Add(i));

            Assert.AreEqual(src.Count(), tree.Count);

            var tmp = tree.Root;
            var acc = true;
            while (tmp != null)
            {
                acc = acc && tmp.Right == null;
                tmp = tmp.Left;
            }

            Assert.IsTrue(acc);
        }
    }
}
