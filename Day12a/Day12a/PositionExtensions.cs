using System;
using System.Collections.Generic;
using System.Text;
using static Day12a.Position;

namespace Day12a
{
    public static class PositionExtensions
    {
        public static Position MoveNorth(this Position position, int amount)
        {
            position.North += amount;

            return position;
        }

        public static Position MoveEast(this Position position, int amount)
        {
            position.East += amount;

            return position;
        }

        public static Position MoveSouth(this Position position, int amount)
        {
            position.North -= amount;

            return position;
        }

        public static Position MoveWest(this Position position, int amount)
        {
            position.East -= amount;

            return position;
        }

        public static Position TurnLeft(this Position position, int amount)
        {
            int heading = (int)position.Facing - amount;

            while (heading < 0)
            {
                heading += 360;
            }

            while (heading > 359)
            {
                heading -= 360;
            }

            if (Enum.IsDefined(typeof(Direction), heading))
            {
                position.Facing = (Direction)heading;
            }

            return position;
        }

        public static Position TurnRight(this Position position, int amount)
        {
            int heading = (int)position.Facing + amount;

            while (heading < 0)
            {
                heading += 360;
            }

            while (heading > 359)
            {
                heading -= 360;
            }

            if (Enum.IsDefined(typeof(Direction), heading))
            {
                position.Facing = (Direction)heading;
            }

            return position;
        }

        public static Position MoveForward(this Position position, int amount)
        {
            position = position.Facing switch
            {
                Direction.North => position.MoveNorth(amount),
                Direction.South => position.MoveSouth(amount),
                Direction.East => position.MoveEast(amount),
                Direction.West => position.MoveWest(amount),
                _ => position
            };
        
            return position;
        }
    }
}
