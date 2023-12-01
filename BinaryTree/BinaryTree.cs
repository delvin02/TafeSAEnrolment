using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TafeSAEnrolment.BinaryTree
{
    // Binary tree implementation
    public class BinaryTree<T> where T : IComparable<T>
    {
        public TreeNode<T> Root { get; private set; }

        public bool Add(T value)
        {
            TreeNode<T> before = null, after = this.Root;

            // keep looping down the tree until a suitable position is found
            while (after != null)
            {
                before = after;

                // if the value is smaller, go to the left node. otherwise right node.
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
                // Assign the new node to the left or right based on the comparison result
                if (value.CompareTo(before.Data) < 0)
                    before.LeftNode = newNode;
                else
                    before.RightNode = newNode;
            }

            return true;
        }

        // Find a node with the specified value in the binary tree
        public TreeNode<T> Find(T value)
        {
            return this.Find(value, Root);
        }

        // Recursive helper method to find a node with the specified value
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

        // Remove a node with specified value in the binary tree
        public void Remove(T value)
        {
            this.Root = Remove(this.Root, value);
        }

        // Recursive helper method to remove a node with specified value
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

        // Helper method to find the minimum value in a subtree
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

        // Traverse the tree in pre-order and print the node values
        public void TraversePreOrder(TreeNode<T> parent)
        {
            if (parent != null)
            {
                Console.WriteLine(parent.Data + " ");

                // traverse left subtree
                TraversePreOrder(parent.LeftNode);

                // traverse right subtree
                TraversePreOrder(parent.RightNode);
            }
        }

        public void TraverseInOrder(TreeNode<T> parent)
        {
            if (parent != null)
            {
                // Traverse the left subtree
                TraverseInOrder(parent.LeftNode);

                Console.WriteLine(parent.Data + " ");

                // Traverse the right subtree
                TraverseInOrder(parent.RightNode);
            }
        }

        public void TraversePostOrder(TreeNode<T> parent)
        {
            if (parent != null)
            {
                // Traverse the left subtree
                TraversePostOrder(parent.LeftNode);

                // Traverse the right subtree
                TraversePostOrder(parent.RightNode);

                Console.WriteLine(parent.Data + " ");
            }
        }
    }
}
