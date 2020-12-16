using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day16a
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
                                .ToList()
                            };
                            break;
                        case 3:
                            nearbyTickets
                                .Add(new Ticket { numbers = input[row]
                                    .Split(',', StringSplitOptions.RemoveEmptyEntries)
                                    .Select(number => new Number { value = int.Parse(number) })
                                    .ToList()
                                });
                            break;
                    }
                }

                row++;
            }

            Console.WriteLine("AoC 2020 - Day 16a");
            Console.WriteLine($"Ticket Scanning Error Rate: {nearbyTickets.SelectMany(ticket => ticket.InvalidNumbers(rules)).Select(number => number.value).Sum()}");
        }
    }
}
