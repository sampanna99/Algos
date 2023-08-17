using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithsPractise.LeetCode_Eric.Phase1
{
    public class BinarySearch
    {
    }


    //leetcode 153
    //Neetcode video
    //https://www.youtube.com/watch?v=nIVW4P8b1VA&t=442s
    public class MinimumInRotatedArray
    {
        public int[] GivenArray { get; set; }
        public MinimumInRotatedArray()
        {
            GivenArray = new[] { 3, 4, 5, 1, 2 };
        }
        public void Algorithmn()
        {
            var answer = 0;
            var length = GivenArray.Length;
            var (remainder, midPointer) = (length % 2, length / 2);
            var (leftPointer, rightPointer) = 
                (0, length - 1);

            while (rightPointer > leftPointer)
            {
                if (length == 2)
                {
                    if (GivenArray[leftPointer] > GivenArray[rightPointer])
                    {
                        answer = GivenArray[leftPointer];
                    }
                    else
                    {
                        answer = GivenArray[rightPointer];
                    }
                    break;
                }
                if (GivenArray[midPointer] < GivenArray[leftPointer])
                {
                    length = rightPointer - leftPointer + 1;
                    remainder = length % 2;
                    rightPointer = midPointer;
                    midPointer = leftPointer + (rightPointer - leftPointer / 2);
                }
                else if(GivenArray[midPointer] > GivenArray[rightPointer])
                {
                    length = rightPointer - leftPointer + 1;
                    remainder = length % 2;
                    leftPointer = midPointer;
                    midPointer = leftPointer +(rightPointer - leftPointer / 2);
                }else if (GivenArray[midPointer] == GivenArray[rightPointer])
                {
                    if (midPointer == rightPointer)
                    {
                        midPointer -= 1;
                    }
                    rightPointer -= 1;
                    length = rightPointer - leftPointer + 1;
                }
            }

        }
    }

    //could be duplicates
    //https://www.youtube.com/watch?v=BfsyDRRTUI4
    //I added it up in the code.
    public class MinimumInRotatedArray2
    {
        public int[] ArrayGiven { get; set; }
        public MinimumInRotatedArray2()
        {
            ArrayGiven = new[] { 4, 5, 6, 7, 0, 1, 2 };
        }

    }

    //https://www.youtube.com/watch?v=kMzJy9es7Hc
    //leetcode 162
    public class FindPeakElement
    {
        public int[] ArrayGiven { get; set; }
        public FindPeakElement()
        {
            ArrayGiven = new[] {1,2,3,1 };
        }
        public void Algorithmn()
        {
            var length = ArrayGiven.Length;
            var (firstPointer, secondPointer, mid) = (0, 
                ArrayGiven.Length - 1, length / 2);

            while (secondPointer < firstPointer)
            {
                if (secondPointer - firstPointer < 2)
                {
                    if (secondPointer - firstPointer == 0)
                    {
                        //only one
                        if (firstPointer == length - 1)
                        {
                            //lastone
                        }
                        else
                        {
                            //firstone
                        }
                    }
                    else
                    {
                        //1
                        //find the big one and go left and right
                        if (ArrayGiven[firstPointer] > ArrayGiven[secondPointer])
                        {
                            
                        }
                        else
                        {
                            
                        }
                    }
                    break;
                }
                if (ArrayGiven[mid] > ArrayGiven[mid + 1] && ArrayGiven[mid] > ArrayGiven[mid - 1])
                {
                    //bingo
                    break;
                }else if (ArrayGiven[mid] < ArrayGiven[mid + 1])
                {
                    //go right
                    firstPointer = mid + 1;
                    mid = (secondPointer - firstPointer + 1) / 2 + firstPointer;
                }else if (ArrayGiven[mid] < ArrayGiven[mid - 1])
                {
                    //go left
                    secondPointer = mid - 1;
                    mid = (secondPointer - firstPointer + 1) / 2 + firstPointer;
                }
            }
        }
    }
    public class SearchOnARotatedBinaryArray
    {
        public int[] GivenintArray { get; set; }
        public int Target { get; set; }

        public SearchOnARotatedBinaryArray()
        {
            GivenintArray = new[] { 4, 5, 6, 7, 0, 1, 2 };
            Target = 0;
        }

        public void Algorithmn()
        {
            var length = GivenintArray.Length;
            var (left, right, mid) = (0,length - 1, length / 2);

            while (right > left)
            {
                bool check = GivenintArray[left] < GivenintArray[mid];

                if (right -left <= 1)
                {
                    if (right - left == 1)
                    {
                        //2
                        if (GivenintArray[right] == Target)
                        {
                            
                        }

                        if (GivenintArray[left] == Target)
                        {
                            
                        }
                    }
                    else
                    {
                        //1
                        if (GivenintArray[left] == Target)
                        {

                        }
                    }
                }
                if (check)
                {
                    if (Target == GivenintArray[mid])
                    {
                        //found
                        break;
                    }
                    if (Target > GivenintArray[mid])
                    {
                        //go right
                        left = mid + 1;
                        DoTHelogic(ref left, ref right, ref mid);
                    }
                    else
                    {
                        //go left
                        right = mid - 1;
                        DoTHelogic(ref left, ref right, ref mid);
                    }
                    //else if(Target < GivenintArray[mid] && Target > GivenintArray[left])
                    //{
                    //    //go left
                    //}
                }
                else
                {
                    //skewed side is left so check right
                    if (Target == GivenintArray[mid])
                    {
                        //found
                        break;
                    }
                    if (Target > GivenintArray[mid])
                    {
                        //go right
                        left = mid + 1;
                        DoTHelogic(ref left, ref right, ref mid);
                    }
                    else 
                    {
                        //go left
                        right = mid - 1;
                        DoTHelogic(ref left, ref right, ref mid);
                    }

                }
            }
        }

        private void DoTHelogic(ref int left, ref int right, ref int mid)
        {

            mid = (right - left) / 2 + left;
        }
    }

    //https://www.youtube.com/watch?v=4sQL7R5ySUU&t=327s
    //Way better solution in the video above. I complicated it
    public class FirstAndLastPoxitionInSortedArray
    {
        public int[] ArrayGiven { get; set; }
        public int Target { get; set; }
        public FirstAndLastPoxitionInSortedArray()
        {
            ArrayGiven = new[] {5,7,7,8,8,10 };
            Target = 8;
        }

        public void Algorithmn()
        {
            var length = ArrayGiven.Length;
            var (left, right, mid, leftIndex, rightIndex) = (0, length - 1, length / 2, 
                -1, -1);

            while (right >= left)
            {
                //TODO: things if only two here

                if (ArrayGiven[mid] == mid)
                {
                    //now do found Binary search
                    //find right first
                    (leftIndex, rightIndex) = AfterFoundBS(left, right, mid);

                    //rightIndex = (rightIndex < mid) ? mid : rightIndex;
                }
                else
                {
                    //find the element
                    if (ArrayGiven[mid] > Target)
                    {
                        //left
                        right = mid - 1;
                        BinarySearch(ref left, ref right, ref mid);
                    }
                    else
                    {
                        left = mid + 1;
                        BinarySearch(ref left, ref right, ref mid);
                    }
                }
            }
        }

        private (int, int)  AfterFoundBS(int left, int right, int mid)
        {
            var (leftAns, rightAns) = (Int32.MaxValue, Int32.MinValue);
            for (int i = 0; i < 2; i++)
            {
                var (leftWhenFound, rightWhenFound, midWhenFound) = (left, right, mid);

                while (leftWhenFound <= rightWhenFound)
                {
                    if (i == 0)
                    {
                        //left
                        var distance = rightWhenFound - leftWhenFound;
                        if (distance <= 1)
                        {
                            leftAns = WhenOnlyTwo(true, rightWhenFound, leftWhenFound,
                                leftAns);
                            break;
                        }

                        if (ArrayGiven[midWhenFound] == Target)
                        {
                            leftWhenFound = midWhenFound - 1;
                            BinarySearch(ref leftWhenFound, ref rightWhenFound, ref rightWhenFound);
                        }
                        else
                        {
                            //go to right to find the left
                            leftWhenFound = midWhenFound + 1;
                            BinarySearch(ref leftWhenFound, ref rightWhenFound, ref rightWhenFound);
                        }
                    }
                    else
                    {
                        //right
                        var distance = rightWhenFound - leftWhenFound;
                        if (distance <= 1)
                        {
                            rightAns = WhenOnlyTwo(true, rightWhenFound, leftWhenFound,
                                rightAns);
                            break;
                        }

                        if (ArrayGiven[midWhenFound] == Target)
                        {
                            if (rightAns < midWhenFound)
                            {
                                rightAns = midWhenFound;
                            }
                            rightWhenFound = rightWhenFound + 1;
                            BinarySearch(ref leftWhenFound, ref rightWhenFound, ref rightWhenFound);
                        }
                        else
                        {
                            //go to left to find the right
                            rightWhenFound = midWhenFound - 1;
                            BinarySearch(ref leftWhenFound, ref rightWhenFound, ref rightWhenFound);
                        }
                    }
                }
            }

            return (leftAns, rightAns);
        }

        private int WhenOnlyTwo(bool isLeft, int right, int left, int currentValue)
        {
            if (isLeft)
            {
                if (right - left <= 0)
                {
                    if (ArrayGiven[right] == Target)
                    {
                        if (ArrayGiven[right] < ArrayGiven[currentValue])
                        {
                            return right;
                        }
                        else
                        {
                            return currentValue;
                        }
                    }
                    else
                    {
                        return currentValue;
                    }
                }
                else
                {
                    if (ArrayGiven[left] == Target)
                    {
                        if (ArrayGiven[left] < ArrayGiven[currentValue])
                        {
                            return left;
                        }
                        else
                        {
                            return currentValue;
                        }
                    }else if (ArrayGiven[right] == Target)
                    {
                        if (ArrayGiven[right] < ArrayGiven[currentValue])
                        {
                            return right;
                        }
                        else
                        {
                            return currentValue;
                        }
                    }
                    else
                    {
                        return currentValue;
                    }
                }
            }
            else
            {
                if (right - left <= 0)
                {
                    if (ArrayGiven[right] == Target)
                    {
                        if (ArrayGiven[right] > ArrayGiven[currentValue])
                        {
                            return right;
                        }
                        else
                        {
                            return currentValue;
                        }
                    }
                    else
                    {
                        return currentValue;
                    }
                }
                else
                {
                    if (ArrayGiven[right] == Target)
                    {
                        if (ArrayGiven[right] > ArrayGiven[currentValue])
                        {
                            return right;
                        }
                        else
                        {
                            return currentValue;
                        }
                    }
                    else if (ArrayGiven[left] == Target)
                    {
                        if (ArrayGiven[left] > ArrayGiven[currentValue])
                        {
                            return left;
                        }
                        else
                        {
                            return currentValue;
                        }
                    }
                    else
                    {
                        return currentValue;
                    }
                }
            }
        }
        private void BinarySearch(ref int left, ref int right, ref int mid)
        {
            mid = (right - left) / 2 + left;
        }
    }

    public class TimeBasedKeyValueStore
    {
        public string[] Operations { get; set; }
        public string[][] ArrayOfArrays { get; set; }
        public Dictionary<string, List<Tuple<string, int>>> Dictionary { get; set; }
        public TimeBasedKeyValueStore()
        {
            Operations = new[] { "TimeMap", "set", "get", "get", "set", "get", "get" };
            Dictionary = new Dictionary<string, List<Tuple<string, int>>>();
            //https://www.programiz.com/csharp-programming/jagged-array
            //ArrayOfArrays = new string[5][];
            ArrayOfArrays = new []
            {
                Array.Empty<string>(), 
                new String []{"foo", "bar", "1"},
                new String []{"foo",  "1"},
                new String []{"foo", "3"},
                new String []{"foo", "bar2", "4"},
                new String []{"foo", "4"},
                new String []{"foo", "5"}
            };

        }

        public void ALgorithmn()
        {
            var answer = new string[Operations.Length];

            for (int i = 0; i < Operations.Length; i++)
            {
                var value = Operations[i];
                if (value.Contains("set") || value.Contains("get"))
                {
                    var keyname = ArrayOfArrays[i][0];
                    if (value == "set")
                    {
                        var val1 = ArrayOfArrays[i][1];
                        var val2 = Convert.ToInt32(ArrayOfArrays[i][2]);
                        if (Dictionary.ContainsKey(keyname))
                        {
                            Dictionary[keyname].Add(new Tuple<string, int>(val1, val2));
                        }
                        else
                        {
                            Dictionary[keyname] = new List<Tuple<string, int>>()
                            {
                                new Tuple<string, int>(val1, val2)
                            };
                        }
                        answer[i] = null;
                    }
                    else
                    {
                        var values = Dictionary[keyname];
                        var valueToFindCloseTo = Convert.ToInt32(ArrayOfArrays[i][1]);

                        var length = values.Count;
                        var (firstPointer, lastpointer, mid, closestOneDiff, indexC) = (0, 
                            length - 1, length / 2, Int32.MaxValue ,-1);

                        while (lastpointer >= firstPointer)
                        {
                            var diff = lastpointer - firstPointer;
                            var midValue = values[mid].Item2;
                            var startValue = values[firstPointer].Item2;
                            var endValue = values[lastpointer].Item2;


                           

                            if (midValue <= valueToFindCloseTo)
                            {
                                var diffrence = Math.Abs(midValue - valueToFindCloseTo);

                                if (diffrence < closestOneDiff)
                                {
                                    closestOneDiff = diffrence;
                                    indexC = mid;
                                }
                            }

                            if (diff <= 1)
                            {
                                if (diff == 0)
                                {
                                    break;
                                }
                                else
                                {
                                    var toFind = (mid == firstPointer) ? lastpointer : firstPointer;
                                    var valueAgain = values[toFind].Item2;
                                    if (valueAgain < valueToFindCloseTo)
                                    {
                                        var diffrence = Math.Abs(midValue - valueToFindCloseTo);

                                        if (diffrence < closestOneDiff)
                                        {
                                            closestOneDiff = diffrence;
                                            indexC = toFind;
                                        }
                                    }
                                }
                                break;
                            }

                            if (midValue == valueToFindCloseTo)
                            {
                                break;
                            }
                            else
                            {
                                if (startValue > valueToFindCloseTo)
                                {
                                    break;
                                }
                                else
                                {
                                    if (midValue > valueToFindCloseTo)
                                    {
                                        //check left
                                        lastpointer = mid - 1;
                                        mid = firstPointer + (lastpointer - firstPointer) / 2;
                                    }
                                    else
                                    {
                                        firstPointer = mid + 1;
                                        mid = firstPointer + (lastpointer - firstPointer) / 2;
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    answer[i] = null;
                }
            }
        }
    }

    public class KClosestElements
    {
        public int[] GivenArray { get; set; }
        public int NumberofValuesToReturn { get; set; }
        public int ValueToCheckFrom { get; set; }
        public KClosestElements()
        {
            GivenArray = new[] { 1, 2, 3, 4, 5 };
            NumberofValuesToReturn = 4;
            ValueToCheckFrom = 3;
        }

        public void Algorithmn()
        {
            var length = GivenArray.Length;
            var (leftPointer, rightPointer, midPointer) = (0, length - NumberofValuesToReturn
                , length / 2);

            while (leftPointer < rightPointer)
            {

                var (diffwithMid, diffWithRightPlus1) = (Math.Abs(GivenArray[midPointer] -
                                                                  ValueToCheckFrom),
                    Math.Abs(GivenArray[rightPointer + 1]) - ValueToCheckFrom);

                if (diffwithMid < diffWithRightPlus1)
                {
                    rightPointer = midPointer;
                    midPointer = leftPointer + (rightPointer - leftPointer) / 2;
                }
                else
                {
                    leftPointer = midPointer + 1;
                    midPointer = leftPointer + (rightPointer - leftPointer) / 2;
                }
            }
        }
    }
}