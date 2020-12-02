using System;
using System.Reflection;

namespace AdventOfCode2020
{
    class Program
    {
        static void Main(string[] args)
        {
            int day;
            try
            {
                day = Int32.Parse(args[0]);
            }
            catch (Exception)
            {
                Console.WriteLine("Select Day!");
                return;
            }

            var type = Type.GetType($"{nameof(AdventOfCode2020)}.Day{day}");

            if (type is null)
            {
                Console.WriteLine($"Day{day} solution does not exist!");
                return;
            }

            if (Activator.CreateInstance(type) is not Day solution)
            {
                Console.WriteLine($"Day{day} solution does not exist!");
                return;
            }

            Console.WriteLine(solution.Calculate());
        }
    }
}
