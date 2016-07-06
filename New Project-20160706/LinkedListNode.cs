namespace DataWorks
{
    public sealed class LinkedListNode<T>
    {
        public LinkedListNode(T value)
        {
            Value = value;
        }

        public T Value { get; set; }
        public LinkedListNode<T> Next { get; set; }
        public LinkedListNode<T> Previous { get; set; }

        internal void Invalidate()
        {
            Value = default(T);
            Next = null;
            Previous = null;
        }
    }
}