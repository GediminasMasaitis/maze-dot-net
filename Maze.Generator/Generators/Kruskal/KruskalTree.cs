using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze.Generator.Generators.Kruskal
{
    public class KruskalTree
    {

        public KruskalTree(int width, int height)
        {
            InnerMatrix = new KruskalNode[width, height];
            for (var i = 0; i < width; i++)
            {
                for (var j = 0; j < height; j++)
                {
                    InnerMatrix[i, j] = new KruskalNode();
                }
            }
        }

        private class KruskalNode
        {
            public KruskalNode Parent;

            public KruskalNode()
            {
                Parent = null;
            }
        }

        private KruskalNode[,] InnerMatrix { get; }

        private KruskalNode FindRoot(int x, int y)
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
            return FindRoot(aX, aY) == FindRoot(bX, bY);
        }

        public bool Connect(int aX, int aY, int bX, int bY)
        {
            var rootA = FindRoot(aX, aY);
            var rootB = FindRoot(bX, bY);
            if (rootA == rootB)
                return false;
            rootA.Parent = rootB;
            return true;
        }
    }
}
