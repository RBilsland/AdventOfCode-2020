using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day09a
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines(@"..\..\..\Input.txt");
            long[] xmasData = Array.ConvertAll(input, long.Parse);

            int checkDepth = 25;

            bool numberFound = true;
            int numberToCheckPosition = checkDepth - 1;

            while (numberToCheckPosition < xmasData.Length && numberFound)
            {
                numberToCheckPosition++;

                numberFound = CheckNumber(new List<long>(xmasData).GetRange(numberToCheckPosition - checkDepth, checkDepth).ToArray(), xmasData[numberToCheckPosition]);
            }

            long invalidNumber = xmasData[numberToCheckPosition];

            (bool found, long lowestValue, long highestValue) = FindSum(xmasData, invalidNumber);

            Console.WriteLine("AoC 2020 - Day 09a");
            Console.WriteLine($"Invalid number: {invalidNumber}");
            Console.WriteLine($"Encryption weakness: {lowestValue + highestValue}");
        }

        static bool CheckNumber(long[] baseNumbers, long newNumber)
        {
            for(int firstPos = 0; firstPos < baseNumbers.Length; firstPos ++)
            {
                for(int secondPos = 0; secondPos < baseNumbers.Length; secondPos ++)
                {
                    if (firstPos != secondPos)
                    {
                        if (baseNumbers[firstPos] + baseNumbers[secondPos] == newNumber)
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        static (bool found, long lowestValue, long highestValue) FindSum(long[] baseNumbers, long newNumber)
        {
            for(int lowerPosition = 0; lowerPosition < baseNumbers.Length; lowerPosition ++)
            {
                long runningTotal = baseNumbers[lowerPosition];

                int upperPosition = lowerPosition + 1;

                while (upperPosition < baseNumbers.Length)
                {
                    runningTotal += baseNumbers[upperPosition];

                    if (runningTotal == newNumber)
                    {
                        List<long> subsetNumbers = new List<long>(baseNumbers).GetRange(lowerPosition, upperPosition - lowerPosition + 1);

                        return (found: true, lowestValue: subsetNumbers.Min(), highestValue: subsetNumbers.Max());
                    }

                    upperPosition++;
                }
            }

            return (found: false, lowestValue: 0, highestValue: 0);
        }
    }
}
