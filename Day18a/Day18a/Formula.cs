using System;

namespace Day18a
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
            string[] parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            long accumulator = 0;
            string lastOperator = string.Empty;

            foreach(string part in parts)
            {
                long number = 0;

                if (long.TryParse(part, out number))
                {
                    if (lastOperator == string.Empty)
                    {
                        accumulator = number;
                    }
                    else
                    {
                        switch (lastOperator)
                        {
                            case "+":
                                accumulator += number;
                                break;
                            case "*":
                                accumulator *= number;
                                break;
                        }
                    }
                }
                else
                {
                    lastOperator = part;
                }
            }

            return accumulator.ToString();
        }
    }
}
