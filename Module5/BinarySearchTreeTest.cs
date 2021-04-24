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

        [Test]
        public void Always_Adds_Greater_Values_To_The_Right()
        {
            var tree = new BinarySearchTree<int>();
            var src = Enumerable.Range(0, 100);

            src.ToList().ForEach(i => tree.Add(i));

            Assert.AreEqual(src.Count(), tree.Count);

            var tmp = tree.Root;
            var acc = true;
            while (tmp != null)
            {
                acc = acc && tmp.Left == null;
                tmp = tmp.Right;
            }

            Assert.IsTrue(acc);
        }

        [Test]
        public void Adds_Values_To_The_Right_Side()
        {
            var tree = new BinarySearchTree<int>();

            tree.Add(5); //       5
            tree.Add(7); //   3       7
            tree.Add(9); // 2   4   6   9
            tree.Add(3);
            tree.Add(6);
            tree.Add(4);
            tree.Add(2);

            Assert.AreEqual(5, tree.Root.Value);
            Assert.AreEqual(3, tree.Root.Left.Value);
            Assert.AreEqual(7, tree.Root.Right.Value);
            Assert.AreEqual(2, tree.Root.Left.Left.Value);
            Assert.AreEqual(4, tree.Root.Left.Right.Value);
            Assert.AreEqual(6, tree.Root.Right.Left.Value);
            Assert.AreEqual(9, tree.Root.Right.Right.Value);
        }
    }
}
