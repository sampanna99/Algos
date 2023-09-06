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
            var answer = new List<int>();
            //make sure min heap >= max Heap 's first value
            //second gotta make sure they are height balanced

            for (int i = 0; i < GivenArray.Length; i++)
            {
                maxSmallHeap.Add(GivenArray[i]);
                Heapify(maxSmallHeap, GivenArray[i], true);
                if (i < KVal - 1)
                {
                    //Heapify(maxSmallHeap, GivenArray[i], true);
                    continue;
                }
               
                //balance the height
                BalanceHeight(minBigHeap, maxSmallHeap);
                //find the median
                if (minBigHeap.Count == maxSmallHeap.Count)
                {
                    var fromminBig = minBigHeap[0];
                    var frommaxSmall = maxSmallHeap[0];
                    var median = (frommaxSmall + fromminBig) / 2;
                    answer.Add(median);
                }
                else
                {
                    var whichoneIsBig = maxSmallHeap.Count > minBigHeap.Count ? maxSmallHeap : minBigHeap;
                    answer.Add(whichoneIsBig[0]);
                }
                //remove one
                var indexToRemoveFrom = i - KVal - 1;
                var valueToRemove = GivenArray[indexToRemoveFrom];
                if (maxSmallHeap[0] < valueToRemove)
                {
                    RemoveFromHeapCertainNum(minBigHeap, valueToRemove, false);
                }
                else
                {
                    RemoveFromHeapCertainNum(maxSmallHeap, valueToRemove, true);
                }

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
            else
            {
                while (addedLocation != parent && heapToAdd[parent] > heapToAdd[addedLocation])
                {
                    //have to switch
                    (heapToAdd[addedLocation], heapToAdd[parent]) =
                        (heapToAdd[parent], heapToAdd[addedLocation]);

                    addedLocation = parent;
                    parent /= 2;
                }
            }
        }

        public void RemoveFromHeapCertainNum(List<int> heap, int val, bool ismaxSmall)
        {
            //var (parent, child1, child2) = (1, 2, 3);
            //var removeAtIndex = Int32.MinValue;
            //while (child1 < heap.Count - 1)
            //{
            //    if (heap[child1] == val || heap[child2] == val)
            //    {
            //        removeAtIndex = heap[child1] == val ? child1 - 1 : child2 - 1;
            //    }
            //    else
            //    {
                    
            //    }
            //}
            //REMOVING ELEMENTS IN THE MIDDLE DIDN"T MAKE SENSE
            for (int i = 0; i < heap.Count; i++)
            {
                if (heap[i] == val)
                {
                    heap.RemoveAt(i);
                    break;
                }
            }

        }
        public int RemoveHeap(List<int> heap, bool ismaxSmallHeap)
        {
            var removedVal = heap[0];
            heap[0] = heap[^1];
            heap.RemoveAt(heap.Count - 1);

                var (parent, child1, child2) = (1, 2, 3);

                while (child1 - 1 <= heap.Count - 1)
                {
                    //is child2 present
                    //biggestOne is also the smallest one
                    var biggestOne = Int32.MinValue;
                    var indexBiggest = 1;
                    if (child2 -1 < heap.Count - 1)
                    {
                        var (parentVal, child1Val, child2Val) =
                            (heap[parent], heap[child1 - 1], heap[child2 - 1]);

                        if (ismaxSmallHeap)
                        {
                            (biggestOne, indexBiggest) = child1Val > child2Val ?
                                (child1Val, child1) : (child2Val, child2);
                            if (parentVal > biggestOne)
                            {
                                break;
                            }

                        }
                        else
                        {
                            (biggestOne, indexBiggest) = child1Val < child2Val ?
                                (child1Val, child1) : (child2Val, child2);
                            if (parentVal < biggestOne)
                            {
                                break;
                            }
                        }

                    }
                    else
                    {
                        //just child1
                        var (parentVal, child1Val) =
                            (heap[parent], heap[child1 - 1]);
                        (biggestOne, indexBiggest) = (child1Val, child1);
                        if (ismaxSmallHeap)
                        {
                            if (parentVal > biggestOne)
                            {
                                break;
                            }

                        }
                        else
                        {
                            if (parentVal < biggestOne)
                            {
                                break;
                            }

                        }
                    }

                    (heap[parent], heap[indexBiggest]) = (heap[indexBiggest], heap[parent]);
                    parent = biggestOne;
                    child1 = parent * 2;
                    child2 = child1 + 1;
                }

            return removedVal;
        }

        public void BalanceHeight(List<int> minBigHeap, List<int> maxSmallHeap)
        {
            var (len1, len2) = (maxSmallHeap.Count, minBigHeap.Count);
            while (Math.Abs(len1 - len2) > 1)
            {
                if (len2 > len1)
                {
                    RemoveHeap(minBigHeap, false);

                }
                else
                {
                    //default
                    RemoveHeap(maxSmallHeap, true);
                }
                (len1, len2) = (maxSmallHeap.Count, minBigHeap.Count);
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