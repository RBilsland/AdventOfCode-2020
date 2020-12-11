using System;
using System.IO;

namespace Day11a
{
    class Program
    {
        static void Main(string[] args)
        {
            SeatLayout mySeatLayout = new SeatLayout
            {
                plan = File.ReadAllLines(@"..\..\..\Input.txt")
            };

            Console.WriteLine("AoC 2020 - Day 11a");
            Console.WriteLine($"Occupied Seats: {mySeatLayout.run()}");
        }
    }
}
