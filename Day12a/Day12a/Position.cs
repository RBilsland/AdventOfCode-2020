using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Day12a;

namespace Day12a
{
    public class Position
    {
        public enum Direction
        {
            North = 0,
            East = 90,
            South = 180,
            West = 270
        }

        public Direction Facing { get; set; } = Direction.East;
        public int North { get; set; } = 0;
        public int East { get; set; } = 0;

        public int ManhattanDistance 
        { 
            get
            {
                return Math.Abs(East) + Math.Abs(North);
            }
        }

        public Position()
        {
        }
    }
}
