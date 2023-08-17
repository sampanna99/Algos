using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithsPractise.LeetcodeBlind75
{
    public class InsertInterval
    {
        public int[][] ArrayOfIntervals { get; set; }
        public int[] IntervalToAdd { get; set; }
        public List<int[]> ReturnArray { get; set; }

        public InsertInterval()
        {
            //ArrayOfIntervals = new int[2][];
            ArrayOfIntervals = new int[][]
            {
                new[] { 1, 2 },
                new[] { 3, 5 },
                new[] { 6, 7 },
                new[] { 8, 10 },
                new[] { 12, 16 },
            };
            IntervalToAdd = new int[] { 4, 9 };
            ReturnArray = new List<int[]>();
        }

        public List<int[]> AllIntervals()
        {
            var doneUpto = recurse(ArrayOfIntervals[0], IntervalToAdd, 1);
            while (doneUpto < ArrayOfIntervals.Length)
            {
                doneUpto = recurse(ArrayOfIntervals[doneUpto], IntervalToAdd, doneUpto + 1);
            }

            return ReturnArray;
        }

        private int recurse(int[] givenarray, int[] addarray, int num)
        {
            if (num > ArrayOfIntervals.Length)
            {
                ReturnArray.Add(givenarray);
                return ArrayOfIntervals.Length;
            }
            var isininterval = IsInTheInterval(givenarray, addarray);
            
            if (isininterval.Item1 == true)
            {
                return recurse(isininterval.Item2, addarray, num + 1);
            }
            else
            {
                ReturnArray.Add(isininterval.Item2);
            }

            return num;
        }
        private Tuple<bool, int[]> IsInTheInterval(int[] givenInterval, int[] toBeInserted)
        {
            if (givenInterval[1] > toBeInserted[0] && toBeInserted[1] > givenInterval[0])
            {
                var intToReturn = new int[]
                {
                    Math.Min(givenInterval[0], toBeInserted[0]),
                    Math.Max(givenInterval[1], toBeInserted[1])

                };
                return Tuple.Create(true, intToReturn);
            }

            return Tuple.Create(false, givenInterval);
        }

    }
}
