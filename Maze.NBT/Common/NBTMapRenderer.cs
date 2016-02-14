using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using fNbt;
using Maze.Core.Cells;
using Maze.Core.Common;
using Maze.Core.Maps;
using Maze.Core.Renderers;
using Maze.Core.Results;

namespace Maze.NBT.Common
{

    public class NBTMapRenderer : IMapRenderer
    {
        public NBTMapRenderer(IMap map, string path)
        {
            Map = map;
            Path = path;
            HeightOn2DMaps = 4;
        }

        public IMap Map { get; set; }
        public string Path { get; set; }
        public int HeightOn2DMaps { get; set; }

        public void Render(MazeGenerationResults results)
        {
            if (results?.ResultsType == GenerationResultsType.GenerationCompleted)
            {
                RenderMap();
            }
        }

        public void RenderMap()
        {
            var width = (short)Map.Size[0];
            var length = (short)Map.Size[1];
            var height = (short)(Map.Dimensions > 2 ? Map.Size[2] : HeightOn2DMaps);

            var data = new byte[width*length*height];

            for (var i = 0; i < width; i++)
            {
                for (var j = 0; j < length; j++)
                {
                    Point point = null;
                    var fill = false;
                    if (Map.Dimensions == 2)
                    {
                        point = new Point(i, j);
                        fill = Map.CellExists(point) && Map.GetCell(point).State == CellState.Filled;
                    }

                    for (var k = 0; k < height; k++)
                    {
                        if (Map.Dimensions == 3)
                        {
                            point = new Point(i,j,k);
                            fill = Map.CellExists(point) && Map.GetCell(point).State == CellState.Filled;
                        }
                        if (fill)
                        {
                            data[k*width*length + j*width + i] = 1;
                        }
                    }
                }
            }

            var sch = new McSchematic(width, length, height, data);
            sch.SaveFile(Path);
        }

        public void Dispose()
        {
            
        }
    }
}
