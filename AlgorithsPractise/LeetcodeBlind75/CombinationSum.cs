using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgorithsPractise.LeetcodeBlind75
{
    public class CombinationSum
    {
        public int[] Array { get; set; }
        public int Sum { get; set; } = 7;

        public List<List<int>> AllListOfInts { get; set; }
        public CombinationSum()
        {
            Array = new[] { 2, 3, 6, 7 };
            AllListOfInts = new List<List<int>>();
        }

        public void CallForAllCombinations()
        {
            Combinations(0, new Stack<int>());
        }
        public void Combinations(int indexToStartFrom, Stack<int> ValuesUpUntilThen)
        {
            if (indexToStartFrom == Array.Length)
            {
                return;
            }
            ValuesUpUntilThen.Push(Array[indexToStartFrom]);
            var sum = ValuesUpUntilThen.Sum();
            if (sum == Sum)
            {
                var listToadd = new List<int>(ValuesUpUntilThen);
                AllListOfInts.Add(listToadd);
            }
            else if (sum < Sum)
            {
                Combinations(indexToStartFrom, ValuesUpUntilThen);
            }
            ValuesUpUntilThen.Pop();

            //Maybe add one more line like sum < Sum here.
            Combinations(indexToStartFrom + 1, ValuesUpUntilThen);
        }

    }
}
