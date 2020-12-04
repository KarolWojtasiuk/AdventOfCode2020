using System;
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

                var reader = new StreamReader(fileName);
                var file = reader.ReadToEnd();

                return file.Split(Environment.NewLine);
            }
        }

        public abstract string Calculate();
    }
}
