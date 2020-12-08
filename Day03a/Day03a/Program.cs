using System;
using System.IO;

namespace Day03a
{
    class Program
    {
        static void Main(string[] args)
        {
            int xPos = 0;
            int yPos = 0;

            int treeCount = 0;

            string[] mapRows = File.ReadAllLines(@"..\..\..\Input.txt");

            while(yPos < mapRows.Length)
            {
                treeCount = treeCount + (mapRows[yPos][xPos] == '#' ? 1 : 0);

                yPos += 1;
                xPos += 3;

                if (yPos < mapRows.Length)
                {
                    if (xPos >= mapRows[yPos].Length)
                    {
                        xPos -= mapRows[yPos].Length;
                    }
                }
            }

            Console.WriteLine("AoC 2020 - Day 03a");
            Console.WriteLine($"Tree Count: {treeCount}");
        }
    }
}
