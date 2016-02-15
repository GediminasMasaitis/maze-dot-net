namespace Maze.NBT.Common
{
    public class SchematicBlock
    {
        public SchematicBlock(byte block, byte data)
        {
            Block = block;
            Data = data;
        }

        public byte Block { get; set; }
        public byte Data { get; set; }
    }
}