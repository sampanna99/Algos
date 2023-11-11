using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithsPractise.LeetCode_Eric.Phase4
{
    public class UnionFind
    {

    }

    public class NumberOfProvinces
    {
        public int[,] GivenMatrix { get; set; }

        public NumberOfProvinces()
        {
            
        }

        public void Algorithmn()
        {
            var intArray = new int[GivenMatrix.GetLength(0)];
            Array.Fill(intArray, -1);

            for (int i = 0; i < GivenMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < GivenMatrix.GetLength(1); j++)
                {
                    var isConnectediTj = GivenMatrix[i, j];

                    if (isConnectediTj == 1)
                    {
                        if (i == j)
                        {
                            continue;
                        }

                        var (indexForFirst, valueForFirst) = (i, intArray[i]);
                        var (indexForSecond, valueForSecond) = (j, intArray[j]);
                        //cases
                        //same parent index also value needed
                        //diffrent parent index && value needed

                        while (valueForFirst >= 0 || valueForSecond >= 0)
                        {
                            if (valueForFirst >= 0)
                            {
                                indexForFirst = valueForFirst;
                                valueForFirst = intArray[indexForFirst];
                            }

                            if (valueForSecond >= 0)
                            {
                                indexForSecond = valueForSecond;
                                valueForSecond = intArray[indexForSecond];
                            }
                        }

                        if (indexForFirst == indexForSecond)
                        {
                            continue;
                        }
                        //now do union
                        var (makeThisChild, makeThisParent) = Math.Abs(valueForFirst) < Math.Abs(valueForSecond)
                            ? (indexForFirst, indexForSecond)
                            : (indexForSecond, indexForFirst);

                        var addedVal = Math.Abs(valueForFirst) + Math.Abs(valueForSecond);

                        intArray[makeThisChild] = makeThisChild;
                        intArray[makeThisParent] = -1 * addedVal;
                    }

                }
            }

            var numberOfProvinces = 0;
            for (int i = 0; i < intArray.Length; i++)
            {
                if (intArray[i] < 0)
                {
                    numberOfProvinces += 1;
                }
            }
        }
    }

    //could use neetcode way but want to practise Union Find disjoint
    public class GraphValidTree
    {
        public int[][] GivenConnections { get; set; }

        //could use an array which saves space.
        public Dictionary<int, NodeForUnionFind> DictionaryOfNodes { get; set; }
        public void Algorithmn()
        {
            var isCycle = false;
            var numberofDisconnected = 0;
            foreach (var givenConnection in GivenConnections)
            {
                for (int i = 0; i < 2; i++)
                {
                    if (!DictionaryOfNodes.ContainsKey(givenConnection[0]))
                    {
                        DictionaryOfNodes.Add(givenConnection[i], new NodeForUnionFind());
                    }

                }
                var (source, dest) =
                    (FindParent(DictionaryOfNodes[0]), FindParent(DictionaryOfNodes[1]));

                if (source == dest)
                {
                    //cycle
                    isCycle = true;
                    break;
                }

                var (makeThisParent, makeThisChild) = 
                    source.Weight > dest.Weight ? (source, dest) : (dest, source);
                makeThisChild.ParentNode = makeThisParent;
                makeThisParent.Weight += makeThisChild.Weight;
            }

            foreach (var dictionaryOfNode in DictionaryOfNodes)
            {
                var doesHaveParent = dictionaryOfNode.Value.ParentNode == null;

                if (!doesHaveParent)
                {
                    numberofDisconnected += 1;
                }
            }

        }


        public NodeForUnionFind FindParent(NodeForUnionFind nodeToFind)
        {
            var forParent = nodeToFind;
            while (forParent.ParentNode != null)
            {
                forParent = forParent.ParentNode;
            }

            return forParent;
        }
    }

    public class NodeForUnionFind
    {
        public NodeForUnionFind ParentNode { get; set; }
        public int Value { get; set; }
        public int Weight { get; set; } = 1;
    }
}
