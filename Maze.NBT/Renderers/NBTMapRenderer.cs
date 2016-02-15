﻿using System.Collections.Generic;
using Maze.Core.Cells;
using Maze.Core.Common;
using Maze.Core.Maps;
using Maze.Core.Renderers;
using Maze.Core.Results;
using Maze.NBT.Common;

namespace Maze.NBT.Renderers
{
    public class NBTMapRenderer : IMapRenderer
    {
        public NBTMapRenderer(IMap map, string path)
        {
            Map = map;
            Path = path;
            HeightOn2DMaps = 4;
            Blocks = new Dictionary<CellState, SchematicBlock>
            {
                { CellState.Empty, new SchematicBlock(0,0) },
                { CellState.Filled, new SchematicBlock(1,0) },
            };
            AddFloor = false;
            AddCeiling = false;
            FloorBlock = new SchematicBlock(1,0);
            CeilingBlock = new SchematicBlock(1,0);
        }

        public IMap Map { get; set; }
        public string Path { get; set; }
        public int HeightOn2DMaps { get; set; }
        public IDictionary<CellState, SchematicBlock> Blocks { get; }
        public bool AddFloor { get; set; }
        public bool AddCeiling { get; set; }
        public SchematicBlock FloorBlock { get; set; }
        public SchematicBlock CeilingBlock { get; set; }

        public void Render(MazeGenerationResults results)
        {
            if (results?.ResultsType == GenerationResultsType.GenerationCompleted)
            {
                var sch = MapToSchematic();
                sch.SaveFile(Path);
            }
        }

        private Schematic MapToSchematic()
        {
            var width = (short)Map.Size[0];
            var length = (short)Map.Size[1];
            var height = (short)(Map.Dimensions > 2 ? Map.Size[2] : HeightOn2DMaps);
            if (AddFloor)
            {
                height++;
            }
            var heightWithoutCeiling = height;
            if (AddCeiling)
            {
                height++;
            }
            var sch = new Schematic(width, length, height);

            for (short i = 0; i < width; i++)
            {
                for (short j = 0; j < length; j++)
                {
                    Point point = null;
                    SchematicBlock block = null;
                    var fill = false;
                    if (Map.Dimensions == 2)
                    {
                        point = new Point(i, j);
                        if (Map.CellExists(point))
                        {
                            fill = true;
                            var state = Map.GetCell(point).State;
                            block = Blocks[state];
                        }
                    }
                    short k = 0;
                    if (AddFloor)
                    {
                        sch.Set(i, j, k, FloorBlock.Block, FloorBlock.Data);
                        k++;
                    }

                    for (; k < heightWithoutCeiling; k++)
                    {
                        if (Map.Dimensions == 3)
                        {
                            point = new Point(i,j,k);
                            if (Map.CellExists(point))
                            {
                                fill = true;
                                var state = Map.GetCell(point).State;
                                block = Blocks[state];
                            }
                        }
                        if (fill)
                        {
                            sch.Set(i, j, k, block.Block, block.Data);
                        }
                    }

                    if (AddCeiling)
                    {
                        sch.Set(i, j, k, CeilingBlock.Block, CeilingBlock.Data);
                    }
                }
            }

            return sch;
        }

        public void Dispose()
        {
            
        }
    }
}