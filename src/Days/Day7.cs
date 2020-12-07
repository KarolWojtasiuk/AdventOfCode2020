using System;
using System.Linq;
using System.Collections.Generic;

namespace AdventOfCode2020
{
    public class Day7 : Day
    {
        public override object CalculatePart1()
        {
            var bags = ParseInput();
            return bags.Count(b => b.CanHold(GetBag(bags, "shiny gold")));
        }

        public override object CalculatePart2()
        {
            var bags = ParseInput();
            return GetBag(bags, "shiny gold").CountAll();
        }

        private List<Bag> ParseInput()
        {
            var list = new List<Bag>();

            foreach (var line in InputLines.Where(l => !String.IsNullOrWhiteSpace(l)))
            {
                var bagName = line[0..(line.IndexOf("bags") - 1)];
                var bagContent = line[(line.IndexOf("contain") + 8)..^1].Split(", ");

                var content = new Dictionary<Bag, int>();

                var bag = GetBag(list, bagName);

                if (!bagContent.Contains("no other bags"))
                {
                    foreach (var item in bagContent)
                    {
                        var amount = Int32.Parse(item.Split(' ')[0]);
                        var name = item.Split(' ', 2)[1].Replace(" bags", null).Replace(" bag", null);

                        bag.Bags.Add(GetBag(list, name), amount);
                    }
                }
            }

            return list;
        }

        private static Bag GetBag(List<Bag> bags, string name)
        {
            return bags.FirstOrDefault(b => b.Name == name) ?? new Bag(name, bags);
        }
    }

    public record Bag
    {
        public string Name { get; init; }
        public Dictionary<Bag, int> Bags { get; init; }

        public Bag(string name, ICollection<Bag> bags)
        {
            Name = name;
            Bags = new();
            bags.Add(this);
        }

        public bool CanHold(Bag bag)
        {
            return Bags.Keys.Any(b => b == bag) || Bags.Keys.Any(b => b.CanHold(bag));
        }

        public int CountAll()
        {
            return Bags.Aggregate(0, (i, p) => i + p.Value + p.Value * p.Key.CountAll());
        }
    }
}
