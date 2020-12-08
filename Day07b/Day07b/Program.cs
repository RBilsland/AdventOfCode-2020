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

            Console.WriteLine("AoC 2020 - Day 07b");
            Console.WriteLine($"Shiny Gold Bag Count: {ShinyGoldContains(outerBags, "shiny gold") - 1}");
        }

        static int ShinyGoldContains(Dictionary<string, List<InnerBag>> outerBags, string outerBagColour)
        {
            if (outerBags[outerBagColour].Count() == 0)
            {
                return 1;
            }
            else
            {
                int innerBags = 0;

                foreach(InnerBag innerBag in outerBags[outerBagColour])
                {
                    innerBags += ShinyGoldContains(outerBags, innerBag.Colour) * innerBag.Number;
                }

                return innerBags + 1;
            }
        }
    }
}
