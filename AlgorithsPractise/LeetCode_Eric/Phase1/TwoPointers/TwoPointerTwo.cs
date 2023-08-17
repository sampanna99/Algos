using System;
using System.Collections.Generic;
using System.Text;
using AlgorithsPractise.LeetcodeBlind75;

namespace AlgorithsPractise.LeetCode_Eric.Phase1.TwoPointers
{
    public class TwoPointerTwo
    {
        public int[] ArrayGiven { get; set; }
        public int Target { get; set; }

        public TwoPointerTwo()
        {
            ArrayGiven = new []{1,2,3,4,6}
            ;
            Target = 6;
        }

        public void Algorithmn()
        {
            var (firstPointer, secondPointer) = (0, ArrayGiven.Length - 1);

            var sum = ArrayGiven[firstPointer] + ArrayGiven[secondPointer];

            while (sum != Target && firstPointer < secondPointer)
            {
                if (sum > Target)
                {
                    secondPointer -= 1;
                }
                else
                {
                    firstPointer += 1;
                }

                sum = ArrayGiven[firstPointer] + ArrayGiven[secondPointer];
            }
        }
    }

    public class MoveZeros
    {
        public int[] Array { get; set; }

        public MoveZeros()
        {
            Array = new[] { 1, 3, 12, 0, 0 };
        }

        public void Algorithmn()
        {
            var (firstPointer, secondPointer) = (0, 1);

            while (secondPointer < Array.Length)
            {
                if (Array[firstPointer] == 0 && Array[secondPointer] != 0)
                {
                    var temp = Array[secondPointer];
                    Array[secondPointer] = Array[firstPointer];
                    Array[firstPointer] = temp;

                    firstPointer += 1;
                    secondPointer += 1;
                }else if (Array[firstPointer] == 0 && Array[secondPointer] == 0)
                {
                    secondPointer += 1;
                }
                else if(Array[firstPointer] != 0 && Array[secondPointer] == 0)
                {
                    firstPointer += 1;
                    secondPointer += 1;
                }
            }
        }
    }



    //SORTED ARRAY
    public class RemoveDuplicates
    {
        public int[] ArrayGiven { get; set; }

        public RemoveDuplicates()
        {
            ArrayGiven = new[] { 0, 1, 2, 3, 4, 2, 3, 3, 4 };
        }

        public void ALgorithmn()
        {
            var (firstPointer, secondPointer) = (0, ArrayGiven.Length - 1);

            while (secondPointer < ArrayGiven.Length)
            {
                if (ArrayGiven[firstPointer] == ArrayGiven[secondPointer])
                {
                    secondPointer += 1;
                }
                else
                {
                    ArrayGiven[firstPointer + 1] = ArrayGiven[secondPointer];
                    firstPointer += 1;
                    secondPointer += 1;
                }
            }
        }

        public void ALgorithmn2()
        {
            var (firstPointer, secondPointer, counter) = (0, 0, 0);
            var valueTo = ArrayGiven[secondPointer];

            while (secondPointer < ArrayGiven.Length)
            {
                var checkvalueWith = ArrayGiven[secondPointer];
                if (checkvalueWith != valueTo)
                {
                    valueTo = checkvalueWith;
                    counter = 0;
                }

                if (valueTo == ArrayGiven[secondPointer])
                {
                    if (counter > 2)
                    {
                        secondPointer += 1;
                    }
                    else
                    {
                        firstPointer += 1;
                        secondPointer += 1;
                    }

                    counter += 1;
                }
                else
                {
                    counter = 1;
                    ArrayGiven[firstPointer] = ArrayGiven[secondPointer];
                    valueTo = ArrayGiven[secondPointer];
                    firstPointer += 1;
                    secondPointer += 1;
                }
                

            }

        }


    }
    public class SquaresofSortedArray
    {
        public int[] ArrayGiven { get; set; }

        public SquaresofSortedArray()
        {
            ArrayGiven = new[] { -4, -1, 0, 2, 5 };
        }
        public void Algorithm()
        {
            var (firstPointer, secondPointer) = (0, ArrayGiven.Length - 1);
            var ArrayGiven1 = new int[ArrayGiven.Length];
            var whereToPut = ArrayGiven1.Length - 1;
            while (firstPointer <= secondPointer)
            {
                var (firstSquared, secondSquared) = (ArrayGiven[firstPointer] * ArrayGiven[firstPointer],
                        ArrayGiven[secondPointer] * ArrayGiven[secondPointer]);

                if (firstSquared > secondSquared)
                {
                    ArrayGiven1[whereToPut] = firstSquared;
                    firstPointer += 1;
                }
                else
                {
                    ArrayGiven1[whereToPut] = secondSquared;
                    secondPointer -= 1;
                }

                whereToPut -= 1;
            }
        }
    }

    public class ContainerWithMostWater
    {
        public int[] Heights { get; set; }

        public ContainerWithMostWater()
        {
            Heights = new[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 };
        }

        public void ALgorithmn()
        {
            var (firstPointer, secondPointer) = (0, Heights.Length - 1);
            var maxArea = Int32.MinValue;
            while (firstPointer < secondPointer)
            {
                var area = new int();
                if (Heights[firstPointer] > Heights[secondPointer])
                {
                     area = Heights[secondPointer] * (secondPointer - firstPointer + 1);
                     secondPointer -= 1;
                }
                else
                {
                    area = Heights[firstPointer] * (secondPointer - firstPointer + 1);
                    firstPointer += 1;
                }

                if (area > maxArea)
                {
                    maxArea = area;
                }
            }

        }
    }

    public class ThreeSum1{
        public int[] Array { get; set; }
        public int Sum { get; set; } = 0;
        public ThreeSum1()
        {
            Array = new int[] { -1, 0, 1, 2, -1, -4 };
        }

        public void Algorithmn()
        {
            //todo:Gotta sort first;
            var listofListofint = new List<List<int>>();

            for (int i = 0; i < Array.Length; i++)
            {

                var (remainingSum, firstPointer, secondPointer) = (Array[i], i, 
                    Array.Length - 1);

                while (firstPointer < secondPointer)
                {
                    var addall = remainingSum + Array[firstPointer] + Array[secondPointer];

                    if (addall == Sum)
                    {
                        listofListofint.Add(new List<int>{i, firstPointer, secondPointer});
                        firstPointer += 1;
                    }else if (addall < Sum)
                    {
                        firstPointer += 1;
                    }
                    else
                    {
                        secondPointer -= 1;
                    }
                }
            }
        }

    }

    public class ThreeSumClosest
    {
        public int[] Array { get; set; }
        public int Sum { get; set; } = 0;
        public ThreeSumClosest()
        {
            Array = new int[] { -1, 0, 1, 2, -1, -4 };
        }

        public void Algorithmn()
        {
            //todo: gotta sort it first;
            var ans = new List<int>();
            var gap = Int32.MaxValue;
            for (int i = 0; i < Array.Length; i++)
            {
                var (firstPointer, secondPointer, reaqminingSum) =
                    (i, Array.Length - 1, Array[i]);

                while (firstPointer < secondPointer)
                {
                    var afterAdded = reaqminingSum + Array[firstPointer] + Array[secondPointer];
                    var diff = Math.Abs(afterAdded - Sum);
                    if (afterAdded == Sum)
                    {
                        ans.Add(i);
                        ans.Add(firstPointer);
                        ans.Add(secondPointer);

                        firstPointer += 1;
                        secondPointer -= 1;
                        gap = 0;
                    }else if (afterAdded < Sum)
                    {
                        if (diff < gap)
                        {
                            ans = new List<int> { i, firstPointer, secondPointer };
                        }

                        firstPointer += 1;
                    }
                    else
                    {
                        if (diff < gap)
                        {
                            ans = new List<int> { i, firstPointer, secondPointer };
                        }
                        secondPointer -= 1;
                    }
                }

            }

        }

    }

    public class ThreeSumSmaller
    {
        public int[] Array { get; set; }
        public int Target { get; set; }
        public ThreeSumSmaller()
        {
            Array = new[] { -2, 0, 1, 3, 5 };
        }

        public void Algorithmn()
        {
            //todo: gotta sort first
            var numberOfelements = 0;
            for (int i = 0; i < Array.Length; i++)
            {
                var (firstPointer, secondPointer) = (i + 1, Array.Length - 1);

                while (firstPointer < secondPointer)
                {
                    var sum = Array[i] + Array[firstPointer] + Array[secondPointer];

                    if (sum < Target)
                    {
                        numberOfelements += (secondPointer - firstPointer);
                        firstPointer += 1;
                    }
                    else
                    {
                        secondPointer -= 1;
                    }

                }
            }
        }
    }

    //Neetcode video
    public class PartitionLabels
    {
        public string GivenString { get; set; }

        public PartitionLabels()
        {
            GivenString = "ababcbacadefegdehijklij";
        }

        public void Algorithmn()
        {
            var answer = new List<int>();
            var intArray = new int[26];
            for (int i = 0; i < GivenString.Length; i++)
            {
                intArray[GivenString[i]] = i;
            }

            var (size, end) = (0, 0); 
            for (int i = 0; i < GivenString.Length; i++)
            {
                var furthestOne = intArray[GivenString[i]];
                if (size == 0)
                {
                    end = furthestOne;
                    size += 1;
                }

                if (i == end)
                {
                    size += 1;
                    answer.Add(size);
                    size = 0;
                }
                else if (i < end)
                {
                    if (furthestOne > end)
                    {
                        end = furthestOne;
                    }
                }
                else
                {

                }

            }

        }
    }

    //Neetcode video
    public class TrappingRainWater
    {
        public int[] GivenHeight { get; set; }

        public TrappingRainWater()
        {
            GivenHeight = new[] { 0, 1, 0, 2, 1, 0, 1, 3, 1, 2, 1 };
        }
        public void Algorithmn()
        {
            var (firstPointer, secondPointer, maxLeft, maxRight, amountOFWater) = 
                (0, GivenHeight.Length, 0, 0, 0);

            while (firstPointer < secondPointer)
            {
                if (maxLeft <= maxRight)
                {
                    var value = GivenHeight[firstPointer];
                    var heightOfWater = maxLeft - value;
                    if (heightOfWater > 0)
                    {
                        amountOFWater += heightOfWater;
                    }

                    if (value > maxLeft)
                    {
                        maxLeft = value;
                    }
                    firstPointer += 1;
                }
                else
                {
                    var value = GivenHeight[secondPointer];
                    var heightOfWater = maxLeft - value;
                    if (heightOfWater > 0)
                    {
                        amountOFWater += heightOfWater;
                    }

                    if (value > maxLeft)
                    {
                        maxLeft = value;
                    }
                    secondPointer += 1;
                }
            }

        }
    }

    //Neetcode. Also easily done with bucket sort but a lil harder way is two pointers
    public class SortColors
    {
        public int[] Nums { get; set; }
        public SortColors()
        {
            Nums = new[] { 2, 0, 2, 1, 1, 0 };
        }

        public void Algorithmn()
        {
            var (leftPointer, rightPointer) = (0, Nums.Length - 1);

            for (int i = 0; i < Nums.Length; i++)
            {
                if (i > rightPointer)
                {
                    break;
                }
                if (Nums[i] == 0)
                {
                    (Nums[leftPointer], Nums[i]) = (Nums[i], Nums[leftPointer]);
                    leftPointer += 1;
                }else if (Nums[i] == 2)
                {
                    (Nums[rightPointer], Nums[i]) = (Nums[i], Nums[rightPointer]);
                    i = i - 1;
                    rightPointer -= 1;
                }
                
            }
        }
    }

    public class RemoveDuplicatesFromSorted
    {
        public NodeH LinkedList { get; set; }

        public RemoveDuplicatesFromSorted()
        {
            LinkedList = new NodeH();
            Initialize();
        }

        private void Initialize()
        {
            LinkedList = new NodeH
            {
                Value = 1,
                Next = new NodeH
                {
                    Value = 2,
                    Next = new NodeH
                    {
                        Value = 3,
                        Next = new NodeH
                        {
                            Value = 4,
                            Next = new NodeH
                            {
                                Value = 4,
                                Next = new NodeH
                                {
                                    Value = 5
                                }
                            }
                        }
                    }
                }
            };
        }

        //https://www.youtube.com/watch?v=R6-PnHODewY
        ///I used above link but I formed my own style. Work on conditions when duplicate
        ///and right after duplicate
        public void Algorithmn()
        {
            var head = LinkedList;
            var returnNode = new NodeH();
            var prevNode = returnNode;
            var skippingProcessPrior = false;

            while (head != null)
            {
                if (head.Next != null && head.Value != head.Next.Value)
                {
                    if (skippingProcessPrior)
                    {
                        head = head.Next;
                        prevNode.Next = new NodeH()
                        {
                            Value = head.Value,
                            Next = new NodeH()
                        };
                    }
                    else
                    {
                        prevNode.Next = new NodeH()
                        {
                            Value = head.Value,
                            Next = new NodeH()
                        };
                        head = head.Next;
                        prevNode = prevNode.Next;
                    }

                    skippingProcessPrior = false;
                }
                else
                {
                    if (head.Next == null)
                    {
                        if (!skippingProcessPrior)
                        {
                            prevNode.Next = new NodeH()
                            {
                                Value = head.Value
                            };
                        }
                    }
                    else
                    {
                        skippingProcessPrior = true;
                    }
                    head = head.Next;
                }
            }



            //while (head != null)
            //{
            //    if (head.Value != head.Next.Value)
            //    {
            //        if (returnNode == null)
            //        {
            //            returnNode = new NodeH()
            //            {
            //                Value = head.Value,
            //                Next = new NodeH()
            //            };
            //        }
            //        else
            //        {
            //            returnNode.Next = new NodeH
            //            {
            //                Value = head.Value,
            //                Next = new NodeH()
            //            };
            //        }

            //        //move both
            //        prevVal = Int32.MaxValue;
            //        head = head.Next;
            //        returnNode = returnNode.Next;
            //    }
            //    else
            //    {
            //        //move just the head
            //        prevVal = head.Value;
            //        returnNode = new NodeH();
            //        head = head.Next;
            //    }
            //}
        }
    }
}
