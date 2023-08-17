 using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithsPractise.LeetcodeSolutions
{
    public class SpiralMatrix
    {
        public int[,] Matrix { get; set; }

        public SpiralMatrix()
        {
            Matrix = new int[,]
            {
                { 1, 2, 3, 4 },
                { 5, 6, 7, 8 },
                { 9, 10, 11, 12 }
            };
        }

        public void ALgorithm()
        {
            var (startRow, endRow, startColumn, endColumn) = (0, Matrix.GetLength(0) - 1,
                0, Matrix.GetLength(1) - 1);
            var listToReturn = new List<int>();
            while (startRow < endRow && startColumn < endColumn)
            {
                for (int i = startColumn; i <= endColumn; i++)
                {
                    listToReturn.Add(Matrix[startRow,i]);
                }

                startRow += 1;

                for (int i = startRow; i <= endRow; i++)
                {
                    listToReturn.Add(Matrix[i, endColumn]);
                }

                endColumn -= 1;

                for (int i = endColumn; i >= endColumn; i--)
                {
                    listToReturn.Add(Matrix[endRow, i]);
                }

                endRow -= 1;

                for (int i = startRow; i <= endRow; i++)
                {
                    listToReturn.Add(Matrix[i, endColumn]);
                }
                startColumn += 1;
            }
        }
    }
}
