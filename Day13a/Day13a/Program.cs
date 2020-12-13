using System;
using System.IO;
using System.Linq;

namespace Day13a
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines(@"..\..\..\Input.txt");

            decimal arrivalTime = int.Parse(input[0]);

            var firstBus = input[1]
                .Split(',')
                .Where(bus => bus != "x")
                .Select(bus => new { bus = int.Parse(bus), arrival = NextBus(arrivalTime, int.Parse(bus)) } )
                .OrderBy(bus => bus.arrival)
                .FirstOrDefault();

            Console.WriteLine("AoC 2020 - Day 13a");
            Console.WriteLine($"First Bus: {firstBus.bus}");
            Console.WriteLine($"Arriving At: {firstBus.arrival}");
            Console.WriteLine($"Answer: {(firstBus.arrival - arrivalTime) * firstBus.bus}");
        }

        static int NextBus(decimal arrivalTime, int bus)
        {
            return ((int)Math.Truncate(arrivalTime / bus) + 1) * bus;
        }
    }
}
