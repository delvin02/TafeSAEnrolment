using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TafeSAEnrolment
{
    public class Node<T>
    {
        public Node(T value)
        {
            Value = value;
            Next = null;
            Previous = null;
        }

        public T Value { get; set; }
        public Node<T> Next { get; set; }
        public Node<T> Previous { get; set; }


    }

    public class DoubleLinkedList<T> 
    {
        private Node<T> head;

        public DoubleLinkedList()
        {
            head = null;
        }

        public void Append(T data)
        {
            Node<T> newNode = new Node<T>(data);

            if (head == null)
            {
                head = newNode;
            } else
            {
                Node<T> current = head;
                while (current.Next != null)
                {
                    // keep going until the end
                    current = current.Next;
                }

                current.Next = newNode;
                newNode.Previous = current;

            }
        }

        // head
        public void Prepend(T data)
        {
            Node<T> newNode = new Node<T>(data);

            if (head != null)
            {
                head.Previous = newNode;
            }
            head = newNode;
        }

        public void InsertAt(int position, T data)
        {
            if (position == 0)
            {
                Prepend(data);
                return;
            }
            
            Node<T> newNode = new Node<T>(data);
            Node<T> current = head;
            int index = 0;

            while (current.Next != null && index < position - 1)
            {
                current = current.Next;
                index++;
            }

            if (current == null) return;


            newNode.Next = current.Next;
            
            if (current.Next != null)
            {
                current.Next.Previous = newNode.Next;
            }
            current.Next = newNode;
            newNode.Previous = current;

        }

        public void Delete(T data)
        {
            Node<T> current = head;

            while (current != null && !current.Value.Equals(data))
            {
                current = current.Next;
            }

            // not found
            if (current == null) return;

            if (current.Previous != null)
            {
                current.Previous.Next = current.Next;
            }
            else
            {
                head = current.Next;
            }

            if (current.Next != null)
            {
                current.Next.Previous = current.Previous;
            }
        }

        public void Traverse(Action<T> action)
        {
            Node<T> current = head;
            while (current != null)
            {
                action(current.Value);
                current = current.Next;
            }
        }

        public Node<T> Find(T data)
        {
            if (head == null)
                return null;

            Node<T> current = head;

            while (current != null)
            {
                if (current.Value.Equals(data))
                    return current;
                current = current.Next;
            }
            return null;
        }

    }
}
