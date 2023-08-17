using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithsPractise.LeetcodeBlind75
{

    //DFS way
    public class ClimbingStairs
    {
        public int[] StepsThatCouldBeTaken { get; set; }
        public int NumberOfSteps { get; set; } = 5;
        public Dictionary<int,int> NumberOfways { get; set; }
        public ClimbingStairs()
        {
            StepsThatCouldBeTaken = new[] { 1, 2 };
            NumberOfways = new Dictionary<int, int>();
        }

        public int ClimbingSteps(int whichStepYouin = 0)
        {
            if (NumberOfways.ContainsKey(whichStepYouin))
            {
                return NumberOfways[whichStepYouin];
            }

            if (whichStepYouin == NumberOfSteps)
            {
                return 1;
            }
            if (whichStepYouin > NumberOfSteps)
            {
                return 0;
            }

            var totalWays = 0;
            for (int i = 0; i < StepsThatCouldBeTaken.Length; i++)
            {
                totalWays += ClimbingSteps(StepsThatCouldBeTaken[i]);
            }

            NumberOfways.Add(whichStepYouin, totalWays);
            return totalWays;
        }
    }
}
