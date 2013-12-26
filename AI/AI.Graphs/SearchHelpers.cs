using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        public static Node<T> FindValueUsingBFS(Node<T> graphRoot, Predicate<T> condition, List<T> log)
        {
            Queue<Node<T>> queue = new Queue<Node<T>>();

            queue.Enqueue(graphRoot);
            graphRoot.IsProcessed = true;

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                if (log != null)
                {
                    log.Add(node.Value);
                }

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

        public static Node<T> FindValueUsingDFSRecursive(Node<T> node, Predicate<T> condition, List<T> log)
        {
            Debug.Write(string.Format("{0}->", node.Value));
            if (log != null)
            {
                log.Add(node.Value);
            }
            if (condition(node.Value))
            {
                Debug.Write("success");
                return node;
            }

            if (!node.IsProcessed)
            {
                node.IsProcessed = true;
                foreach (var child in node.Children)
                {
                    if (!child.IsProcessed)
                    {
                        var res = FindValueUsingDFSRecursive(child, condition, log);
                        if (res != null)
                        {
                            return res;
                        }
                    }
                }
            }

            return null;
        }
    }
}
