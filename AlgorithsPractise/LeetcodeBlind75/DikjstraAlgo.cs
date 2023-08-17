using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgorithsPractise.LeetcodeBlind75
{
    public class DikjstraAlgo
    {

        public Dictionary<int, List<Tuple<int, int>>> AdjacencyList { get; set; }
        public Dictionary<int, int> StartVertexToOtherVertexDistance { get; set; }
        public HashSet<int> VisitedVertex { get; set; }
        public DikjstraAlgo()
        {
            //Tuple is Vertex, EdgeLength
            AdjacencyList = new Dictionary<int, List<Tuple<int, int>>>();
            StartVertexToOtherVertexDistance = new Dictionary<int, int>();
            VisitedVertex = new HashSet<int>();
            Initialize();
        }

        private void Initialize()
        {
            var forOne = new List<Tuple<int, int>>();
            forOne.Add(Tuple.Create(2,2));
            forOne.Add(Tuple.Create(3,4));

            var forTwo = new List<Tuple<int, int>>();
            forTwo.Add(Tuple.Create(3,1));
            forTwo.Add(Tuple.Create(4,7));

            var forThree = new List<Tuple<int, int>>();
            forThree.Add(Tuple.Create(5,3));

            var forFpur = new List<Tuple<int, int>>();
            forFpur.Add(Tuple.Create(6,1));

            var forFive = new List<Tuple<int, int>>();
            forFive.Add(Tuple.Create(4,2));
            forFive.Add(Tuple.Create(6,5));

            var forSix = new List<Tuple<int, int>>();
            
            AdjacencyList.Add(1, forOne);
            AdjacencyList.Add(2, forTwo);
            AdjacencyList.Add(3, forThree);
            AdjacencyList.Add(4, forFpur);
            AdjacencyList.Add(5, forFive);
            AdjacencyList.Add(6, forSix);

            StartVertexToOtherVertexDistance.Add(2, 2);
            StartVertexToOtherVertexDistance.Add(3, 4);
            StartVertexToOtherVertexDistance.Add(4, Int32.MaxValue);
            StartVertexToOtherVertexDistance.Add(5, Int32.MaxValue);
            StartVertexToOtherVertexDistance.Add(6, Int32.MaxValue);
        }

        //Tuple is Vertex, EdgeLength
        public void AlgoRithm()
        {
            var minValue = GetMinValue();
            VisitedVertex.Add(minValue.Item1);
            while (minValue.Item2 < Int32.MaxValue)
            {
                //perform relaxation
                var allConnectedToThis = AdjacencyList[minValue.Item1];
                foreach (var eachConnected in allConnectedToThis)
                {
                    var edgeLengthFromStartToNext = 
                        StartVertexToOtherVertexDistance[eachConnected.Item1];
                    var edgeLengthFromNonStartToNext = eachConnected.Item2;

                    if (edgeLengthFromNonStartToNext + minValue.Item2 < 
                        edgeLengthFromStartToNext)
                    {
                        StartVertexToOtherVertexDistance[eachConnected.Item1] =
                            edgeLengthFromNonStartToNext + minValue.Item2;
                    }

                }

                minValue = GetMinValue();
            }
        }

        private (int, int) GetMinValue()
        {
            var minValue = Int32.MaxValue;
            var vertex = -1;
            foreach (var eachOne in StartVertexToOtherVertexDistance)
            {
                if (VisitedVertex.Contains(eachOne.Key))
                {
                    continue;
                }
                if (minValue > eachOne.Value)
                {
                    minValue = eachOne.Value;
                    vertex = eachOne.Key;
                }
            }
            return (vertex, minValue);
        }
    }
}
