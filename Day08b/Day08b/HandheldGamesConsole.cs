using System;
using System.Collections.Generic;
using System.Text;

namespace Day08a
{
    class HandheldGamesConsole
    {
        public string[] Memory { get; private set; }

        public HandheldGamesConsole()
        {
        }

        public (int accumulator, bool looping) Run(string[] program)
        {
            Memory = program;

            int accumulator = 0;
            int currentInstruction = 0;

            List<int> alreadyRunInstructions = new List<int>();

            while (currentInstruction < Memory.Length && !alreadyRunInstructions.Contains(currentInstruction))
            {
                alreadyRunInstructions.Add(currentInstruction);
                switch (Memory[currentInstruction][..3].ToLower())
                {
                    case "acc":
                        accumulator += int.Parse(Memory[currentInstruction][4..]);
                        currentInstruction++;
                        break;
                    case "jmp":
                        currentInstruction += int.Parse(Memory[currentInstruction][4..]);
                        break;
                    case "nop":
                        currentInstruction++;
                        break;
                }
            }

            return (accumulator, looping: currentInstruction < Memory.Length);
        }
    }
}
