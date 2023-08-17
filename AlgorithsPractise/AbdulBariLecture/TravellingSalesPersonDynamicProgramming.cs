using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgorithsPractise.AbdulBariLecture
{
    public class TravellingSalesPersonDynamicProgramming
    {
        public int NumberOfVertex { get; set; } = 4;
        public int StartVertex { get; set; } = 1;
        public int[,] AdjacencyMatrix { get; set; }
        public int[,] AdjacencyMatrixDP { get; set; }
        public HashSet<int> AllVertexes { get; set; }

        public int WhatVertexDidItCalled { get; set; } = 1;
        public TravellingSalesPersonDynamicProgramming()
        {
            AdjacencyMatrix = new int[,]{{0,10,15,20}, {5,0,9,10}, {6,13,0,12}, {8,8,9,0}};
            AdjacencyMatrixDP = new int[NumberOfVertex, NumberOfVertex];

            AllVertexes = new HashSet<int>();
            AllVertexes.Add(1);
            AllVertexes.Add(2);
            AllVertexes.Add(3);
            AllVertexes.Add(4);
        }

        private void Initialize()
        {
            //AdjacencyMatrixDP may not work.
            //for (int i = 0; i <= NumberOfVertex; i++)
            //{
            //    if (i == 0)
            //    {
            //        AdjacencyMatrixDP[i, i] = 0;
            //    }
            //    else if (i == 1)
            //    {
            //        AdjacencyMatrixDP[i, i] = 0;
            //    }
            //    else
            //    {
            //        AdjacencyMatrix[i, i] = AdjacencyMatrix[i, StartVertex - 1];
            //    }
            //}


            for (int i = 0; i < NumberOfVertex; i++)
            {
                if (i == 0)
                {
                    AdjacencyMatrixDP[i, 0] = 0;
                    continue;
                }
                AdjacencyMatrixDP[i, 0] = AdjacencyMatrix[i, StartVertex - 1];
            }
        }


        //brute force.
        //maybe 1 should already be in there. done
        //maybe need to use stack and push 1 and then 234 and 34 and blah blah
        public int TravellingSalesMan(Stack<int> indexesDone, int startVertex = 1)
        {

            if (indexesDone.Count == NumberOfVertex)
            {
                WhatVertexDidItCalled = startVertex;

                return AdjacencyMatrix[startVertex - 1, StartVertex - 1];
            }

            var minimum = int.MaxValue;
            for (int i = 0; i < NumberOfVertex; i++)
            {
                if (!indexesDone.Contains(i + 1))
                {
                    var indexPlusOne = i + 1;
                    indexesDone.Push(indexPlusOne);
                    var minimum1 = TravellingSalesMan(indexesDone, indexPlusOne);
                    var actualMinimum = minimum1;


                    var fromThatVertexToAnother = AdjacencyMatrix[startVertex - 1,
                        i];
                    actualMinimum = actualMinimum + fromThatVertexToAnother;

                    if (actualMinimum < minimum)
                    {
                        minimum = actualMinimum;
                    }
                    indexesDone.Pop();
                }
            }
            return minimum;
        }

        public void TravellingSalesManDynamicP()
        {
            var allvertexes = new HashSet<int> { 1, 2, 3 };
            var abc = minimumOf(0, new HashSet<int>(), allvertexes);
            //Initialize();


            //for (int i = 1; i <= NumberOfVertex; i++)
            //{
            //    for (int j = 1; j <= NumberOfVertex; j++)
            //    {
            //        AdjacencyMatrixDP[j, j + i] = minimumOf(j, j+i);
            //    }
            //}
        }

        //remainingVertexes areused of vertexes
        public int minimumOf(int startVertex, HashSet<int> remainingVertexes, HashSet<int> allVertex)
        {

            if (remainingVertexes.Count == 3)
            {
                return AdjacencyMatrix[startVertex, StartVertex - 1];
            }
            int min = Int32.MaxValue;
            //if (remainingVertexes.Count == 0)
            //{
            //    return AdjacencyMatrix[startVertex, StartVertex - 1];
            //}
            //int min = Int32.MaxValue;


            foreach (var alver in allVertex)
            {
                if (remainingVertexes.Contains(alver))
                {
                    continue;
                }

                remainingVertexes.Add(alver);
                var g = minimumOf(alver, remainingVertexes, allVertex);
                var minA = AdjacencyMatrix[startVertex, alver] + g;
                if (minA < min)
                {
                    min = minA;
                }
                remainingVertexes.Remove(alver);
            }
            //foreach (var remainingVertex in remainingVertexes)
            //{
            //    remainingVertexes.Remove(remainingVertex);
            //    var g = minimumOf(remainingVertex, remainingVertexes, allVertex);
            //    var minA = AdjacencyMatrix[startVertex, remainingVertex] + g;
            //    if (minA < min)
            //    {
            //        min = minA;
            //    }
            //    remainingVertexes.Add(remainingVertex);
            //}
            return min;

        }
    }

    public class AllSubsetsCombination
    {
        public int[] AllSets { get; set; }
        public List<List<int>> AllResults { get; set; }

        public Stack<int> IntegerStack { get; set; }

        public AllSubsetsCombination()
        {
            AllSets = new[] { 1, 2, 3 };
            AllResults = new List<List<int>>();
            IntegerStack = new Stack<int>();
        }

        public List<List<int>> GetAllSubsets()
        {
            Backtracking(0);
            return AllResults;
        }
        public void Backtracking(int index = 0)
        {
            if (index >= AllSets.Length)
            {
                var Listofint = new List<int>();

                //while (IntegerStack.Count > 0)
                //{
                //    Listofint.Add(IntegerStack.Pop());
                //}
                //this way doesn't clear out the stack.
                foreach (var i in IntegerStack)
                {
                    Listofint.Add(i);
                }

                AllResults.Add(Listofint);
                return;
            }
            IntegerStack.Push(AllSets[index]);
            Backtracking(index + 1);
            IntegerStack.Pop();
            Backtracking(index + 1);
        }
    }
}
