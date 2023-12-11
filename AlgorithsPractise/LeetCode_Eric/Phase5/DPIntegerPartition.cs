using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgorithsPractise.LeetCode_Eric.Phase5
{
    public class DPIntegerPartition
    {


    }

    public class DPIntegerBreak
    {
        public int GivenIntToBreak { get; set; }
        public Dictionary<int, int> MemoDictionary { get; set; }
        public DPIntegerBreak()
        {
            MemoDictionary = new Dictionary<int, int>();
        }
        

        //Add 1, 2,3 in the memodictionary before even starting.
        public int DFSApproach(int integer)
        {
            //base case
            if (integer <= 3)
            {
                return integer;
            }

            if (MemoDictionary.ContainsKey(integer))
            {
                return MemoDictionary[integer];
            }

            var max = Int32.MinValue;
            for (int i = 2; i < integer; i++)
            {
                var remaining = integer - i;

                var maxMultiplyI = MemoDictionary.ContainsKey(i) ? MemoDictionary[remaining] :
                    DFSApproach(i);
                var maxMultiplySe = MemoDictionary.ContainsKey(remaining) ? MemoDictionary[remaining] :
                    DFSApproach(remaining);

                //definitely do it better
                MemoDictionary[i] = maxMultiplyI;
                MemoDictionary[remaining] = maxMultiplySe;

                var multiplied = maxMultiplyI * maxMultiplySe;

                if (multiplied > max)
                {
                    max = multiplied;
                }
            }

            MemoDictionary[integer] = max;
            return max;
        }

        public int DPApproach()
        {
            if (GivenIntToBreak <= 3)
            {
                return GivenIntToBreak - 1;
            }

            var intArr = new int[GivenIntToBreak + 1];

            intArr[1] = 1;
            intArr[2] = 2;
            intArr[3] = 3;

            for (int i = 4; i <= GivenIntToBreak; i++)
            {
                var max = Int32.MinValue;
                for (int j = 2; j <= i / 2; j++)
                {
                    var remaining = i - j;
                    var multiply = intArr[j] * intArr[remaining];
                    if (multiply > max)
                    {
                        max = multiply;
                    }
                }

                if (i != GivenIntToBreak)
                {
                    intArr[i] = Math.Max(max, i);
                }
                else
                {
                    intArr[i] = max;
                }
            }

            return intArr[^1];
        }
    }

    public class PerfectSquares
    {
        public int GivenInteger { get; set; }
        public Dictionary<int, List<int>> MemoDictionary { get; set; }
        public PerfectSquares()
        {
            MemoDictionary = new Dictionary<int, List<int>>();
        }

        public List<int> DFSAlgo(int sumRemaining)
        {
            //base case if sum is over
            if (sumRemaining == 0)
            {
                return new List<int>();
            }

            if (MemoDictionary.ContainsKey(sumRemaining))
            {
                return MemoDictionary[sumRemaining];
            }
            var least = Enumerable.Repeat(1, sumRemaining).ToList();
            //var least = sumRemaining;

            for (int i = 2; Math.Pow(i, 2) <= sumRemaining; i++)
            {
                var value = Math.Pow(i, 2);
                var remaining = (int)(sumRemaining - value);
                var listReturn = MemoDictionary.ContainsKey(remaining) ? MemoDictionary[remaining]
                    :DFSAlgo(remaining);
                listReturn.Add(i);
                if (least.Count > listReturn.Count)
                {
                    least = listReturn;
                }
            }

            MemoDictionary.Add(sumRemaining, least);
            return least;
        }
    }
}
