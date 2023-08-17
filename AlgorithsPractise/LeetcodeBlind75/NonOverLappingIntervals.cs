using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithsPractise.LeetcodeBlind75
{
    class NonOverLappingIntervals
    {
        public int[][] Intervals { get; set; }
        public NonOverLappingIntervals()
        {
            Intervals = new[] { new[] { 1, 2 },
                new[] { 2,3 },
                new[] { 3, 4 },
                new[] { 1,3 }
            };
        }
        public void QuickSort(int[][] listofInts, int startIndex, int endIndex)
        //public void QuickSort(List<int> listofInts, int startIndex, int endIndex)
        {
            if (startIndex > endIndex)
            {
                return;
            }
            var partitionIndex = ReturnPartitionIndex(listofInts, 0, listofInts.Length - 1);
            QuickSort(listofInts, startIndex, partitionIndex - 1);
            QuickSort(listofInts, partitionIndex - 1, endIndex);
        }
        public int ReturnPartitionIndex(int[][] listOfints, int startIndex, int endIndex)
        //public int ReturnPartitionIndex(List<int> listOfints, int startIndex, int endIndex)
        {
            var pivot = listOfints[endIndex];
            var pivotIndex = startIndex;

            for (int i = 0; i < endIndex; i++)
            {
                if (listOfints[i][0] < pivot[0])
                {
                    //var valueAti = listOfints[i];
                    //listOfints[i] = listOfints[pivotIndex];
                    //listOfints[pivotIndex] = valueAti;

                    //swap via declaration
                    (listOfints[i], listOfints[pivotIndex]) = (listOfints[pivotIndex], listOfints[i]);
                    pivotIndex += 1;
                }
            }
            (listOfints[endIndex], listOfints[pivotIndex]) = (listOfints[pivotIndex], listOfints[endIndex]);
            return pivotIndex;
        }

        public void RemoveArray()
        {
            var listofEachStatement = new List<int>();

            foreach (var interval in Intervals)
            {
                listofEachStatement.Add(interval[0]);
            }

            QuickSort(Intervals, 0, listofEachStatement.Count);
            //QuickSort(listofEachStatement, 0, listofEachStatement.Count);

            //SortTheInterval(listofEachStatement, 0, listofEachStatement.Count - 1);

            //maybe converting to a list and removing that index and back to array.

            //https://stackoverflow.com/questions/457453/remove-element-of-a-regular-array
            //var foos = new List<Foo>(array);
            //foos.RemoveAt(index);
            //return foos.ToArray();
            var listofindexToRemove = new List<int>();

            for (int i = 0; i < Intervals.Length - 1; i++)
            {
                if (Intervals[i][1] < Intervals[i + 1][0] || 
                    (Intervals[i + 1][1] < Intervals[i][0]))
                {
                    continue;
                }
                else
                {
                    var endOfFirst = Intervals[i][1];
                    var endOfSecond = Intervals[i + 1][1];

                    if (endOfSecond > endOfFirst)
                    {
                        //remove second
                        listofindexToRemove.Add(i + 1);
                        i = i + 1;
                    }
                    else
                    {
                        listofindexToRemove.Add(i);
                        //remove first
                    }
                }
            }


        }
    }
}
