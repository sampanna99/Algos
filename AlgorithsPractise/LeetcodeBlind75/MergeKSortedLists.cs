using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace AlgorithsPractise.LeetcodeBlind75
{
    public class MergeKSortedLists
    {
        public int[][] ListsInts { get; set; }

        //https://leetcode.com/problems/merge-k-sorted-lists/

        //so each of them are already sorted!
        public MergeKSortedLists()
        {
            ListsInts = new[] { new[] { 1, 4, 5 }, new[] { 1, 3, 4 }, new[] { 2, 6 } };
            //linked list 1 --> 4 --> 5 and whateva
        }

        //using divide and conquer
        public List<int> DivideAndConquer(int start, int end)
        {

            if (end - start <= 0)
            {
                if (end - start == 0)
                {
                    return new List<int>(ListsInts[end]);
                }
                else
                {
                    return new List<int>();
                }
            }
            var numberofelements = (end - start) + 1;
            var midValue = numberofelements / 2;
            var remainder = numberofelements % 2;
            var list1 = DivideAndConquer(start, (end - midValue) + remainder);
            var list2 = DivideAndConquer(start + midValue, end);
            return CombineTwoLists(list1, list2);

        }

        private List<int> CombineTwoLists(List<int> firstList, List<int> secondList)
        {
            var returningList = new List<int>();
            var firstLength = firstList.Count;
            var secondLength = secondList.Count;

            var minlength = Math.Min(firstLength, secondLength);
            var i = 0;
            while (i < minlength)
            {
                var firstOne = firstList[i];
                var secondOne = secondList[i];
                returningList.Add(firstOne > secondOne ? secondOne : firstOne);
                i++;
            }

            var listwhichIsBigger = firstLength > secondLength ? firstList : secondList;
            for (int j = minlength; j < listwhichIsBigger.Count; j++)
            {
                returningList.Add(listwhichIsBigger[j]);
            }

            return returningList;
        }


        //USING HEAP NOW.

        private void CreateMinHeap()
        {
            var heap = new List<Tuple<int, int, int>>();
            
            //first of each
            for (int i = 0; i < ListsInts.Length; i++)
            {
                AddToHeap(ListsInts[i][0], i, 0, ref heap);

            }

            //we need which list that it removed from so that we could move the pointer Also
            //need which index of that list was it removed from and
            //Add to heap again
            var (removedVal, removedValIndex, removedValIndexI) = HeapifyAfterRemove(heap);
            while (heap.Count > 0)
            {
                //ListsInts[removedValIndex][removedValIndexI] <=
                //    ListsInts[removedValIndex].Length - 2

                if (ListsInts[removedValIndex][removedValIndexI] <=
                    ListsInts[removedValIndex].Length - 2)
                {
                    AddToHeap(ListsInts[removedValIndex][removedValIndexI + 1], removedValIndex
                        , removedValIndexI + 1, ref heap);
                }

                (removedVal, removedValIndex, removedValIndexI) = HeapifyAfterRemove(heap);

            }
        }

        private void AddToHeap(int value, int whichList, int whichIndexInList,
            ref List<Tuple<int, int, int>> heap)
        {
            var heapLength = heap.Count;
            heap[heapLength] = new Tuple<int, int, int>(value, whichList, whichIndexInList);
            HeapifyAfterAdd(heap);
        }

        private void HeapifyAfterAdd(List<Tuple<int, int, int>> heap)
        {
            var addedPlace = heap.Count; //to use the formula 2i, 2i + 1, i/2
            var addedPlaceIndex = heap.Count - 1; //to use the formula 2i, 2i + 1, i/2
            var parent = addedPlace / 2;
            var valueTocheckafterAdd = heap[^1];

            while (parent != 0)
            {
                if (heap[parent].Item1 > valueTocheckafterAdd.Item1)
                {
                    var (parentVal, index, indexofinside) = (heap[parent].Item1,
                        heap[parent].Item2, heap[parent].Item3);

                    heap[parent] = valueTocheckafterAdd;
                    heap[addedPlaceIndex] = new Tuple<int, int, int>(parentVal, index, indexofinside);

                    addedPlaceIndex = parent;
                    parent = addedPlaceIndex / 2;
                }
                else
                {
                    break;
                }
            }
        }

        private (int, int, int) HeapifyAfterRemove(List<Tuple<int, int, int>> heap)
        {
            //https://stackoverflow.com/questions/35754020/destructuring-assignment-object-properties-to-variables-in-c-sharp

            var (itemRemovedVal, index, indexOFActual) = heap[0];
            var (itemRemovedValMoved, indexM, indexOFActualM) = heap[^1];

            heap[0] = heap[^1];
            heap.RemoveAt(heap.Count - 1);

            var parentInd = 0;
            var heapValueTomoveAround = heap[parentInd];
            var chileExists = heap.Count > 1 ? true : false;
            var childAt = 2 - 1;
            while (chileExists)
            {
                var minChild = heap[childAt];
                
                if (heap.Count - 1 >= childAt + 1)
                {
                    //var minChildValue = Math.Min(heap[childAt].Item1, heap[childAt + 1].Item1);
                    //minChild = heap[childAt].Item1 > heap[childAt + 1].Item1 ? heap[childAt + 1] : 
                    //    heap[childAt];
                    if (heap[childAt].Item1 > heap[childAt + 1].Item1)
                    {
                        minChild = heap[childAt + 1];
                        childAt = childAt + 1;
                    }
                    else
                    {
                        minChild = heap[childAt];
                    }

                }

                if (minChild.Item1 < heapValueTomoveAround.Item1)
                {
                    var (parentV, parentI, parentInIn) = heapValueTomoveAround;

                    heap[parentInd] = minChild;
                    heap[childAt] = new Tuple<int, int, int>(parentV, parentI, parentInIn);
                }
                else
                {
                    break;
                }

                childAt = 2 * childAt - 1;

                if (heap.Count < 2*childAt)
                {
                    chileExists = false;
                }
            }

            return (itemRemovedVal, index, indexOFActual);
        }
    }
}
