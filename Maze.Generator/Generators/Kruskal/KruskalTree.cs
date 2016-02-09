using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maze.Generator.Common;

namespace Maze.Generator.Generators.Kruskal
{
    public class KruskalTree<TNode>
        where TNode : INode<TNode>
    {

        public KruskalTree(int width, int height, IGenericFactory<TNode> nodeFactory)
        {
            NodeFactory = nodeFactory;
            InnerMatrix = new TNode[width, height];
            for (var i = 0; i < width; i++)
            {
                for (var j = 0; j < height; j++)
                {
                    InnerMatrix[i, j] = NodeFactory.Create();
                }
            }
        }

        private IGenericFactory<TNode> NodeFactory { get; }

        private TNode[,] InnerMatrix { get; }

        private TNode FindRoot(int x, int y)
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
