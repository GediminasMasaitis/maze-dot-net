using System.Collections.Generic;
using Maze.Generator.Generators.Kruskal;

namespace Maze.Generator.Common
{
    public class ConnectingTree<TKey>
    {
        public ConnectingTree(int width, int height)
        {
            InnerDictionary = new Dictionary<TKey, Node>();
        }

        private Dictionary<TKey, Node> InnerDictionary { get; }

        private Node FindRoot(TKey key)
        {
            var origNode = InnerDictionary[key];
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

        public bool AreConnected(params TKey[] keys)
        {
            if (keys.Length < 2)
            {
                return true;
            }
            var firstRoot = FindRoot(keys[0]);
            for (var i = 1; i < keys.Length; i++)
            {
                var root = FindRoot(keys[i]);
                if (firstRoot.Equals(root))
                {
                    return false;
                }
            }
            return true;
        }

        public bool Connect(params TKey[] keys)
        {
            if (keys.Length < 2)
            {
                return true;
            }
            // TODO: Check if connected
            var firstRoot = FindRoot(keys[0]);
            for (var i = 1; i < keys.Length; i++)
            {
                var root = FindRoot(keys[i]);
                root.Parent = firstRoot;
            }
            return true;
        }
    }
}