using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day17b
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines(@"..\..\..\Input.txt");

            Console.WriteLine("AoC 2020 - Day 17b");
            Console.WriteLine("Loading Initial State");

            List<HyperCube> hyperCubes = new List<HyperCube>();

            int y = -3;

            foreach (string row in input)
            {
                int x = -3;

                foreach (char position in row.ToCharArray())
                {
                    if (position == '#')
                    {
                        hyperCubes.Add(new HyperCube() { Position = new Position() { X = x, Y = y, Z = 0, W = 0 }, State = true, HyperCubes = hyperCubes });
                    }

                    x++;
                }

                y++;
            }

            List<Position> playArea = new List<Position>();

            foreach (int cycle in Enumerable.Range(1, 6))
            {
                Console.Write($"\r                               \rCycle : {cycle} - Adjusting Play Area");

                var (minX, maxX, minY, maxY, minZ, maxZ, minW, maxW) = hyperCubes.GetActiveBounds();

                    playArea = Enumerable
                    .Range(minX - 1, (maxX + 3) - minX)
                    .SelectMany(x => Enumerable
                        .Range(minY - 1, (maxY + 3) - minY)
                        .Select(y => new { x, y })
                    )
                    .SelectMany(plane => Enumerable
                        .Range(minZ - 1, (maxZ + 3) - minZ)
                        .Select(z => new { plane.x, plane.y, z })
                    )
                    .SelectMany(cube => Enumerable
                        .Range(minW - 1, (maxW + 3) - minW)
                        .Select(w => new Position() { X = cube.x, Y = cube.y, Z = cube.z, W = w })
                    )
                    .ToList();

                playArea
                    .Where(area => !hyperCubes
                        .Any(hyperCubes => 
                            hyperCubes.Position.X == area.X && 
                            hyperCubes.Position.Y == area.Y && 
                            hyperCubes.Position.Z == area.Z && 
                            hyperCubes.Position.W == area.W))
                .ToList()
                .ForEach(area => hyperCubes.Add(new HyperCube() { Position = new Position() { X = area.X, Y = area.Y, Z = area.Z, W = area.W }, State = false, HyperCubes = hyperCubes }));

                hyperCubes
                    .Where(hyperCubes => !playArea
                        .Any(area => 
                            area.X == hyperCubes.Position.X && 
                            area.Y == hyperCubes.Position.Y && 
                            area.Z == hyperCubes.Position.Z && 
                            area.W == hyperCubes.Position.W))
                    .ToList()
                    .ForEach(hCubes => hyperCubes.Remove(hCubes));

                Console.Write($"\r                               \rCycle : {cycle} - Updating State");

                hyperCubes.ForEach(cube => cube.CalculateNextState());
                hyperCubes.ForEach(cube => cube.UpdateState());
            }

            Console.WriteLine("Finalising");
            Console.WriteLine($"Active Cubes: {hyperCubes.CountActive()}");
        }
    }
}
