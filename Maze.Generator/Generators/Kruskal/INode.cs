namespace Maze.Generator.Generators.Kruskal
{
    public interface INode<TNode>
        where TNode : INode<TNode>
    {
        TNode Parent { get; set; }
    }
}