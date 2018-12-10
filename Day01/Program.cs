using System;
using System.Collections.Generic;
using System.Drawing;
using Common;

namespace Day01
{
    class Program
    {
        static void Main()
        {
            var input = InputFile.ReadInput();
            var instructions = input.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var directions = new LinkedList<Direction>(new[]
            {
                new Direction(0, 1), //N
                new Direction(1, 0), //E
                new Direction(0, -1),//S
                new Direction(-1, 0) //W
            });
            var currentDirection = directions.First;
            var position = new Point(0, 0);
            var history = new List<Point>{position};
            var locationsVisitedTwice = new List<Point>();
            foreach (var instruction in instructions)
            {
                if (instruction[0] == 'R')
                    currentDirection = currentDirection.Next ?? directions.First;
                else
                    currentDirection = currentDirection.Previous ?? directions.Last;

                var steps = int.Parse(instruction.Substring(1));
                for (var i = 0; i < steps; i++)
                {
                    position = currentDirection.Value.Walk(position);
                    if (history.Contains(position))
                        locationsVisitedTwice.Add(position);
                    history.Add(position);
                }
            }
            var part1Answer = Math.Abs(position.X) + Math.Abs(position.Y);
            Console.WriteLine($"Shortest path: {part1Answer}");
            var part2Answer = Math.Abs(locationsVisitedTwice[0].X) + Math.Abs(locationsVisitedTwice[0].Y);
            Console.WriteLine($"First location visited twice: {part2Answer} blocks away");
            Console.ReadLine();
        }


        private class Direction
        {
            private int Dx { get; }
            private int Dy { get; }

            public Direction(int dx, int dy)
            {
                Dx = dx;
                Dy = dy;
            }

            public Point Walk(Point location, int steps = 1)
            {
                location.X += (Dx * steps);
                location.Y += (Dy * steps);
                return location;
            }
        }
    }
}
