using System.Collections;
using System.Collections.Generic;
using Maze.Generator.Generators.Kruskal;

namespace Maze.Generator.Common
{
    public class ConnectingTree<TKey> : IEnumerable<TKey>
    {
        public ConnectingTree()
        {
            InnerDictionary = new Dictionary<TKey, Node>();
        }

        private Dictionary<TKey, Node> InnerDictionary { get; }

        public void Add(TKey key)
        {
            var node = new Node();
            InnerDictionary.Add(key, node);
        }

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
                if (!firstRoot.Equals(root))
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
            if (AreConnected(keys))
            {
                return false;
            }
            var firstRoot = FindRoot(keys[0]);
            for (var i = 1; i < keys.Length; i++)
            {
                var root = FindRoot(keys[i]);
                root.Parent = firstRoot;
            }
            return true;
        }

        public IEnumerator<TKey> GetEnumerator() => InnerDictionary.Keys.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => InnerDictionary.Keys.GetEnumerator();
    }
}