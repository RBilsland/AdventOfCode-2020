using System;
using System.IO;

namespace Day03a
{
    class Program
    {
        static void Main(string[] args)
        {
            long multipliedTreeCount = 1;

            string[] mapRows = File.ReadAllLines(@"..\..\..\Input.txt");

            multipliedTreeCount *= CountTrees(mapRows, 1, 1);
            multipliedTreeCount *= CountTrees(mapRows, 3, 1);
            multipliedTreeCount *= CountTrees(mapRows, 5, 1);
            multipliedTreeCount *= CountTrees(mapRows, 7, 1);
            multipliedTreeCount *= CountTrees(mapRows, 1, 2);

            Console.WriteLine("AoC 2020 - Day 03b");
            Console.WriteLine($"Multiplied Tree Count: {multipliedTreeCount}");
        }

        static int CountTrees(string[] mapRows, int xStep, int yStep)
        {
            int xPos = 0;
            int yPos = 0;

            int treeCount = 0;

            while (yPos < mapRows.Length)
            {
                treeCount = treeCount + (mapRows[yPos][xPos] == '#' ? 1 : 0);

                xPos += xStep;
                yPos += yStep;

                if (yPos < mapRows.Length)
                {
                    if (xPos >= mapRows[yPos].Length)
                    {
                        xPos -= mapRows[yPos].Length;
                    }
                }
            }

            return treeCount;
        }
    }
}
