using System;

namespace Day14b
{
    public static class StringExtensions
    {
        public static long ReplaceXs(this string input, string binaryReplacement)
        {
            char[] baseMask = input.ToLower().ToCharArray();

            int binaryPosition = 0;

            for(int basePosition = 0; basePosition < baseMask.Length; basePosition++)
            {
                if (baseMask[basePosition] == 'x')
                {
                    if (binaryPosition < binaryReplacement.Length)
                    {
                        baseMask[basePosition] = binaryReplacement[binaryPosition];

                        binaryPosition++;
                    }
                }
            }

            return Convert.ToInt64(new string(baseMask), 2);
        }
    }
}
