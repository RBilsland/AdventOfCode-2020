using System;
using System.Collections.Generic;
using System.Text;

namespace Day15b
{
    public static class DictionaryExtensions
    {
        public static Dictionary<int, NumberSpoken> UpdateNumberSpoken(this Dictionary<int, NumberSpoken> input, int numberSpoken, int turn)
        {
            if (input.ContainsKey(numberSpoken))
            {
                input[numberSpoken].Difference = turn - input[numberSpoken].LastSpoken;
                input[numberSpoken].LastSpoken = turn;
                input[numberSpoken].Occurances++;
            }
            else
            {
                input.Add(numberSpoken, new NumberSpoken
                { 
                    Difference = 0,
                    LastSpoken = turn, 
                    Occurances = 1 
                });
            }

            return input;
        }
    }
}
