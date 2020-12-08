using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace Day07a
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] rules = File.ReadAllLines(@"..\..\..\Input.txt");

            Dictionary<string, List<InnerBag>> outerBags = new Dictionary<string, List<InnerBag>>();

            List<string> shinyGoldHolders = new List<string>();

            foreach(string rule in rules)
            {
                string[] ruleParts = rule.Split(" bags contain ", StringSplitOptions.RemoveEmptyEntries);

                List<InnerBag> innerBags = new List<InnerBag>();

                string[] innerBagsParts = ruleParts[1].Split(new[] { " bag, ", " bags, ", " bag.", " bags." }, StringSplitOptions.RemoveEmptyEntries);

                foreach (string innerBag in innerBagsParts)
                {
                    string[] innerBagParts = innerBag.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                    if (innerBagParts[0] != "no")
                    {
                        innerBags.Add(new InnerBag() { Number = int.Parse(innerBagParts[0]), Colour = innerBagParts[1] + " " + innerBagParts[2] });
                    }
                }

                outerBags.Add(ruleParts[0], innerBags);
            }

            int shinyGoldCount = 0;

            foreach(KeyValuePair<string, List<InnerBag>> outerBag in outerBags)
            {
                if (FoundShinyGold(outerBags, outerBag.Key))
                {
                    shinyGoldCount++;
                }
            }

            Console.WriteLine("AoC 2020 - Day 07a");
            Console.WriteLine($"Coloured Bags Containg A Shing Gold Bag: {shinyGoldCount}");
        }

        static bool FoundShinyGold(Dictionary<string, List<InnerBag>> outerBags, string outerBagColour)
        {
                if (outerBags.ContainsKey(outerBagColour))
            {
                if (outerBags[outerBagColour]
                    .Where(innerBag => innerBag.Colour.ToLower() == "shiny gold")
                    .Count() > 0)
                {
                    return true;
                }
                else
                {
                    bool foundShinyGold = false;

                    foreach (InnerBag innerBag in outerBags[outerBagColour])
                    {
                        if (FoundShinyGold(outerBags, innerBag.Colour))
                        {
                            foundShinyGold = true;
                        }
                    }
                    return foundShinyGold;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
