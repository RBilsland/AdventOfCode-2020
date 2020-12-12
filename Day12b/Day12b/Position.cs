using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Day12b;

namespace Day12b
{
    public class Position
    {
        public int North { get; set; } = 0;
        public int East { get; set; } = 0;

        public Waypoint Waypoint { get; set; } = new Waypoint();

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
