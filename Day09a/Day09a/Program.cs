﻿using System;
using System.Collections.Generic;
using System.IO;

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

            Console.WriteLine("AoC 2020 - Day 09a");
            Console.WriteLine($"Invalid number: {invalidNumber}");
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
    }
}
