using System;
using System.Linq;
using System.Collections.Generic;

namespace AdventOfCode2020
{
    public class Day8 : Day
    {
        public override object CalculatePart1()
        {
            var set = ParseInput();
            return set.Accumulator;
        }

        public override object CalculatePart2()
        {
            var set = ParseInput();
            foreach (var instruction in set.Instructions)
            {
                if (instruction.Name == "nop")
                {
                    instruction.Name = "jmp";
                    set.ExecuteInstructions();
                    if (set.IsInfiniteLoop)
                    {
                        instruction.Name = "nop";
                    }
                    else
                    {
                        break;
                    }
                }
                else if (instruction.Name == "jmp")
                {
                    instruction.Name = "nop";
                    set.ExecuteInstructions();
                    if (set.IsInfiniteLoop)
                    {
                        instruction.Name = "jmp";
                    }
                    else
                    {
                        break;
                    }
                }
            }
            return set.Accumulator;
        }

        private InstructionSet ParseInput()
        {
            var input = InputLines.Where(s => !String.IsNullOrWhiteSpace(s));
            var set = new InstructionSet();

            foreach (var line in input)
            {
                set.Instructions.Add(new()
                {
                    Name = line.Split(' ')[0],
                    Value = Convert.ToInt32(line.Split(' ')[1])
                });
            }

            set.ExecuteInstructions();
            return set;
        }

        public class Instruction
        {
            public string Name { get; set; } = String.Empty;
            public int Value { get; set; }
        }

        public class InstructionSet
        {
            public List<Instruction> Instructions { get; set; } = new();
            public bool IsInfiniteLoop { get; set; }
            public int Accumulator { get; set; }

            public InstructionSet() => ExecuteInstructions();

            public void ExecuteInstructions()
            {
                IsInfiniteLoop = false;
                Accumulator = 0;

                var currentIndex = 0;
                var executedInstructions = new List<Instruction>();
                while (currentIndex < Instructions.Count)
                {
                    var currentInstruction = Instructions[currentIndex];

                    if (executedInstructions.Contains(currentInstruction))
                    {
                        IsInfiniteLoop = true;
                        return;
                    }
                    else
                    {
                        executedInstructions.Add(currentInstruction);
                    }

                    switch (currentInstruction.Name)
                    {
                        case "nop":
                            currentIndex++;
                            break;
                        case "jmp":
                            currentIndex += currentInstruction.Value;
                            break;
                        case "acc":
                            Accumulator += currentInstruction.Value;
                            currentIndex++;
                            break;
                    }
                }
            }
        }
    }
}
