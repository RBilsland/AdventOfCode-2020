using System.Collections.Generic;
using System.Linq;

namespace Day17a
{
    public static class ListExtensions
    {
        public static int CountActive(this List<Cube> cubes, List<Position> cubesToCount, int baseX = 0, int baseY = 0, int baseZ = 0) =>
            (cubesToCount == null ?
                cubes :
                cubes
                    .Join(
                        cubesToCount,
                        cube => (cube.Position.X, cube.Position.Y, cube.Position.Z),
                        cubeToCount => (baseX + cubeToCount.X, baseY + cubeToCount.Y, baseZ + cubeToCount.Z),
                        (cube, cubeToCount) => cube))
            .Select(cube => cube.State == true ? 1 : 0)
            .Sum();
    }
}
