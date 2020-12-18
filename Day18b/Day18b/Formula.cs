using System;
using System.Collections.Generic;
using System.Linq;

namespace Day18b
{
    public static class Formula
    {
        public static string Process(string input)
        {
            int currentPos = 0;

            while (currentPos < input.Length)
            {
                if (input[currentPos] == '(')
                {
                    currentPos++;

                    int startPos = currentPos;
                    int openBracketCount = 1;

                    while (openBracketCount > 0)
                    {
                        switch (input[currentPos])
                        {
                            case '(':
                                openBracketCount++;
                                break;
                            case ')':
                                openBracketCount--;
                                break;
                        }
                        currentPos++;
                    }
                    int originalLength = input.Length;

                    input = $"{input[..(startPos - 1)]}{Process(input[startPos..(currentPos - 1)])}{input[(currentPos)..]}";

                    currentPos -= (originalLength - input.Length);
                }
                else
                {
                    currentPos++;
                }
            }

            return Calculate(input);
        }

        public static string Calculate(string input)
        {
            List<string> parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();

            int position = 1;

            while (position < parts.Count() - 1)
            {
                if (parts[position] == "+")
                {
                    parts[position - 1] = (long.Parse(parts[position - 1]) + long.Parse(parts[position + 1])).ToString();

                    parts.RemoveRange(position, 2);
                }
                else
                {
                    position++;
                }
            }

            position = 1;

            while (position < parts.Count() - 1)
            {
                if (parts[position] == "*")
                {
                    parts[position - 1] = (long.Parse(parts[position - 1]) * long.Parse(parts[position + 1])).ToString();

                    parts.RemoveRange(position, 2);
                }
                else
                {
                    position++;
                }
            }

            return parts[0].ToString();
        }
    }
}
