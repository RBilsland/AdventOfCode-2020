using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day14b
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] commands = File.ReadAllLines(@"..\..\..\Input.txt");

            Dictionary<long, long> memory = new Dictionary<long, long>();

            long baseMask = Convert.ToInt64("111111111111111111111111111111111111", 2);
            long baseAddition = Convert.ToInt64("000000000000000000000000000000000000", 2);
            List<long> addressMasks = new List<long>();

            foreach (string command in commands)
            {
                if(command[..4].ToLower() == "mask")
                {
                    string mask = command[^36..].ToLower();

                    baseMask = Convert.ToInt64(mask.Replace("0", "*").Replace("1", "0").Replace("x", "0").Replace("*", "1"), 2);
                    baseAddition = Convert.ToInt64(mask.Replace("x", "0"), 2);

                    addressMasks = BuildMasks(mask.Replace("1", "0"));
                }

                if (command[..3].ToLower() == "mem")
                {
                    string[] commandParts = command.Split(new[] { '[', ']', ' ', '=' }, StringSplitOptions.RemoveEmptyEntries);

                    long baseAddress = Int64.Parse(commandParts[1]);
                    long value = Int64.Parse(commandParts[2]);

                    baseAddress &= baseMask;
                    baseAddress |= baseAddition;

                    foreach(long addressMask in addressMasks)
                    {
                        long address = baseAddress | addressMask;

                        if (memory.ContainsKey(address))
                        {
                            memory[address] = value;
                        }
                        else
                        {
                            memory.Add(address, value);
                        }
                    }
                }
            }

            Console.WriteLine("AoC 2020 - Day 14b");
            Console.WriteLine($"Sum Of All Memory Values: {memory.Select(memory => memory.Value).Sum()}");
        }

        public static List<long> BuildMasks(string baseMask)
        {
            int lengthOfBinaryDigits = baseMask.ToLower().Count(character => character == 'x');
            double numberOfAddresses = Math.Pow(2, lengthOfBinaryDigits);

            List<long> masks = new List<long>();

            for (int addressCount = 0; addressCount < numberOfAddresses; addressCount ++)
            {
                masks.Add(baseMask.ReplaceXs(Convert.ToString(addressCount, 2).PadLeft(lengthOfBinaryDigits, '0')));
            }

            return masks;
        }
    }
}
