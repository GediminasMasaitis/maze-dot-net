namespace Maze.Core.Common
{
    public interface IGenericFactory<out TObject>
    {
        TObject Create();
    }
}