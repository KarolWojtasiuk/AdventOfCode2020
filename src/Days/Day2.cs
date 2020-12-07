using System;
using System.Linq;
using System.Collections.Generic;

namespace AdventOfCode2020
{
    public class Day2 : Day
    {
        public override object CalculatePart1()
        {
            var passwords = ParseInput();
            var validPasswords = 0;

            foreach (var password in passwords)
            {
                if (password.Content is not null)
                {

                    var letterCount = password.Content.Count(l => l == password.Letter);

                    if (letterCount >= password.LowestNumber && letterCount <= password.HighestNumber)
                    {
                        validPasswords++;
                    }
                }
            }

            return validPasswords;
        }

        public override object CalculatePart2()
        {
            var passwords = ParseInput();
            var validPasswords = 0;

            foreach (var password in passwords)
            {
                var matches = 0;

                if (password.Content is not null)
                {
                    if (password.Content[password.LowestNumber - 1] == password.Letter)
                    {
                        matches++;
                    }

                    if (password.Content[password.HighestNumber - 1] == password.Letter)
                    {
                        matches++;
                    }
                }

                if (matches == 1)
                {
                    validPasswords++;
                }
            }

            return validPasswords;
        }

        private List<Password> ParseInput()
        {
            var input = InputLines.Where(s => !String.IsNullOrWhiteSpace(s)).Select(l => l.Split(' '));

            var passwords = new List<Password>();

            foreach (var line in input)
            {
                passwords.Add(new()
                {
                    LowestNumber = Int32.Parse(line[0].Split('-')[0]),
                    HighestNumber = Int32.Parse(line[0].Split('-')[1]),
                    Letter = line[1][0],
                    Content = line[2]
                });
            }

            return passwords;
        }
    }

    public class Password
    {
        public int LowestNumber { get; set; }
        public int HighestNumber { get; set; }
        public char Letter { get; set; }
        public string? Content { get; set; }
    }
}
