using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithsPractise.LeetcodeSolutions
{
    public class SubArraySumEqualsK
    {
        public int SumToMake { get; set; } = 7;

        public int[] ArrayOfNums { get; set; }

        public Dictionary<int, List<int>> PrefixSumArr { get; set; }

        public SubArraySumEqualsK()
        {
            ArrayOfNums = new[] { 3, 4, 7, 2, -3, 1, 4, 2 };
            PrefixSumArr = new Dictionary<int, List<int>>();
        }

        public void Algorithmn()
        {
            var valuesWithIndesesResult = new List<string>();
            var initialVal = 0;
            for (int i = 0; i < ArrayOfNums.Length; i++)
            {
                var val = ArrayOfNums[i] + initialVal;
                initialVal = val;

                if (PrefixSumArr.ContainsKey(val))
                {
                    PrefixSumArr[val].Add(i);
                }
                else
                {
                    PrefixSumArr.Add(val, new List<int>{i});
                }

                var sumRemaining = val - SumToMake;

                if (i != 0 && ArrayOfNums[i] == SumToMake)
                {
                    valuesWithIndesesResult.Add($"{i} to {i}");
                }

                if (val == SumToMake)
                {
                    valuesWithIndesesResult.Add($"0 to {i}");
                }
                else if (PrefixSumArr.ContainsKey(sumRemaining))
                {
                    var allindexes = PrefixSumArr[sumRemaining];
                    foreach (var each in PrefixSumArr)
                    {
                        valuesWithIndesesResult.Add($"{each} to {i}");
                    }
                }
            }
        }
    }
}
