using System;
using System.IO;

namespace Day08a
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] program = File.ReadAllLines(@"..\..\..\Input.txt");

            HandheldGamesConsole handheldGamesConsole = new HandheldGamesConsole(program);

            handheldGamesConsole.Run();

            Console.WriteLine("AoC 2020 - Day 08a");
        }
    }
}
