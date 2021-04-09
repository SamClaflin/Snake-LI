using System;

namespace Snake
{
    public class LinkedList<T>
    {
        private ListNode<T> head;
        private ListNode<T> tail;

        public ListNode<T> Head
        {
            get => head;
            set { head = value; }
        }

        public ListNode<T> Tail
        {
            get => tail;
            set { tail = value; }
        }

        public LinkedList()
        {
            head = null;
            tail = null;
        }

        public void InsertHead(T data)
        {
            if (head == null)
            {
                head = new ListNode<T>(data);
                tail = head;
            }
            else
            {
                ListNode<T> newNode = new ListNode<T>(data);
                newNode.Next = head;
                head = newNode;
            }
        }

        public void InsertTail(T data)
        {
            if (head == null)
            {
                head = new ListNode<T>(data);
                tail = head;
            }
            else
            {
                ListNode<T> newNode = new ListNode<T>(data);
                tail.Next = newNode;
                tail = newNode;
            }
        }

        public void RemoveTail()
        {
            if (tail == null) { return; }
            if (tail == head)
            {
                tail = null;
                head = null;
            }
            else
            {
                ListNode<T> curr = head;
                while (curr.Next != tail) { curr = curr.Next; }
                curr.Next = null;
                tail = curr;
            }
        }

        public void TailToHead()
        {
            if (head == null || head == tail) { return; }
            ListNode<T> curr = head;
            while (curr.Next != tail) { curr = curr.Next; }
            tail.Next = head;
            head = tail;
            curr.Next = null;
        }
    }
}
