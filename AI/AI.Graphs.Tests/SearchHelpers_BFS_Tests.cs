using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace AI.Graphs.Tests
{
    [TestClass]
    public class SearchHelpers_BFS_Tests
    {
        /// <summary>
        /// Checks if two lists of typ List<int> are equal. 
        /// Comparing is by element
        /// </summary>
        /// <param name="list1"></param>
        /// <param name="list2"></param>
        /// <returns></returns>
        public bool AreEqual(List<int> list1, List<int> list2)
        {
            return ListHelpers<int>.AreEqual(list1, list2);
        }

        /// <summary>
        /// New graph root int node from wikipedia sample http://en.wikipedia.org/wiki/Breadth-first_search
        /// </summary>
        /// <returns>Graph root</returns>
        public Node<int> Get_InitNode_With_Wikipedia_Sample()
        {

            var graphRoot = N(1,
                                N(2,
                                    N(5,
                                        N(9),
                                        N(10)),
                                    N(6)),
                                N(3),
                                N(4,
                                    N(7,
                                        N(11),
                                        N(12)),
                                    N(8))
                              );
            return graphRoot;
        }

        [TestMethod]
        public void Test_If_FindValueUsingBFS_Works_Properly_With_FirstNode()
        {
            var graphRoot = Get_InitNode_With_Wikipedia_Sample();
            var log = new List<int>();
            var foundNode = SearchHelpers<int>.FindValueUsingBFS(graphRoot, (val => val == 1), log);

            Assert.AreEqual(foundNode.Value, 1);
            AreEqual(log, new List<int>() { 1 });
        }


        [TestMethod]
        public void Test_If_FindValueUsingBFS_Works_Properly_With_Node_Without_Children()
        {
            var graphRoot = Get_InitNode_With_Wikipedia_Sample();
            var log = new List<int>();
            var foundNode = SearchHelpers<int>.FindValueUsingBFS(graphRoot, (val => val == 10), log);

            Assert.AreEqual(foundNode.Value, 10);
            AreEqual(log, new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });
        }

        [TestMethod]
        public void Test_If_FindValueUsingBFS_Works_Properly_With_Node_With_Children()
        {
            var graphRoot = Get_InitNode_With_Wikipedia_Sample();
            var log = new List<int>();
            var foundNode = SearchHelpers<int>.FindValueUsingBFS(graphRoot, (val => val == 5), log);

            Assert.AreEqual(foundNode.Value, 5);
            AreEqual(log, new List<int>() { 1, 2, 3, 4, 5 });
        }

        [TestMethod]
        public void Test_If_FindValueUsingBFS_Works_Properly_Without_Match()
        {
            var graphRoot = Get_InitNode_With_Wikipedia_Sample();
            var log = new List<int>();
            var foundNode = SearchHelpers<int>.FindValueUsingBFS(graphRoot, (val => val == 66), log);

            Assert.IsNull(foundNode);
            AreEqual(log, new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 });
        }

        public Node<int> N(int value, params Node<int>[] children)
        {
            return new Node<int>(value, children);
        }
    }
}
