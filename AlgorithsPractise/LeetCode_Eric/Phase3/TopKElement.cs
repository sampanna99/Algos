using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithsPractise.LeetCode_Eric.Phase3
{
    //TODO: again heap and merge sort;
    public class TopKElement
    {

    }

    //neetcode
    //https://www.youtube.com/watch?v=YPTqKIgVk-k
    public class TopKFrequent
    {
        public int[] GivenArrayOfInteger { get; set; }
        public int HowManyK { get; set; }
        public Dictionary<int, List<int>> Dictionary { get; set; }
        public TopKFrequent()
        {
            Dictionary = new Dictionary<int, List<int>>(GivenArrayOfInteger.Length);
        }
        public void Algorithmn()
        {
            var dict = new Dictionary<int, int>();
            for (int i = 0; i < GivenArrayOfInteger.Length; i++)
            {
                if (dict.ContainsKey(GivenArrayOfInteger[i]))
                {
                    dict[GivenArrayOfInteger[i]] += 1;
                }
                else
                {
                    dict[GivenArrayOfInteger[i]] = 1;
                }
            }

            foreach (var i in dict)
            {
                var value = i.Value;

                Dictionary[value].Add(i.Key);
            }

            var addedNum = 0;
            var ans = new List<int>();
            for (int i = Dictionary.Count - 1; i >= 0 ; i--)
            {
                if (addedNum == HowManyK)
                {
                    break;
                }

                var values = Dictionary[i];
                if (values.Count > 0)
                {
                    addedNum += 1;
                    foreach (var value in values)
                    {
                        ans.Add(value);
                    }
                }
            }
        }
    }

    //https://www.youtube.com/watch?v=vltY5jxqcco
    public class SortCharByFrequency
    {
        public string GivenString { get; set; } = "tree"; //eetr or eert

        public Dictionary<int, List<string>> Dictionary { get; set; }
        //for Aabb it's bbAa or bbaA 

        public SortCharByFrequency()
        {
            //initialize dictionary up unti 55;
            Dictionary = new Dictionary<int, List<string>>();
        }

        public void Algorithmn()
        {
            var dictOfChar = new Dictionary<char, int>();
            foreach (var val in GivenString)
            {
                if (dictOfChar.ContainsKey(val))
                {
                    dictOfChar[val] += 1;
                }
                else
                {
                    dictOfChar[val] = 1;
                }

            }

            foreach (var i in dictOfChar)
            {

                if (Dictionary.ContainsKey(i.Value))
                {
                    Dictionary[i.Value].Add(i.Key.ToString());
                }
                else
                {
                    Dictionary[i.Value] = new List<string> { i.Key.ToString() };
                }
            }

            var stringToReturn = GetReversed(Dictionary.Count - 1);
        }

        private string GetReversed(int start)
        {

            if (start < 0)
            {
                return "";
            }
            var value = Dictionary[start];
            StringBuilder stringTopass = new StringBuilder();
            if (value != null && value.Count > 1)
            {
                foreach (var val in value)
                {
                    stringTopass.Append(new string(val.ToCharArray()[0], start));
                }

            }

            return stringTopass.Append(GetReversed(start - 1)).ToString();
        }
    }

    //leetcode 973
    //https://www.youtube.com/watch?v=rI2EBUEMfTk
    public class KClosestPointsToOrigin
    {
        public List<List<int>> GivenListOfArrays { get; set; }
        public int[] GivenRoot { get; set; }
        public int KValue { get; set; }
        public KClosestPointsToOrigin()
        {
            GivenListOfArrays = new List<List<int>>();
            GivenRoot = new[] { 0, 0 };
        }

        public void Algorithmn()
        {
            //find the distance
            for (int i = 0; i < GivenListOfArrays.Count; i++)
            {
                var xDistance = GivenListOfArrays[i][0] - GivenRoot[0];
                var yDistance = GivenListOfArrays[i][1] - GivenRoot[1];
                var distance = (xDistance * xDistance) + (yDistance * yDistance);
                GivenListOfArrays[i][2] = distance;
                Heapify(i);
            }

            var answer = new List<List<int>>();
            for (int i = 0; i <= KValue; i++)
            {
                var getVal = GetValueFromMinHeap();
                answer.Add(getVal);
            }
        }

        public void Heapify(int index)
        {
            var checkparent = (index + 1) / 2;
            var pointerIndex = index;
            var valueAtInd = GivenListOfArrays[pointerIndex];
            while (checkparent != 0)
            {
                var valueAtParent = GivenListOfArrays[checkparent][2];

                if (valueAtParent < valueAtInd[2])
                {
                    //switch
                    var tempVal = GivenListOfArrays[checkparent];
                    GivenListOfArrays[checkparent] = valueAtInd;
                    GivenListOfArrays[pointerIndex] = tempVal;
                    pointerIndex = checkparent;
                    checkparent = (pointerIndex + 1) / 2;
                }
                else
                {
                    break;
                }
            }
        }

        public List<int> GetValueFromMinHeap()
        {
            var returnvalue = GivenListOfArrays[0];

            //now heapify
            var lastone = GivenListOfArrays[^1];
            GivenListOfArrays[0] = lastone;
            lastone = null;
            var parentI = 1;
            var (child1, child2) = (parentI * 2, parentI * 2 + 1);
            while (child1 <= GivenListOfArrays.Count)
            {
                var valueAtChild1 = GivenListOfArrays[child1 - 1];
                var valueAtChild2 = (child2 != GivenListOfArrays.Count &&
                                     GivenListOfArrays[child2 - 1] != null)
                    ? GivenListOfArrays[child2 - 1]
                    : null;
                var smallerOne = valueAtChild1;
                var smallerIndex = child1 - 1;
                if (valueAtChild2 != null)
                {
                    if (valueAtChild1[2] > valueAtChild2[2])
                    {
                        smallerOne = valueAtChild2;
                        smallerIndex = child2 - 1;
                    }
                }

                if (GivenListOfArrays[parentI - 1][2] < smallerOne[2])
                {
                    break;
                }
                else
                {
                    //swap
                    var temp = GivenListOfArrays[parentI - 1];
                    GivenListOfArrays[parentI - 1] = smallerOne;
                    GivenListOfArrays[smallerIndex] = temp;

                    parentI = smallerIndex + 1;
                    (child1, child2) = (parentI * 2, parentI * 2 + 1);
                }
            }

            return returnvalue;
        }
    }
}
