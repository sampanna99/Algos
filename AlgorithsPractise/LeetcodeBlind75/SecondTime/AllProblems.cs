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

    public class NumberOfislands
    {
        public int[,] Matrix { get; set; }
        public bool[,] VisitedDupeMatrix { get; set; }

        public NumberOfislands()
        {
            VisitedDupeMatrix = new bool[Matrix.GetLength(0), Matrix.GetLength(1)];
        }
        public void Algorithmn()
        {
            //skip if visited.
            //go over each. 
            //if 1 add 1 to the number of islands.
            //if 1 DFS and add it to the Visited Set
            var numberOfIslands = 0;
            for (int i = 0; i < Matrix.GetLength(0); i++)
            {
                for (int j = 0; j < Matrix.GetLength(1); j++)
                {
                    if (!VisitedDupeMatrix[i, j])
                    {
                        //DFS HERE
                        if (Matrix[i, j] != 1)
                        {
                            VisitedDupeMatrix[i, j] = true;
                        }
                        else
                        {
                            DFS(i,j);
                            numberOfIslands += 1;
                        }
                    }
                }
            }
        }

        private void DFS(int row, int column)
        {
            //base case
            if (Matrix.GetLength(0) >= row || Matrix.GetLength(1) >= column)
            {
                return;
            }


            if (VisitedDupeMatrix[row, column])
            {
                return;
            }

            VisitedDupeMatrix[row, column] = true;

            var (rP, rM, cP, cM) = (row + 1, row - 1, column + 1, column - 1);

            DFS(row, cP);
            DFS(row, cM);
            DFS(rP, column);
            DFS(rM, column);
        }
    }

    public class NodeH
    {
        public int TotalNum { get; set; }
        public int Minimum { get; set; }
        public int Maximum { get; set; }
    }

    public class Node
    {
        public int ValueGiven { get; set; }
        public Node NextNode { get; set; }
    }

    //Neetcode video is okay but I like mine better.
    public class LongestConsecutiveSequence
    {
        public Dictionary<int, NodeH> Dictionary { get; set; }
        public int[] GivenArray { get; set; }
        public LongestConsecutiveSequence()
        {
            
        }
        public void Algorithmn()
        {
            var answer = Int32.MinValue;
            foreach (var each in GivenArray)
            {
                var prev = each - 1;
                var next = each + 1;
                if (Dictionary.ContainsKey(prev) && Dictionary.ContainsKey(next))
                {
                    var getPrev = Dictionary[prev];
                    var getNext = Dictionary[next];
                    var (min, total) = (getPrev.Minimum, getPrev.TotalNum);
                    //var (max, totalOnMax) = (getPrev.Maximum, getNext.TotalNum);

                    Dictionary[prev] = getNext;
                    getNext.Minimum = min;
                    getNext.TotalNum += total + 1;
                    Dictionary[each] = getNext;
                }
                else if(Dictionary.ContainsKey(prev))
                {
                    var getPrev = Dictionary[prev];
                    Dictionary[each] = getPrev;
                    getPrev.TotalNum += 1;
                    getPrev.Maximum = each;
                }
                else if (Dictionary.ContainsKey(next))
                {
                    var getNext = Dictionary[next];
                    Dictionary[each] = getNext;
                    getNext.TotalNum += 1;
                    getNext.Minimum = each;
                }
                else
                {
                    Dictionary[each] = new NodeH{TotalNum = 1, Maximum = each, Minimum = each};
                }

                if (Dictionary[each].TotalNum > answer)
                {
                    answer = Dictionary[each].TotalNum;
                }
            }
        }
    }

    public class AlienDictionary
    {
        public string[] GivenArrayOfStrings { get; set; }
        public Dictionary<string, HashSet<string>> Dictionary { get; set; }
        public StringBuilder StringInSortedAlien { get; set; }
        public HashSet<string> AlreadyProcessed { get; set; }
        public AlienDictionary()
        {
            StringInSortedAlien = new StringBuilder();
            AlreadyProcessed = new HashSet<string>();
        }

        public void Algorithmn()
        {
            //Compare two numbers. n and n + 1;
            //first differing character create a dict--> List<string>
            //if already presents add another node

            for (int i = 1; i < GivenArrayOfStrings.Length; i++)
            {
                var iMinusOne = i - 1;

                var wordBefore = GivenArrayOfStrings[iMinusOne];
                var wordHere = GivenArrayOfStrings[i];

                var minimumOne = wordHere.Length > wordBefore.Length ? wordHere.Length : wordBefore.Length;
                for (int j = 0; j < minimumOne; j++)
                {
                    var wordB = wordBefore[j].ToString();
                    var wordH = wordHere[j].ToString();

                    if (wordB != wordH)
                    {
                        if (Dictionary.ContainsKey(wordB))
                        {
                            Dictionary[wordB].Add(wordH);
                        }
                        else
                        {
                            Dictionary[wordB] = new HashSet<string> { wordH };
                        }
                    }
                }
            }

            var hashOfThingsDone = new HashSet<string>();
            //Now start with any one of the in dictionary
            var hashToPass = new HashSet<string>();
            foreach (var keyPair in Dictionary)
            {
                var keyValue = keyPair.Key;
                //var Valuevalue = keyPair.Value;
                DFS(hashToPass, keyValue);
                hashToPass.Clear();
            }
        }


        private StringBuilder DFS(HashSet<string> inThePath, string key)
        {
            if (inThePath.Contains(key))
            {
                return null;
            }

            if (AlreadyProcessed.Contains(key))
            {
                return StringInSortedAlien;
            }

            var getAllForThatKey = Dictionary[key];
            inThePath.Add(key);
            var toadd = key;
            foreach (var each in getAllForThatKey)
            {
                
                var goEach = DFS(inThePath, each);
                if (goEach == null)
                {
                    toadd = null;
                    break;
                }
            }
            inThePath.Remove(key);
            AlreadyProcessed.Add(key);
            if (toadd == null)
            {
                return null;
            }
            StringInSortedAlien.Insert(0, toadd);
            return StringInSortedAlien;
        }
    }

    public class GraphValidTree
    {

        public int TotalNumber { get; set; }

        public int[][] GivenEdges { get; set; }

        public Dictionary<int, HashSet<int>> Dictionary { get; set; }
        public bool[] Array { get; set; }

        public GraphValidTree()
        {
            PopulateDictionary();
        }
        private void PopulateDictionary()
        {
            for (int i = 0; i < GivenEdges.Length; i++)
            {
                var first = GivenEdges[i][0];
                var second = GivenEdges[i][1];

                if (Dictionary.ContainsKey(first))
                {
                    Dictionary[first].Add(second);
                }
                else
                {
                    Dictionary[first] = new HashSet<int> { second };
                }

                if (Dictionary.ContainsKey(second))
                {
                    Dictionary[second].Add(first);
                }
                else
                {
                    Dictionary[second] = new HashSet<int> { first };
                }
            }

            Array = new bool[Dictionary.Count];
        }
        public void Algorithmn()
        {
            var currentPath = new HashSet<int>();
            var isValidTree = true;
            foreach (var keyVal in Dictionary)
            {
                var callDFS = DFSToCheckLoop(keyVal.Key, currentPath);
                if (callDFS)
                {
                    isValidTree = false;
                    break;
                }
            }

            Console.WriteLine($"The given Graph is Tree.  {isValidTree}");
        }

        //I did it for Directred Graph. This is good maybe not even right. Just need visit set and pre order
        private bool DFSToCheckLoop(int index, HashSet<int> inPath)
        {
            //base case
            if (inPath.Contains(index))
            {
                return true;
            }

            if (Array[index])
            {
                return false;
            }

            var getAll = Dictionary[index];

            var loop = false;
            inPath.Add(index);
            foreach (var eachHash in getAll)
            {
                var isLoop = DFSToCheckLoop(eachHash, inPath);
                if (isLoop)
                {
                    loop = true;
                    break;
                }
            }

            inPath.Remove(index);
            Array[index] = true;
            return loop;
        }

    }

    public class NumberOfConnectedComponents
    {
        public int NumberOfNodes { get; set; }
        public int[][] ArrayOfArrays { get; set; }
        public Dictionary<int, HashSet<int>> AdjacencyList { get; set; }
        public HashSet<int> VisitedHash { get; set; }

        public NumberOfConnectedComponents()
        {
            AdjacencyList = new Dictionary<int, HashSet<int>>();
            VisitedHash = new HashSet<int>();
        }

        private void AddToAdjacency(int key, int value)
        {
            if(AdjacencyList.ContainsKey(key))
            {
                AdjacencyList[key].Add(value);
            }
            else
            {
                AdjacencyList[key] = new HashSet<int> { value };
            }
        }

        private void CreateAdjacency()
        {
            for (int i = 0; i < ArrayOfArrays.Length; i++)
            {
                var first = ArrayOfArrays[i][0];
                var second = ArrayOfArrays[i][1];

                AddToAdjacency(first, second);
                AddToAdjacency(second, first);
            }
        }
        public void Algorithmn()
        {
            //Create Adjacency List
            //Make sure you have visited Hash
            //go through each on the adjacency. if not all are done in first DFS then we have more than one
            //keep adding one until you find how many are there.
            var totalNumberOfConnected = 1;
            foreach (var keyVal in AdjacencyList)
            {
                var key = keyVal.Key;
                DFS(key, key);
                if (VisitedHash.Count == AdjacencyList.Count)
                {
                    break;
                }

                totalNumberOfConnected += 1;
            }

            Console.WriteLine($"Total number of connected components are {totalNumberOfConnected}");
        }

        public void DFS(int key, int parent)
        {
            //base case
            if (VisitedHash.Contains(key))
            {
                return;
            }

            VisitedHash.Add(key);
            var allFromAdjacency = AdjacencyList[key];

            foreach (var hashes in allFromAdjacency)
            {
                if (parent == hashes)
                {
                    continue;
                }
            }
        }

        //using unionFind
        public void Algorithm2()
        {
            var unionDummy = new int[NumberOfNodes];
            Array.Fill(unionDummy, -1);
            var totalIslands = NumberOfNodes;

            foreach (var arrayOfArray in ArrayOfArrays)
            {
                var first = arrayOfArray[0];
                var second = arrayOfArray[1];
                //second parent of first
                //if negative self parent. Value is the weight
                var firstVal = FindParent(unionDummy, first);
                var secondVal = FindParent(unionDummy, second);

                if (firstVal == secondVal)
                {
                    //means they have the same parent
                    continue;
                }

                var (smallestOne, larger) = unionDummy[firstVal] < unionDummy[secondVal]
                    ? (firstVal, secondVal)
                    : (secondVal, firstVal);
                var howManyAlreadyThere = unionDummy[larger];
                unionDummy[larger] = smallestOne;
                unionDummy[smallestOne] -= howManyAlreadyThere;
                totalIslands -= 1;
            }
        }

        private int FindParent(int[] dummy, int index)
        {
            if (dummy[index] < 0)
            {
                return index;
            }

            return FindParent(dummy, dummy[index]);
        }
    }

    public class InsertInterval
    {
        public int[][] MainInterval { get; set; }
        public int[] SecondInterval { get; set; }

        public InsertInterval()
        {
            
        }

        public void Algorithmn()
        {
            //end of main should be greater or equal to start of small

            //foreach from the main list
            //check with the given one
            //if not in between add it to the list
            //if it's in there then do the code section and add it to a temonetocheck with the next one

            var secondInterValA = SecondInterval[0];
            var secondInterValB = SecondInterval[1];

            var answer = new List<int[]>();
            bool addAux = false;
            var aux = new int[2];
            for (int i = 0; i < MainInterval.Length; i++)
            {
                var firstVal = MainInterval[i][0];
                var secondVal = MainInterval[i][1];

                //means intersection
                if (secondVal >= secondInterValA && secondInterValB >= firstVal)
                {
                    addAux = true;
                    var minVal = Math.Min(firstVal, secondInterValA);
                    var maxVal = Math.Max(secondVal, secondInterValB);
                    aux[0] = minVal;
                    aux[1] = maxVal;
                }
                else
                {
                    if (addAux)
                    {
                        answer.Add(aux);
                    }
                    answer.Add(MainInterval[i].ToArray());
                }
            }
        }
    }

    public class NonOverlappingIntervals
    {
        public int[][] GivenArrays { get; set; }

        public NonOverlappingIntervals()
        {
            
        }

        public void Algrotihmn()
        {
            QuickSort(0, GivenArrays.Length - 1);

            //Go through each if 
            var maximumRemoval = 0;

            var prevOne = GivenArrays[0];
            for (int i = 1; i < GivenArrays.Length; i++)
            {
                //check if overlapping
                var (startPrev, endPrev) = (prevOne[0], prevOne[1]);
                var (start, end) = (GivenArrays[i][0], GivenArrays[i][1]);

                //interval
                if (endPrev > start)
                {
                    maximumRemoval += 1;
                }

                prevOne = endPrev < end ? prevOne : GivenArrays[i];

            }
        }

        private void QuickSort(int startInd, int endInd)
        {
            //base case
            if (startInd >= endInd)
            {
                return;
            }
            //find the partition index
            var partIndex = FindPartitionIndex(startInd, endInd);
            //Sort Left
            QuickSort(startInd, partIndex - 1);
            //Sort Right
            QuickSort(partIndex + 1, endInd);
        }

        private int FindPartitionIndex(int startIndex, int endIndex)
        {
            var takeLastAsThe = GivenArrays[endIndex][0];

            var partition = startIndex;

            while (startIndex < endIndex)
            {
                var valueHereAtStart = GivenArrays[startIndex][0];
                if (valueHereAtStart < takeLastAsThe)
                {
                    //swap with the partition
                    (GivenArrays[startIndex], GivenArrays[partition]) = (GivenArrays[partition],
                        GivenArrays[startIndex]);
                    partition += 1;
                }
                startIndex += 1;
            }

            (GivenArrays[partition], GivenArrays[endIndex]) = (GivenArrays[endIndex], GivenArrays[partition]);
            return partition;
        }
    }

    public class MeetingRooms2
    {
        public int[][] MeetingIntervals { get; set; }
        public MeetingRooms2()
        {
            
        }

        public void Algorithmn()
        {
            //sort it first
            var dictionaryOfMeetingsEndingAtTimes = new Dictionary<int, int>();
            var maximumRooms = 0;
            var numberOfMeetings = 0;
            for (int i = 0; i < MeetingIntervals.Length; i++)
            {
                var (start, end) = (MeetingIntervals[i][0], MeetingIntervals[i][1]);
                //Remove all before that time. and reduce the number of meeting rooms used
                //WOuld take n^2 complexicity

            }

        }
        public void Algorithmn2()
        {
            var getSortedStartTime = new int[MeetingIntervals.Length];
            var getSortedEndTime = new int[MeetingIntervals.Length];

            var (iterateStart, iterateEnd, currentRooms, maxRooms) = (0,0,0,0);
            while (iterateStart < getSortedEndTime.Length)
            {
                var startTime = getSortedStartTime[iterateStart];
                var endTime = getSortedEndTime[iterateEnd];
                if (endTime <= startTime)
                {
                    //decrease the number of meetings
                    currentRooms -= 1;
                    iterateEnd += 1;
                    continue;
                }

                currentRooms += 1;
                if (currentRooms > maxRooms)
                {
                    maxRooms = currentRooms;
                }
                iterateStart += 1;
            }
        }
    }

    public class LinkedListCycle
    {
        public Node GivenNode { get; set; }

        public LinkedListCycle()
        {
            
        }

        public void Algorithmn()
        {
            var (fastPointer, slowPointer, isCycle) = (GivenNode, GivenNode, false);

            while (slowPointer != null)
            {
                slowPointer = slowPointer.NextNode;
                fastPointer = fastPointer == null ? GivenNode.NextNode : fastPointer.NextNode;
                if (fastPointer != null)
                {
                    fastPointer = fastPointer.NextNode ?? GivenNode;
                }
                else
                {
                    fastPointer = GivenNode.NextNode;
                }

                if (slowPointer == fastPointer)
                {
                    //they are in a cycle
                    isCycle = true;
                    break;
                }
            }
        }
    }

    public class MergeSortedLinkedList
    {
        public Node NodeA { get; set; }
        public Node NodeB { get; set; }

        public MergeSortedLinkedList()
        {
            
        }

        public void Algorithmn()
        {
            //check val from nodeA, nodeB
            //next NodeA or node BN do it until it's done.
            var (dumNodeA, dumNodeB, ans) = (NodeA, NodeB, new Node());

            while (dumNodeA != null && dumNodeB != null)
            {
                var valA = dumNodeA.ValueGiven;
                var valB = dumNodeB.ValueGiven;

                if (valA > valB)
                {
                    ans.NextNode = dumNodeA;
                    dumNodeA = dumNodeA.NextNode;
                }
                else
                {
                    ans.NextNode = dumNodeB;
                    dumNodeB = dumNodeB.NextNode;
                }
                ans = ans.NextNode;
            }

            if (dumNodeA == null)
            {
                ans.NextNode = dumNodeB;
            }
            else
            {
                ans.NextNode = dumNodeA;
            }

        }
    }

    public class MergeKSortedList
    {
        public List<Node> SortedLinkedListsGiven { get; set; }

        public MergeKSortedList()
        {
            SortedLinkedListsGiven = new List<Node>();
        }

        public void Algorithmn()
        {
            //go through each one of them and create a new one. //not good approach
            while (SortedLinkedListsGiven.Count > 1)
            {
                var auxiliary = new List<Node>();
                for (int i = 0; i < SortedLinkedListsGiven.Count; i += 2)
                {
                    var firstOne = SortedLinkedListsGiven[i];
                    var iPlusOne = i + 1;
                    var secondOne = SortedLinkedListsGiven.Count > iPlusOne ? SortedLinkedListsGiven[iPlusOne]
                        : null;

                    if (secondOne != null)
                    {
                        var mergeTwo = MergeTwoSortedLinkedList(firstOne, secondOne);
                        auxiliary.Add(mergeTwo);
                    }
                    else
                    {
                        auxiliary.Add(firstOne);
                    }
                }

                SortedLinkedListsGiven = auxiliary;
            }
            //the one in SortedLinkedListsGiven is the answer.
        }

        private Node MergeTwoSortedLinkedList(Node nodeA, Node nodeB)
        {
            var dummy = new Node();
            var head = dummy;
            while (nodeA != null && nodeB != null)
            {
                var valA = nodeA.ValueGiven;
                var valB = nodeB.ValueGiven;

                if (valA > valB)
                {
                    dummy.NextNode = nodeA;
                    nodeA = nodeA.NextNode;
                }
                else
                {
                    dummy.NextNode = nodeB;
                    nodeB = nodeB.NextNode;
                }
            }

            if (nodeA != null)
            {
                dummy.NextNode = nodeA;
            }

            if (nodeB != null)
            {
                dummy.NextNode = nodeB;
            }

            return head.NextNode;
        }
    }

    public class RemoveNthFromEnd
    {
        public Node LinkedList { get; set; }
        public int Number { get; set; }
        public RemoveNthFromEnd()
        {
            LinkedList = new Node();
        }

        public Node Algorithmn()
        {
            //1,2,3,4,5,6
            //Left pointer and right pointer difference is Number + 1;
            var dummy = new Node();
            dummy.NextNode = LinkedList;

            var firstPointer = dummy;
            var secondPointer = new Node();
            for (int i = 0; i <= Number; i++)
            {
                secondPointer = secondPointer.NextNode;

            }

            while (secondPointer != null)
            {
                firstPointer = firstPointer.NextNode;
                secondPointer = secondPointer.NextNode;
            }

            firstPointer.NextNode = firstPointer.NextNode.NextNode;
            return dummy.NextNode;
        }
    }

    public class SetMatrixZeros
    {
        public int[,] GivenMatrix { get; set; }
        public SetMatrixZeros()
        {
            
        }
        public void Algorithmn()
        {
            var firstRow = 1;

            var (row, col) = (GivenMatrix.GetLength(0), GivenMatrix.GetLength(1));

            //do the first row
            for (int i = 0; i < col; i++)
            {
                var val = GivenMatrix[0, i];

                if (val == 0)
                {
                    firstRow = 0;
                }
            }
            //row
            for (int i = 1; i < row; i++)
            {
                //column
                for (int j = 0; j < col; j++)
                {
                    var value = GivenMatrix[i, j];
                    if (value == 0)
                    {
                        GivenMatrix[0, j] = 0;
                        GivenMatrix[i, 0] = 0;
                    }
                }
            }

            for (int i = 1; i < col; i++)
            {
                //let's zero out the colm
                var valueAtFirst = GivenMatrix[0, i];
                if (valueAtFirst == 0)
                {
                    for (int j = 1; j < row; j++)
                    {
                        GivenMatrix[j, i] = 0;
                    }
                }
                
            }
            //Now 0 the row if required.
            if (firstRow == 0)
            {
                for (int i = 0; i < col; i++)
                {
                    GivenMatrix[0, i] = 0;
                }
            }

            for (int i = 1; i < row; i++)
            {
                var valueHere = GivenMatrix[i, 0];
                if (valueHere == 0)
                {
                    for (int j = 1; j < col; j++)
                    {
                        GivenMatrix[i, j] = 0;
                    }
                }
            }
        }
    }

    public class SpiralMatrix
    {
        public int[,] GivenMatrix { get; set; }

        public SpiralMatrix()
        {
            
        }

        public void Algorithmn()
        {
            var (row, col) = (GivenMatrix.GetLength(0), GivenMatrix.GetLength(1));
            var (left, right, top, down) = (0, col-1, 0, row-1);

            var intArr = new int[GivenMatrix.Length];
            var listofIntANs = new List<int>();
            var index = 0;
            while (left <= right && top <= down)
            {
                //left to right
                for (int i = top; i <= right; i++)
                {
                    intArr[index] = GivenMatrix[top, i];
                    index += 1;
                    top += 1;
                    if (top < down)
                    {
                        break;
                    }
                }

                //top to bottom
                for (int i = top; i <= down; i++)
                {
                    intArr[index] = GivenMatrix[i, right];
                    index += 1;
                    right -= 1;
                    if (left > right)
                    {
                        break;
                    }
                }
                //right to left
                for (int i = right; i >= left; i--)
                {
                    intArr[index] = GivenMatrix[i, down];
                    index += 1;
                    down -= 1;
                    if (right < left)
                    {
                        break;
                    }
                }
                //bottom to top
                for (int i = down; i >= top; i--)
                {
                    intArr[index] = GivenMatrix[i, left];
                    index += 1;
                    down -= 1;
                    if (down < top)
                    {
                        break;
                    }
                }
            }
        }
    }

    public class RotateImage
    {
        public int[,] GivenMatrix { get; set; }

        public RotateImage()
        {
            
        }

        public void Algorithmn()
        {
            //boundries
            //go from l-r, t-d, r-l, d-t
            var (col, row) = (GivenMatrix.GetLength(1), GivenMatrix.GetLength(0));
            var (left, right, top, down) = 
                (0, GivenMatrix.GetLength(1), 0, GivenMatrix.GetLength(0));
            //var numberOfFills = right

            while (left < right && top < down)
            {
                //var numberOfFillsFirst = right - left;
                //for (int i = 0; i < numberOfFillsFirst; i++)
                //{
                //    var toBeReplaced = GivenMatrix[top + i, right];
                //    GivenMatrix[top + i, right] = GivenMatrix[top, left + i];
                //}

                var toBeReplaced = GivenMatrix[top, right];
                GivenMatrix[top, right] = GivenMatrix[top, left];
                //l--r
                (GivenMatrix[down, right], toBeReplaced) = (toBeReplaced, GivenMatrix[down, right]);
                //t--d
                (GivenMatrix[down, left], toBeReplaced) = (toBeReplaced, GivenMatrix[down, left]);
                //r--l
                GivenMatrix[top, left] = toBeReplaced;
                //d--t
                top += 1;
                down -= 1;
                right -= 1;
                left += 1;
            }
        }
    }

    public class WordSearch
    {
        public string[,] GivenMatrix { get; set; }
        public string GivenString { get; set; }

        public void Algorithmn()
        {

        }

        private bool DFS(int indexR, int indexC, HashSet<string> inThePath)
        {
            //base case
            if (indexR >= GivenMatrix.GetLength(0) || indexC >= GivenMatrix.GetLength(1)
            || indexR < 0 || indexC < 0)
            {
                return false;
            }

            var valueHere = GivenMatrix[indexR, indexC];
            //go using prev
            var count = inThePath.Count;
            var thisPath = $"{indexR}, {indexC}";

            var (rP, cP, rM, cM) = (indexR + 1, indexC + 1, indexR - 1, indexC - 1);

            if (count > 0)
            {
                if (!inThePath.Contains(thisPath) && GivenString[count].ToString() == valueHere)
                {
                    inThePath.Add(thisPath);
                    var df1 = DFS(rP, indexC, inThePath);
                    var df2 = DFS(rM,indexC, inThePath);
                    var df3 = DFS(indexR, cP, inThePath);
                    var df4 = DFS(indexR, cM, inThePath);
                    inThePath.Remove(thisPath);
                    if (df1 || df2 || df3 || df4)
                    {
                        return true;
                    }
                }
            }
            //go starting this
            var firstOne = GivenString[0].ToString();
            if (valueHere == firstOne)
            {
                inThePath.Add(thisPath);
                var newHash = new HashSet<string>();
                var df1 = DFS(rP, indexC, inThePath);
                var df2 = DFS(rM, indexC, inThePath);
                var df3 = DFS(indexR, cP, inThePath);
                var df4 = DFS(indexR, cM, inThePath);
                inThePath.Remove(thisPath);
                if (df1 || df2 || df3 || df4)
                {
                    return true;
                }
            }
            return false;
        }
    }

    //Two pointer solution
    public class LongestSubstringWithoutRepeatingChars
    {
        public string GivenString { get; set; }
        public LongestSubstringWithoutRepeatingChars()
        {
            
        }

        public void Algorithmn()
        {
            //two pointers have a hash

            var (hashOfwords, highestNumber, left, right) = (new HashSet<string>(),
                0, 0, 0);

            while (right < GivenString.Length)
            {
                var valueHereAtRight = GivenString[right].ToString();
                if (hashOfwords.Contains(valueHereAtRight))
                {
                    var getValAtLeft = GivenString[left].ToString();
                    hashOfwords.Remove(getValAtLeft);
                    left += 1;
                }
                else
                {
                    hashOfwords.Add(valueHereAtRight);
                    right += 1;
                    if (hashOfwords.Count > highestNumber)
                    {
                        highestNumber = hashOfwords.Count;
                    }
                }
            }

        }
    }

    public class LongesatRepeatingCharacterReplacement
    {
        public string GivenString { get; set; }
        public int NumberOfTimes { get; set; }
        public LongesatRepeatingCharacterReplacement()
        {
            
        }

        public void Algorithmn()
        {
            var dictOfAllChar = new Dictionary<string, int>();
            var (start, end, maximumRepeatingChar) = (0, 0, 0);
            var longestOne = "";

            while (end < GivenString.Length)
            {
                var valueHere = GivenString[end].ToString();
                if (dictOfAllChar.ContainsKey(valueHere))
                {
                    dictOfAllChar[valueHere] += 1;
                }
                else
                {
                    dictOfAllChar[valueHere] = 1;
                }

                if (longestOne != "")
                {
                    var longest = dictOfAllChar[longestOne];
                    if (longest < dictOfAllChar[valueHere])
                    {
                        //longest = dictOfAllChar[valueHere];
                        longestOne = valueHere;
                    }
                }
                else
                {
                    longestOne = valueHere;
                }

                //check to see if it breaks
                var numberofChars = end - start + 1;
                var longestD = dictOfAllChar[longestOne];
                var numCharsMinusNumOfTimes = numberofChars - NumberOfTimes;
                if (numCharsMinusNumOfTimes > longestD)
                {
                    //remove from start until it is valid
                    while (numCharsMinusNumOfTimes > longestD)
                    {
                        var letterAtStart = GivenString[start].ToString();
                        var valueAtStart = dictOfAllChar[letterAtStart];

                        //check if it is the longestD
                        if (longestOne == letterAtStart)
                        {
                            //if longestOne and loongestD with the new one.

                            if (valueAtStart == 1)
                            {
                                //remove
                                dictOfAllChar.Remove(letterAtStart);
                            }
                            else
                            {
                                dictOfAllChar[letterAtStart] -= 1;
                            }

                            ReplaceLongestOneAndUpdate(ref longestD, ref longestOne, dictOfAllChar);
                        }

                        start += 1;

                        numberofChars = end - start + 1;
                        numCharsMinusNumOfTimes = numberofChars - NumberOfTimes;
                    }
                }

                var actualNumsofchars = end - start + 1;
                if (maximumRepeatingChar < actualNumsofchars)
                {
                    maximumRepeatingChar = actualNumsofchars;
                }
                end += 1;
            }
        }

        private void ReplaceLongestOneAndUpdate(ref int longest, ref string longestOne, 
            Dictionary<string, int> dict)
        {
            var keyVal = new KeyValuePair<string, int>();

            foreach (var each in dict)
            {
                if (each.Value > keyVal.Value)
                {
                    keyVal = each;
                }
            }

            longestOne = keyVal.Key;
            longest = keyVal.Value;
        }
    }

    public class MinimumWindowSubstring
    {
        public string StringA { get; set; }
        public string StringB { get; set; }

        public MinimumWindowSubstring()
        {
            
        }

        public void Algorithmn()
        {
            //Go through each in A
            //have and ToMake hashes
            var haveDict = new Dictionary<string, int>();
            var needDict = new Dictionary<string, int>();

            foreach (var eachString in StringB)
            {
                var eachStringinStr = eachString.ToString();
                if (needDict.ContainsKey(eachStringinStr))
                {
                    needDict[eachStringinStr] += 1;
                }
                else
                {
                    needDict[eachStringinStr] = 1;
                    haveDict.Add(eachStringinStr, 0);
                }
            }

            var (first, second, currMatch, totalMatchNeed) = (0, 0, 0, needDict.Count);
            var (maximum, maximumVal) = (0, "");

            while (second < StringA.Length)
            {
                var valueHereAtSec = StringA[second].ToString();

                if (needDict.ContainsKey(valueHereAtSec))
                {
                    haveDict[valueHereAtSec] += 1;
                    var needVal = needDict[valueHereAtSec];
                    var haveDictV = haveDict[valueHereAtSec];

                    if (haveDictV == needVal)
                    {
                        //increase by 1
                        currMatch += 1;

                        if (totalMatchNeed == currMatch)
                        {
                          //start removing from start
                          while (first <= second && currMatch == totalMatchNeed)
                          {
                              var numberMin = second - first + 1;
                              if (maximum < numberMin)
                              {
                                  maximum = numberMin;
                                  var secondPlusO = second + 1;
                                  maximumVal = StringA[first..secondPlusO];
                              }
                              var toRemove = StringA[first].ToString();
                              if (needDict.ContainsKey(toRemove))
                              {
                                  var valueNeed = needDict[toRemove];
                                  haveDict[toRemove] -= 1;
                                  var valueOfHave = haveDict[toRemove];
                                  if (valueOfHave < valueNeed)
                                  {
                                      currMatch -= 1;
                                  }
                              }
                              first += 1;
                          }
                        }
                    }
                }
            }
        }
    }

    public class GroupAnagrams
    {
        public string[] GivenStringArray { get; set; }

        public GroupAnagrams()
        {
            
        }

        public void Algorithmn()
        {
             //a-z array
             //for each documents create a string for the dictionary (string, List <string>)
             var dictionary = new Dictionary<string, List<string>>();

             for (int i = 0; i < GivenStringArray.Length; i++)
             {
                 var valueHere = GivenStringArray[i];

                 var bucket = new int[26];
                 for (int j = 0; j < valueHere.Length; j++)
                 {
                     var charH = valueHere[j];
                     var index = charH - 'a';
                     bucket[index] += 1;
                 }

                 var hash = new StringBuilder();
                 foreach (var i1 in bucket)
                 {
                     if (i1 > 0)
                     {
                         var whatIsTheChar = i1 + 'a';
                        var charVal = Convert.ToChar(whatIsTheChar).ToString();
                        hash.Append(charVal + whatIsTheChar);
                     }
                 }

                 var hashStr = hash.ToString();
                 if (dictionary.ContainsKey(hashStr))
                 {
                    dictionary[hashStr].Add(valueHere);                     
                 }
                 else
                 {
                     dictionary[hashStr] = new List<string> { valueHere };
                 }
             }
             //Now just go over the dictionary and you got the answer.
        }
    }

    public class ValidPalindrome
    {
        public string GivenString { get; set; }
        public ValidPalindrome()
        {
            
        }

        public void Algorithmn()
        {
            //o to n, 0+1, n-1 
            var length = GivenString.Length;
            var (first, last, isValid) = (0, length - 1, true);
            //check if both are alphanumeric
            while (first < last)
            {
                var valA = GivenString[first];
                var valB = GivenString[last];

                var firstAlpha = IsAlphaNumeric(GivenString[first]);
                var lastAlpha = IsAlphaNumeric(GivenString[last]);

                if (firstAlpha && lastAlpha)
                {
                    if (valA == valB)
                    {
                        first += 1;
                        last -= 1;
                    }
                    else
                    {
                        isValid = false;
                        break;
                    }
                }

                if (!firstAlpha)
                {
                    first += 1;
                }
                if (!lastAlpha)
                {
                    last -= 1;
                }
            }
        }

        private bool IsAlphaNumeric(char toCheckStr)
        {
            var checkIfAlpha = toCheckStr - 'a';

            if (checkIfAlpha >= 0 && checkIfAlpha <= 25)
            {
                return true;
            }

            checkIfAlpha = toCheckStr - '0';
            if (checkIfAlpha >= 0 && checkIfAlpha <= 9)
            {
                return true;
            }

            return false;
        }
    }

    public class LongestPalindromicSubstring
    {
         
    }
}
