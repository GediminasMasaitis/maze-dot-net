using Maze.Generator.Common;

namespace Maze.Generator.Generators.Kruskal
{
    public class KruskalTree
    {

        public KruskalTree(int width, int height)
        {
            InnerMatrix = new Node[width, height];
            for (var i = 0; i < width; i++)
            {
                for (var j = 0; j < height; j++)
                {
                    InnerMatrix[i, j] = new Node();
                }
            }
        }


        private Node[,] InnerMatrix { get; }

        private Node FindRoot(int x, int y)
        {
            var origNode = InnerMatrix[x, y];
            if (origNode.Parent == null)
            {
                return origNode;
            }

            var node = origNode;
            while (node.Parent != null)
            {
                node = node.Parent;
            }
            origNode.Parent = node;
            return node;
        }

        public bool AreConnected(int aX, int aY, int bX, int bY)
        {
            var rootA = FindRoot(aX, aY);
            var rootB = FindRoot(bX, bY);
            return rootA.Equals(rootB);
        }

        public bool Connect(int aX, int aY, int bX, int bY)
        {
            var rootA = FindRoot(aX, aY);
            var rootB = FindRoot(bX, bY);
            if (rootA.Equals(rootB))
            {
                return false;
            }
            rootA.Parent = rootB;
            return true;
        }
    }
}
