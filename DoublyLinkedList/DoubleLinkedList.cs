using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TafeSAEnrolment.DoublyLinkedList
{

    public class DoubleLinkedList<T> : ICollection<T>
    {
        public DoublyLinkedListNode<T> Head
        {
            get;
            private set;
        }

        public DoublyLinkedListNode<T> Tail
        {
            get;
            private set;
        }

        public int Count { get; private set; }

        public bool IsReadOnly { get; private set; }

        // Add a new node to the doubly linked list
        public void Add(T value)
        {
            AddFirst(value);
        }

        // Add a new node to the beginning of the doubly linked list
        public void AddFirst(T value)
        {
            AddFirst(new DoublyLinkedListNode<T>(value));
        }

        // Add a new node to the beginning of the doubly linked list
        public void AddFirst(DoublyLinkedListNode<T> node)
        {
            DoublyLinkedListNode<T> tmp = Head;
            Head = node;
            Head.Next = tmp;
            if (Count == 0)
            {
                Tail = Head;
            }
            else 
            {
                tmp.Previous = Head;
            }
            Count++;
        }

        // Add a new node to the end of the doubly linked list
        public void AddLast(T value)
        {
            AddLast(new DoublyLinkedListNode<T>(value));
        }

        // Add a new node to the end of the doubly linked list
        public void AddLast(DoublyLinkedListNode<T> node)
        {

            // if linked list is blank
            if (Count == 0)
            {
                Head = node;
            }
            else
            {
                Tail.Next = node;
                node.Previous = Tail;
            }
            Tail = node;
            Count++;
        }

        // Remove the first node from the doubly linked list
        public void RemoveFirst(T value)
        {
            RemoveFirst(new DoublyLinkedListNode<T>(value));
        }

        public void RemoveFirst(DoublyLinkedListNode<T> node)
        {
            if (Count != 0)
            {
                Head = Head.Next;

                if (Head != null)
                {
                    Head.Previous = null;
                }
                Count--;

                if (Count == 0)
                {
                    Tail = null;
                }
            }
        }
        // Remove the last node from the doubly linked list
        public void RemoveLast()
        {
            if (Count < 1)
            {
                return;
            }

            if (Count == 1)
            {
                Head = null;
                Tail = null;
            }
            else
            {
                Tail = Tail.Previous;
                Tail.Next = null;
            }
            Count--;

        }
        // Remove the last node from the doubly linked list

        public void RemoveLast(T value)
        {
            RemoveLast(new DoublyLinkedListNode<T>(value));
        }

        public void RemoveLast(DoublyLinkedListNode<T> node)
        {
            if (Count == 1)
            {
                Head = null;
                Tail = null;
            }

            if (Count != 0)
            {

                DoublyLinkedListNode<T> current = Head;
                int index = 0;
                while (current != null && index < Count -1)
                {
                    current = current.Next;
                    index++;
                }

                current.Next = null;
                Tail = current;
            }
            Count--;
        }

        // Check if the doubly linked list contains a specific value
        public bool Contains(T item)
        {
            DoublyLinkedListNode<T> current = Head;

            while (current != null)
            {
                if (current.Value.Equals(item))
                    return true;
                current = current.Next;
            }
            return false;
        }

        // Copy the elements of the doubly linked list to an array
        public void CopyTo(T[] array, int arrayIndex)
        {
            DoublyLinkedListNode<T> current = Head;
            while (current != null)
            {
                array[arrayIndex++] = current.Value;
                current = current.Next;
            }
        }

        // Insert a new node at a specific position in the doubly linked list
        public void InsertAt(int position, T value)
        {
            if (position < 0 || position > Count)
            {
                throw new ArgumentOutOfRangeException(nameof(position));
            }

            // add first if the linked list has nothing
            if (position == 0)
            {
                AddFirst(value);
                return;
            }

            // add last if the linked list size is equal to the position
            if (position == Count)
            {
                AddLast(value);
                return;
            }

            DoublyLinkedListNode<T> newNode = new DoublyLinkedListNode<T>(value);
            DoublyLinkedListNode<T> current = Head;
            int index = 0;

            while (current != null && index < position - 1)
            {
                current = current.Next;
                index++;
            }

            // to avoid losting track the next node, we first assign
            newNode.Next = current.Next;
            current.Next.Previous = newNode;

            // once we assign the newNode, the chain is linked, 
            current.Next = newNode;
            newNode.Previous = current;
        }

        // Remove a specific value from the doubly linked list
        public bool Remove(T value)
        {
            if (Count == 0)
                return false;

            DoublyLinkedListNode<T> current = Head;

            while (current != null)
            {
                if (current.Value.Equals(value))
                {
                    if (current.Next == Tail)
                    {
                        RemoveLast();
                    }
                    else
                    {
                        current.Next = current.Next.Next;
                        current.Next.Previous = current;
                        Count--;
                    }
                    
                    return true;
                }
                current = current.Next;
            }
            return false;
        }

        // Delete the node at a specific position in the doubly linked list
        public void DeleteAt(int position)
        {
            if (position < 0 || position > Count)
            {
                throw new ArgumentOutOfRangeException(nameof(position));
            }

            // Remove First
            if (position == Count)
            {
                //RemoveFirst(position);
                return;
            }

            // Remove Last
            if (position == Count)
            {
                //RemoveLast(position);
                return;
            }
            DoublyLinkedListNode<T> current = Head;
            int index = 0;

            while (current != null && index < position - 1)
            {
                current = current.Next;
                index++;
            }

            // to avoid losting track the next node, we first assign
            current.Next = current.Next.Next;
            current.Next.Previous = current;
            Count--;

        }

        public void Traverse(Action<T> action)
        {
            DoublyLinkedListNode<T> current = Head;

            while (current != null)
            {
                action(current.Value);
                current = current.Next;
            }
        }

        // Find the node with a specific value in the doubly linked list
        public DoublyLinkedListNode<T> Find(T value)
        {
            if (Count == 0)
                return null;

            DoublyLinkedListNode<T> current = Head;
            while (current != null)
            {
                if (current.Value.Equals(value))
                    return current;
                current = current.Next;
            }
            return null;
        }

        // Clear the doubly linked list
        public void Clear()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }

        // Return a string representation of the doubly linked list
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            DoublyLinkedListNode<T> current = Head;

            while (current != null)
            {
                builder.Append(current.Value.ToString());
                builder.Append(" <-> ");
                current = current.Next;
            }
            return builder.ToString();
        }

        public IEnumerator<T> GetEnumerator()
        {
            DoublyLinkedListNode<T> current = Head;

            while (current != null)
            {
                // stateful return
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

    }
}
