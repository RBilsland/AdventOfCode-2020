using System.Collections.Generic;
using System.Linq;

namespace Day16b
{
    public class Ticket
    {
        public Number[] numbers { get; set; }

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
