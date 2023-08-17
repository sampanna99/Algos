using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithsPractise.LeetcodeBlind75
{
    public class MedianFromDataStream
    {
        public List<int> ForMinHeap { get; set; }
        public List<int> ForMaxHeap { get; set; }

        public MedianFromDataStream()
        {
            ForMinHeap = new List<int>();
            ForMaxHeap = new List<int>();
        }
        public int FindMedian()
        {
            return 0;
        }

        private void AddAndMakeItToHeap(int valueToAdd)
        {
            ForMinHeap.Add(valueToAdd);

            //first heap check
            var heapLengthTostart = ForMinHeap.Count;
            var parentTocheck = ForMinHeap.Count / 2;

            //as parenttocheck should always be 1 at the minimum as we start the heap from 1;
            while (parentTocheck != 0 &&
                   ForMinHeap[heapLengthTostart - 1] < ForMinHeap[parentTocheck - 1])
            //while (parentTocheck != 0 &&
            //       ForMinHeap[heapLengthTostart - 1] < ForMinHeap[parentTocheck - 1])
            {
                //heapify
                (ForMinHeap[heapLengthTostart - 1], ForMinHeap[parentTocheck - 1]) = 
                    (ForMinHeap[parentTocheck - 1], ForMinHeap[heapLengthTostart - 1]);
                //var temp = ForMinHeap[heapLengthTostart - 1];
                //ForMinHeap[heapLengthTostart - 1] = ForMinHeap[parentTocheck - 1];
                //ForMinHeap[parentTocheck - 1] = temp;
                heapLengthTostart = parentTocheck;
                parentTocheck /= 2;

                if (parentTocheck == 0)
                {
                    break;
                }
            }

            if (Math.Abs(ForMinHeap.Count - ForMaxHeap.Count) > 1)
            {
                //heapify again
                if (ForMaxHeap.Count > ForMinHeap.Count)
                {
                    var maxHeapVal = ForMaxHeap[0];
                    //remove it from the heap
                    Remove(ForMaxHeap, false);
                    Add(ForMinHeap, maxHeapVal, false);
                    //add it to the other heap
                }
                else
                {
                    var minHeapVal = ForMaxHeap[0];
                    //remove it from the heap
                    Remove(ForMinHeap);
                    Add(ForMaxHeap, minHeapVal);
                    //add it to the other heap
                }
            }
        }

        private void MedianVal()
        {
            decimal median;
            if (ForMinHeap.Count == ForMaxHeap.Count)
            {
                var maxHVal = ForMaxHeap[0];
                var minHVal = ForMinHeap[0];

                median = ((decimal)minHVal + maxHVal) / 2;
            }
            else
            {
                var bigger = ForMaxHeap.Count > ForMinHeap.Count ? ForMaxHeap : ForMinHeap;
                median = bigger[0];
            }

            Console.WriteLine($"Median is {median}");
        }
        private void Remove(List<int> toRemoveFrom, bool isMinHeap = true)
        {
            var valueToRemove = toRemoveFrom[0];
            toRemoveFrom[0] = toRemoveFrom[^1];
            toRemoveFrom.RemoveAt(toRemoveFrom.Count - 1);

            var startWithIndex = 1;
            var childrenLeft = 2 * startWithIndex - 1;
            var childrenRight = 2 * startWithIndex;
            while (childrenLeft >= toRemoveFrom.Count - 1)
            {
                if (childrenRight <= toRemoveFrom.Count - 1)
                {
                    if (isMinHeap)
                    {
                        var (value, index) = toRemoveFrom[childrenLeft] < toRemoveFrom[childrenRight]
                            ? (toRemoveFrom[childrenLeft], childrenLeft)
                            : (toRemoveFrom[childrenRight], childrenRight);

                        if (value < valueToRemove)
                        {
                            //switch
                            (toRemoveFrom[startWithIndex - 1], toRemoveFrom[index]) = (toRemoveFrom[index],
                                toRemoveFrom[startWithIndex - 1]);
                        }
                        else
                        {
                            break;
                        }
                        startWithIndex = index + 1;
                        valueToRemove = value;
                    }
                    else
                    {
                        var (value, index) = toRemoveFrom[childrenLeft] > toRemoveFrom[childrenRight]
                            ? (toRemoveFrom[childrenLeft], childrenLeft)
                            : (toRemoveFrom[childrenRight], childrenRight);

                        if (value > valueToRemove)
                        {
                            //switch
                            (toRemoveFrom[startWithIndex - 1], toRemoveFrom[index]) = (toRemoveFrom[index],
                                toRemoveFrom[startWithIndex - 1]);
                        }
                        else
                        {
                            break;
                        }
                        startWithIndex = index + 1;
                        valueToRemove = value;
                    }
                }
                else
                {
                    //just check with the left one
                    //if not break
                    if (childrenLeft <= toRemoveFrom.Count - 1)
                    {
                        if (isMinHeap)
                        {
                            if (toRemoveFrom[startWithIndex - 1] > toRemoveFrom[childrenLeft])
                            {
                                (toRemoveFrom[startWithIndex - 1], toRemoveFrom[childrenLeft]) =
                                    (toRemoveFrom[childrenLeft], toRemoveFrom[startWithIndex - 1]);
                            }

                            break;
                        }
                        else
                        {
                            if (toRemoveFrom[startWithIndex - 1] < toRemoveFrom[childrenLeft])
                            {
                                (toRemoveFrom[startWithIndex - 1], toRemoveFrom[childrenLeft]) =
                                    (toRemoveFrom[childrenLeft], toRemoveFrom[startWithIndex - 1]);
                            }

                            break;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }

        }

        private void Add(List<int> toaddTo, int value, bool isMinHeap = true)
        {

            toaddTo.Add(value);
            var length = toaddTo.Count; //(including the added one)

            var location = length;
            var parent = length / 2;
            while (parent != 0)
            {
                if (isMinHeap)
                {
                    if (toaddTo[parent - 1] > value)
                    {

                        (toaddTo[parent - 1], toaddTo[location - 1]) = 
                            (toaddTo[location - 1], toaddTo[parent - 1]);

                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    if (toaddTo[parent - 1] < value)
                    {

                        (toaddTo[parent - 1], toaddTo[location - 1]) =
                            (toaddTo[location - 1], toaddTo[parent - 1]);
                    }
                    else
                    {
                        break;
                    }
                }

                location = parent;
                parent /= 2;

                if (parent == 0)
                {
                    break;
                }
            }
        }
    }
}
