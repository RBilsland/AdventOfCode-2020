using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day10b
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines(@"..\..\..\Input.txt");
            List<int> adapters = Array.ConvertAll(input, int.Parse).ToList();

            adapters.Add(0);
            adapters.Add(adapters.Max() + 3);

            Dictionary<int, long> paths = adapters.ToDictionary(adapter => adapter, adapter => 0L);

            paths[adapters.Min()] = 1;

            foreach(int fromAdapter in adapters.OrderBy(adapter => adapter))
            {
                foreach(int toAdapter in adapters.Where(adapter => adapter > fromAdapter && adapter <= fromAdapter + 3))
                {
                    paths[toAdapter] += paths[fromAdapter];
                }
            }

            Console.WriteLine("AoC 2020 - Day 10b");
            Console.WriteLine($"Permutations: {paths.Where(path => path.Key == adapters.Max()).FirstOrDefault().Value}");
        }
    }
}
