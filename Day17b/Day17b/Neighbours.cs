using System.Collections.Generic;
using System.Linq;

namespace Day17b
{
    public static class Neighbours
    {
        public static List<Position> Adjustments => Enumerable
            .Range(-1, 3)
            .SelectMany(y => Enumerable
                .Range(-1, 3)
                .Select(x => new { x, y })
            )
            .SelectMany(plane => Enumerable
                .Range(-1, 3)
                .Select(z => new { plane.x, plane.y, z })
            )
            .SelectMany(cube => Enumerable
                .Range(-1, 3)
                .Select(w => new { cube.x, cube.y, cube.z, w })
            )
            .Where(position => !(position.x == 0 && position.y == 0 && position.z == 0 && position.w == 0))
            .Select(position => new Position() { X = position.x, Y = position.y, Z = position.z, W = position.w })
            .ToList();
    }
}
