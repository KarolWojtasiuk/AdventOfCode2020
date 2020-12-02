using System.IO;

namespace AdventOfCode2020
{
    public abstract class Day
    {
        public string[] InputLines
        {
            get
            {
                var fileName = $"input/{GetType().Name}.txt";
                return File.ReadAllLines(fileName);
            }
        }

        public abstract string Calculate();
    }
}
