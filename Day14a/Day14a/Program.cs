using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day14a
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] commands = File.ReadAllLines(@"..\..\..\Input.txt");

            Dictionary<long, long> memory = new Dictionary<long, long>();

            long currentMask = Convert.ToInt64("111111111111111111111111111111111111", 2);
            long currentAddition = Convert.ToInt64("000000000000000000000000000000000000", 2);

            foreach (string command in commands)
            {
                if(command[..4].ToLower() == "mask")
                {
                    string mask = command[^36..].ToLower();

                    currentMask = Convert.ToInt64(mask.Replace("1", "0").Replace("x", "1"), 2);
                    currentAddition = Convert.ToInt64(mask.Replace("x", "0"), 2);
                }
                if(command[..3].ToLower() == "mem")
                {
                    string[] commandParts = command.Split(new[] { '[', ']', ' ', '=' }, StringSplitOptions.RemoveEmptyEntries);

                    long address = Int64.Parse(commandParts[1]);
                    long value = Int64.Parse(commandParts[2]);

                    if (!memory.ContainsKey(address))
                    {
                        memory.Add(address, 0);
                    }

                    memory[address] = value;
                    memory[address] &= currentMask;
                    memory[address] |= currentAddition;
                }
            }

            Console.WriteLine("AoC 2020 - Day 14a");
            Console.WriteLine($"Sum Of All Memory Values: {memory.Select(memory => memory.Value).Sum()}");
        }
    }
}
