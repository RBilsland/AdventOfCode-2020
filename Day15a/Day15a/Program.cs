using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;

namespace Day15a
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines(@"..\..\..\Input.txt");

            int[] numbers = input[0]
                .Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Where(number => int.TryParse(number, out _))
                .Select(int.Parse)
                .ToArray();

            int turn = 1;
            Dictionary<int, NumberSpoken> numbersSpoken = new Dictionary<int, NumberSpoken>();
            int lastSpokenNumber = 0;

            foreach(int number in numbers)
            {
                lastSpokenNumber = number;

                numbersSpoken = numbersSpoken.UpdateNumberSpoken(number, turn);

                turn++;
            }

            while (numbersSpoken.ContainsKey(lastSpokenNumber) && turn <= 2020)
            {
                if (numbersSpoken[lastSpokenNumber].Occurances == 1)
                {
                    lastSpokenNumber = 0;
                }
                else
                {
                    lastSpokenNumber = numbersSpoken[lastSpokenNumber].Difference;
                }

                numbersSpoken = numbersSpoken.UpdateNumberSpoken(lastSpokenNumber, turn);

                turn++;
            }

            Console.WriteLine("AoC 2020 - Day 15a");
            Console.WriteLine($"Last Spoken Number: {lastSpokenNumber}");
        }
    }
}
