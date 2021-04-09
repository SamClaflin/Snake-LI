using System;

namespace Snake
{
    public class ListNode<T>
    {
        private T data;
        private ListNode<T> next;

        public T Data
        {
            get => data;
            set { data = value; }
        }

        public ListNode<T> Next
        {
            get => next;
            set { next = value; }
        }

        public ListNode(T data = default)
        {
            this.data = data;
            next = null;
        }
    }
}
