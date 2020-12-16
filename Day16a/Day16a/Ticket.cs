using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Day16a
{
    public class Ticket
    {
        public List<Number> numbers { get; set; } = new List<Number>();

        public List<Number> ValidNumbers(List<Rule> rules) =>
            numbers
            .Where(number => number.Validate(rules).validRules.Count > 0)
            .Select(number => number)
            .ToList();

        public List<Number> InvalidNumbers(List<Rule> rules) =>
            numbers
            .Where(number => number.Validate(rules).validRules.Count == 0)
            .Select(number => number)
            .ToList();
    }
}
