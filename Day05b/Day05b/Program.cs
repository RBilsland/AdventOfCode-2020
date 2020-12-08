using System;
using System.Collections.Generic;
using System.IO;

namespace Day05a
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] seatCodes = File.ReadAllLines(@"..\..\..\Input.txt");

            List<string> seatsAvailable = new List<string>();
            List<int> seatIdsTaken = new List<int>();

            for (int row = 1; row <= 126; row++)
            {
                for (int column = 0; column <= 7; column++)
                {
                    seatsAvailable.Add($"{row:D3}{column:D1}");
                }
            }

            foreach(string seatCode in seatCodes)
            {
                (int row, int column) = LookupPosition(seatCode);

                if (seatsAvailable.Contains($"{row:D3}{column:D1}"))
                {
                    seatsAvailable.Remove($"{row:D3}{column:D1}");
                    seatIdsTaken.Add((row * 8) + column);
                }
            }

            Console.WriteLine("AoC 2020 - Day 05b");

            foreach (string seatAvailable in seatsAvailable)
            {
                int row = int.Parse(seatAvailable[..3]);
                int column = int.Parse(seatAvailable[2..]);

                int seatId = (row * 8) + column;

                if (seatIdsTaken.Contains(seatId - 1) && seatIdsTaken.Contains(seatId + 1))
                {
                    Console.WriteLine($"Your Seat Id: {seatId}");
                }
            }
        }

        static (int row, int column) LookupPosition(string seatCode)
        {
            return (row: DecodePosition(seatCode[..7], 'F', 0, 'B', 127), column: DecodePosition(seatCode[3..], 'L', 0, 'R', 7));
        }

        static int DecodePosition(string toDecode, char lowerChar, int lowerRange, char higherChar, int higherRange)
        {
            foreach (char toCheck in toDecode)
            {
                int halfRangeDifference = ((higherRange - lowerRange) + 1) / 2;

                if (toCheck == lowerChar)
                {
                    higherRange -= halfRangeDifference;
                }
                
                if (toCheck == higherChar)
                {
                    lowerRange += halfRangeDifference;
                }
            }

            return lowerRange;
        }
    }
}
