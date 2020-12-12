using System;
using System.IO;

namespace Day12b
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] commands = File.ReadAllLines(@"..\..\..\Input.txt");

            Ship myShip = new Ship();

            foreach(string command in commands)
            {
                myShip.Move(command);
            }

            Console.WriteLine("AoC 2020 - Day 12b");
            Console.WriteLine($"Manhattan Distance {myShip.Position.ManhattanDistance}");
        }
    }
}
