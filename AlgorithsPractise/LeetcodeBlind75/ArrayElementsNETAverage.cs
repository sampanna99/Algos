using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithsPractise.LeetcodeBlind75
{
    public class ArrayElementsNETAverage
    {
        public int[] Array { get; set; }


        public ArrayElementsNETAverage()
        {
            Array = new[] { 1, 4,5,3,2 };
        }


        public void ActualAlgo()
        {
            SortItQuick(0, Array.Length - 1);

            var queue = new Queue<int>();
            var skip = 0;
            for (int i = 1; i < Array.Length - 1; i++)
            {
                if (skip + i < Array.Length)
                {
                    skip += 1;
                    queue.Enqueue(Array[i + skip]);
                    Array[i + skip] = Array[i];
                    //Array[i] = Array[i + skip];
                }
            }

            var firstLocation = 1;
            while (queue.Count > 0)
            {
                Array[firstLocation] = queue.Dequeue();
                firstLocation += 2;
            }
        }


        //QuickSort. //Divide and conquer // in place //

        public void SortItQuick(int startIndex, int endIndex)
        {
            if (startIndex < endIndex)
            {
                var partitionIndex = PartitionAndSwap(startIndex, endIndex);
                SortItQuick(startIndex, partitionIndex - 1);
                SortItQuick(partitionIndex + 1, endIndex);
            }
        }
        public int PartitionAndSwap(int startindex, int endIndex)
        {

            var pivot = Array[endIndex];
            var partitionIndex = startindex;

            for (int i = startindex; i < endIndex; i++)
            {
                if (pivot < Array[i])
                {
                    (Array[i], Array[partitionIndex]) = (Array[partitionIndex], Array[i]);
                    partitionIndex++;
                    //var arrayValAti = Array[i];
                    //Array[i] = Array[partitionIndex];
                    //Array[partitionIndex] = arrayValAti;
                }
            }
            (Array[endIndex], Array[partitionIndex]) = (Array[partitionIndex], Array[endIndex]);
            return partitionIndex;
        }
    }
}
 