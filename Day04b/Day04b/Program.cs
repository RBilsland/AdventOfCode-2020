using System;
using System.Collections.Generic;
using System.IO;

namespace Day04b
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
                    validPassports += ValidatePassport(passportFields);

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
                validPassports += ValidatePassport(passportFields);
            }

            Console.WriteLine("AoC 2020 - Day 04b");
            Console.WriteLine($"Valid Passport Count: {validPassports}");
        }

        public static int ValidatePassport(Dictionary<string, string> passportFields)
        {
            return (ValidateBYR(passportFields) && 
                ValidateIYR(passportFields) &&
                ValidateEYR(passportFields) &&
                ValidateHGT(passportFields) &&
                ValidateHCL(passportFields) &&
                ValidateECL(passportFields) &&
                ValidatePID(passportFields)) ? 1 : 0;
        }

        public static bool ValidateBYR(Dictionary<string, string> passportFields)
        {
            bool byrValid = false;

            if (passportFields.ContainsKey("byr"))
            {
                int birthYear = 0;

                if (int.TryParse(passportFields["byr"], out birthYear))
                {
                    if (birthYear >= 1920 && birthYear <= 2002)
                    {
                        byrValid = true;
                    }
                }
            }

            return byrValid;
        }

        public static bool ValidateIYR(Dictionary<string, string> passportFields)
        {
            bool iyrValid = false;

            if (passportFields.ContainsKey("iyr"))
            {
                int issueYear = 0;

                if (int.TryParse(passportFields["iyr"], out issueYear))
                {
                    if (issueYear >= 2010 && issueYear <= 2020)
                    {
                        iyrValid = true;
                    }
                }
            }

            return iyrValid;
        }

        public static bool ValidateEYR(Dictionary<string, string> passportFields)
        {
            bool eyrValid = false;

            if (passportFields.ContainsKey("eyr"))
            {
                int expirationYear = 0;

                if (int.TryParse(passportFields["eyr"], out expirationYear))
                {
                    if (expirationYear >= 2020 && expirationYear <= 2030)
                    {
                        eyrValid = true;
                    }
                }
            }

            return eyrValid;
        }

        public static bool ValidateHGT(Dictionary<string, string> passportFields)
        {
            bool hgtValid = false;

            if (passportFields.ContainsKey("hgt"))
            {
                if (passportFields["hgt"].Length >= 4)
                {
                    int height = 0;

                    if (int.TryParse(passportFields["hgt"][0..^2], out height))
                    {
                        switch(passportFields["hgt"][^2..].ToLower())
                        {
                            case "cm":
                                if (height >= 150 && height <= 193)
                                {
                                    hgtValid = true;
                                }
                                break;
                            case "in":
                                if (height >= 59 && height <= 76)
                                {
                                    hgtValid = true;
                                }
                                break;
                        }
                    }
                }
            }

            return hgtValid;
        }

        public static bool ValidateHCL(Dictionary<string, string> passportFields)
        {
            bool hclValid = false;

            if (passportFields.ContainsKey("hcl"))
            {
                if (passportFields["hcl"].StartsWith("#") && passportFields["hcl"].Length == 7)
                {
                    int hexValue = 0;

                    if (int.TryParse(passportFields["hcl"][1..], System.Globalization.NumberStyles.HexNumber, null, out hexValue))
                    {
                        hclValid = true;
                    }
                }
            }

            return hclValid;
        }

        public static bool ValidateECL(Dictionary<string, string> passportFields)
        {
            bool eclValid = false;

            if (passportFields.ContainsKey("ecl"))
            {
                eclValid = passportFields["ecl"] switch
                {
                    string eyeColour when new List<string> { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" }.Contains(eyeColour) => true,
                    _ => false
                };
            }

            return eclValid;
        }

        public static bool ValidatePID(Dictionary<string, string> passportFields)
        {
            bool pidValid = false;

            if (passportFields.ContainsKey("pid"))
            {
                if (passportFields["pid"].Length == 9)
                {
                    int passportId = 0;

                    if (int.TryParse(passportFields["pid"], out passportId)) {
                        pidValid = true;
                    }
                }
            }

            return pidValid;
        }
    }
}
