using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithsPractise.LeetcodeSolutions
{
    public class MaxAreaOfIsland
    {
        public int[][] ArrayOfArrays { get; set; }
        public HashSet<string> AlreadyVisited { get; set; }
        public MaxAreaOfIsland()
        {
            ArrayOfArrays = new[]
            {
                new[]
                    { 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0 },
                new[]
                    { 0, 0, 1, 0, 0, 0, 1, 0, 0, 1, 0, 0 },
                new[]
                    { 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0 },
                new[]
                    { 0, 0, 1, 0, 1, 0, 1, 0, 0, 0, 0, 0 },
                new[]
                    { 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0 },
                new[]
                    { 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0 },
            };
            AlreadyVisited = new HashSet<string>();
        }


        public void Algorithmn()
        {
            var maxArea = 0;
            for (int i = 0; i < ArrayOfArrays.Length; i++)
            {
                for (int j = 0; j < ArrayOfArrays[i].Length; j++)
                {
                    // now go all 4 recursively
                    if (!AlreadyVisited.Contains(i.ToString() +  j.ToString()) &&
                        ArrayOfArrays[i][j] != 0)
                    {
                        //do recursive
                        var maxArea1 = MaxArea(i, j);
                        if (maxArea1 > maxArea)
                        {
                            maxArea = maxArea1;
                        }
                    }
                }
            }
        }

        public int MaxArea(int bigArrayIndex, int smallArrayIndex)
        {
            if (bigArrayIndex < 0 || bigArrayIndex >= ArrayOfArrays.Length || smallArrayIndex < 0 ||
                smallArrayIndex >= ArrayOfArrays[bigArrayIndex].Length)
            {
                //shouldn't return 0.
                return 0;
            }

            var valA = MaxArea(bigArrayIndex - 1,smallArrayIndex);
            var valB = MaxArea(bigArrayIndex + 1,smallArrayIndex);
            var valC = MaxArea(bigArrayIndex - 1,smallArrayIndex - 1);
            var valD = MaxArea(bigArrayIndex - 1, smallArrayIndex + 1);

            return 1 + valA + valB + valC + valD;
        }
    }
}
