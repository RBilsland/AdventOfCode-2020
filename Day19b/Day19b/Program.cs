using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day19b
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
                if(input[row].Length % 8 == 0)
                {
                    string inputRow = input[row];

                    int combination31Count = 0;
                    int combination42Count = 0;

                    while(inputRow != string.Empty)
                    {
                        int chunk = inputRow[0..8].ToBin().ToInt();
                        inputRow = inputRow[8..];

                        if (combination31Count == 0)
                        {
                            if (valid31Combinations.Contains(chunk))
                            {
                                combination31Count++;
                            }
                            else
                            {
                                combination42Count += valid42Combinations.Contains(chunk) ? 1 : 0;
                            }
                        }
                        else
                        {
                            combination31Count += valid31Combinations.Contains(chunk) ? 1 : 0;
                        }
                    }

                    matchCount +=
                        input[row].Length / 8 == combination31Count + combination42Count &&
                        combination31Count >= 1 &&
                        combination42Count >= 2 &&
                        combination42Count > combination31Count ? 1 : 0;
                }

                row++;
            }

            Console.WriteLine("AoC 2020 - Day 19b");
            Console.WriteLine($"Match Count: {matchCount}");
        }
    }
}
