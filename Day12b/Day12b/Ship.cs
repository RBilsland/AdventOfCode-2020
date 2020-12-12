using System;
using System.Collections.Generic;
using System.Text;

namespace Day12b
{
    public class Ship
    {
        public Position Position { get; set; } = new Position();

        public Ship()
        {
        }

        public void Move(string command)
        {
            string instruction = command[..1].ToLower();
            int amount = int.Parse(command[1..]);

            Position = instruction switch
            {
                "n" => Position.MoveNorth(amount),
                "s" => Position.MoveSouth(amount),
                "e" => Position.MoveEast(amount),
                "w" => Position.MoveWest(amount),
                "l" => Position.TurnLeft(amount),
                "r" => Position.TurnRight(amount),
                "f" => Position.MoveForward(amount),
                _ => Position
            };
        }
    }
}
