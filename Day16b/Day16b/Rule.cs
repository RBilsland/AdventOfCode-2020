using System;
using System.Collections.Generic;

namespace Day16b
{
    public class Rule
    {
        public string name { get; set; } = string.Empty;

        public List<Range> ranges { get; set; } = new List<Range>();

        public Rule(string input)
        {
            string[] parts = input.Split(new string[] { ": ", " or " }, StringSplitOptions.RemoveEmptyEntries);

            name = parts[0];

            for(int range = 1; range < parts.Length; range++)
            {
                ranges.Add(new Range(parts[range]));
            }
        }
    }
}
