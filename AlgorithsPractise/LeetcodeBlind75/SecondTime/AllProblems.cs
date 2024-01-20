using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgorithsPractise.LeetcodeBlind75.SecondTime
{
    public class AllProblems
    {
    }

    public struct COntiguousSUbAr
    {
        public int Value { get; set; }
        public int StartInd { get; set; }
        public int EndInd { get; set; }

    }
    //leetcode 152
    public class ProductSubArray
    {
        public int[] GivenArray { get; set; }

        public void Algorithmn()
        {
            //Go over from first to last and find the Mini/Max including that index;
            //two variables. One the biggest. Another while moving along

            var i = 0;
            var ansstruct = new COntiguousSUbAr();
            var lastStruct = new COntiguousSUbAr();
            var lastStructMin = new COntiguousSUbAr();

            while (i < GivenArray.Length)
            {
                var valueHere = GivenArray[i];
                if (i == 0 || GivenArray[i-1] == 0)
                {
                    lastStruct.Value = valueHere;
                    lastStruct.StartInd = i;
                    lastStruct.EndInd = i;
                    lastStructMin.Value = valueHere;
                    lastStructMin.StartInd = i;
                    lastStructMin.EndInd = i;
                    //ansstruct = lastStruct;
                }
                else
                {
                    var (valueMultWithMax, valueMultWithMin) = (valueHere * lastStruct.Value,
                        valueHere * lastStructMin.Value);

                    if (valueHere > valueMultWithMax && valueHere > valueMultWithMin)
                    {
                        lastStruct.Value = valueHere;
                        lastStruct.StartInd = i;
                        lastStruct.EndInd = i;
                    }
                    else
                    {
                        var togetFromstruct = valueMultWithMin > valueMultWithMax ? 
                            lastStructMin : lastStruct;
                        lastStruct.Value = togetFromstruct.Value;
                        lastStruct.EndInd = i;
                    }

                    //Now do for the minimum
                    if (valueHere < valueMultWithMax && valueHere < valueMultWithMin)
                    {
                        lastStructMin.Value = valueHere;
                        lastStructMin.StartInd = i;
                        lastStructMin.EndInd = i;
                    }
                    else
                    {
                        var togetFromstruct = valueMultWithMin > valueMultWithMax ?
                            lastStruct : lastStructMin;
                        lastStructMin.Value = togetFromstruct.Value;
                        lastStructMin.EndInd = i;
                    }

                }

                if (ansstruct.Value < lastStruct.Value)
                {
                    ansstruct = lastStruct;
                }
                i += 1;
            }

            Console.WriteLine($"Maximum contiguous subarray mult is {ansstruct.Value} starting index " +
                              $"{ansstruct.StartInd} and ending on {ansstruct.EndInd}");
        }
    }

    public class MinimumInSorted
    {
        public int[] GivenArray { get; set; }

        public MinimumInSorted()
        {
            
        }

        public void Algorithmn()
        {
            FindMinimum(0, GivenArray.Length - 1);
        }

        private int FindMinimum(int startInd, int EndInd)
        {
            var diff = Math.Abs(startInd - EndInd);
            if (diff <= 1)
            {
                //Find the minimum one
                if (diff == 0)
                {
                    return GivenArray[startInd];
                }
                else
                {
                    return GivenArray[startInd] < GivenArray[EndInd] ? GivenArray[startInd] : 
                        GivenArray[EndInd];
                }
            }

            //which side to search
            var total = EndInd - startInd + 1;

            var nthPlace = total / 2;

            var valueNth = GivenArray[nthPlace];

            return valueNth < GivenArray[startInd] ? FindMinimum(startInd, nthPlace) :
                FindMinimum(nthPlace, EndInd);

        }
    }

    public class ThreeSum
    {
        public int[] GivenArray { get; set; }

        public ThreeSum()
        {
            
        }

        public void Algorithmn()
        {
            //Sort it
            Sort(0, GivenArray.Length - 1);
            //then do 2 sum on a sorted array

            var last = 0;
            var listofList = new List<List<int>>();
            var j = GivenArray.Length;
            for (int i = 0; i < j; i++)
            {
                if (GivenArray[i] != last || i == 0)
                {
                    var listwithTHisFirst = new List<int>()
                    {
                        GivenArray[i]
                    };

                    var remaining = 0 - GivenArray[i];
                    var (k, k1) = (i, j);
                    while (k < k1)
                    {
                        var sum = GivenArray[k] + GivenArray[k1];
                        if (sum == remaining)
                        {
                            listwithTHisFirst.Add(GivenArray[k]);
                            listwithTHisFirst.Add(GivenArray[k1]);
                            listofList.Add(listwithTHisFirst);
                            break;
                        }
                    }

                    last = GivenArray[i];
                }
            }
        }

        private void Sort(int startIndex, int endIndex)
        {
            //find articulation point sort until that point and swap it

            //take the last element and if it is smaller swap with that point 
            var pivot = endIndex;
            var (partitionIndex, strt) = (startIndex, startIndex);
            var valueAtPiv = GivenArray[pivot];
            while (strt < endIndex)
            {
                var valueAtstrt = GivenArray[strt];
                if (valueAtstrt < valueAtPiv)
                {
                    //swap with partitionIndex
                    (GivenArray[partitionIndex], GivenArray[strt]) = (GivenArray[strt],
                        GivenArray[partitionIndex]);
                    partitionIndex += 1;
                }

                strt += 1;
            }

            //Think here boiii!! what if two and 1,2 and it's alreay sorted.
            //Second thought if it is 1,2. then it will go through the above while and partition would be last
            (GivenArray[partitionIndex], GivenArray[pivot]) = (GivenArray[pivot], GivenArray[partitionIndex]);

            Sort(startIndex, partitionIndex - 1);
            Sort(partitionIndex +1, endIndex);
        }
    }

    public class ContainerWithMostWater
    {
        public int[] ArrayOfHeights { get; set; }

        public ContainerWithMostWater()
        {
            
        }

        public void ALgorithmn()
        {
            var (i, j, maxArea) = (0, ArrayOfHeights.Length - 1, Int32.MinValue);

            while (i < j)
            {
                var left = ArrayOfHeights[i];
                var right = ArrayOfHeights[i];

                var diff = right - left;

                var area = 0;
                if (left < right)
                {
                     area = left * diff;
                    i += 1;
                }
                else
                {
                     area = right * diff;
                    j -= 1;
                }
                if (area > maxArea)
                {
                    maxArea = area;
                }

            }
        }
    }


    public class ReverseBits
    {
        public string GivenBinary { get; set; }

        public ReverseBits()
        {
            
        }

        public void Algorithmn()
        {
            //& with 1 binary it gives whatever it is in above
            //after you get it. move left by 1 (i)
            //in the answer. whatever we get above move it to 31 - i; there the above will be 0; so or it with
            //- Value
            uint usedVal = 1;
            var givenInt = (uint)(object)(Convert.ToInt32(GivenBinary, 2));
            uint ans = 0;
            for (int i = 0; i < 32; i++)
            {
                uint bit = (givenInt >> i) & 1;
                ans = ans | (bit << (31 - i));
            }
            var ansinstr = ans.ToString();
            Console.WriteLine($"The answer is {ansinstr}");
        }
    }

    public class ClimbingStairs
    {
        public int NumberOfSteps { get; set; }
        public Dictionary<int, int> NumberOfStepsNeededDict { get; set; }

        public ClimbingStairs()
        {
            NumberOfStepsNeededDict = new Dictionary<int, int>();
        }
        public void Algorithmn()
        {

        }

        public int DFSASpproach(int stairLocation)
        {
            //base case
            if (stairLocation > NumberOfSteps)
            {
                return Int32.MaxValue;
            }

            if (stairLocation == NumberOfSteps)
            {
                return 0;
            }

            if (NumberOfStepsNeededDict.ContainsKey(stairLocation))
            {
                return NumberOfStepsNeededDict[stairLocation];
            }
            var neededA = 1 + DFSASpproach(stairLocation + 1);
            var neededB = 1 + DFSASpproach(stairLocation + 2);

            var min = Math.Min(neededA, neededB);
            //Memoize
            NumberOfStepsNeededDict.Add(stairLocation, min);
            return min;
        }
    }

    public class CoinChange
    {
        public int[] CoinDenominations { get; set; }
        public int SumToMake { get; set; }

        public Dictionary<int, int> DictionaryOfSumNeededAfter { get; set; }

        public CoinChange()
        {
            DictionaryOfSumNeededAfter = new Dictionary<int, int>();
        }

        public void Algorithmn()
        {

        }

        public int DFSApproach(int sumUpto)
        {
            //base case
            if (sumUpto >= SumToMake)
            {
                if (sumUpto == SumToMake)
                {
                    return 0;
                }
                else
                {
                    return -1;
                }
            }

            //go over all of them
            var min = -1;

            if (DictionaryOfSumNeededAfter.ContainsKey(sumUpto))
            {
                return DictionaryOfSumNeededAfter[sumUpto];
            }

            for (int i = 0; i < CoinDenominations.Length; i++)
            {
                var addingThisIndex = sumUpto + CoinDenominations[i];
                var numberNeeded = DFSApproach(addingThisIndex);

                if (numberNeeded != -1)
                {
                    var numberOfCoinsNeeded = 1 + numberNeeded;

                    if (min != -1)
                    {
                        min = Math.Min(min, numberOfCoinsNeeded);
                    }
                    else
                    {
                        min = numberOfCoinsNeeded;
                    }
                }
            }
            DictionaryOfSumNeededAfter.Add(sumUpto, min);
            return min;
        }
    }

    public class LIS
    {
        public int[] GivenNums { get; set; }
        public Dictionary<int, int> Mermoization { get; set; }
        public Dictionary<string, int> Memoization { get; set; }
        public LIS()
        {
            Mermoization = new Dictionary<int, int>();
            Memoization = new Dictionary<string, int>();
        }

        public void Algorithmn()
        {

        }

        public int DfsWay2(int prevMax, int index)
        {
            //base case
            if (index >= GivenNums.Length)
            {
                return 0;
            }

            var valueHere = GivenNums[index];
            var key = index + "$" + prevMax;
            if (Memoization.ContainsKey(key))
            {
                return Memoization[key];
            }
            //taking this
            var takingThis = 0;
            if (valueHere > prevMax)
            {
                takingThis = 1 + DfsWay2(valueHere, index + 1);
            }

            //not taking this
            var nottakingThis = DfsWay2(prevMax, index + 1);
            //compare memoize and return
            var maxOne = takingThis > nottakingThis ? takingThis : nottakingThis;
            Memoization.Add(key, maxOne);
            return maxOne;
        }

        public void TabulationWay()
        {
            //base cases and keep adding to it
            var dp = new int[GivenNums.Length];
            dp[^1] = 1;
            for (int i = GivenNums.Length - 2; i >= 0; i--)
            {
                //Get value here
                //for starting after this till end check if they are smaller if yes add 1 to it
                var valueHere = GivenNums[i];

                var max = 0;
                for (int j = i+1; j < GivenNums.Length; j++)
                {
                    var valueafter = GivenNums[j];
                    if (valueHere > valueafter)
                    {
                        //get dp array's value here
                        var maxLengthAAtIPossibly = 1 + dp[j];
                        if (max < maxLengthAAtIPossibly)
                        {
                            max = maxLengthAAtIPossibly;
                        }
                    }
                }
            }

        }
    }

    public class LongestCommonSubsequence
    {
        public string StringA { get; set; }
        public string StringB { get; set; }

        public Dictionary<string, int> Dictionary { get; set; }
        public void ALgorithmn()
        {
            Dictionary = new Dictionary<string, int>();
        }

        public int DFSWay(int indexOfA, int indexOfB)
        {
            //base case
            if (indexOfA >= StringA.Length || indexOfB >= StringB.Length)
            {
                return 0;
            }

            var key = indexOfA + "$" + indexOfB;
            if (Dictionary.ContainsKey(key))
            {
                return Dictionary[key];
            }

            var (charAtA, charAtB) = (StringA[indexOfA], StringB[indexOfB]);

            //If both same increase both
            var number = 0;
            if (charAtA == charAtB)
            {
                 number = DFSWay(indexOfA + 1, indexOfB + 1) + 1;
            }
            else
            {
                //Increase just A
                //Increase just B
                var increasingA = DFSWay(indexOfA + 1, indexOfB);
                var increasingB = DFSWay(indexOfA, indexOfB + 1);
                number = increasingA > increasingB ? increasingA : increasingB;
            }
            Dictionary.Add(key, number);
            return number;
        }

        public void TabularWay()
        {
            //
            var matrix = new int[StringA.Length + 1, StringB.Length + 1];

            //outer is row
            for (int i = 1; i < matrix.GetLength(0); i++)
            {
                var valueAtA = StringA[i- 1];
                //inner is column
                for (int j = 1; j < matrix.GetLength(1); j++)
                {
                    var valueAtB = StringB[j - 1];

                    if (valueAtA == valueAtB)
                    {
                        matrix[i, j] = 1 + matrix[i - 1, j - 1];
                    }
                    else
                    {
                        matrix[i, j] = Math.Max(matrix[i - 1, j], matrix[i, j - 1]);
                    }
                }
            }
        }
    }

    public class WordBreak
    {
        public string StringToCheck { get; set; }
        public string[] GivenArrayOfStrings { get; set; }
        public HashSet<string> HashSet { get; set; }
        public Dictionary<string, bool> Dictionary { get; set; }

        public WordBreak()
        {
            HashSet = new HashSet<string>();
            Dictionary = new Dictionary<string, bool>();
        }

        public void Algorithmn()
        {
            //including this index.
            //not includingthis this index

            //if includingthisstringsidereturns true it's true. If not including this side returns true check
            //- this string as well
            foreach (var givenArrayOfString in GivenArrayOfStrings)
            {
                HashSet.Add(givenArrayOfString);
            }
        }

        public bool DfsAlgo(int startindex, int currIndex)
        {
            //base case
            if (currIndex >= StringToCheck.Length)
            {
                return true;
            }

            var key = startindex + "$" + currIndex;

            if (Dictionary.ContainsKey(key))
            {
                return Dictionary[key];
            }
            var currPlusOne = currIndex + 1;

            var includingThisAndBeforeIndex = DfsAlgo(startindex, currIndex + 1);

            if (includingThisAndBeforeIndex)
            {
                Dictionary.Add(key, true);
                return true;
            }
            var notIncludingThis = DfsAlgo(currIndex + 1, currIndex + 1);
            if (notIncludingThis)
            {
                var valFromStartToCurr = StringToCheck[startindex..currPlusOne];
                //if this is up there in the hashmap it's true
                if (HashSet.Contains(valFromStartToCurr))
                {
                    Dictionary.Add(key, true);
                    return true;
                }
            }
            Dictionary.Add(key, false);

            return false;
        }

        public void Tabular()
        {
            var dp = new bool[StringToCheck.Length];

            var length = StringToCheck.Length;
            for (int i = dp.Length - 1; i >= 0; i--)
            {
                var wordFromIthToEnd = StringToCheck[i..length];
                if (HashSet.Contains(wordFromIthToEnd))
                {
                    dp[i] = true;
                }
                else
                {
                    //from i +1: till length - 1
                    var isPossible = false;
                    for (int j = i+1; j < StringToCheck.Length - 1; j++)
                    {
                        if (dp[j] == true)
                        {
                            var word = StringToCheck[i..j];
                            if (HashSet.Contains(word))
                            {
                                isPossible = true;
                                break;
                            }
                        }
                    }

                    dp[i] = isPossible;
                }
            }
        }
    }

    public class CombinationSum
    {
        public int[] GivenArrayOfIntegers { get; set; }
        public int Sum { get; set; }

        public List<List<int>> Answers { get; set; }

        public CombinationSum()
        {
            Answers = new List<List<int>>();
        }
        public void Algorithmn()
        {

        }

        public void DFS(HashSet<int> ignoreIndexes, int prevSum, Stack<int> addedValues)
        {
            //base case
            if (prevSum >= Sum)
            {
                if (prevSum == Sum)
                {
                    //Add it to the list
                    Answers.Add(new List<int>(addedValues));
                }
                return;
            }

            if (ignoreIndexes.Count == GivenArrayOfIntegers.Length)
            {
                return;
            }

            for (int i = 0; i < GivenArrayOfIntegers.Length; i++)
            {
                if (!ignoreIndexes.Contains(i))
                {
                    var sumThatWOuldbeIfAdded = GivenArrayOfIntegers[i] + prevSum;

                    if (sumThatWOuldbeIfAdded <= Sum)
                    {
                        addedValues.Push(GivenArrayOfIntegers[i]);
                        //include This index
                        DFS(ignoreIndexes, sumThatWOuldbeIfAdded, addedValues);
                        //exclude this index
                        ignoreIndexes.Add(i);
                        DFS(ignoreIndexes, sumThatWOuldbeIfAdded, addedValues);
                        ignoreIndexes.Remove(i);
                        addedValues.Pop();
                    }
                }
            }
        }
    }

    public class HouseRobber
    {
        public int[] RobbingValues { get; set; }
        public Dictionary<int, int> Dictionary { get; set; }

        public HouseRobber()
        {
            Dictionary = new Dictionary<int, int>();
        }
        public void Algorithmn()
        {
            var dp = new int[RobbingValues.Length];
            dp[0] = RobbingValues[0];

            for (int i = 1; i < RobbingValues.Length - 1; i++)
            {
                var valBefore = dp[i - 1];
                var valDoubleBefore = 0;
                if (i - 2 >= 0)
                {
                    valDoubleBefore = dp[i - 2];
                }

                var addedWithThis = valDoubleBefore + RobbingValues[i];
                dp[i] = Math.Max(valBefore, addedWithThis);
            }

        }

        public int DFSApproach(int index)
        {
            //base case
            if (index > RobbingValues.Length - 1)
            {
                return 0;
            }

            if (Dictionary.ContainsKey(index))
            {
                return Dictionary[index];
            }
            var valueAtThisIndex = RobbingValues[index];

            var max = 0;
            var maxNextDoor = 0;

            for (int i = index + 1; i < RobbingValues.Length; i++)
                //I guess this would work too. WOuld be like. Including this index
            //for (int i = index + 2; i < RobbingValues.Length; i++)
            {

                var valueHere = DFSApproach(i);

                if (i == index + 1)
                {
                    maxNextDoor = valueHere;
                }
                else
                {
                    if (valueHere > max)
                    {
                        max = valueHere;
                    }
                }
            }

            var returnVal = valueAtThisIndex + max;
            var realMax = Math.Max(returnVal, maxNextDoor);
            Dictionary.Add(index, realMax);
            return realMax;
        }
    }

    public class HouseRobber2
    {
        public int[] GivenArray { get; set; }

        public int End1 { get; set; }
        public int End2 { get; set; }

        public int[] MemoArray1 { get; set; }
        public int[] MemoArray { get; set; }
        public int[] MemoArray2 { get; set; }

        public HouseRobber2()
        {
            End1 = GivenArray.Length - 1;
            End1 = GivenArray.Length;
            //MemoArray1 = new int[End1];
            //MemoArray2 = new int[End2];
            //Array.Fill(MemoArray1, -1);
            //Array.Fill(MemoArray2, -1);
            MemoArray = new int[GivenArray.Length];
            Array.Fill(MemoArray, -1);
        }
        public void Algorithmn()
        {
            var valA = DFS(0, true);
            Array.Fill(MemoArray, -1);
            var valB = DFS(1, false);

            var bigOne = valB > valA ? valB: valA;
            Console.WriteLine($"The biggest sum is {bigOne}");
        }

        
        public int DFS(int index, bool isOne)
        {
            //base case
            var maximum = isOne ? End1 : End2;
            if (index >= maximum)
            {
                return 0;
            }

            if (MemoArray[index] != -1)
            {
                return MemoArray[index];
            }
            var valueHere = GivenArray[index];

            var end = isOne ? End1 : End2;

            var indexPlusOne = index + 1;
            var (max, shouldAddThisValue) = (0, true);
            for (int i = indexPlusOne; i < end; i++)
            {
                var getMax = DFS(i, isOne);
                if (i == indexPlusOne)
                {
                    if (getMax > max)
                    {
                        shouldAddThisValue = false;
                        max = getMax;
                    }
                }
                else
                {
                    if (getMax > max)
                    {
                        shouldAddThisValue = true;
                        max = getMax;
                    }
                }
            }

            var maxOnThisInd = shouldAddThisValue ? max + valueHere : max;
            MemoArray[index] = maxOnThisInd;
            return maxOnThisInd;
        }
    }

    public class DecodeWays
    {
        public string StringToDecode { get; set; }
        public int[] Memo { get; set; }

        public DecodeWays()
        {
            Memo = new int[StringToDecode.Length];
            Array.Fill(Memo, -1);
        }

        public void Algorithm()
        {

        }

        public int DFS(int index)
        {
            //base case
            if (index >= StringToDecode.Length)
            {
                return 1;
            }

            //take 1 and then 2
            if (Memo[index] != -1)
            {
                return Memo[index];
            }

            var valueAtThisIndex = Convert.ToInt32(StringToDecode[index]);

            if (valueAtThisIndex == 0)
            {
                return 0;
            }

            var goNext = DFS(index + 1);

            var checkIf2IsPossible = index + 1;
            if (StringToDecode.Length < checkIf2IsPossible)
            {
                var convertToInt = Convert.ToInt32(StringToDecode[checkIf2IsPossible]);

                if (convertToInt <= 6 && valueAtThisIndex <= 2)
                {
                    var takeTwo = DFS(index + 2);
                    goNext += takeTwo;
                }
            }

            Memo[index] = goNext;
            return goNext;
        }
    }

    public class UniquePaths
    {
        public int[,] Grid { get; set; }
        public string[,] Memo { get; set; }
        public int[,] Memo2 { get; set; }
        public UniquePaths()
        {
            Memo = new String[Grid.GetLength(0), Grid.GetLength(1)];
            Memo2 = new int[Grid.GetLength(0), Grid.GetLength(1)];
            //Array.Fill(Memo, -1);
        }

        public void Algorithmn()
        {

        }

        public int DFSApproach(int row, int column)
        {
            //base case
            var totalRows = Grid.GetLength(0);
            var totalColumns = Grid.GetLength(1);

            if (Memo[row, column] != null)
            {
                var convertedToInt = Convert.ToInt32(Memo[row, column]);
                return convertedToInt;
            }
            if (row >= totalRows || column >= totalColumns)
            {
                return 0;
            }

            if (row == totalRows - 1 && column == totalColumns - 1)
            {
                return 1;
            }

            var addOneRow = row + 1;
            var addOneColumn = column + 1;
            //go down
            var goDown = DFSApproach(addOneRow, column);

            //go right
            var goRight = DFSApproach(row, addOneColumn);

            var allPossibleWays = goDown + goRight;
            Memo[row, column] = allPossibleWays.ToString();
            return allPossibleWays;
        }

        public int TabularRecurseWay(int row, int column)
        {
            //Memo[Memo.GetLength(0) - 1, Memo.GetLength(1) - 1] = "1";
            if (row >= Memo.GetLength(0) || column >= Memo.GetLength(1))
            {
                return 0;
            }

            if (Memo2[row, column] != 0)
            {
                return Memo2[row, column];
            }

            Memo2[row, column] = TabularRecurseWay(row +1, column) + TabularRecurseWay(row, column + 1);
            return Memo2[row, column];
        }
    }

    public class JumpGame
    {
        public int[] HowMuchJump { get; set; }

        public bool[] Memo { get; set; }
        public JumpGame()
        {
            Memo = new bool[HowMuchJump.Length];
        }

        public void Algorithmn()
        {

        }

        public bool DFS(int index)
        {
            //base case
            if (index >= HowMuchJump.Length)
            {
                return true;
            }

            if (Memo[index])
            {
                return Memo[index];
            }
            var valueAtThisIndex = HowMuchJump[index];

            var isPossible = false;
            for (int i = valueAtThisIndex; i > 0; i--)
            {
                var whenJumpingThisMuch = DFS(index + i);
                if (whenJumpingThisMuch)
                {
                    isPossible = true;
                    break;
                }
            }

            Memo[index] = isPossible;
            return isPossible;
        }

        public void Tabular()
        {
            Memo[^1] = true;
            //Memo[^1] = HowMuchJump[^1] != 0;

            var toCheckUntil = Memo.Length - 1;

            for (int i = toCheckUntil + 1; i >= 0; i--)
            {
                var valueHere = HowMuchJump[i];

                var highestItWillGo = valueHere + i;

                if (highestItWillGo >= toCheckUntil)
                {
                    toCheckUntil = i;
                    Memo[i] = true;
                }
                else
                {
                    Memo[i] = false;
                }
            }

        }
    }

    public class CourseSchedule
    {
        public int[][] ArrayOfArrays { get; set; }
        public int NumberOfCourses { get; set; }

        public Dictionary<int, HashSet<int>> AdjacencyList { get; set; }
        public Dictionary<int, bool> Memo { get; set; }
        public CourseSchedule()
        {
            Memo = new Dictionary<int, bool>();
        }

        public void Initialize()
        {
            foreach (var arrayOfArray in ArrayOfArrays)
            {
                var fromNode = arrayOfArray[0];
                var toNode = arrayOfArray[1];

                if (AdjacencyList.ContainsKey(fromNode))
                {
                    AdjacencyList[fromNode].Add(toNode);
                }
                else
                {
                    AdjacencyList[fromNode] = new HashSet<int> { toNode };
                }
            }
        }

        public bool Algorithmn()
        {
            var curr = new HashSet<int>();
            bool isPossible = false;
            foreach (var eachAdj in AdjacencyList)
            {
                if (Memo.ContainsKey(eachAdj.Key))
                {
                    isPossible = Memo[eachAdj.Key];
                }
                else
                {
                    isPossible=DFS(eachAdj.Key, curr);
                }

                if (!isPossible)
                {
                    break;
                }
            }

            return isPossible;
        }
        public bool DFS(int nodeKey, HashSet<int> current)
        {
            //base
            if (current.Contains(nodeKey))
            {
                return false;
            }

            if (Memo.ContainsKey(nodeKey))
            {
                return Memo[nodeKey];
            }
            var getAllNeedForThisNode = AdjacencyList.ContainsKey(nodeKey) ?
                AdjacencyList[nodeKey] : null;

            if (getAllNeedForThisNode == null)
            {
                Memo[nodeKey] = true;
                return true;
            }

            var isThisPossible = true;
            current.Add(nodeKey);
            foreach (var each in getAllNeedForThisNode)
            {
               
                if (current.Contains(each))
                {
                    isThisPossible = false;
                    break;
                }

                bool getNeededForThis;
                if (Memo.ContainsKey(each))
                {
                    getNeededForThis = Memo[each];
                }
                else
                {
                    getNeededForThis = DFS(each, current);
                }

                if (!getNeededForThis)
                {
                    isThisPossible = false;
                    break;
                }
            }

            Memo[nodeKey] = isThisPossible;
            current.Remove(nodeKey);
            return isThisPossible;
        }
    }

    public class PacificAtlanticWaterFlow
    {
        public int[,] Matrix { get; set; }
        public bool[,] Visited { get; set; }

        public HashSet<string> ThatItCouldGo { get; set; }
        public List<int[]> Answers { get; set; }
        public PacificAtlanticWaterFlow()
        {
            //Array.Clear(Matrix, 0, );
            //var isdf = new int[4];
            //Array.Clear(isdf, 0, isdf.Length);
            //var len = Matrix.Length;
            Answers = new List<int[]>();
        }

        public void Algorithmn()
        {
            //for pacific and then to atlantic
            for (int i = 0; i < 2; i++)
            {
                if (i == 1)
                {
                    Array.Clear(Visited, 0, Visited.GetLength(0) * Visited.GetLength(1));
                    for (int j = Matrix.GetLength(0); j >= 0 ; j--)
                    {
                        DFS(j, Matrix.GetLength(0) - 1, Matrix[j, 0], true);
                    }
                    for (int j = Matrix.GetLength(1); j >= 0; j--)
                    {
                        DFS(Matrix.GetLength(1) - 1, j, Matrix[0, j], true);
                    }
                }
                else
                {
                    for (int j = 0; j < Matrix.GetLength(0); j++)
                    {
                        DFS(j, 0, Matrix[j, 0]);
                    }
                    for (int j = 0; j < Matrix.GetLength(0); j++)
                    {
                        DFS(0, j, Matrix[0, j]);
                    }
                }
            }
        }
        public void DFS(int row, int column, int prevVal, bool isSecondSoANswer = false)
        {
            //base case
            if (row >= Matrix.GetLength(0) || column >= Matrix.GetLength(1))
            {
                return;
            }

            if (Visited[row, column])
            {
                return;
            }
            Visited[row, column] = true;
            var valueHere = Matrix[row, column];
            if (valueHere < prevVal)
            {
                return;
            }
            if (ThatItCouldGo.Contains($"{row}, {column}"))
            {
                Answers.Add(new[] { row, column });
            }

            if (!isSecondSoANswer)
            {
               ThatItCouldGo.Add($"{row}, {column}");
            }
            var (rowP, colP, rowM, colM) = (row + 1, column + 1, row - 1, column - 1);

            //could do a visited check here.
            DFS(rowM, column, valueHere);
            DFS(rowP, column, valueHere);
            DFS(row, colP, valueHere);
            DFS(row, colM,valueHere);
        }
    }
}
