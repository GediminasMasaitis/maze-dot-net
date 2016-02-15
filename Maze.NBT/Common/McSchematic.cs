using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using fNbt;

namespace Maze.NBT.Common
{
    class McSchematic
    {
        public McSchematic(short width, short length, short height, NbtCompression compression = NbtCompression.None)
        {
            Width = width;
            Length = length;
            Height = height;
            Blocks = new byte[width*length*height];
            Data = new byte[Blocks.Length];
            Compression = compression;
        }

        public short Width { get; }
        public short Length { get; }
        public short Height { get; }
        public byte[] Blocks { get; }
        public byte[] Data { get; }

        public void Set(short x, short z, short y, byte blockByte = 0, byte dataByte = 0)
        {
            if (x < 0 || x >= Width)
            {
                throw new ArgumentOutOfRangeException(nameof(x));
            }
            if (z < 0 || z >= Length)
            {
                throw new ArgumentOutOfRangeException(nameof(z));
            }
            if (y < 0 || y >= Height)
            {
                throw new ArgumentOutOfRangeException(nameof(y));
            }

            var index = (y*Length + z)*Width + x;
            Blocks[index] = blockByte;
            Data[index] = dataByte;
        }

        public NbtCompression Compression { get; set; }


        private NbtFile CreateNBTFile()
        {
            var nbtFile = new NbtFile();
            var schematic = nbtFile.RootTag;
            schematic.Name = "Schematic";
            schematic.Add(new NbtShort("Width", Width));
            schematic.Add(new NbtShort("Length", Length));
            schematic.Add(new NbtShort("Height", Height));
            schematic.Add(new NbtString("Materials", "Alpha"));
            schematic.Add(new NbtByteArray("Blocks", Blocks));
            schematic.Add(new NbtByteArray("Data", Data));
            schematic.Add(new NbtCompound("Entities"));
            schematic.Add(new NbtCompound("TileEntities"));
            return nbtFile;
        }

        public void SaveFile(string path)
        {
            var nbtFile = CreateNBTFile();
            nbtFile.SaveToFile(path, Compression);
        }

        public void SaveStream(Stream stream)
        {
            var nbtFile = CreateNBTFile();
            nbtFile.SaveToStream(stream, Compression);
        }
    }
}
