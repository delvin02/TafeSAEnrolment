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

        public void Add(T value)
        {
            AddFirst(value);
        }
        public void AddFirst(T value)
        {
            AddFirst(new DoublyLinkedListNode<T>(value));
        }
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

        public void AddLast(T value)
        {
            AddLast(new DoublyLinkedListNode<T>(value));
        }

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

        public void RemoveFist(T value)
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

        public void CopyTo(T[] array, int arrayIndex)
        {
            DoublyLinkedListNode<T> current = Head;
            while (current != null)
            {
                array[arrayIndex++] = current.Value;
                current = current.Next;
            }
        }

        public void InsertAt(int position, T value)
        {
            if (position < 0 || position > Count)
            {
                throw new ArgumentOutOfRangeException(nameof(position));
            }

            if (position == 0)
            {
                AddFirst(value);
                return;
            }

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

        public void Clear()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }

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
