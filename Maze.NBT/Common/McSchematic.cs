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
        public McSchematic(short width, short length, short height, byte[] data, NbtCompression compression = NbtCompression.None)
        {
            Width = width;
            Length = length;
            Height = height;
            Compression = compression;

            NbtFile = new NbtFile();
            Schematic = NbtFile.RootTag;
            Schematic.Name = "Schematic";
            Schematic.Add(new NbtShort("Width", width));
            Schematic.Add(new NbtShort("Length", length));
            Schematic.Add(new NbtShort("Height", height));
            Schematic.Add(new NbtString("Materials", "Alpha"));
            Schematic.Add(new NbtByteArray("Blocks", data));
            Schematic.Add(new NbtByteArray("Data", new byte[data.Length]));
            Schematic.Add(new NbtCompound("Entities"));
            Schematic.Add(new NbtCompound("TileEntities"));
        }

        public short Width { get; }
        public short Length { get; }
        public short Height { get; }
        public NbtCompression Compression { get; set; }

        private NbtFile NbtFile { get; }
        private NbtCompound Schematic { get; }

        public void SaveFile(string path)
        {
            NbtFile.SaveToFile(path, Compression);
        }

        public void SaveStream(Stream stream)
        {
            NbtFile.SaveToStream(stream, Compression);
        }
    }
}
