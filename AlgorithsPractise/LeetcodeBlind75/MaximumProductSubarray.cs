using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithsPractise.LeetcodeBlind75
{
    public class MaximumProductSubarray
    {
        public int[] Input { get; set; }

        public MaximumProductSubarray()
        {
            Input = new[] { 2, 3, -2, 4 };
        }

        public void MaximumSubArr()
        {
            (var max, var min) = (1, 1);
            (var maxCurr, var minCurr) = (1, 1);
            (var startIndex, var endIndex) = (0, 0);
            (var startIndexCurr, var endIndexCurr) = (0, 0);

            for (int i = 0; i < Input.Length; i++)
            {
                if (Input[i] == 0)
                {
                    startIndexCurr = i + 1;
                }

                var multiPlyWithMax = maxCurr * Input[i];
                var multiPlyWithMin = minCurr * Input[i];
                if (multiPlyWithMax > maxCurr
                || multiPlyWithMin > minCurr)
                {
                    maxCurr = Convert.ToInt32(Math.Max(multiPlyWithMax, multiPlyWithMin));
                    if (maxCurr > max)
                    {
                        startIndex = startIndexCurr;
                        endIndex = i;
                    }
                    endIndexCurr = i;
                }
                else
                {
                    startIndexCurr = i + 1;
                }
            }

            Console.WriteLine($"The maximum Product Subarray is {max} and the index is from {startIndex}" +
                              $" to {endIndex}");
        }
    }
}
