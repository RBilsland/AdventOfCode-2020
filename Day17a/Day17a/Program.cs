using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day17a
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines(@"..\..\..\Input.txt");

            Console.WriteLine("AoC 2020 - Day 17a");
            Console.WriteLine("Initialising Play Area");

            List<Position> playArea = Enumerable
                .Range(-10, 21)
                .SelectMany(y => Enumerable
                    .Range(-10, 21)
                    .Select(x => new { x, y })
                )
                .SelectMany(plane => Enumerable
                    .Range(-10, 21)
                    .Select(z => new Position() { X = plane.x, Y = plane.y, Z = z })
                )
                .ToList();

            List<Cube> cubes = new List<Cube>();

            playArea.ForEach(area => cubes.Add(new Cube { Position = new Position() { X = area.X, Y = area.Y, Z = area.Z }, State = false, Cubes = cubes }));

            Console.WriteLine("Loading Initial State");

            int y = -3;

            foreach(string row in input)
            {
                int x = -3;

                foreach(char position in row.ToCharArray())
                {
                    if (position == '#')
                    {
                        cubes
                            .Where(cube => cube.Position.X == x && cube.Position.Y == y && cube.Position.Z == 0)
                            .ToList()
                            .ForEach(cube => cube.State = true);
                    }

                    x++;
                }

                y++;
            }


            foreach (int cycle in Enumerable.Range(1, 6))
            {
                Console.Write($"\rCycle : {cycle}");

                cubes.ForEach(cube => cube.CalculateNextState());
                cubes.ForEach(cube => cube.UpdateState());
            }

            Console.WriteLine();

            Console.WriteLine($"Active Cubes: {cubes.CountActive(playArea)}");
        }
    }
}
