using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithsPractise.LeetcodeBlind75
{
    public class MaximumSubarray
    {
        public int[] Inputs { get; set; }
        public MaximumSubarray()
        {
            Inputs = new[] { -2, -1, -3, 4, -1, 2, 1, -5, 4 };
        }

        public void MaximumSubarrayValues()
        {
            var maxSum = 0;
            var currSum = 0;
            (var startPositionMax, var endPositionMax) = (-1, -1);
            (var startPositionCurr, var endPositionCurr) = (0, 0);
            var updateStart = true;
            for (int i = 0; i < Inputs.Length; i++)
            {
                var sum = currSum + Inputs[i];
                if (sum > 0)
                {
                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        endPositionMax = i;
                        startPositionMax = startPositionCurr;
                    }
                    endPositionCurr = i;
                }
                else
                {
                    startPositionCurr = i + 1;
                }
            }

            Console.WriteLine($"The max sum is {maxSum} Starting at index {startPositionMax} and " +
                              $"ending at {endPositionMax}");
        }
    }
}
