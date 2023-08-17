using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithsPractise.LeetcodeBlind75
{
    public class GridGame
    {
        public int[,] Matrix { get; set; }
        public int[,] PrePostMatrix { get; set; }
        public GridGame()
        {
            Initialize();
        }

        public void Initialize()
        {
            Matrix = new int[,]
            {
                { 2, 5, 4 },
                { 1, 5, 1 }
            };
            PrePostMatrix = (int[,]) Matrix.Clone();

            for (int i = 0; i < PrePostMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < PrePostMatrix.GetLength(1); j++)
                {
                    if (j == 0)
                    {
                        continue;
                    }
                    PrePostMatrix[i, j] += PrePostMatrix[i, j - 1];
                }
            }
        }

        public void LowestValueForSecondTime()
        {
            //where to break

            var minimumForSec = Int32.MaxValue;
            var breakIndex = 0;
            var topMaxVal = PrePostMatrix[0, 2];
            var bottomMaxVal = PrePostMatrix[1, 2];
            while (breakIndex < Matrix.GetLength(1))
            {
                var topRowVal = topMaxVal - PrePostMatrix[0, breakIndex];
                var bottomREowVal = (breakIndex - 1 >= 0) ? PrePostMatrix[1, breakIndex] : 
                    0;
                var secondRobnotmax = Math.Max(topRowVal, bottomREowVal);
                minimumForSec = Math.Min(minimumForSec, secondRobnotmax);
                breakIndex++;
            }

        }
    }
}
 