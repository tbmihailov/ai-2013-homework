using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace AI.Graphs.Tests
{
    [TestClass]
    public class SearchHelpers_DFS_Tests
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
        /// New graph root int node from wikipedia sample http://en.wikipedia.org/wiki/Depth-first_search#Output_of_a_depth-first_search
        /// </summary>
        /// <returns>Graph root</returns>
        public Node<int> Get_InitNode_With_Wikipedia_Sample()
        {
            var graphRoot = N(1,
                                N(2,
                                    N(3,
                                        N(4),
                                        N(5)),
                                    N(6)),
                                N(7),
                                N(8,
                                    N(9,
                                        N(10),
                                        N(11)),
                                    N(12))
                              );
            return graphRoot;
        }

        [TestMethod]
        public void Test_If_FindValueUsingDFSRecursive_Works_Properly_With_FirstNode()
        {
            var graphRoot = Get_InitNode_With_Wikipedia_Sample();
            var log = new List<int>();
            var foundNode = SearchHelpers<int>.FindValueUsingDFSRecursive(graphRoot, (val => val == 1), log);

            Assert.AreEqual(foundNode.Value, 1);
            AreEqual(log, new List<int>() { 1 });
        }

        [TestMethod]
        public void Test_If_FindValueUsingDFSRecursive_Works_Properly_With_Left_Bottom_Node()
        {
            var graphRoot = Get_InitNode_With_Wikipedia_Sample();
            var log = new List<int>();
            var foundNode = SearchHelpers<int>.FindValueUsingDFSRecursive(graphRoot, (val => val == 4), log);

            Assert.AreEqual(foundNode.Value, 4);
            AreEqual(log, new List<int>() { 1, 2, 3, 4 });
        }

        [TestMethod]
        public void Test_If_FindValueUsingDFSRecursive_Works_Properly_With_Central_Node_Without_Children()
        {
            var graphRoot = Get_InitNode_With_Wikipedia_Sample();
            var log = new List<int>();
            var foundNode = SearchHelpers<int>.FindValueUsingDFSRecursive(graphRoot, (val => val == 7), log);

            Assert.AreEqual(foundNode.Value, 7);
            AreEqual(log, new List<int>() { 1, 2, 3, 4, 5, 6, 7 });
        }

        [TestMethod]
        public void Test_If_FindValueUsingDFSRecursive_Works_Properly_With_Last_Node()
        {
            var graphRoot = Get_InitNode_With_Wikipedia_Sample();
            var log = new List<int>();
            var foundNode = SearchHelpers<int>.FindValueUsingDFSRecursive(graphRoot, (val => val == 12), log);

            Assert.AreEqual(foundNode.Value, 12);
            AreEqual(log, new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 });
        }

        [TestMethod]
        public void Test_If_FindValueUsingDFSRecursive_Works_Properly_With_NoResult()
        {
            var graphRoot = Get_InitNode_With_Wikipedia_Sample();
            var log = new List<int>();
            var foundNode = SearchHelpers<int>.FindValueUsingDFSRecursive(graphRoot, (val => val == 66), log);

            Assert.IsNull(foundNode);
            AreEqual(log, new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 });
        }


        public Node<int> N(int value, params Node<int>[] children)
        {
            return new Node<int>(value, children);
        }
    }
}
