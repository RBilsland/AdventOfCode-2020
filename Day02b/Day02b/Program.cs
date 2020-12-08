using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Day02b
{
    class Program
    {
        static void Main(string[] args)
        {
            int validPasswordCount = 0;

            string policyAndPassword = string.Empty;
            string[] parts;

            using (StreamReader streamReader = new System.IO.StreamReader(@"..\..\..\Input.txt"))
            {
                while ((policyAndPassword = streamReader.ReadLine()) != null)
                {
                    parts = policyAndPassword.Split(new char[] { '-', ' ', ':' }, StringSplitOptions.RemoveEmptyEntries);

                    string firstCharacter = parts[3][int.Parse(parts[0]) - 1].ToString();
                    string secondCharacter = parts[3][int.Parse(parts[1]) - 1].ToString();

                    validPasswordCount = validPasswordCount + (firstCharacter == parts[2] ? secondCharacter == parts[2] ? 0 : 1 : secondCharacter == parts[2] ? 1 : 0); 
                }
            }

            Console.WriteLine("AoC 2020 - Day 02b");
            Console.WriteLine($"Valid Passwords: {validPasswordCount}");

        }
    }
}
