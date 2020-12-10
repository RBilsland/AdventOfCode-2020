using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;

namespace Day10a
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines(@"..\..\..\Input.txt");
            List<int> adapters = Array.ConvertAll(input, int.Parse).ToList();

            adapters.Add(0);
            adapters.Add(adapters.Max() + 3);

            int[] sortedAdapters = adapters.OrderBy(adapter => adapter).ToArray();

            int runningJoltDifferences = 0;

            Dictionary<int, int> joltDifferences = new Dictionary<int, int>();

            for(int position = 1; position < sortedAdapters.Length; position ++)
            {
                runningJoltDifferences += sortedAdapters[position] - sortedAdapters[position - 1];

                int joltDifference = sortedAdapters[position] - sortedAdapters[position - 1];

                if (!joltDifferences.ContainsKey(joltDifference))
                {
                    joltDifferences.Add(joltDifference, 0);
                }

                joltDifferences[joltDifference]++;
            }

            Console.WriteLine("AoC 2020 - Day 10a");
            Console.WriteLine($"Running Jolt Differences: {runningJoltDifferences}");

            foreach(KeyValuePair<int, int> joltDifference in joltDifferences)
            {
                Console.WriteLine($"Jolt Difference: {joltDifference.Key} Count: {joltDifference.Value}");
            }

            Console.WriteLine($"Answer: {joltDifferences[1] * joltDifferences[3]}");
        }
    }
}
