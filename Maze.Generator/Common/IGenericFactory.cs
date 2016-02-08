namespace Maze.Generator.Generators.Kruskal
{
    public interface IGenericFactory<out TObject>
    {
        TObject Create();
    }
}