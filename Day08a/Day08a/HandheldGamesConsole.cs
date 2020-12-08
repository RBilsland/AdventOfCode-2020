using System;
using System.Collections.Generic;
using System.Text;

namespace Day08a
{
    class HandheldGamesConsole
    {
        public string[] memory { get; private set; }

        public int accumulator { get; set; } = 0;
        public int currentInstruction { get; set; } = 0;

        public HandheldGamesConsole(string[] program)
        {
            accumulator = 0;
            currentInstruction = 0;

            memory = program;
        }

        public void Run()
        {
            List<int> alreadyRunInstructions = new List<int>();

            while (!alreadyRunInstructions.Contains(currentInstruction))
            {
                alreadyRunInstructions.Add(currentInstruction);
                switch (memory[currentInstruction][..3].ToLower())
                {
                    case "acc":
                        accumulator += int.Parse(memory[currentInstruction][4..]);
                        currentInstruction++;
                        break;
                    case "jmp":
                        currentInstruction += int.Parse(memory[currentInstruction][4..]);
                        break;
                    case "nop":
                        currentInstruction++;
                        break;
                }
            }
        }
    }
}
