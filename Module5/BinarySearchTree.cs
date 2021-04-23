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
    }
}
