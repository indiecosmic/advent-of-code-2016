using Common;
using System;
using System.Collections.Generic;

namespace Day02
{
    class Program
    {
        static void Main(string[] args)
        {
            var rows = InputFile.ReadRows();
            var digits = "";
            var pos = (x: 0, y: 0);
            foreach (var row in rows)
            {
                foreach (var dir in row)
                {
                    pos = Move(dir, pos.x, pos.y);
                }
                digits += GetDigit(pos.x, pos.y);
            }

            Console.WriteLine(digits);
        }

        public static (int x, int y) Move(char dir, int x, int y)
            => (dir, x, y) switch
            {
                ('U', _, -1) => (x, y + 1),
                ('U', _, 0) => (x, y + 1),
                ('D', _, 1) => (x, y - 1),
                ('D', _, 0) => (x, y - 1),
                ('L', 1, _) => (x - 1, y),
                ('L', 0, _) => (x - 1, y),
                ('R', -1, _) => (x+1, y),
                ('R', 0, _) => (x+1, y),
                (_,_,_) => (x, y)
            };

        public static int GetDigit(int x, int y)
            => (x, y) switch
            {
                (-1, 1) => 1,
                (0, 1) => 2,
                (1, 1) => 3,
                (-1, 0) => 4,
                (0, 0) => 5,
                (1, 0) => 6,
                (-1, -1) => 7,
                (0, -1) => 8,
                (1, -1) => 9,
                _ => 0
            };
    }
}