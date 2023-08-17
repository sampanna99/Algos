using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithsPractise.AbdulBariLecture
{
    public class KnapsackBranchAndBound
    {
        public Dictionary<int, List<int>> ValuesGiven { get; set; }
        public int TotalThatCouldBeTaken { get; set; } = 15;

        public int Upper { get; set; }
        public List<NodeHere> NodeHeres { get; set; }

        public NodeHere MinimumOne { get; set; }
        public KnapsackBranchAndBound()
        {
            ValuesGiven = new Dictionary<int, List<int>>();
            Upper = Int32.MaxValue;
            NodeHeres = new List<NodeHere>();
            MinimumOne = new NodeHere();
            Initialize();
        }

        private void Initialize()
        {
            ValuesGiven.Add(1, new List<int>{10,2});
            ValuesGiven.Add(2, new List<int>{10,4});
            ValuesGiven.Add(3, new List<int>{12,6});
            ValuesGiven.Add(1, new List<int>{18,9});

            var val = CalculateUpperAndCost(new[] { 1, 1, 1, 1 });
            Upper = val.Item1;
            var cost = val.Item2;

            NodeHeres.Add(new NodeHere
            {
                Upper = Upper,
                Cost = cost,
                NextUpIndex = 1,
                ArrayOfAddedThings = new int[]{1,1,1,1}
            });
            
            var val2 = CalculateUpperAndCost(new[] { 0, 1, 1, 1 });
            var Upper2 = val2.Item1;
            var cost2 = val2.Item2;

            NodeHeres.Add(new NodeHere
            {
                Upper = Upper2,
                Cost = cost2,
                NextUpIndex = 1,
                ArrayOfAddedThings = new int[]{0,1,1,1}
            });
        }

        //Maybe use a min heap(if you put - infront of that) to put the generated node/whatever you decide
        //so you could just take it off the heap
        //maybe heap not a great approach as it makes adding is alright but removing you may need -
        //- to remove more than one at a time which isn't ideal for a heap.

        public void StartHere()
        {
            //TODO:
            //find the minimun in the NodeHeres and expand that

            var smallestNodeCostTuple = FindTheMinimum();
            var smallestNodeCost = smallestNodeCostTuple.Item1;
            var isNodeChanged = smallestNodeCostTuple.Item2;
            var nullThenode = false;
            var nullThenodes = false;
            while (smallestNodeCost != null || isNodeChanged)
            {
                //it's the same object; for with included
                var nextUp = smallestNodeCost.NextUpIndex;
                smallestNodeCost.ArrayOfAddedThings[nextUp] = 1;
                var costAndUpper = CalculateUpperAndCost(smallestNodeCost.ArrayOfAddedThings);
                if (costAndUpper.Item1 < Upper)
                {
                    Upper = costAndUpper.Item1;
                    nullThenodes = true;
                    //now null the nodes with less values
                }
                if (Upper < costAndUpper.Item2)
                {
                    nullThenode = true;
                    //smallestNodeCost = null;
                }

                //diffrent object for not included
                var arrayToPass = (int [])smallestNodeCost.ArrayOfAddedThings.Clone();
                arrayToPass[nextUp] = 0;
                var costAndUpperNotInc = CalculateUpperAndCost(smallestNodeCost.ArrayOfAddedThings);
                var nodeHere = new NodeHere
                {
                    Upper = costAndUpperNotInc.Item1,
                    Cost = costAndUpperNotInc.Item2,
                    NextUpIndex = nextUp + 1,
                    ArrayOfAddedThings = arrayToPass
                };
                if (costAndUpperNotInc.Item1 < Upper)
                {
                    Upper = costAndUpperNotInc.Item1;
                }

                if (Upper >= costAndUpperNotInc.Item2)
                {
                    //Add here
                    NodeHeres.Add(nodeHere);
                }

                if (nullThenode)
                {
                    //smallestNodeCost = null;
                    nullThenodes = true;
                    //also find the node and actuall null it from the list
                }

                if (nullThenodes)
                {
                    //Logic to null them. Already done in the FindTheMinimum
                }
                smallestNodeCostTuple = FindTheMinimum();
                smallestNodeCost = smallestNodeCostTuple.Item1;
                isNodeChanged = smallestNodeCostTuple.Item2;
            }

        }

        //find the minimum cost. Maybe Null it here directly
        public (NodeHere, bool) FindTheMinimum()
        {
            NodeHere nodeHr = null;
            var isChanged = false;

            for (int i = 0; i < NodeHeres.Count; i++)
            {
                var nodeHere = NodeHeres[i];
                if (nodeHere == null)
                {
                    continue;
                }
                if (Upper < nodeHere.Cost)
                {
                    NodeHeres[i] = null;
                    continue;
                }

                if (nodeHr == null)
                {
                    nodeHr = nodeHere;
                }
                else
                {
                    if (nodeHr.Cost > nodeHere.Cost)
                    {
                        nodeHr = nodeHere;
                    }
                }
            }


            //if they are both null or empty they are equal.
            var serializedObject = JsonConvert.SerializeObject(MinimumOne);
            var serializedObject2 = JsonConvert.SerializeObject(nodeHr);

            //check what if both are null while serializing the object.
            if (serializedObject != serializedObject2)
            {
                isChanged = true;
            }
            //if (MinimumOne.Cost = nodeHr.Cost)
            //{
                
            //}
            MinimumOne = nodeHr;

            return (nodeHr, isChanged);

        }

        private (int, int) CalculateUpperAndCost(int[] arrayOfIncluded) //{0,0,1,0} means third included
        {
            var cost = 0;
            var upperLocal = 0;
            var weightLocal = 0;
            for (int i = 0; i < arrayOfIncluded.Length; i++)
            {
                if (arrayOfIncluded[i] != 0)
                {
                    if (weightLocal < TotalThatCouldBeTaken)
                    {
                        if (ValuesGiven[i][1] <= TotalThatCouldBeTaken - weightLocal)
                        {
                            upperLocal += ValuesGiven[i][0];
                            cost += ValuesGiven[i][0];
                            weightLocal += ValuesGiven[i][1];
                        }
                        else
                        {
                            if (weightLocal >= TotalThatCouldBeTaken)
                            {
                                break;
                            }
                            else
                            {
                                var diffrence = TotalThatCouldBeTaken - weightLocal;
                                cost += diffrence * (ValuesGiven[i][0] / ValuesGiven[i][1]);
                                weightLocal = TotalThatCouldBeTaken;
                            }
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }

            return (-upperLocal, -cost);
        }
    }

    public class NodeHere
    {
        public int Upper { get; set; }
        public int Cost { get; set; }
        public int NextUpIndex { get; set; }
        public int[] ArrayOfAddedThings { get; set; }

        public NodeHere()
        {
        }
    }
}
