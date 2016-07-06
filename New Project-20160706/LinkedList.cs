using System;
using System.Collections;
using System.Collections.Generic;

namespace DataWorks
{
    public class LinkedList<T> : IEnumerable<T>
    {
        private int _count;
        internal LinkedListNode<T> Head;
        internal LinkedListNode<T> Tail;

        public LinkedList()
        {
        }

        public LinkedList(IEnumerable<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException();
            }

            foreach (var item in collection)
            {
                AddLast(item);
            }
        }


        public IEnumerator<T> GetEnumerator()
        {
            var current = Head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public LinkedListNode<T> AddFirst(T value)
        {
            var result = new LinkedListNode<T>(value);
            if (Head == null)
            {
                InsertNodeToEmptyList(result);
            }
            else
            {
                result.Next = Head;
                result.Next.Previous = result;

                Head = result;
            }
            ++_count;
            return result;
        }


        public LinkedListNode<T> AddLast(T value)
        {
            var result = new LinkedListNode<T>(value);
            if (Head == null)
            {
                InsertNodeToEmptyList(result);
            }
            else
            {
                result.Previous = Tail;
                result.Previous.Next = result;
                Tail = result;
            }
            ++_count;
            return result;
        }

        public LinkedListNode<T> AddAfter(LinkedListNode<T> node, T value)
        {
            var newNode = new LinkedListNode<T>(value);
            var current = Head;

            while (current != null && current != node)
            {
                current = current.Next;
            }
            if (current == null)
                return null;

            if (current.Next == null)
            {
                current.Next = newNode;
                newNode.Previous = current;
                Tail = newNode;
            }
            else
            {
                newNode.Next = current.Next;
                newNode.Previous = current;

                current.Next.Previous = newNode;
                current.Next = newNode;
            }

            return newNode;
        }

        public LinkedListNode<T> AddBefore(LinkedListNode<T> node, T value)
        {
            var newNode = new LinkedListNode<T>(value);

            var current = Head;

            while (current != null && current != node)
            {
                current = current.Next;
            }
            if (current == null)
                return null;

            if (current.Previous == null)
            {
                newNode.Next = current;
                current.Previous = newNode;
                Head = newNode;
            }
            else
            {
                newNode.Previous = current.Previous;
                newNode.Next = current;

                current.Previous.Next = newNode;
                current.Previous = newNode;
            }
            return newNode;
        }

        public LinkedListNode<T> RemoveFirst()
        {
            if (Head == null) return null;
            if (_count == 1)
            {
                Head = null;
                Tail = null;
            }

            Head = Head.Next;
            Head.Previous.Invalidate();
            Head.Previous = null;
            --_count;
            return Head;
        }

        public LinkedListNode<T> RemoveLast()
        {
            if (Tail == null) return null;
            if (_count == 1)
            {
                Head = null;
                Tail = null;
            }

            Tail = Tail.Previous;
            Tail.Next.Invalidate();
            Tail.Next = null;
            --_count;
            return Tail;
        }

        private void InsertNodeToEmptyList(LinkedListNode<T> result)
        {
            Head = result;
            Tail = result;

            result.Previous = null;
            result.Next = null;
        }


        public void Reverse()
        {
            if (Head == null)
                return;

            var start = Head;


            while (start != null)
            {
                var current = start.Next;

                start.Next = start.Previous;
                start.Previous = current;

                if (start.Previous == null)
                {
                    Head = start;
                }

                start = start.Previous;
            }
        }


        public void Clear()
        {
            var current = Head;
            while (current != null)
            {
                var temp = current;
                current = current.Next;
                temp.Invalidate();
            }
            Head = null;
            _count = 0;
        }
    }
}