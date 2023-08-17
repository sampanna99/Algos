using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace AlgorithsPractise.AbdulBariLecture
{
    public class MatrixChainMultiPlication
    {
        public List<Tuple<int, int>> Matrix { get; set; }
        public List<int> AllNumbers { get; set; }
        public int[,] NumberOfMultiPlications { get; set; }
        public int[,] WhereToSeparate { get; set; }

        public int NumberOfMatrix { get; set; }
        public MatrixChainMultiPlication()
        {
            AllNumbers = new List<int>();
            NumberOfMultiPlications = new int[4, 4];
            WhereToSeparate = new int[4, 4];
            NumberOfMatrix = 4;
            Matrix = new List<Tuple<int, int>>();
        }

        public void Initialize()
        {
            Matrix.Add(new Tuple<int, int>(3, 2));
            Matrix.Add(new Tuple<int, int>(2, 4));
            Matrix.Add(new Tuple<int, int>(4, 2));
            Matrix.Add(new Tuple<int, int>(2, 5));

            for (int i = 0; i < Matrix.Count; i++)
            {
                AllNumbers.Add(Matrix[i].Item1);
            }
            AllNumbers.Add(Matrix[Matrix.Count - 1].Item2);

            //foreach (var tuple in Matrix)
            //{
            //    AllNumbers.Add(tuple.Item1);

            //    //if (!AllNumbers.Contains(tuple.Item2))
            //    //{
            //    //    AllNumbers.Add(tuple.Item2);
            //    //}
            //}
        }

        public void FindEachAndPopulateMatrix(int startIndex, int EndIndex)
        {
            //formula C[i, j] = min (i<= k <=j) { c(i, k) + c(k + 1, j) + d(i) * d(k) * d(j + 1) } //some people
            //have d(i - 0);

            var leastValue = Int32.MaxValue;

            for (int i = startIndex + 1; i <= EndIndex; i++)
            {
                var val = NumberOfMultiPlications[startIndex, i - 1] + NumberOfMultiPlications[i, EndIndex] +
                          (AllNumbers[startIndex] * AllNumbers[i] * AllNumbers[EndIndex + 1]);

                if (val < leastValue)
                {
                    NumberOfMultiPlications[startIndex, EndIndex] = val;
                    WhereToSeparate[startIndex, EndIndex] = i;
                    leastValue = val;
                }
            }
        }

        public void CalculateMinimumMultiplication()
        {
            Initialize();
            //meaning 1 other
            for (int i = 1; i <= NumberOfMatrix; i++)
            {
                for (int j = 0; j < NumberOfMatrix - 1; j++)
                {
                    if (j + i >= NumberOfMatrix)
                    {
                        break;
                    }
                    FindEachAndPopulateMatrix(j, j + i);
                }

            }

            Console.WriteLine(NumberOfMultiPlications[0, 3]);

        }

    }
}
