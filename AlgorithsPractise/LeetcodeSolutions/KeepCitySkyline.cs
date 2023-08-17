using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithsPractise.LeetcodeSolutions
{
    public class KeepCitySkyline
    {
        public int[][] ArrayofArrays { get; set; }

        public KeepCitySkyline()
        {
            ArrayofArrays = new[]
            {
                new[] { 3, 0, 8, 4 },
                new[] { 2, 4, 5, 7 },
                new[] { 9, 2, 6, 3 },
                new[] { 0, 3, 1, 0 }
            };

        }

        public void Algorithm()
        {
            var arrayRow = new Int32[4];
            var arrayColumn = new Int32[4];
            var resultToReturn = 0;

            for (int i = 0; i < ArrayofArrays.Length - 1; i++)
            {
                for (int j = 0; j < ArrayofArrays[i].Length - 1; j++)
                {
                    if (arrayRow[i] < ArrayofArrays[i][j])
                    {
                        arrayRow[i] = ArrayofArrays[i][j];
                    }
                    if (arrayColumn[j] < ArrayofArrays[i][j])
                    {
                        arrayColumn[j] = ArrayofArrays[i][j];
                    }
                }
            }

            for (int i = 0; i < ArrayofArrays.Length - 1; i++)
            {
                for (int j = 0; j < ArrayofArrays[i].Length; j++)
                {
                    resultToReturn += Math.Min(arrayRow[i], arrayColumn[j]) - ArrayofArrays[i][j];
                }
            }
        }
    }
} 