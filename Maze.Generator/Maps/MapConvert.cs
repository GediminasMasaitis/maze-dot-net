using System;

namespace Maze.Generator.Maps
{
    public static class MapConvert
    {
        public static IMap ToInfiniteMap(IMap map)
        {
            if (map.Infinite)
            {
                return map;
            }

            throw new NotImplementedException();
        }
    }
}