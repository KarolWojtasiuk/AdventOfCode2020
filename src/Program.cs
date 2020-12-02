using System;
using System.Reflection;

namespace AdventOfCode2020
{
    class Program
    {
        static void Main(string[] args)
        {
            var day = 0;
            try
            {
                day = Int32.Parse(args[0]);
            }
            catch (Exception)
            {
                Console.WriteLine("Select Day!");
                return;
            }

            var type = Type.GetType($"Day{day}");

            if (type is null)
            {
                Console.WriteLine($"Day{day} solution does not exist!");
                return;
            }

            if (Activator.CreateInstance(type) is not IDay solution)
            {
                Console.WriteLine($"Day{day} solution does not exist!");
                return;
            }

            solution.Calculate();
        }
    }
}
