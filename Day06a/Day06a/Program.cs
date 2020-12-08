using System;
using System.Collections.Generic;
using System.IO;

namespace Day06a
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] customDeclorationForms = File.ReadAllLines(@"..\..\..\Input.txt");

            List<char> groupYesAnswers = new List<char>();

            int runningGroupYesCount = 0;

            foreach(string row in customDeclorationForms)
            {
                if (string.IsNullOrEmpty(row))
                {
                    runningGroupYesCount += groupYesAnswers.Count;

                    groupYesAnswers = new List<char>();
                }
                else
                {
                    foreach(char yesAnswer in row)
                    {
                        if (!groupYesAnswers.Contains(yesAnswer))
                        {
                            groupYesAnswers.Add(yesAnswer);
                        }
                    }
                }
            }

            runningGroupYesCount += groupYesAnswers.Count;

            Console.WriteLine("AoC 2020 - Day 06a");
            Console.WriteLine($"Running Group Yes Count: {runningGroupYesCount}");
        }
    }
}
