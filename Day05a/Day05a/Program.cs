using System;
using System.IO;

namespace Day05a
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] seatCodes = File.ReadAllLines(@"..\..\..\Input.txt");

            int highestSeatId = 0;

            foreach(string seatCode in seatCodes)
            {
                (int row, int column) = LookupPosition(seatCode);

                int seatId = (row * 8) + column;

                if (seatId > highestSeatId)
                {
                    highestSeatId = seatId;
                }
            }

            Console.WriteLine("AoC 2020 - Day 05a");
            Console.WriteLine($"Highest Seat Id: {highestSeatId}");
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
