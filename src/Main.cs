using System;
using System.Threading;

namespace Snake
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            ConsoleKeyInfo cki;
            Console.CursorVisible = false;
            bool shouldContinue = true;
            Snake snake = new Snake(10, 20, 20);
            Arena arena = new Arena(40, ref snake);
            arena.Draw();

            do
            {
                while (!Console.KeyAvailable)
                {
                    Console.Clear();
                    snake.Move();
                    if (!arena.Draw())
                    {
                        Console.WriteLine("GAME OVER");
                        Console.WriteLine($"Final Score: {arena.Score}");
                        shouldContinue = false;
                        break;
                    }
                    Thread.Sleep(60);
                }

                if (!shouldContinue) { break; }

                cki = Console.ReadKey(true);
                switch (cki.Key)
                {
                    case ConsoleKey.W:
                    case ConsoleKey.UpArrow:
                        if (snake.CurrDir != Direction.SOUTH) { snake.CurrDir = Direction.NORTH; }
                        break;
                    case ConsoleKey.A:
                    case ConsoleKey.LeftArrow:
                        if (snake.CurrDir != Direction.EAST) { snake.CurrDir = Direction.WEST; }
                        break;
                    case ConsoleKey.S:
                    case ConsoleKey.DownArrow:
                        if (snake.CurrDir != Direction.NORTH) { snake.CurrDir = Direction.SOUTH; }
                        break;
                    case ConsoleKey.D:
                    case ConsoleKey.RightArrow:
                        if (snake.CurrDir != Direction.WEST) { snake.CurrDir = Direction.EAST; }
                        break;
                    default:
                        break;
                }
            } while (cki.Key != ConsoleKey.Escape);

            Console.CursorVisible = true;
        }
    }
}
