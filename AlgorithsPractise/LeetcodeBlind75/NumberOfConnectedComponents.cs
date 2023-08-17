using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithsPractise.LeetcodeBlind75
{
    //disjoint sets
    //weighted union and collapsing find
    public class NumberOfConnectedComponents
    {
        public int[][] ArrayOfEdges { get; set; }
        public int NumberOfcomponents { get; set; }
        public int[] AllNodeArray { get; set; }

        public Dictionary<int, Tuple<int, int>> UsedNodes { get; set; }
        public Dictionary<int, int> UsedNodesN { get; set; }
        public Dictionary<int, int> UsedNodesNN { get; set; }
        public HashSet<int> ReadValues { get; set; }


        public int ArrayValue { get; set; } = 0;
        public NumberOfConnectedComponents()
        {
            ArrayOfEdges = new int[][]
            {
               
                new int[] {0,1},
                new int[] {1,2},
                new int[] {3,4}
            };

            NumberOfcomponents = 5;
            AllNodeArray = new int[NumberOfcomponents];
            Array.Fill(AllNodeArray, 1);
            //AllNodeArray = new int[NumberOfcomponents];
            UsedNodes = new Dictionary<int,Tuple<int, int>>();
            UsedNodesN = new Dictionary<int,int>();
            UsedNodesNN = new Dictionary<int,int>();
            ReadValues = new HashSet<int>();
        }

        //Dictionary --> index, value/parent
        public int NumberOfconnected()
        {
            UsedNodesN.Add(ArrayOfEdges[0][0], -2);
            UsedNodesN.Add(ArrayOfEdges[0][1], ArrayOfEdges[0][0]);

            //UsedNodes.Add(ArrayOfEdges[0][0], Tuple.Create(ArrayValue++, -1));
            //UsedNodes.Add(ArrayOfEdges[0][1], Tuple.Create(ArrayValue++, -1));

            //ReadValues.Add(ArrayOfEdges[0][0]);
            //ReadValues.Add(ArrayOfEdges[0][1]);

            for (int i = 1; i < ArrayOfEdges.Length; i++)
            {
                var firstValue = ArrayOfEdges[i][0];
                var secondValue = ArrayOfEdges[i][1];

                //if (UsedNodes.ContainsKey(firstValue))
                //{

                //}

                var parentOfFirst = -1;
                var parentOfSecond = -1;

                if (UsedNodesN.ContainsKey(firstValue))
                {
                    parentOfFirst = UsedNodesN[firstValue];
                }
                else
                {
                    UsedNodesN.Add(firstValue,-1);
                }
                if (UsedNodesN.ContainsKey(secondValue))
                {
                     parentOfSecond = UsedNodesN[secondValue];
                }
                else
                {
                    UsedNodesN.Add(secondValue, -1);
                }

                if (parentOfFirst == -1 && parentOfSecond == -1)
                {
                    UsedNodesN.Add(ArrayOfEdges[i][0], -2);
                    UsedNodesN.Add(ArrayOfEdges[i][1], ArrayOfEdges[i][0]);
                }
                else
                {
                    if (parentOfFirst == -1 || parentOfSecond == -1)
                    {
                        var nonnegativeone = parentOfFirst == -1 ? secondValue : firstValue;
                        var negativeone = nonnegativeone == firstValue ? secondValue : firstValue;

                        if (nonnegativeone < 0)
                        {
                            //count
                            UsedNodesN[nonnegativeone] -= -1;
                            UsedNodesN[negativeone] = nonnegativeone;
                        }
                        else
                        {
                            //value
                            var parentofThat = UsedNodesN[nonnegativeone];
                            var parentNestedParent = UsedNodesN[parentofThat];
                            UsedNodesN[parentNestedParent] -= -1;
                            UsedNodesN[negativeone] = nonnegativeone;

                        }
                    }
                    else
                    {
                        if (parentOfFirst < 0 && parentOfSecond < 0)
                        {
                            var bigger = parentOfSecond > parentOfFirst ? firstValue : secondValue;
                            var smaller = parentOfSecond > parentOfFirst ? secondValue : firstValue;

                            UsedNodesN[bigger] += UsedNodesN[smaller];
                            UsedNodesN[smaller] = bigger;
                        }
                        else
                        {
                         
                            
                        }

                    }
                }




            }
            foreach (var edge in ArrayOfEdges)
            {
                var firstValue = edge[0];
                var secondValue = edge[1];



            }

            return 0;
        }

        //finally works
        public int NUmberOfconnected2()
        {
            //each node parent of itself
            //rank of 1 initially
            //find
            //union

            //todo: maybe a dictionary with node key with index value.

            var returnThis = NumberOfcomponents;
            foreach (var edge in ArrayOfEdges)
            {
                var firstvalue = edge[0];
                var secondvalue = edge[1];

                var parent = FindParent(firstvalue);
                var parentSecond = FindParent(secondvalue);

                //var dsa = typeof(parent.Item1);
                if ((parent.Item1 == parentSecond.Item1) && parent.Item1 != -1)
                {
                    //same parent. //what if there are same number of elements on
                    //two disjoiunt component aka -4 and -4
                    continue;
                }
                //else if (parent.Item1 == -1 && parentSecond.Item1 == -1)
                //{
                //    UsedNodes[firstvalue] = new Tuple<int, int>(-1, 2);
                //    UsedNodes[secondvalue] = new Tuple<int, int>(firstvalue, parentSecond.Item2);
                //    returnThis--;
                //    //UsedNodesN[firstvalue] = -2;
                //    //UsedNodesN[secondvalue] = firstvalue;
                //}
                else
                {

                    if (parent.Item2 > parentSecond.Item2)
                    {
                        parentSecond.Item1 = parent.Item1;
                        parent.Item2 += parentSecond.Item2;
                        returnThis--;
                        UsedNodes[firstvalue] = new Tuple<int, int>(parent.Item1, parent.Item2);
                        UsedNodes[secondvalue] = new Tuple<int, int>(parentSecond.Item1, parentSecond.Item2);
                    }
                    else
                    {
                        parent.Item1 = parentSecond.Item1;
                        parentSecond.Item2 += parent.Item2;
                        UsedNodes[firstvalue] = new Tuple<int, int>(parent.Item1, parent.Item2);
                        UsedNodes[secondvalue] = new Tuple<int, int>(parentSecond.Item1, parentSecond.Item2);

                        returnThis--;
                    }

                    //var bigRank = parent.Item2 > parentSecond.Item2 ? firstvalue : secondvalue;
                    //var smallrank = parent.Item2 > parentSecond.Item2 ? secondvalue : firstvalue;

                    //var bigRankParent = parent.Item2 > parentSecond.Item2 ? parent : parentSecond;
                    //var smallrankParent = parent.Item2 > parentSecond.Item2 ? parentSecond : parent;

                    //UsedNodes[smallrank] = new Tuple<int, int>(bigRankParent.Item1, smallrankParent.Item2);
                    //UsedNodes[bigRank] =
                    //    new Tuple<int, int>(bigRankParent.Item1, smallrankParent.Item2 + bigRankParent.Item2);
                    //returnThis--;

                    //var bigwhenPositive = parent.Item1 > parentSecond.Item1 ? parentSecond : parent;
                    //var smallwhenPositive = parent.Item1 > parentSecond.Item1 ? parent : parentSecond;


                }

            }

            return returnThis;
        }

        private (int, int) FindParent(int value)
        {
            if (UsedNodes.ContainsKey(value))
            {
                //var returnValue = UsedNodesN[value];
                var valueChanged = value;
                while (UsedNodes[valueChanged].Item1 != -1)
                {
                    valueChanged = UsedNodes[valueChanged].Item1;
                }

                return (valueChanged, UsedNodes[value].Item2);
            }
            else
            {
                //UsedNodesN.Add(value, -1);
                UsedNodes.Add(value, new Tuple<int, int>(-1, 1));
            }

            return (-1, 1);
        }

        //copied neetcode video
        public int NUmberOfconnected3()
        {
            var parent = new int [NumberOfcomponents];
            var rank = new int[NumberOfcomponents];
            Array.Fill(parent, -1);
            Array.Fill(rank, 1);
            var res = NumberOfcomponents;
            foreach (var array in ArrayOfEdges)
            {
                res -= Union(array[0], array[1], parent, rank);
            }

            return res;
        }

        private int Find(int n1, int[] parent)
        {
            var res = n1;
            while (res != -1)
            {
                //path compresssion
                parent[res] = parent[parent[res]];
                res = parent[res];
            }

            return res;

        }

        private int Union(int n1, int n2, int[] parent, int[] rank)
        {
            var p1 = Find(n1, parent);
            var p2 = Find(n2, parent);

            //if you have -1 for all parent it wouldn't work.....
            if (p1 == p2)
            {
                return 0;
            }

            if (rank[p2] > rank[p1])
            {
                parent[p1] = p2;
                rank[p2] += 1;
            }
            else
            {
                parent[p2] = p1;
                rank[p1] += 1;

            }

            return 1;
        }

        //tuple is parent, rank
    }
}
