﻿using System;

namespace Day16b
{
    public class Range
    {
        public int low { get; set; } = int.MinValue;
        public int high { get; set; } = int.MaxValue;

        public Range(string input)
        {
            string[] parts = input.Split('-', StringSplitOptions.RemoveEmptyEntries);

            low = int.Parse(parts[0]);
            high = int.Parse(parts[1]);
        }
    }
}
