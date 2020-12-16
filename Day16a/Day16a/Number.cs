using System;
using System.Collections.Generic;
using System.Text;

namespace Day16a
{
    public class Number
    {
        public int value { get; set; } = 0;

        public (List<Rule> validRules, List<Rule> invalidRules) Validate(List<Rule> rules)
        {
            List<Rule> validRules = new List<Rule>();
            List<Rule> invalidRules = new List<Rule>();

            foreach(Rule rule in rules)
            {
                bool ruleValid = false;

                foreach(Range range in rule.ranges)
                {
                    if (value >= range.low && value <= range.high)
                    {
                        ruleValid = true;
                    }
                }

                if (ruleValid)
                {
                    validRules.Add(rule);
                } 
                else
                {
                    invalidRules.Add(rule);
                }
            }

            return (validRules: validRules, invalidRules: invalidRules);
        }
    }
}
