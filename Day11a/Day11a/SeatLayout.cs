using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Day11a
{
    class SeatLayout
    {
        public string[] plan { get; set; }

        public SeatLayout() { }

        public int run()
        {
            int previousOccupiedSeatCount = -1;
            int currentOccupiedSeatCount = plan
                .Select(row => CountOccupiedSeats(row))
                .Sum();

            while (currentOccupiedSeatCount != previousOccupiedSeatCount)
            {
                step();

                previousOccupiedSeatCount = currentOccupiedSeatCount;

                currentOccupiedSeatCount = plan
                .Select(row => CountOccupiedSeats(row))
                .Sum();
            }

            return currentOccupiedSeatCount;
        }

        public void step()
        {
            string[] newPlan = new string[plan.Length];

            for (int rowPosition = 0; rowPosition < plan.Length; rowPosition ++)
            {
                string newSeatRow = string.Empty;

                for (int columnPosition = 0; columnPosition < plan[rowPosition].Length; columnPosition ++)
                {
                    int occupiedNeighboursSeats = CountOccupiedSeats(GetNeighbours(rowPosition, columnPosition));
                    char currentSeatStatus = GetSeatStatus(rowPosition, columnPosition);

                    switch (currentSeatStatus)
                    {
                        case 'L':
                            if (occupiedNeighboursSeats == 0)
                            {
                                newSeatRow += '#';
                            }
                            else
                            {
                                newSeatRow += currentSeatStatus;
                            }
                            break;

                        case '#':
                            if (occupiedNeighboursSeats >= 4)
                            {
                                newSeatRow += 'L';
                            }
                            else
                            {
                                newSeatRow += currentSeatStatus;
                            }
                            break;

                        default:
                            newSeatRow += currentSeatStatus;
                            break;
                    };
                }

                newPlan[rowPosition] = newSeatRow;
            }

            plan = newPlan;
        }

        private string GetNeighbours(int rowPosition, int columnPosition)
        {
            string neighbours = string.Empty;

            for (int rowDifference = -1; rowDifference < 2; rowDifference++)
            {
                for (int columnDifference = -1; columnDifference < 2; columnDifference++)
                {
                    if (columnDifference == 0 && rowDifference == 0)
                    {
                        neighbours += " ";
                    } 
                    else
                    {
                        neighbours += GetSeatStatus(rowPosition + rowDifference, columnPosition + columnDifference);
                    }
                }
            }

            return neighbours;
        }

        private char GetSeatStatus(int rowPosition, int columnPosition)
        {
            char seatStatus = '*';

            if (rowPosition >= 0 && rowPosition < plan.Length)
            {
                if (columnPosition >= 0 && columnPosition < plan[rowPosition].Length)
                {
                    seatStatus = plan[rowPosition][columnPosition];
                }
            }

            return seatStatus;
        }

        private int CountOccupiedSeats(string toCheck) => toCheck
            .GroupBy(position => position)
            .Where(position => position.Key == '#')
            .Select(position => position.Count())
            .Sum();
    }
}
