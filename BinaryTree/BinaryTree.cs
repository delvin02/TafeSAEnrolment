using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TafeSAEnrolment.BinaryTree
{
    public class BinaryTree<T> where T : IComparable<T>
    {
        public TreeNode<T> Root { get; private set; }

        public bool Add(T value)
        {
            TreeNode<T> before = null, after = this.Root;

            // keep looping down the trees
            while (after != null)
            {
                before = after;
                if (value.CompareTo(after.Data) < 0)
                {
                    after = after.LeftNode;
                }
                else if (value.CompareTo(after.Data) > 0)
                {
                    after = after.RightNode;
                }
                else
                {
                    return false;
                }
            }

            TreeNode<T> newNode = new TreeNode<T>(value);
            newNode.Data = value;

            // Empty
            if (this.Root == null)
                this.Root = newNode;
            else
            {
                // if lesser, then go to the left node
                if (value.CompareTo(before.Data) < 0)
                    before.LeftNode = newNode;
                else
                    before.RightNode = newNode;
            }

            return true;
        }

        public TreeNode<T> Find(T value)
        {
            return this.Find(value, Root);
        }

        public TreeNode<T> Find(T value, TreeNode<T> parent)
        {
            if (parent != null)
            {
                int result = value.CompareTo(parent.Data);
                // found
                if (result == 0) return parent;

                // keep looking till the end of it
                if (result < 0)
                    return Find(value, parent.LeftNode);
                else
                    return Find(value, parent.RightNode);
            }

            return null;
        }

        public void Remove(T value)
        {
            this.Root = Remove(this.Root, value);
        }

        public TreeNode<T> Remove(TreeNode<T> parent, T key)
        {
            if (parent == null) return parent;

            int result = key.CompareTo(parent.Data);
            if (result < 0)
            {
                parent.LeftNode = Remove(parent.LeftNode, key);
            }
            else if (result > 0)
            {
                parent.RightNode = Remove(parent.RightNode, key);
            }
            else
            {
                if (parent.LeftNode == null)
                    return parent.RightNode;
                else if (parent.RightNode == null)
                    return parent.LeftNode;

                parent.Data = MinValue(parent.RightNode);
                parent.RightNode = Remove(parent.RightNode, parent.Data);
            }
            return parent;
        }

        private T MinValue(TreeNode<T> node)
        {
            T minv = node.Data;

            while (node.LeftNode != null)
            {
                minv = node.LeftNode.Data;
                node = node.LeftNode;
            }
            return minv;
        }

        public void TraversePreOrder(TreeNode<T> parent)
        {
            if (parent != null)
            {
                Console.WriteLine(parent.Data + " ");

                // left subtree
                TraversePreOrder(parent.LeftNode);

                // right subtree
                TraversePreOrder(parent.RightNode);
            }
        }

        public void TraverseInOrder(TreeNode<T> parent)
        {
            if (parent != null)
            {
                TraverseInOrder(parent.LeftNode);
                Console.WriteLine(parent.Data + " ");
                TraverseInOrder(parent.RightNode);
            }
        }

        public void TraversePostOrder(TreeNode<T> parent)
        {
            if (parent != null)
            {
                TraversePostOrder(parent.LeftNode);
                TraversePostOrder(parent.RightNode);

                Console.WriteLine(parent.Data + " ");
            }
        }
    }
}
