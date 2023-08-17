using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithsPractise.LeetcodeBlind75
{
    public class PacificAtlanticWaterFlow
    {
        public int[,] ArrayOfValues { get; set; }
        public HashSet<Tuple<int, int>> AllVisitedAtlantic { get; set; }
        public HashSet<Tuple<int, int>> AllVisitedPacific { get; set; }

        public HashSet<Tuple<int, int>> AllViableFromAtlantic { get; set; }
        public HashSet<Tuple<int, int>> AllViableFromPacific { get; set; }



        public PacificAtlanticWaterFlow()
        {
            ArrayOfValues = new int[,]
            {
                {1,2,2,3,5},
                {3,2,3,4,4},
                {2,4,5,3,1},
                {6,7,1,4,5},
                {5,1,1,2,4}
            };

            AllVisitedAtlantic = new HashSet<Tuple<int, int>>();
            AllVisitedPacific = new HashSet<Tuple<int, int>>();
            AllViableFromAtlantic = new HashSet<Tuple<int, int>>();
            AllViableFromPacific = new HashSet<Tuple<int, int>>();
        }


        public void GetAllConeection()
        {
            for (int i = 0; i < ArrayOfValues.GetLength(0); i++)
            {
                DFS(Tuple.Create(i, 0), "ATLANTIC");
                //since they are the same height
                DFS(Tuple.Create(0,i), "ATLANTIC");
            }

            for (int i = ArrayOfValues.GetLength(0) - 1; i >= 0; i--)
            {
                DFS(Tuple.Create(ArrayOfValues.GetLength(0) - 1, i), "PACIFIC");
                DFS(Tuple.Create(i, ArrayOfValues.GetLength(0) - 1), "PACIFIC");
            }

            //Find the intersection of two AllViableFromAtlantic and AllViableFromPacific

        }
        public void DFS(Tuple<int, int> prevcoOrdinates, string atlanticOrpacific)
        {
            if (prevcoOrdinates.Item1 >= ArrayOfValues.GetLength(0) || 
                prevcoOrdinates.Item2 >= ArrayOfValues.GetLength(1))
            {
                return;
            }

            if (atlanticOrpacific == "ATLANTIC")
            {
                if (AllVisitedAtlantic.Contains(prevcoOrdinates))
                {
                    return;
                }

                AllVisitedAtlantic.Add(prevcoOrdinates);
                AllViableFromAtlantic.Add(prevcoOrdinates);
            }
            else
            {
                if (AllVisitedPacific.Contains(prevcoOrdinates))
                {
                    return;
                }

                AllVisitedPacific.Add(prevcoOrdinates);
                AllViableFromPacific.Add(prevcoOrdinates);

            }

            var arrayValue = ArrayOfValues[prevcoOrdinates.Item1, prevcoOrdinates.Item2];

            if (prevcoOrdinates.Item1 + 1 <= ArrayOfValues.GetLength(0) - 1)
            {
                var arvl = ArrayOfValues[prevcoOrdinates.Item1 + 1, prevcoOrdinates.Item2];

                if (arvl > arrayValue)
                {
                    DFS(Tuple.Create(prevcoOrdinates.Item1 + 1, prevcoOrdinates.Item2), atlanticOrpacific);
                }
            }
            if (prevcoOrdinates.Item2 + 1 <= ArrayOfValues.GetLength(1) - 1)
            {
                var arvl = ArrayOfValues[prevcoOrdinates.Item1, prevcoOrdinates.Item2 + 1];

                if (arvl > arrayValue)
                {
                    DFS(Tuple.Create(prevcoOrdinates.Item1, prevcoOrdinates.Item2 + 1), atlanticOrpacific);
                }

            }


            if (prevcoOrdinates.Item1 - 1 > 0)
            {
                var arvl = ArrayOfValues[prevcoOrdinates.Item1 - 1, prevcoOrdinates.Item2];

                if (arvl > arrayValue)
                {
                    DFS(Tuple.Create(prevcoOrdinates.Item1 - 1, prevcoOrdinates.Item2), atlanticOrpacific);
                }

            }
            if (prevcoOrdinates.Item2 - 1 > 0)
            {
                var arvl = ArrayOfValues[prevcoOrdinates.Item1, prevcoOrdinates.Item2 - 1];

                if (arvl > arrayValue)
                {
                    DFS(Tuple.Create(prevcoOrdinates.Item1, prevcoOrdinates.Item2 - 1), atlanticOrpacific);
                }
            }


            //DFS(Tuple.Create(prevcoOrdinates.Item1 + 1, prevcoOrdinates.Item2), atlanticOrpacific);
            //DFS(Tuple.Create(prevcoOrdinates.Item1, prevcoOrdinates.Item2 + 1), atlanticOrpacific);
            //DFS(Tuple.Create(prevcoOrdinates.Item1 - 1, prevcoOrdinates.Item2), atlanticOrpacific);
            //DFS(Tuple.Create(prevcoOrdinates.Item1, prevcoOrdinates.Item2 - 1), atlanticOrpacific);

        }
    }
}
