using System;
using System.IO;

namespace Day08a
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] program = File.ReadAllLines(@"..\..\..\Input.txt");

            HandheldGamesConsole handheldGamesConsole = new HandheldGamesConsole();

            string[] programCopy;

            int position = 0;

            bool looping = true;
            int accumulator = 0;

            while (position < program.Length && looping)
            {
                programCopy = (string[]) program.Clone();

                if (programCopy[position][..3].ToLower() != "acc")
                {
                    switch (programCopy[position][..3].ToLower())
                    {
                        case "jmp":
                            programCopy[position] = "nop" + programCopy[position][3..];
                            break;
                        case "nop":
                            programCopy[position] = "jmp" + programCopy[position][3..];
                            break;
                    }

                    (int runAccumulator, bool runLooping) = handheldGamesConsole.Run(programCopy);

                    if (!runLooping)
                    {
                        looping = false;
                        accumulator = runAccumulator;
                    }
                }

                position++;
            }

            Console.WriteLine("AoC 2020 - Day 08b");
            Console.WriteLine($"Accumulator: {accumulator}");
        }
    }
}
