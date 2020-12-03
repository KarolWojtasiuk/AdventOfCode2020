using System;
using System.Linq;

namespace AdventOfCode2020
{
    public class Day3 : Day
    {
        public override string Calculate()
        {
            return $"{CalculatePart1()} | {CalculatePart2()}";
        }

        private int CalculatePart1()
        {
            var map = ParseInput();
            return Slope(map, 3, 1);
        }


        private long CalculatePart2()
        {
            var map = ParseInput();

            long totalTrees = Slope(map, 1, 1);
            totalTrees *= Slope(map, 3, 1);
            totalTrees *= Slope(map, 5, 1);
            totalTrees *= Slope(map, 7, 1);
            totalTrees *= Slope(map, 1, 2);
            return totalTrees;
        }

        private bool[,] ParseInput()
        {
            var map = new bool[InputLines.Length, InputLines[0].Length];

            for (int y = 0; y < InputLines.Length; y++)
            {
                for (int x = 0; x < InputLines[y].Length; x++)
                {
                    if (InputLines[y][x] == '#')
                    {
                        map[y, x] = true;
                    }
                    else
                    {
                        map[y, x] = false;
                    }
                }
            }

            return map;
        }

        private static int Slope(bool[,] map, int xOffset, int yOffset)
        {
            var encounters = 0;

            var (x, y) = (0, 0);

            while (true)
            {
                if (map.GetLength(0) <= y)
                {
                    break;
                }

                if (map.GetLength(1) <= x)
                {
                    var offset = x - map.GetLength(1);
                    x = offset;
                }

                if (map[y, x])
                {
                    encounters++;
                }

                x += xOffset;
                y += yOffset;
            }

            return encounters;
        }

    }
}
