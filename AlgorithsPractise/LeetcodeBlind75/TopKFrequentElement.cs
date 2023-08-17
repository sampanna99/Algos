using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgorithsPractise.LeetcodeBlind75
{
    public class TopKFrequentElement
    {
        public int[] GivenArray { get; set; }
        public int NumberofFrequent { get; set; }

        public int[][] FrequentVsNumber { get; set; }
        //public Dictionary<int, List<int>> FrequentVsNumber { get; set; }
        public Dictionary<int, int> NumberVsNumberOfTimes { get; set; }
        public TopKFrequentElement()
        {
            //GivenArray = new int[5];
            GivenArray = new[] { 1, 1, 1, 2, 2, 100 };
            FrequentVsNumber = new int[GivenArray.Length + 1][];
            //FrequentVsNumber = new Dictionary<int, List<int>>();
            NumberVsNumberOfTimes = new Dictionary<int, int>();
        }
        public void FindTheKFrequent()
        {
            foreach (var value in GivenArray)
            {
                if (NumberVsNumberOfTimes.ContainsKey(value))
                {
                    NumberVsNumberOfTimes[value] += 1;
                }
                else
                {
                    NumberVsNumberOfTimes[value] = 1;
                }
            }

            foreach (var numberVsNumberOfTime in NumberVsNumberOfTimes)
            {
                var key = numberVsNumberOfTime.Key;
                var value = numberVsNumberOfTime.Value;

                if (FrequentVsNumber[value] == null)
                {
                    FrequentVsNumber[value] = new [] { key };
                }
                else
                {
                    var array = FrequentVsNumber[value];
                    var list = array.ToList();
                    list.Add(value);
                    FrequentVsNumber[value] = list.ToArray();
                }
            }

            var toreturn = new List<int>();
            var numberOfItemsFound = 0;
            for (int i = FrequentVsNumber.Length - 1; i >= 0; i--)
            {
                if (numberOfItemsFound >= 2)
                {
                    break;
                }
                if (FrequentVsNumber[i] != null)
                {
                    foreach (var i1 in FrequentVsNumber[i])
                    {
                        toreturn.Add(i1);
                    }
                    numberOfItemsFound += 1;
                }
                else
                {
                    continue;
                }
            }

            Console.WriteLine("values in toreturn are the actual numbers ti return");
        }
    }
}
