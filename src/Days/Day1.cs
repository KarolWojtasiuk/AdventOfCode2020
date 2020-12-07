using System;
using System.Linq;
using System.Collections.Generic;

namespace AdventOfCode2020
{
    public class Day1 : Day
    {
        public override object CalculatePart1()
        {
            var result = 0;
            var numbers = ParseInput();

            foreach (var firstNumber in numbers)
            {
                var secondNumber = numbers.FirstOrDefault(n => firstNumber + n == 2020);

                if (secondNumber != default)
                {
                    result = firstNumber * secondNumber;
                }
            }

            return result;
        }

        public override object CalculatePart2()
        {
            var result = 0;
            var numbers = ParseInput();

            foreach (var firstNumber in numbers)
            {
                foreach (var secondNumber in numbers)
                {

                    var thirdNumber = numbers.FirstOrDefault(n => firstNumber + secondNumber + n == 2020);

                    if (thirdNumber != default)
                    {
                        result = firstNumber * secondNumber * thirdNumber;
                    }
                }
            }

            return result;
        }

        private List<int> ParseInput()
        {
            return InputLines.Where(s => !String.IsNullOrWhiteSpace(s)).Select(s => Int32.Parse(s)).ToList();
        }
    }
}
