using System;
using System.Linq;

namespace AdventOfCode2020
{
    public class Day1 : Day
    {
        public override string Calculate()
        {
            return $"{CalculatePart1()} | {CalculatePart2()}";
        }

        private string CalculatePart1()
        {
            var result = 0;
            var numbers = InputLines.Select(s => Int32.Parse(s));

            foreach (var firstNumber in numbers)
            {
                var secondNumber = numbers.FirstOrDefault(n => firstNumber + n == 2020);

                if (secondNumber != default)
                {
                    result = firstNumber * secondNumber;
                }
            }

            return result.ToString();
        }

        private string CalculatePart2()
        {
            var result = 0;
            var numbers = InputLines.Select(s => Int32.Parse(s));

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

            return result.ToString();
        }
    }
}
