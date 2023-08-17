using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace AlgorithsPractise.LeetcodeBlind75
{
    public class LISAllPossibilites
    {
        public int[] Array { get; set; }

        //all below first list and all in the second list.
        public Dictionary<int, List<int>> StartLengthBelowAllBelow { get; set; }
        //public Dictionary<int, Tuple<List<int>, List<int>>> StartLengthBelowAllBelow { get; set; }
        public int MaxSubsequence { get; set; } = Int32.MinValue;
        public LISAllPossibilites()
        {
            Array = new[] { 1, 2, 4, 3 };
            StartLengthBelowAllBelow = new Dictionary<int, List<int>>();
            //StartLengthBelowAllBelow = new Dictionary<int, Tuple<List<int>, List<int>>>();
        }

        public void DFS()
        {
            DFSWithCache(new Stack<int>());
        }

        //tuple length below and values below
        public (List<int>, List<int>) DFSWithCache(Stack<int> ValuesUntil, int startingIndex = 0)
        {
            if (startingIndex >= Array.Length)
            {
                return (new List<int>(), ValuesUntil.ToList());
            }

            if (StartLengthBelowAllBelow.ContainsKey(Array[startingIndex]))
            {
                var list = new List<int>(ValuesUntil);
                //list.Add(Array[startingIndex]);
                return (StartLengthBelowAllBelow[Array[startingIndex]], list);
            }

            var allbelow = new List<int>();
            var allOfThem = new List<int>(ValuesUntil);
            //var allOfThem = new List<int>();
            for (int i = startingIndex; i < Array.Length; i++)
            {
                if (startingIndex - 1 >= 0)
                {
                    if (Array[startingIndex - 1] > Array[i])
                    {
                        continue;
                    }

                }
                ValuesUntil.Push(Array[i]);
                var allValuesAndLengthBelow = DFSWithCache(ValuesUntil, i + 1);

                StartLengthBelowAllBelow.Add(Array[i], allValuesAndLengthBelow.Item1);

                if (allValuesAndLengthBelow.Item2.Count > allOfThem.Count)
                {
                    allbelow = allValuesAndLengthBelow.Item1;
                    allOfThem = allValuesAndLengthBelow.Item2;
                }

                ValuesUntil.Pop();
            }

            if (MaxSubsequence < allOfThem.Count)
            {
                MaxSubsequence = allOfThem.Count;

                //allbelow.Add(allOfThem[0]);
            }
            if (allOfThem.Count != ValuesUntil.Count)
            {
                allbelow.Add(allOfThem[0]);
            }

            return (allbelow, allOfThem);
        }

        public void IncludeOrnoteach()
        {
            for (int i = 0; i < Array.Length; i++)
            {
                var valueWithIncluded = IncludeNotInclude(i, true, new Stack<int>());
                var valueWithNotIncluded = IncludeNotInclude(i, false, new Stack<int>());
            }
        }
        public List<int> IncludeNotInclude(int indexToStartFrom, bool include, Stack<int> valuesUntil)
        {

            if (indexToStartFrom == Array.Length)
            {
                var list = new List<int>(valuesUntil);

                if (MaxSubsequence < list.Count)
                {
                    MaxSubsequence = list.Count;
                }
                
                return list;
            }
            var value = valuesUntil.Count > 0 ? valuesUntil.Peek() : Int32.MinValue;

            valuesUntil.Push(Array[indexToStartFrom]);

            List<int> withIncluded;
            if (Array[indexToStartFrom] >= value)
            {
                withIncluded = IncludeNotInclude(indexToStartFrom + 1, true, valuesUntil);
            }
            else
            {
                withIncluded = new List<int>(valuesUntil);
            }
            valuesUntil.Pop();
            var withoutIncluded = IncludeNotInclude(indexToStartFrom + 1, false, valuesUntil);

            if (withoutIncluded.Count > withIncluded.Count)
            {
                return withoutIncluded;
            }
            else
            {
                return withIncluded;
            }
        }
    }
}
