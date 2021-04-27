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

        /**
         * Left, then Right, and finally Node
         */
        public void PostOrderTraversal(Action<T> f)
        {
            PostOrder(f, this.Root);
        }

        private void PostOrder(Action<T> f, BinaryTreeNode<T> node)
        {
            if (node != null)
            {
                PostOrder(f, node.Left);
                PostOrder(f, node.Right);
                f(node.Value);
            }
        }

        public BinaryTreeNode<T> Search(T t)
        {
            if (this.Count <= 0) return null;

            var tmp = this.Root;
            do
            {
                if (t.CompareTo(tmp.Value) == 0) break;
                if (t.CompareTo(tmp.Value) < 0)
                {
                    tmp = tmp.Left;
                }
                else
                {
                    tmp = tmp.Right;
                }
            } while (tmp != null);

            return tmp;
        }

        private readonly Func<BinaryTreeNode<T>, bool> IsLeaf =
            n => n.Left == null && n.Right == null;

        private readonly Func<BinaryTreeNode<T>, bool> HasOnlyLeftChild =
            n => n.Right == null && n.Left != null;

        private readonly Func<BinaryTreeNode<T>, bool> HasOnlyRightChild =
            n => n.Left == null && n.Right != null;

        private BinaryTreeNode<T> LeftMostChild(BinaryTreeNode<T> node)
        {
            var tmp = node;
            while (tmp != null && tmp.Left != null)
            {
                tmp = tmp.Left;
            }
            return tmp;
        }

        public void Remove(T t)
        {
            if (this.Count <= 0) return;

            var actual = this.Root;
            BinaryTreeNode<T> parent = null;
            do
            {
                if (t.CompareTo(actual.Value) == 0)
                {
                    // deleting root
                    if (IsLeaf(actual) && parent == null) { this.Root = null; break; }

                    // deleting node with both both children
                    /*if (actual.HasBothChildren)
                    {
                        var leftMostChild = LeftMostChild(actual.Right);
                        if (parent != null && parent.HasLeft(actual.Value))
                    }*/

                    // from here, we assume that parent is not null
                    // deleting leaf
                    if (IsLeaf(actual) && parent.HasLeft(t)) {
                        parent.Left = null;
                        break; 
                    }
                    if (IsLeaf(actual) && parent.HasRight(t)) {
                        parent.Right = null;
                        break;
                    }

                    // deleting node with only one child
                    if (HasOnlyLeftChild(actual))
                    {
                        parent.Left = actual.Left; 
                        break;
                    }
                    if (HasOnlyRightChild(actual))
                    {
                        parent.Right = actual.Right;
                        break;
                    }
                }

                parent = actual;
                if (t.CompareTo(actual.Value) < 0) actual = actual.Left;
                else actual = actual.Right;
            } while (actual != null);
            this.Count--;
        }
    }
}
