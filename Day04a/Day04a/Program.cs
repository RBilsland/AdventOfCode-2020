using System;
using System.Collections.Generic;
using System.IO;

namespace Day04a
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] passports = File.ReadAllLines(@"..\..\..\Input.txt");

            int validPassports = 0;

            Dictionary<string, string> passportFields = new Dictionary<string, string>();

            foreach (string row in passports)
            {
                if (string.IsNullOrEmpty(row))
                {
                    validPassports += ValidCheck(passportFields);

                    passportFields = new Dictionary<string, string>();
                }
                else
                {
                    string[] parts = row.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                    foreach (string part in parts)
                    {
                        string[] keyValue = part.Split(':', StringSplitOptions.RemoveEmptyEntries);

                        passportFields.Add(keyValue[0], keyValue[1]);
                    }
                }
            }

            if (passportFields.Count > 0)
            {
                validPassports += ValidCheck(passportFields);
            }

            Console.WriteLine("AoC 2020 - Day 04a");
            Console.WriteLine($"Valid Passport Count: {validPassports}");
        }

        public static int ValidCheck(Dictionary<string, string> passportFields)
        {
            return passportFields.ContainsKey("byr") && 
                passportFields.ContainsKey("iyr") &&
                passportFields.ContainsKey("eyr") &&
                passportFields.ContainsKey("hgt") &&
                passportFields.ContainsKey("hcl") &&
                passportFields.ContainsKey("ecl") &&
                passportFields.ContainsKey("pid") ? 1 : 0;
        }
    }
}
