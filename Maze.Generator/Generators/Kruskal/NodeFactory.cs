using Maze.Generator.Common;

namespace Maze.Generator.Generators.Kruskal
{
    public class NodeFactory : IGenericFactory<Node>
    {
        public Node Create()
        {
            return new Node();
        }
    }
}