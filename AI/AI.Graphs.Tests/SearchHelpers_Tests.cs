using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AI.Graphs.Tests
{
    [TestClass]
    public class SearchHelpers_Test
    {
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

            var foundNode = SearchHelpers<int>.FindValueUsingBFS(graphRoot, (val => val == 1));
            Assert.AreEqual(foundNode.Value, 1);
        }

        [TestMethod]
        public void Test_If_FindValueUsingBFS_Works_Properly_With_Node_Without_Children()
        {
            var graphRoot = Get_InitNode_With_Wikipedia_Sample();

            var foundNode = SearchHelpers<int>.FindValueUsingBFS(graphRoot, (val => val == 10));
            Assert.AreEqual(foundNode.Value, 10);
        }

        [TestMethod]
        public void Test_If_FindValueUsingBFS_Works_Properly_With_Node_With_Children()
        {
            var graphRoot = Get_InitNode_With_Wikipedia_Sample();

            var foundNode = SearchHelpers<int>.FindValueUsingBFS(graphRoot, (val => val == 5));
            Assert.AreEqual(foundNode.Value, 5);
        }

        [TestMethod]
        public void Test_If_FindValueUsingBFS_Works_Properly_Without_Match()
        {
            var graphRoot = Get_InitNode_With_Wikipedia_Sample();

            var foundNode = SearchHelpers<int>.FindValueUsingBFS(graphRoot, (val => val == 66));
            Assert.IsNull(foundNode);
        }

        public Node<int> N(int value, params Node<int>[] children)
        {
            return new Node<int>(value, children);
        }
    }
}
