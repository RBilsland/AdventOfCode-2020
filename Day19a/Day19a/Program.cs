using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day19a
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines(@"..\..\..\Input.txt");

            Dictionary<int, string> rules = new Dictionary<int, string>();

            int row = 0;

            while (row < input.Length && !string.IsNullOrEmpty(input[row]))
            {
                string[] parts = input[row].Split(":", StringSplitOptions.RemoveEmptyEntries);

                rules.Add(int.Parse(parts[0]), parts[1].Trim());

                row++;
            }

            List<int> valid31Combinations = rules.ReturnRuleStrings(31)
                .Select(validCombination => Convert.ToInt32(validCombination, 2))
                .ToList();

            List<int> valid42Combinations = rules.ReturnRuleStrings(42)
                .Select(validCombination => Convert.ToInt32(validCombination, 2))
                .ToList();

            row++;

            int matchCount = 0;

            while (row < input.Length)
            {
                if(input[row].Length == 24)
                {
                    matchCount +=
                        valid42Combinations.Contains(input[row][0..8].ToBin().ToInt()) &&
                        valid42Combinations.Contains(input[row][8..16].ToBin().ToInt()) &&
                        valid31Combinations.Contains(input[row][16..24].ToBin().ToInt()) ? 1 : 0;
                }

                row++;
            }

            Console.WriteLine("AoC 2020 - Day 19a");
            Console.WriteLine($"Match Count: {matchCount}");
        }
    }
}
