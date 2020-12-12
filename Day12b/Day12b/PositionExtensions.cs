using System;
using System.Collections.Generic;
using System.Text;
using static Day12b.Position;

namespace Day12b
{
    public static class PositionExtensions
    {
        public static Position MoveNorth(this Position position, int amount)
        {
            position.Waypoint.North += amount;

            return position;
        }

        public static Position MoveEast(this Position position, int amount)
        {
            position.Waypoint.East += amount;

            return position;
        }

        public static Position MoveSouth(this Position position, int amount)
        {
            position.Waypoint.North -= amount;

            return position;
        }

        public static Position MoveWest(this Position position, int amount)
        {
            position.Waypoint.East -= amount;

            return position;
        }

        public static Position TurnLeft(this Position position, int amount)
        {
            while (amount < 0)
            {
                amount += 360;
            }

            while (amount > 359)
            {
                amount -= 360;
            }

            int waypointNorth;

            switch (amount)
            {
                case 90:
                    waypointNorth = position.Waypoint.North;
                    position.Waypoint.North = position.Waypoint.East;
                    position.Waypoint.East = waypointNorth * -1;
                    break;
                case 180:
                    position.Waypoint.North = position.Waypoint.North * -1;
                    position.Waypoint.East = position.Waypoint.East * -1;
                    break;
                case 270:
                    waypointNorth = position.Waypoint.North;
                    position.Waypoint.North = position.Waypoint.East * -1;
                    position.Waypoint.East = waypointNorth;
                    break;
            }

            return position;
        }

        public static Position TurnRight(this Position position, int amount)
        {
            while (amount < 0)
            {
                amount += 360;
            }

            while (amount > 359)
            {
                amount -= 360;
            }

            int waypointNorth;

            switch (amount)
            {
                case 90:
                    waypointNorth = position.Waypoint.North;
                    position.Waypoint.North = position.Waypoint.East * -1;
                    position.Waypoint.East = waypointNorth;
                    break;
                case 180:
                    position.Waypoint.North = position.Waypoint.North * -1;
                    position.Waypoint.East = position.Waypoint.East * -1;
                    break;
                case 270:
                    waypointNorth = position.Waypoint.North;
                    position.Waypoint.North = position.Waypoint.East;
                    position.Waypoint.East = waypointNorth * -1;
                    break;
            }

            return position;
        }

        public static Position MoveForward(this Position position, int amount)
        {
            position.North = position.North + (position.Waypoint.North * amount);
            position.East = position.East + (position.Waypoint.East * amount);
        
            return position;
        }
    }
}
