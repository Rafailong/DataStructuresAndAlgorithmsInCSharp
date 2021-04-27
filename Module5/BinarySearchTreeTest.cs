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

        [Test]
        public void Pre_Order_Traversal()
        {
            var tree = new BinarySearchTree<int>();
            int[] src = { 5, 7, 9, 3, 6, 4, 2 };
            src.ToList().ForEach(tree.Add);

            var sb = new System.Text.StringBuilder();
            Action<int> f = delegate (int i) { sb.Append(i.ToString()); };

            tree.PreOrderTraversal(f);

            Assert.AreEqual("5324769", sb.ToString());
        }

        [Test]
        public void In_Order_Traversal()
        {
            var tree = new BinarySearchTree<int>();
            int[] src = { 5, 7, 9, 3, 6, 4, 2 };
            src.ToList().ForEach(tree.Add);

            var sb = new System.Text.StringBuilder();
            Action<int> f = delegate (int i) { sb.Append(i.ToString()); };

            tree.InOrderTraversal(f);

            Assert.AreEqual("2345679", sb.ToString());
        }

        [Test]
        public void Post_Order_Traversal()
        {
            var tree = new BinarySearchTree<int>();
            int[] src = { 5, 7, 9, 3, 6, 4, 2 };
            src.ToList().ForEach(tree.Add);

            var sb = new System.Text.StringBuilder();
            Action<int> f = delegate (int i) { sb.Append(i.ToString()); };

            tree.PostOrderTraversal(f);

            Assert.AreEqual("2436975", sb.ToString());
        }

        [Test]
        public void Search()
        {
            var tree = new BinarySearchTree<int>();
            int[] src = { 5, 7, 9, 3, 6, 4, 2 };
            src.ToList().ForEach(tree.Add);

            Assert.IsNull(tree.Search(8));
            Assert.IsNotNull(tree.Search(4));
            Assert.IsNotNull(tree.Search(6));
        }

        [Test]
        public void Deleting_Leaf_Node_Root_Without_Children()
        {
            var tree = new BinarySearchTree<int>();
            tree.Add(0);
            Assert.AreEqual(1, tree.Count);
            Assert.AreEqual(0, tree.Root.Value);
            tree.Remove(0);
            Assert.IsNull(tree.Root);
            Assert.AreEqual(0, tree.Count);
        }

        [Test]
        public void Deleting_Leaf_Node()
        {
            var tree = new BinarySearchTree<int>();
            tree.Add(0); tree.Add(1);
            Assert.AreEqual(2, tree.Count);
            Assert.AreEqual(0, tree.Root.Value);
            tree.Remove(1);
            Assert.IsNull(tree.Search(1));
            Assert.AreEqual(1, tree.Count);
        }

        [Test]
        public void Deleting_Node_With_Only_One_Child()
        {
            var tree = new BinarySearchTree<int>();
            tree.Add(2);
            tree.Add(1); tree.Add(0); // left
            tree.Add(3); tree.Add(4); // right

            var sb = new System.Text.StringBuilder();
            Action<int> f = delegate (int i) { sb.Append(i.ToString()); };

            tree.Remove(1);
            tree.InOrderTraversal(f);
            Assert.AreEqual("0234", sb.ToString());

            sb.Clear();

            tree.Remove(3);
            tree.InOrderTraversal(f);
            Assert.AreEqual("024", sb.ToString());
        }

        [Test]
        public void Deleting_Root_Node_With_Two_Children()
        {
            var tree = new BinarySearchTree<int>();
            tree.Add(2);
            tree.Add(1); tree.Add(3);

            var sb = new System.Text.StringBuilder();
            Action<int> f = delegate (int i) { sb.Append(i.ToString()); };

            tree.Remove(2);
            tree.InOrderTraversal(f);
            Assert.AreEqual(3, tree.Root.Value);
            Assert.AreEqual(1, tree.Root.Left.Value);
            Assert.IsNull(tree.Root.Right);
            Assert.AreEqual("13", sb.ToString());
        }

        [Test]
        public void Deleting_Node_With_Two_Children()
        {
            var tree = new BinarySearchTree<int>();
            //            10
            //    5                15
            // 3     8         13      18
            //     7   9    11    14      19
            //   6                           20
            tree.Add(10);
            tree.Add(5); tree.Add(15);
            tree.Add(3); tree.Add(8); tree.Add(13); tree.Add(18);
            tree.Add(7); tree.Add(9); tree.Add(11); tree.Add(14); tree.Add(19);
            tree.Add(6); tree.Add(20);

            var sb = new System.Text.StringBuilder();
            Action<int> f = delegate (int i) { sb.Append(i.ToString()); };

            tree.Remove(5);
            //            10
            //    6                15
            // 3     8         13      18
            //     7   9    11    14      19
            //                               20
            tree.InOrderTraversal(f);
            Assert.AreEqual("367891011131415181920", sb.ToString());

            sb.Clear();

            tree.Remove(15);
            //            10
            //    6                18
            // 3     8         13      19
            //     7   9    11    14      20
            tree.InOrderTraversal(f);
            Assert.AreEqual("3678910111314181920", sb.ToString());

            sb.Clear();

            tree.Remove(10);
            //            11
            //    6                18
            // 3     8         13      19
            //     7   9          14      20
            tree.InOrderTraversal(f);
            Assert.AreEqual("36789111314181920", sb.ToString());
        }
    }
}
