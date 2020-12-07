using System;
using System.Linq;
using System.Collections.Generic;

namespace AdventOfCode2020
{
    public class Day6 : Day
    {
        public override object CalculatePart1()
        {
            var groups = ParseInput();
            return groups.Select(g => g.UniqueAnswersCount).Sum();
        }

        public override object CalculatePart2()
        {
            var groups = ParseInput();
            return groups.Select(g => g.EveryoneCorrectAnswersCount).Sum();
        }

        private List<Group> ParseInput()
        {
            var groups = new List<Group>();
            var currentGroup = new Group(new());

            foreach (var line in InputLines)
            {
                if (!String.IsNullOrWhiteSpace(line))
                {
                    currentGroup.Answers.Add(line);
                }
                else
                {
                    groups.Add(currentGroup);
                    currentGroup = new(new());
                }
            }

            return groups;
        }
    }

    public class Group
    {
        public List<string> Answers { get; set; }
        public int UniqueAnswersCount
        {
            get
            {
                var chars = String.Join(String.Empty, Answers).Where(c => !Char.IsWhiteSpace(c)).Distinct();
                return chars.Count();
            }
        }
        public int EveryoneCorrectAnswersCount
        {
            get
            {
                var chars = String.Join(String.Empty, Answers).Where(c => !Char.IsWhiteSpace(c));

                var duplicates = chars.GroupBy(x => x).Where(c => c.Count() == Answers.Count);

                return duplicates.Count();
            }
        }

        public Group(List<string> answers)
        {
            Answers = answers;
        }
    }
}
