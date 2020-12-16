using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day16b
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines(@"..\..\..\Input.txt");

            int row = 0;

            int section = 1;
            List<Rule> rules = new List<Rule>();
            Ticket myTicket = new Ticket();
            List<Ticket> nearbyTickets = new List<Ticket>();

            while(row < input.Length)
            {
                if (string.IsNullOrEmpty(input[row]))
                {
                    row++;

                    if (row < input.Length)
                    {
                        switch (input[row].ToLower())
                        {
                            case "your ticket:":
                                section = 2;
                                break;
                            case "nearby tickets:":
                                section = 3;
                                break;
                        }
                    }
                } 
                else
                {
                    switch (section)
                    {
                        case 1:
                            rules.Add(new Rule(input[row]));
                            break;
                        case 2:
                            myTicket = new Ticket { numbers = input[row]
                                .Split(',', StringSplitOptions.RemoveEmptyEntries)
                                .Select(number => new Number { value = int.Parse(number) })
                                .ToArray()
                            };
                            break;
                        case 3:
                            nearbyTickets
                                .Add(new Ticket { numbers = input[row]
                                    .Split(',', StringSplitOptions.RemoveEmptyEntries)
                                    .Select(number => new Number { value = int.Parse(number) })
                                    .ToArray()
                                });
                            break;
                    }
                }

                row++;
            }

            List<Ticket> ticketsToBeRemoved = nearbyTickets
                .Where(ticket => ticket.InvalidNumbers(rules).Count > 0)
                .ToList();

            foreach (Ticket ticket in ticketsToBeRemoved)
            {
                nearbyTickets.Remove(ticket);
            }

            IEnumerable<string> baseRuleNames = rules.Select(rule => rule.name);
            Dictionary<int, List<string>> rulePositions = new Dictionary<int, List<string>>();

            for(int numberPos = 0; numberPos < myTicket.numbers.Length; numberPos++)
            {
                List<string> ruleNames = baseRuleNames.Select(name => name).ToList();

                foreach(Ticket ticket in nearbyTickets)
                {
                    foreach(Rule rule in ticket.numbers[numberPos].Validate(rules).invalidRules)
                    {
                        if (ruleNames.Contains(rule.name))
                        {
                            ruleNames.Remove(rule.name);
                        }
                    }
                }

                rulePositions.Add(numberPos, ruleNames);
            }

            List<string> uniques = rulePositions
                .Where(rulePosition => rulePosition.Value.Count() == 1)
                .SelectMany(rulePosition => rulePosition.Value)
                .ToList();

            List<string> alreadyRemoved = new List<string>();

            while (uniques.Count() > 0)
            {
                foreach(string unique in uniques)
                {
                    rulePositions
                        .Where(rulePosition => rulePosition.Value.Count() > 1 && rulePosition.Value.Contains(unique))
                        .ToList()
                        .ForEach(rulePosition => rulePosition.Value.Remove(unique));
                }

                alreadyRemoved.AddRange(uniques);

                uniques = rulePositions
                    .Where(rulePosition => rulePosition.Value.Count() == 1)
                    .SelectMany(rulePosition => rulePosition.Value)
                    .Where(rulePosition => !alreadyRemoved.Contains(rulePosition))
                    .ToList();
            }

            long departureValue = 1;

            foreach (KeyValuePair<int, List<string>> rulePosition in rulePositions.Where(rulePosition => rulePosition.Value.Where(ruleName => ruleName.ToLower().Contains("departure")).Count() > 0))
            {
                departureValue *= myTicket.numbers[rulePosition.Key].value;
            }

            Console.WriteLine("AoC 2020 - Day 16b");
            Console.WriteLine($"Departure Value: {departureValue}");

        }
    }
}
