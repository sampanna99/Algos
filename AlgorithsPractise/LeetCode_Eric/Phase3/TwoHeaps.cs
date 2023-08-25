using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithsPractise.LeetCode_Eric.Phase3
{
    public class TwoHeaps
    {
    }

    //https://www.youtube.com/watch?v=itmhHWaHupI
    //Leetcode 295
    public class MedianDataStream
    {
        public List<int> AnsGivList{ get; set; }
        public int[][] ThingsToDo { get; set; }
        public string[] Actions { get; set; }
        public MedianDataStream()
        {
            AnsGivList = new List<int>();
            ThingsToDo = new[]
            {
                new []{1},
                new []{2},
                Array.Empty<int>(),
                new []{3},
                Array.Empty<int>()
            };
            Actions = new[] { "addNum", "addNum", "findMedian", "addNum", "findMedian" };
        }
        public void Algorithmn()
        {
            var smallHeap = new List<int>();
            var bigHeap = new List<int>();

            for (int i = 0; i < Actions.Length; i++)
            {
                if (Actions[i] == "addNum")
                {
                    //add it to the heap
                    AddToTheheap(smallHeap, bigHeap, ThingsToDo[i][0]);
                }
            }

            var median = Int32.MaxValue;
            if (bigHeap.Count == smallHeap.Count)
            {
                var valAtB = bigHeap[0];
                var valatS = smallHeap[0];

                median = (valAtB + valatS) / 2;
            }
            else
            {
                var whichHeap = bigHeap.Count > smallHeap.Count ? bigHeap : smallHeap;
                median = whichHeap[0];
            }
        }

        private void AddToTheheap(List<int> smallHeap, List<int> bigHeap, int toAdd)
        {
            smallHeap.Add(toAdd);
            Heapify(smallHeap, true);
            //now check if maintains the property
            var lengthS = smallHeap.Count;
            var lengthB = bigHeap.Count;

            var valueSm = smallHeap[0];
            var valueLg = lengthB > 0 ? bigHeap[0] : Int32.MinValue;
            //biggest in small heap is smaller or equal to smallest in bigheap
            if (valueSm > valueLg)
            {
                Remove(smallHeap, true);
            }
            else
            {
                Remove(bigHeap, false);
            }

            //no more than 1 element difference
            while (Math.Abs(lengthB - lengthS) > 1)
            {
                if (lengthB > lengthS)
                {
                    //big needs to be trimmed
                    Remove(bigHeap, false);
                }
                else
                {
                    //small needs to be trimmed
                    Remove(smallHeap, false);
                }
                lengthS = smallHeap.Count;
                lengthB = bigHeap.Count;
            }
        }

        //this one adds
        private void Heapify(List<int> inTheHeap, bool isSmall = true)
        {
            var addedVal = inTheHeap[^1];
            var child = inTheHeap.Count;
            var parent = (addedVal + 1) / 2;

            if (isSmall)
            {
                while (child <= 1 && 
                       inTheHeap[parent - 1] < inTheHeap[child - 1])
                {
                    //switch
                    var parentMinus1 = parent - 1;
                    var childMinus1 = child - 1;

                    (inTheHeap[parentMinus1], inTheHeap[childMinus1]) = 
                        (inTheHeap[childMinus1], inTheHeap[parentMinus1]);
                    //var valueAtParent = inTheHeap[parentMinus1];
                    //inTheHeap[parentMinus1] = inTheHeap[childMinus1];
                    //inTheHeap[childMinus1] = valueAtParent;
                    child = parent;
                    parent /= 2;
                }
            }
            else
            {
                while (child <= 1 &&
                       inTheHeap[parent - 1] > inTheHeap[child - 1])
                {
                    //switch
                    var parentMinus1 = parent - 1;
                    var childMinus1 = child - 1;

                    (inTheHeap[parentMinus1], inTheHeap[childMinus1]) =
                        (inTheHeap[childMinus1], inTheHeap[parentMinus1]);
                    child = parent;
                    parent /= 2;
                }
            }
        }

        private void Remove(List<int> inTheHeap, bool isSmall = true)
        {
            var removeVal = inTheHeap[0];
            inTheHeap[0] = inTheHeap[^1];
            inTheHeap.RemoveAt(inTheHeap.Count - 1);
            Heapify(inTheHeap, isSmall);
        }
    }

    public class SlidingWindowMedian
    {
        public int[] GivenArray { get; set; }
        public int KVal { get; set; }
        public SlidingWindowMedian()
        {
            
        }

        public void Algorithmn()
        {
            var minBigHeap = new List<int>();
            var maxSmallHeap = new List<int>();

            //make sure min heap >= max Heap 's first value
            //second gotta make sure they are height balanced

            for (int i = 0; i < GivenArray.Length; i++)
            {
                if (i < KVal - 1)
                {
                    Heapify(maxSmallHeap, GivenArray[i]);
                }
                //remove one 

                //add one aka heapify again
            }
        }

        public void Heapify(List<int> heapToAdd, int valueToAdd, bool isMaxHeap)
        {
            heapToAdd.Add(valueToAdd);
            var (addedLocation, parent) = (heapToAdd.Count - 1, (heapToAdd.Count + 1) / 2);
            if (isMaxHeap)
            {
                while (addedLocation != parent && heapToAdd[parent] < heapToAdd[addedLocation])
                {
                    //have to switch
                    (heapToAdd[addedLocation], heapToAdd[parent]) = 
                        (heapToAdd[parent], heapToAdd[addedLocation]);

                    addedLocation = parent;
                    parent /= 2;
                }
            }
        }
    }

    public class SlidingWindowMaximum
    {
        public int[] GivenArray { get; set; }
        public int KVal { get; set; }


        public SlidingWindowMaximum()
        {
            
        }
        public void Algorithmn()
        {
            var listofAns = new List<int>();
            var answer = new List<int>();
            //get upto the k val
            for (int i = 0; i < GivenArray.Length; i++)
            {
                var lastvalue = listofAns[^1];
                var iVal = GivenArray[i];

                if (iVal > lastvalue)
                {
                    //got to pop it out
                    var lastval = listofAns[^1];
                    while (lastval > iVal && listofAns.Count != 0)
                    {
                        listofAns.RemoveAt(listofAns.Count - 1);
                        if (listofAns.Count > 0)
                        {
                            lastval = listofAns[^1];
                        }
                    }
                }
                listofAns.Add(iVal);

                if (i < KVal - 1)
                {
                    continue;
                }

                answer.Add(listofAns[0]);
                //remove
                if (listofAns.Count >= KVal)
                {
                    answer.RemoveAt(0);
                }
            }
        }
    }
}
