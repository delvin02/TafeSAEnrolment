using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TafeSAEnrolment.BinaryTree
{
    public class TreeNode<T> where T : IComparable<T>
    {
        public TreeNode<T> LeftNode { get; set; }
        public TreeNode<T> RightNode { get; set; }
        public T Data { get; set; }

        public TreeNode(T data)
        {
            this.Data = data;
            this.LeftNode = null;
            this.RightNode = null;
        }
    }
}
