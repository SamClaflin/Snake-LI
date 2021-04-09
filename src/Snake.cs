using System;

namespace Snake
{
    public class Snake
    {
        private LinkedList<Segment> segments;
        private Direction currDir;
        private int size;

        public int Size
        {
            get => size;
            set { size = value; }
        }

        public ListNode<Segment> Head
        {
            get => segments.Head;
        }

        public Direction CurrDir
        {
            get => currDir;
            set { currDir = value; }
        }

        public Snake(int initSize, int initX, int initY)
        {
            size = initSize;
            currDir = Direction.NORTH;
            segments = new LinkedList<Segment>();
            for (int i = 0; i < initSize; i++)
            {
                segments.InsertTail(new Segment(initX + i, initY));
            }
        }

        public void Move()
        {
            segments.RemoveTail();

            switch (currDir)
            {
                case Direction.NORTH:
                    segments.InsertHead(new Segment(Head.Data.x, Head.Data.y - 1));
                    break;
                case Direction.SOUTH:
                    segments.InsertHead(new Segment(Head.Data.x, Head.Data.y + 1));
                    break;
                case Direction.EAST:
                    segments.InsertHead(new Segment(Head.Data.x + 1, Head.Data.y));
                    break;
                case Direction.WEST:
                    segments.InsertHead(new Segment(Head.Data.x - 1, Head.Data.y));
                    break;
            }
        }

        public void PushSegment()
        {
            ListNode<Segment> tailAdj = Head;
            while (tailAdj.Next != segments.Tail) { tailAdj = tailAdj.Next; }
            (int, int) tailPos = (segments.Tail.Data.x, segments.Tail.Data.y);
            (int, int) tailAdjPos = (tailAdj.Data.x, tailAdj.Data.y);

            if (tailPos.Item2 == tailAdjPos.Item2)
            {
                if (tailPos.Item1 > tailAdjPos.Item2)
                {
                    segments.InsertTail(new Segment(tailPos.Item1 + 1, tailPos.Item2));
                }
                else
                {
                    segments.InsertTail(new Segment(tailPos.Item1 - 1, tailPos.Item2));
                }
            }
            else
            {
                if (tailPos.Item2 > tailAdjPos.Item2)
                {
                    segments.InsertTail(new Segment(tailPos.Item1, tailPos.Item2 + 1));
                }
                else
                {
                    segments.InsertTail(new Segment(tailPos.Item1, tailPos.Item2 - 1));
                }
            }
        }
    }
}
