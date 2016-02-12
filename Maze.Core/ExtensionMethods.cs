using System;
using System.Collections.Generic;
using System.Linq;

namespace Maze.Core
{
    internal static class ExtensionMethods
    {
        public static void Push<T>(this LinkedList<T> list, T elem)
        {
            list.AddLast(elem);
        }

        public static T Pop<T>(this LinkedList<T> list)
        {
            var last = list.Last.Value;
            list.RemoveLast();
            return last;
        }

        public static void Push<T>(this List<T> list, T elem)
        {
            list.Add(elem);
        }

        public static T Pop<T>(this List<T> list)
        {
            var lastIndex = list.Count-1;
            var last = list[lastIndex];
            list.RemoveAt(lastIndex);
            return last;
        }

        public static void Shuffle<T>(this LinkedList<T> list)
        {
            var tempList = list.ToList();
            tempList.Shuffle();
            var l = list.First;
            foreach (var v in tempList)
            {
                l.Value = v;
                l = l.Next;
            }
        }

        public static void Shuffle<T>(this IList<T> list, Random random = null)
        {
            random = random ?? new Random();
            var len = list.Count;
            for (var i = len - 1; i >= 1; --i)
            {
                var j = random.Next(i);
                var tmp = list[i];
                list[i] = list[j];
                list[j] = tmp;
            }
        }
    }
}