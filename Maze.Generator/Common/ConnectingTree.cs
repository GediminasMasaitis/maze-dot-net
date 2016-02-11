using System.Collections;
using System.Collections.Generic;

namespace Maze.Generator.Common
{
    public class ConnectingTree<TKey> : IEnumerable<TKey>
    {
        public bool ImplicitlyAdding { get; set; }

        public ConnectingTree(bool implicitlyAdding = false)
        {
            ImplicitlyAdding = implicitlyAdding;
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
            Node origNode = null;
            if (ImplicitlyAdding && !InnerDictionary.TryGetValue(key, out origNode))
            {
                origNode = new Node();
                InnerDictionary.Add(key, origNode);
            }
            //var origNode = InnerDictionary[key];
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