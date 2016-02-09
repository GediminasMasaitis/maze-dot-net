namespace Maze.Generator.Common
{
    public interface IGenericFactory<out TObject>
    {
        TObject Create();
    }
}