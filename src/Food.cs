using System;

namespace Snake
{
    public class Food : Segment
    {
        private static Random rand = new Random();

        public Food(int x, int y) : base(x, y) { }

        public static Food GenerateFood(int min, int max)
        {
            return new Food(rand.Next(max) + min, rand.Next(max) + min);
        }
    }
}
