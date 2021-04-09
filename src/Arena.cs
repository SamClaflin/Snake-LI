using System;
using System.Collections.Generic;

namespace Snake
{
    public class Arena
    {
        private Segment[,] matrix;
        private Snake snakeRef;
        private Food foodRef;
        private int size;
        private int score;

        public int Size
        {
            get => size;
            set { size = value; }
        }

        public int Score
        {
            get => score;
            set { score = value; }
        }

        public Arena(int size, ref Snake snakeRef)
        {
            this.size = size;
            this.snakeRef = snakeRef;
            foodRef = Food.GenerateFood(1, size - 2);
            score = 0;
            matrix = new Segment[size, size];
        }

        private bool MergeSnake()
        {
            ListNode<Segment> curr = snakeRef.Head;
            bool retVal = true;
            while (curr != null)
            {
                if (curr == snakeRef.Head)
                {
                    if (curr.Data.x <= 0) { curr.Data.x = size - 2; }
                    else if (curr.Data.x >= size - 1) { curr.Data.x = 1; }
                    else if (curr.Data.y <= 0) { curr.Data.y = size - 2; }
                    else if (curr.Data.y >= size - 1) { curr.Data.y = 1; }

                    if (matrix[curr.Data.y, curr.Data.x] != null && matrix[curr.Data.y, curr.Data.x].GetType() == typeof(Food))
                    {
                        foodRef = null;
                        snakeRef.PushSegment();
                        foodRef = Food.GenerateFood(1, size - 2);
                        score++;
                    }
                }
                else if (curr.Data.x == snakeRef.Head.Data.x && curr.Data.y == snakeRef.Head.Data.y)
                {
                    retVal = false;
                }

                matrix[curr.Data.y, curr.Data.x] = curr.Data;
                curr = curr.Next;
            }

            return retVal;
        }

        private void MergeFood()
        {
            matrix[foodRef.y, foodRef.x] = foodRef;
        }

        public bool Draw()
        {
            Array.Clear(matrix, 0, matrix.Length);
            MergeFood();
            bool retVal = MergeSnake();

            Console.WriteLine($"Score: {score}\n");
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (matrix[i, j] != null)
                    {
                        if (matrix[i, j].GetType() == typeof(Food))
                        {
                            Console.Write("π ");
                        }
                        else if (matrix[i, j].GetType() == typeof(Segment))
                        {
                            Console.Write("o ");
                        }
                    }
                    else
                    {
                        if (i == 0 || j == 0 || i == size - 1 || j == size - 1)
                        {
                            Console.Write("# ");
                        }
                        else
                        {
                            Console.Write("  ");
                        }
                    }
                }
                Console.WriteLine();
            }

            return retVal;
        }
    }
}
