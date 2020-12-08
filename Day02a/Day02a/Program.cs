using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Day02a
{
    class Program
    {
        static void Main(string[] args)
        {
            int validPasswordCount = 0;

            string policyAndPassword = string.Empty;
            string[] parts;
            int characterCount = 0;

            using (StreamReader streamReader = new System.IO.StreamReader(@"..\..\..\Input.txt"))
            {
                while ((policyAndPassword = streamReader.ReadLine()) != null)
                {
                    parts = policyAndPassword.Split(new char[] { '-', ' ', ':' }, StringSplitOptions.RemoveEmptyEntries);

                    characterCount = Regex.Matches(parts[3], parts[2]).Count;

                    if (characterCount >= int.Parse(parts[0]) && characterCount <= int.Parse(parts[1])) {
                        validPasswordCount++;
                    }
                }
            }

            Console.WriteLine("AoC 2020 - Day 02a");
            Console.WriteLine($"Valid Passwords: {validPasswordCount}");

        }
    }
}
