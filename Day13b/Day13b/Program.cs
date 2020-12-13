using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day13b
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines(@"..\..\..\Input.txt");

            Console.WriteLine("AoC 2020 - Day 13b");

            string[] inputIds = input[1].Split(",", StringSplitOptions.RemoveEmptyEntries);

            List<int> busIds = new List<int>();
            List<int> timestampOffsets = new List<int>();

            for(int position = 0; position < inputIds.Length; position ++)
            {
                if (inputIds[position] != "x")
                {
                    int busId = int.Parse(inputIds[position]);
                    busIds.Add(busId);
                    timestampOffsets.Add(busId - position);
                }
            }

            Console.WriteLine("x is " + FindEarliestTimestamp(busIds.ToArray(), timestampOffsets.ToArray(), busIds.Count()));
        }


        // Following functions not mine but taken from
        // https://www.geeksforgeeks.org/chinese-remainder-theorem-set-2-implementation/

        // Returns modulo inverse of  
        // 'a' with respect to 'm'  
        // using extended Euclid Algorithm.  
        // Refer below post for details: 
        // https://www.geeksforgeeks.org/multiplicative-inverse-under-modulo-m/ 
        static long inv(long a, long m)
        {
            long m0 = m, t, q;
            long x0 = 0, x1 = 1;

            if (m == 1)
                return 0;

            // Apply extended  
            // Euclid Algorithm 
            while (a > 1)
            {
                // q is quotient 
                q = a / m;

                t = m;

                // m is remainder now,  
                // process same as  
                // euclid's algo 
                m = a % m; a = t;

                t = x0;

                x0 = x1 - q * x0;

                x1 = t;
            }

            // Make x1 positive 
            if (x1 < 0)
                x1 += m0;

            return x1;
        }

        // k is size of num[] and rem[]. 
        // Returns the earliest timestamp 
        // x such that: 
        // x % busIds[0] = timestampOffsets[0], 
        // x % busIds[1] = timestampOffsets[1], 
        // .................. 
        // x % busIds[k-2] = timestampOffsets[k-1] 
        // Assumption: Numbers in busIds[]  
        // are pairwise coprime (gcd  
        // for every pair is 1) 
        static long FindEarliestTimestamp(int[] busIds, int[] timestampOffsets, int k)
        {
            // Compute product 
            // of all bus ids 
            long prod = 1;
            for (int i = 0; i < k; i++)
                prod *= busIds[i];

            // Initialize result 
            long result = 0;

            // Apply above formula 
            for (int i = 0; i < k; i++)
            {
                long pp = prod / busIds[i];
                result += timestampOffsets[i] * inv(pp, busIds[i]) * pp;
            }

            return result % prod;
        }
    }
}
