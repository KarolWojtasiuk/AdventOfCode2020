using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AdventOfCode2020
{
    public class Day4 : Day
    {
        public override object CalculatePart1()
        {
            var passports = ParseInput();

            return passports.Count(p => HasRequiredFields(p));
        }

        public override object CalculatePart2()
        {
            var passports = ParseInput();

            return passports.Count(p => IsValid(p));
        }

        private List<Dictionary<string, string>> ParseInput()
        {
            var passports = new List<Dictionary<string, string>>();
            var currentPassport = new Dictionary<string, string>();

            foreach (var line in InputLines)
            {
                if (String.IsNullOrWhiteSpace(line))
                {
                    passports.Add(currentPassport);
                    currentPassport = new Dictionary<string, string>();
                }
                else
                {
                    var pairs = line.Split(' ').Select(s => s.Split(':'));

                    foreach (var pair in pairs)
                    {
                        currentPassport.Add(pair[0], pair[1]);
                    }
                }
            }

            return passports;
        }

        private static bool HasRequiredFields(Dictionary<string, string> p)
        {
            return p.ContainsKey("byr") && p.ContainsKey("iyr") && p.ContainsKey("eyr") && p.ContainsKey("hgt") && p.ContainsKey("hcl") && p.ContainsKey("ecl") && p.ContainsKey("pid");
        }

        private static bool IsValid(Dictionary<string, string> passport)
        {
            if (!HasRequiredFields(passport))
            {
                return false;
            }

            return IsValidBYR(passport["byr"]) && IsValidIYR(passport["iyr"]) && IsValidEYR(passport["eyr"]) && IsValidHGT(passport["hgt"]) && IsValidHCL(passport["hcl"]) && IsValidECL(passport["ecl"]) && IsValidPID(passport["pid"]);

        }

        private static bool IsValidBYR(string byr)
        {
            try
            {
                var parsedByr = Int32.Parse(byr);
                if (parsedByr < 1920 || parsedByr > 2020)
                {
                    return false;
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        private static bool IsValidIYR(string iyr)
        {
            try
            {
                var parsedIyr = Int32.Parse(iyr);
                if (parsedIyr < 2010 || parsedIyr > 2020)
                {
                    return false;
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        private static bool IsValidEYR(string eyr)
        {
            try
            {
                var parsedEyr = Int32.Parse(eyr);
                if (parsedEyr < 2020 || parsedEyr > 2030)
                {
                    return false;
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        private static bool IsValidHGT(string hgt)
        {
            if (hgt.EndsWith("cm"))
            {
                var parsedHgt = Int32.Parse(hgt.TrimEnd('c', 'm'));
                if (parsedHgt < 150 || parsedHgt > 193)
                {
                    return false;
                }
                return true;
            }
            else if (hgt.EndsWith("in"))
            {
                var parsedHgt = Int32.Parse(hgt.TrimEnd('i', 'n'));
                if (parsedHgt < 59 || parsedHgt > 76)
                {
                    return false;
                }
                return true;
            }

            return false;
        }

        private static bool IsValidHCL(string hcl)
        {
            return Regex.Match(hcl, @"^#([A-Fa-f0-9]{6})$").Success;
        }

        private static bool IsValidECL(string ecl)
        {
            var validValues = new[] { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" };

            return validValues.Contains(ecl);
        }

        private static bool IsValidPID(string pid)
        {
            if (pid.Length == 9)
            {
                return pid.All(c => Char.IsDigit(c));
            }
            return false;
        }
    }
}
