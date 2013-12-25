using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI.Graphs
{
    public class SearchHelpers<T> where T : struct
    {
        /// <summary>
        /// Finds a Node in the graph that meets given condition using Breadth First Search
        /// </summary>
        /// <param name="graphRoot">Root graph node</param>
        /// <param name="condition">Condition to meet</param>
        /// <returns></returns>
        public static Node<T> FindValueUsingBFS(Node<T> graphRoot, Predicate<T> condition)
        {
            Queue<Node<T>> queue = new Queue<Node<T>>();

            queue.Enqueue(graphRoot);
            graphRoot.IsProcessed = true;

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                if (condition(node.Value))
                {
                    return node;
                }
                else
                {
                    foreach (var child in node.Children)
                    {
                        if (!child.IsProcessed)
                        {
                            queue.Enqueue(child);
                            child.IsProcessed = true;
                        }
                    }
                }
            }

            return null;
        }
    }
}
