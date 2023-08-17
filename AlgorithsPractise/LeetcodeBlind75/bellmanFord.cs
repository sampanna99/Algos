using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace AlgorithsPractise.LeetcodeBlind75
{
    //Won't work if cycles in the graph
    public class bellmanFord
    {
        //use Dictionary<int, Dictionary<int, int>>
        public Dictionary<int, List<Tuple<int, int>>> GivenAdjacency { get; set; }
        public List<Tuple<int, int>> Edges { get; set; }
        public int NumberOfVertexes { get; set; } = 6;
        public Dictionary<int, int> DistanceToThatVertexFromStart { get; set; }

        //DSource is constant
        public Dictionary<int, int> ValueFromSourceToThatVertex { get; set; }
        public List<Tuple<int, int>> ListOfEdges { get; set; }

        public bellmanFord()
        {
            GivenAdjacency = new Dictionary<int, List<Tuple<int, int>>>();
            Edges = new List<Tuple<int, int>>();
            ValueFromSourceToThatVertex = new Dictionary<int, int>();
            DistanceToThatVertexFromStart = new Dictionary<int, int>();
            ListOfEdges = new List<Tuple<int, int>>();
        }

        private void Initialize()
        {
            var firstOne = new List<Tuple<int, int>>();
            firstOne.Add(Tuple.Create(2, 6));
            firstOne.Add(Tuple.Create(3,5));
            firstOne.Add(Tuple.Create(4,5));

            var secondOne = new List<Tuple<int, int>>();
            secondOne.Add(Tuple.Create(5, -1));

            var thirdOne = new List<Tuple<int, int>>();
            thirdOne.Add(Tuple.Create(2,-2));
            thirdOne.Add(Tuple.Create(5,1));

            var fourthOne = new List<Tuple<int, int>>();
            fourthOne.Add(Tuple.Create(3, -2));
            fourthOne.Add(Tuple.Create(6,-1));

            var fifthOne = new List<Tuple<int, int>>();
            fifthOne.Add(Tuple.Create(7,3));

            var sixthOne = new List<Tuple<int, int>>();
            sixthOne.Add(Tuple.Create(7,3));

            var seventhOne = new List<Tuple<int, int>>();
            GivenAdjacency.Add(1, firstOne);
            GivenAdjacency.Add(2, secondOne);
            GivenAdjacency.Add(3, thirdOne);
            GivenAdjacency.Add(4, fourthOne);
            GivenAdjacency.Add(5, fifthOne);
            GivenAdjacency.Add(6, sixthOne);
            GivenAdjacency.Add(7, seventhOne);

            ListOfEdges.Add(Tuple.Create(1,2));
            ListOfEdges.Add(Tuple.Create(1,3));
            ListOfEdges.Add(Tuple.Create(1,4));
            ListOfEdges.Add(Tuple.Create(2,5));
            ListOfEdges.Add(Tuple.Create(3,2));
            ListOfEdges.Add(Tuple.Create(3,5));
            ListOfEdges.Add(Tuple.Create(4,3));
            ListOfEdges.Add(Tuple.Create(4,6));
            ListOfEdges.Add(Tuple.Create(5,7));
            ListOfEdges.Add(Tuple.Create(6,7));

            DistanceToThatVertexFromStart.Add(2, Int32.MaxValue);
            DistanceToThatVertexFromStart.Add(3, Int32.MaxValue);
            DistanceToThatVertexFromStart.Add(4, Int32.MaxValue);
            DistanceToThatVertexFromStart.Add(5, Int32.MaxValue);
            DistanceToThatVertexFromStart.Add(6, Int32.MaxValue);
            DistanceToThatVertexFromStart.Add(7, Int32.MaxValue);
        }

        public void BellmanFordAlgo()
        {
            for (int i = 0; i < NumberOfVertexes - 1; i++)
            {
                //Relax all the edges
                foreach (var listOfEdge in ListOfEdges)
                {
                    var getDistanceToStartVert = DistanceToThatVertexFromStart[listOfEdge.Item1];
                    var getDistanceToDestVert = DistanceToThatVertexFromStart[listOfEdge.Item2];

                    if (getDistanceToStartVert == Int32.MaxValue &&
                        getDistanceToDestVert == Int32.MaxValue)
                    {
                        //no relaxation
                        continue;
                    }

                    var getEdgeLength = GetEdgeVal(listOfEdge);
                    var sum = getDistanceToStartVert + getEdgeLength;
                    if (sum < getDistanceToDestVert)
                    {
                        DistanceToThatVertexFromStart[listOfEdge.Item2] = sum;
                    }

                }

            }
        }

        private int GetEdgeVal(Tuple<int, int> startAndEnd)
        {
            var allConnections = GivenAdjacency[startAndEnd.Item1];
            var returnVal = Int32.MaxValue;
            foreach (var allConnection in allConnections)
            {
                if (allConnection.Item1 == startAndEnd.Item2 )
                {
                    returnVal = allConnection.Item2;
                    break;
                }
            }

            return returnVal;
        }

    }
}
