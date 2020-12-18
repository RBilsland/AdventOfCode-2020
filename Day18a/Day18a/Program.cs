using System;
using System.IO;

namespace Day18a
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines(@"..\..\..\Input.txt");

            long resultingSum = 0;

            foreach(string line in input)
            {
                resultingSum += long.Parse(Formula.Process(line));
            }

            Console.WriteLine("AoC 2020 - Day 18a");
            Console.WriteLine($"Resulting Sum: {resultingSum}");
        }
    }
}
