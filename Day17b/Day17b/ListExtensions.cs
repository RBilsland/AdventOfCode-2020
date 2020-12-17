using System.Collections.Generic;
using System.Linq;

namespace Day17b
{
    public static class ListExtensions
    {
        public static int CountActive(this List<HyperCube> cubes, List<Position> cubesToCount = null, int baseX = 0, int baseY = 0, int baseZ = 0, int baseW = 0) =>
            (cubesToCount == null ?
                cubes :
                cubes
                    .Join(
                        cubesToCount,
                        cube => (cube.Position.X, cube.Position.Y, cube.Position.Z, cube.Position.W),
                        cubeToCount => (baseX + cubeToCount.X, baseY + cubeToCount.Y, baseZ + cubeToCount.Z, baseW + cubeToCount.W),
                        (cube, cubeToCount) => cube))
            .Select(cube => cube.State == true ? 1 : 0)
            .Sum();

        public static (int minX, int maxX, int minY, int maxY, int minZ, int maxZ, int minW, int maxW) GetCoordinateMinMax(this List<HyperCube> cubes) =>
            (
                minX: cubes.Select(cube => cube.Position.X).Min(),
                maxX: cubes.Select(cube => cube.Position.X).Max(),
                minY: cubes.Select(cube => cube.Position.Y).Min(),
                maxY: cubes.Select(cube => cube.Position.Y).Max(),
                minZ: cubes.Select(cube => cube.Position.Z).Min(),
                maxZ: cubes.Select(cube => cube.Position.Z).Max(),
                minW: cubes.Select(cube => cube.Position.W).Min(),
                maxW: cubes.Select(cube => cube.Position.W).Max()
            );

        public static (int minX, int maxX, int minY, int maxY, int minZ, int maxZ, int minW, int maxW) GetBounds(this List<HyperCube> cubes) => 
            cubes
                .GetCoordinateMinMax();

        public static (int minX, int maxX, int minY, int maxY, int minZ, int maxZ, int minW, int maxW) GetActiveBounds(this List<HyperCube> cubes) => 
            cubes
                .Where(cube => cube.State == true)
                .ToList()
                .GetCoordinateMinMax();
    }
}
