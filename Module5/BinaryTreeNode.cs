namespace Module5
{
    public class BinaryTreeNode<T>
    {
        public T Value { get; private set; }

        public BinaryTreeNode<T> Left { get; set; }

        public BinaryTreeNode<T> Right { get; set; }

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
    }
}
