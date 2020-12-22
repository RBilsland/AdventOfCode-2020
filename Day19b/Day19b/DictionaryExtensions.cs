using System;
using System.Collections.Generic;
using System.Linq;

namespace Day19b
{
    public static class DictionaryExtensions
    {
        public static List<string> ReturnRuleStrings(this Dictionary<int, string> rules, int ruleToCheck)
        {
            List<string> returnRules = new List<string>();
            List<string> partRules = new List<string>(){ string.Empty };

            string[] parts = rules[ruleToCheck].Split(" ", StringSplitOptions.RemoveEmptyEntries);

            foreach(string part in parts)
            {
                if (part.StartsWith("\"") && part.EndsWith("\""))
                {
                    partRules = partRules
                        .SelectMany(subRule => new List<string>() { part[1..^1].ToBin() }, (baseRule, subRule) => baseRule + subRule)
                        .ToList();
                }

                if (part == "|")
                {
                    returnRules
                        .AddRange(partRules);

                    partRules = new List<string>() { string.Empty };
                }

                int ruleNumber = 0;

                if (int.TryParse(part, out ruleNumber))
                {
                    partRules = partRules
                        .SelectMany(subRule => rules.ReturnRuleStrings(ruleNumber), (baseRule, subRule) => baseRule + subRule)
                        .ToList();
                }
            }

            returnRules
                .AddRange(partRules);

            return returnRules;
        }
    }
}
