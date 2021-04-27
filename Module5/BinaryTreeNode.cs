namespace Module5
{
    using System;

    public class BinaryTreeNode<T> where T : IComparable<T>
    {
        public T Value { get; private set; }

        public BinaryTreeNode<T> Left { get; set; }

        public BinaryTreeNode<T> Right { get; set; }

        public bool HasBothChildren {
            get {
                return this.Left != null && this.Right != null;
            }
        }

        public BinaryTreeNode(T v)
        {
            this.Value = v;
        }

        public BinaryTreeNode(T v, BinaryTreeNode<T> left, BinaryTreeNode<T> right)
        {
            this.Value = v;
            this.Left = left;
            this.Right = right;
        }

        public bool HasLeft(T t)
        {
            return this.Left != null && t.CompareTo(this.Left.Value) == 0;
        }

        public bool HasRight(T t)
        {
            return this.Right != null && t.CompareTo(this.Right.Value) == 0;
        }

        public override string ToString()
        {
            return this.Value.ToString();
        }
    }
}
