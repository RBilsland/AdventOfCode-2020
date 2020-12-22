using System;

namespace Day19b
{
    public static class StringExtensions
    {
        public static string ToBin(this string input) => input.Replace("a", "0").Replace("b", "1");
        public static int ToInt(this string input) => Convert.ToInt32(input, 2);
    }
}
