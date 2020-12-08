using Microsoft.VisualBasic;
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

            int runningGroupYesCount = 0;

            List<char> groupYesAnswers = new List<char>();

            bool firstRowOfGroup = true;

            foreach(string row in customDeclorationForms)
            {
                if (string.IsNullOrEmpty(row))
                {
                    runningGroupYesCount += groupYesAnswers.Count;

                    groupYesAnswers = new List<char>();

                    firstRowOfGroup = true;
                }
                else
                {
                    List<char> rowYesAnswers = new List<char>();

                    if (firstRowOfGroup)
                    {
                        firstRowOfGroup = false;

                        foreach (char yesAnswer in row)
                        {
                            if (!groupYesAnswers.Contains(yesAnswer))
                            {
                                groupYesAnswers.Add(yesAnswer);
                            }
                        }
                    }
                    else
                    {
                        List<char> rowNoAnswers = new List<char>() { 'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z'};
 
                        foreach(char yesAnswer in row)
                        {
                            if (rowNoAnswers.Contains(yesAnswer))
                            {
                                rowNoAnswers.Remove(yesAnswer);
                            }
                        }

                        foreach(char noAnswer in rowNoAnswers)
                        {
                            if (groupYesAnswers.Contains(noAnswer))
                            {
                                groupYesAnswers.Remove(noAnswer);
                            }
                        }
                    }
                }
            }

            runningGroupYesCount += groupYesAnswers.Count;

            Console.WriteLine("AoC 2020 - Day 06b");
            Console.WriteLine($"Running Group Yes Count: {runningGroupYesCount}");
        }
    }
}
