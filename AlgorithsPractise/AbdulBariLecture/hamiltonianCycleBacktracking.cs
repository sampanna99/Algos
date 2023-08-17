using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithsPractise.AbdulBariLecture
{
    public class hamiltonianCycleBacktracking
    {
        public Dictionary<int, HashSet<int>> AdjacencyList { get; set; }
        public int NumberOfNodes { get; set; } = 5;
        public int[,] Matrix { get; set; }

        public List<List<int>> Answers { get; set; }
        public hamiltonianCycleBacktracking()
        {
            Matrix = new int[5,5]
            {
                { 0, 1, 1, 0, 1 },
                {1,0,1,1,1},
                {1,1,0,1,0},
                {0,1,1,0,1},
                {1,1,0,1,0}
            };
            Answers = new List<List<int>>();
        }

        private void Initialize()
        {
            //for (int i = 0; i < NumberOfNodes; i++)
            //{
            //    switch (i)
            //    {
            //        case 0:
            //            //do for the row and also do for the column
            //            DoForRowColumnGreaterThan(i);
            //        break;
            //        default:
            //            break;
            //    }
            //}



             
        }

        public List<int> Hamiltonian()
        {
            DFS(new HashSet<int>(), 0);

            return null;

        }
        private void DFS(HashSet<int> allnumbers, int startIndex)
        {
            if (startIndex == 0)
            {
                allnumbers.Add(0);
            }

            if (allnumbers.Count >= 5)
            {
                var newList = new List<int>();
                foreach (var allnumber in allnumbers)
                {
                    newList.Add(allnumber);
                }
                Answers.Add(newList);
                return;
            }
            for (int i = 1; i < NumberOfNodes; i++)
            {
                if (!allnumbers.Contains(i) && Matrix[startIndex, i] != 0)
                {
                    allnumbers.Add(i);
                    DFS(allnumbers, i);
                    allnumbers.Remove(i);
                }
            }
        }
        //private void DoForRowColumnGreaterThan(int greaterThan)
        //{
        //    for (int i = greaterThan; i < NumberOfNodes; i++)
        //    {
        //        Matrix[greaterThan, i] = 
        //    }
        //}
    }
}
