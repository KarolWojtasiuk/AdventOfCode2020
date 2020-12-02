using System;
using System.Linq;

namespace AdventOfCode2020
{
    public class Day2 : Day
    {
        public override string Calculate()
        {
            return $"{CalculatePart1()} | {CalculatePart2()}";
        }

        private int CalculatePart1()
        {

            var validPasswords = 0;

            foreach (var line in InputLines.Select(l => l.Split(' ')))
            {
                var lowestNumber = Int32.Parse(line[0].Split('-')[0]);
                var highestNumber = Int32.Parse(line[0].Split('-')[1]);
                var letter = line[1][0];
                var password = line[2];

                var letterCount = password.Count(l => l == letter);

                if (letterCount >= lowestNumber && letterCount <= highestNumber)
                {
                    validPasswords++;
                }
            }

            return validPasswords;
        }

        private int CalculatePart2()
        {

            var validPasswords = 0;

            foreach (var line in InputLines.Select(l => l.Split(' ')))
            {
                var lowestNumber = Int32.Parse(line[0].Split('-')[0]);
                var highestNumber = Int32.Parse(line[0].Split('-')[1]);
                var letter = line[1][0];
                var password = line[2];

                var matches = 0;

                if (password[lowestNumber - 1] == letter)
                {
                    matches++;
                }

                if (password[highestNumber - 1] == letter)
                {
                    matches++;
                }

                if (matches == 1)
                {
                    validPasswords++;
                }
            }

            return validPasswords;
        }
    }
}
