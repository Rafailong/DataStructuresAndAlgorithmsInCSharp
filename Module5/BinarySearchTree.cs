namespace Module5
{
    using System;

    /**
     * A binary tree where nodes with lesser values are placed to the left
     * of the root, and nodes with equal or greater values are placed to the right.
     */
    public class BinarySearchTree<T> where T : IComparable<T>
    {
        public BinaryTreeNode<T> Root { get; private set; }

        public int Count { get; private set; }

        public void Add(T t)
        {
            var newNode = new BinaryTreeNode<T>(t);

            if (this.Count == 0)
            {
                this.Root = newNode;
            }
            else
            {
                var tmp = this.Root;
                do
                {
                    if (t.CompareTo(tmp.Value) < 0)
                    {
                        if (tmp.Left == null)
                        {
                            tmp.Left = newNode;
                            break;
                        }
                        else
                        {
                            tmp = tmp.Left;
                        }
                    }
                    else if(t.CompareTo(tmp.Value) >= 0)
                    {
                        if (tmp.Right == null)
                        {
                            tmp.Right = newNode;
                            break;
                        }
                        else
                        {
                            tmp = tmp.Right;
                        }
                    }
                } while (tmp != null);
            }

            this.Count++;
        }

        /**
         * Root is visited before its children which are visited Left first then Right.
         */
        public void PreOrderTraversal(Action<T> f)
        {
            PreOrder(f, this.Root);
        }

        private void PreOrder(Action<T> f, BinaryTreeNode<T> node)
        {
            if (node != null)
            {
                f(node.Value);
                PreOrder(f, node.Left);
                PreOrder(f, node.Right);
            }
        }

        /**
         * Left, then Node, and finally Right
         */
        public void InOrderTraversal(Action<T> f)
        {
            InOrder(f, this.Root);
        }

        private void InOrder(Action<T> f, BinaryTreeNode<T> node)
        {
            if (node != null)
            {
                InOrder(f, node.Left);
                f(node.Value);
                InOrder(f, node.Right);
            }
        }
    }
}
