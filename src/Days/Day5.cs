using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020
{
    public class Day5 : Day
    {
        public override string Calculate()
        {
            return $"{CalculatePart1()} | {CalculatePart2()}";
        }

        private int CalculatePart1()
        {
            var highestId = 0;
            foreach (var line in InputLines.Where(l => !String.IsNullOrWhiteSpace(l)))
            {
                var currentId = GetSeat(line).Id;
                if (GetSeat(line).Id > highestId)
                {
                    highestId = currentId;
                }
            }
            return highestId;
        }

        private int CalculatePart2()
        {
            var ids = new List<int>();
            foreach (var line in InputLines.Where(l => !String.IsNullOrWhiteSpace(l)))
            {
                ids.Add(GetSeat(line).Id);
            }

            return ids.First(id => !ids.Contains(id + 1) && ids.Contains(id + 2)) + 1;
        }

        private static Seat GetSeat(string code)
        {
            Console.WriteLine(code);
            var row = code[0..7];
            var column = code[7..];

            var positionInRow = SolveRange(0, 127, TextToSelections(row));
            var positioninColumn = SolveRange(0, 7, TextToSelections(column));

            return new Seat
            {
                Row = positionInRow,
                Column = positioninColumn
            };
        }

        private static List<bool> TextToSelections(string text)
        {
            var list = new List<bool>();

            foreach (var character in text.ToLower())
            {
                if (character == 'b' || character == 'r')
                {
                    list.Add(true);
                }
                else
                {
                    list.Add(false);
                }
            }
            return list;
        }

        private static int SolveRange(int startPosition, int endPosition, IEnumerable<bool> selections)
        {
            foreach (var selection in selections)
            {
                var middlePoint = (startPosition + endPosition) / 2;
                if (endPosition - startPosition is 1 or 2)
                {
                    if (selection)
                    {
                        return endPosition;
                    }
                    else
                    {
                        return middlePoint;
                    }
                }
                else
                {
                    if (selection)
                    {
                        startPosition = middlePoint;
                    }
                    else
                    {
                        endPosition = middlePoint;
                    }
                }
            }
            throw new Exception("Too small amount of selections to solve range");
        }
    }

    public record Seat
    {
        public int Row { get; init; }
        public int Column { get; init; }
        public int Id
        {
            get => (Row * 8) + Column;
        }
    }
}
