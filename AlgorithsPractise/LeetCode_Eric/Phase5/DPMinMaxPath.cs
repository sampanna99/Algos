using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithsPractise.LeetCode_Eric.Phase5
{
    public class DPMinMaxPath
    {
    }

    public class Triangle
    {


        public int[][] GivenArrayOfArrays { get; set; }

        public void ALgorithmn()
        {

        }


        //could do memoization but I am skipping it for now.
        //could use another way. Kind of using finding level wise.
        //https://www.youtube.com/watch?v=OM1MTokvxs4
        public Tuple<List<int>, int> DFSApproach(int bigArrayIndex, int smallArrayIndex)
        {
            //base case
            if (bigArrayIndex >= GivenArrayOfArrays.Length)
            {
                return new Tuple<List<int>, int>(new List<int>(), 0);
            }

            var sameIndexBelow = DFSApproach(bigArrayIndex +1, smallArrayIndex);
            var oneStepAhead = DFSApproach(bigArrayIndex + 1, smallArrayIndex + 1);
            var valueAtThisIndex = GivenArrayOfArrays[bigArrayIndex][smallArrayIndex];
            if (sameIndexBelow.Item2 > oneStepAhead.Item2)
            {
                var list = new List<int>(oneStepAhead.Item1);
                list.Add(valueAtThisIndex);
                var itemSum = oneStepAhead.Item2 + valueAtThisIndex; 
                return Tuple.Create(list, itemSum);
            }
            else
            {
                var list = new List<int>(sameIndexBelow.Item1);
                list.Add(valueAtThisIndex);
                var itemSum = sameIndexBelow.Item2 + valueAtThisIndex;
                return Tuple.Create(list, itemSum);
            }
        }
    }

    //https://www.youtube.com/watch?v=pGMsrvt0fpk
    public class MinimumPath
    {
        public int[,] Grid { get; set; }
        public Dictionary<string, Tuple<int, List<int>>> DictionaryMemo { get; set; }

        public MinimumPath()
        {
            DictionaryMemo = new Dictionary<string, Tuple<int, List<int>>>();
        }

        public void Algorithmn()
        {

        }

        public Tuple<int, List<int>> DFS(int row, int column)
        {
            //base case
            // when row or col is outta boundry
            //when they are at the last one.
            if (row >= Grid.GetLength(0) || column >= Grid.GetLength(1))
            {
                return null;
            }


            if (DictionaryMemo.ContainsKey($"{row}{column}"))
            {
                return DictionaryMemo[$"{row}{column}"];
            }

            if (row == Grid.GetLength(0) - 1 && column == Grid.GetLength(1) - 1)
            {
                return new Tuple<int, List<int>>(Grid[Grid.GetLength(0) - 1, Grid.GetLength(1) - 1],
                new List<int>{Grid[Grid.GetLength(0) - 1, Grid.GetLength(1) - 1] });
            }

            var goright = DFS(row + 1, column);
            var godown = DFS(row + 1, column);
            if (goright.Item1 > godown.Item1)
            {
                var addedThisInd = Grid[row, column] + godown.Item1;
                var list = new List<int>(godown.Item2);
                list.Add(Grid[row, column]);
                var returnThisTup = new Tuple<int, List<int>>(addedThisInd, list);
                DictionaryMemo.Add($"{row}{column}", Tuple.Create(addedThisInd, list));
                return returnThisTup;
            }
            else
            {
                var addedThisInd = Grid[row, column] + goright.Item1;
                var list = new List<int>(goright.Item2);
                list.Add(Grid[row, column]);
                var returnThisTup = new Tuple<int, List<int>>(addedThisInd, list);
                DictionaryMemo.Add($"{row}{column}", Tuple.Create(addedThisInd, list));
                return returnThisTup;
            }

        }
    }

    public class MaximalSquare
    {
        public int[,] GivenMatrix { get; set; }
        public Dictionary<string, int> MemoDictionary { get; set; }
        public MaximalSquare()
        {
            MemoDictionary = new Dictionary<string, int>();
        }

        public void Algorithmn()
        {

        }


        //https://www.youtube.com/watch?v=6X7Ha2PrDmM
        //Also another way of doing it Bottom up DP
        public int TopDownAkaDFS(int row, int column)
        {
            //base case if out of r/c

            if (MemoDictionary.ContainsKey($"{row}{column}"))
            {
                return MemoDictionary[$"{row}{column}"];
            }
            var (rP, cP) = (row + 1, column + 1);
            var valueHere = GivenMatrix[row, column];

            if (valueHere == 0)
            {
                MemoDictionary.Add($"{row}{column}", valueHere);
            }

            //go down
            var areaB = TopDownAkaDFS(rP, column);
            //go right
            var areaR = TopDownAkaDFS(row, cP);
            //go diagonal
            var areaD = TopDownAkaDFS(rP, cP);

            var minimum = Math.Min(areaB, Math.Min(areaR, areaD));
            var returnValue = 1 + minimum;

            MemoDictionary.Add($"{row}{column}", returnValue);

            return returnValue;
        }
    }

    public class CoinChange
    {
        public int SumToMake { get; set; }
        public Dictionary<int, int> MemoInNotI { get; set; }
        public int[] GivenArray { get; set; }

        public CoinChange()
        {
            MemoInNotI = new Dictionary<int, int>();
        }

        //taking/not taking
        //I think it has to be sorted. Maybe not
        public int DFSAS(int sum, int startIndex)
        {
            //base case
            if (sum == SumToMake)
            {
                return 0;
            }
            if (sum > SumToMake || startIndex >= GivenArray.Length)
            {
                return Int32.MaxValue;
            }

            if (MemoInNotI.ContainsKey(sum))
            {
                return MemoInNotI[sum];
            }
            //taking this index
            var newSum = sum + GivenArray[startIndex];
            var numberofInc = DFSAS(newSum, startIndex);

            //not taking this
            var numberofNotInc = DFSAS(sum, startIndex + 1);

            var retVal =  numberofInc >= numberofNotInc ? numberofNotInc : numberofInc + 1;
            MemoInNotI.Add(sum, retVal);
            return retVal;
        }

        public int DFSTakingAllInto(int sum)
        {
            //base case
            if (sum == SumToMake)
            {
                return 0;
            }

            if (sum > SumToMake)
            {
                return Int32.MaxValue;
            }

            if (MemoInNotI.ContainsKey(sum))
            {
                return MemoInNotI[sum];
            }
            var minimum = Int32.MaxValue;
            for (int i = 0; i < GivenArray.Length; i++)
            {
                var newSum = sum + GivenArray[i];
                var sumWithThis = DFSTakingAllInto(newSum);
                if (sumWithThis < minimum)
                {
                    minimum = sumWithThis + 1;
                }
                //if (newSum <= SumToMake)
                //{
                //    var sumWithThis = DFSTakingAllInto(newSum);
                //}
            }

            MemoInNotI[sum] = minimum;
            return minimum;
        }

        public void BottomUp()
        {
            var intArr = new int[SumToMake + 1];

            intArr[0] = 0;
            intArr[1] = 1;

            var hashset = new HashSet<int>(GivenArray);

            for (int i = 2; i < intArr.Length; i++)
            {
                if (hashset.Contains(i))
                {
                    intArr[i] = 1;
                }
                else
                {
                    var min = Int32.MaxValue;

                    foreach (var i1 in hashset)
                    {
                        if (i1 > i)
                        {
                            continue;
                        }

                        var remaining = i - i1;
                        var checkThis = 1 + intArr[remaining];
                        if (min > checkThis)
                        {
                            min = checkThis;
                        }
                    }

                    intArr[i] = min;
                }
            }

            Console.WriteLine($"The minimum coins is {intArr[^1]}");
        }
    }

    public class MinimumCostClimbingStairs
    {
        public int[] GivenArray { get; set; }
        public Dictionary<int, int> Dictionary { get; set; }
        public MinimumCostClimbingStairs()
        {
            Dictionary = new Dictionary<int, int>();
        }

        public int DFS(int startIndex)
        {
            //base case
            //when exactly at the length
            if (startIndex == GivenArray.Length)
            {
                return 0;
            }

            //when over the length
            if (startIndex > GivenArray.Length)
            {
                return Int32.MaxValue;
            }

            if (Dictionary.ContainsKey(startIndex))
            {
                return Dictionary[startIndex];
            }
            var oneStep = DFS(startIndex + 1);
            var twoStep = DFS(startIndex + 2);

            var returnVal = oneStep > twoStep ? twoStep : oneStep;

            Dictionary[startIndex] = returnVal;

            return returnVal;
        }

        public int DPWay()
        {
            var dp = new int[GivenArray.Length + 1];
            dp[^1] = 0;

            for (int i = dp.Length - 2; i >= 0; i++)
            {
                if (i + 2 >= dp.Length)
                {
                    
                }
                dp[i] = Math.Min(dp[i + 1], dp[i + 2]) + GivenArray[i];
            }
            return dp[0];
        }
    }
    public class MinimumPathSum
    {
        public int[,] Given2DArray { get; set; }
        public Dictionary<string, int> DictionaryMemo { get; set; }
        public MinimumPathSum()
        {
            DictionaryMemo = new Dictionary<string, int>();
        }

        public int DFSWay(int row, int column)
        {
            //base case
            if (row >= Given2DArray.GetLength(0) || column >= Given2DArray.GetLength(1))
            {
                return Int32.MaxValue;
            }

            if (DictionaryMemo.ContainsKey($"{row}{column}"))
            {
                return DictionaryMemo[$"{row}{column}"];
            }
            var (rowPO, colPO) = (row + 1, column + 1);
            //go right
            var right = DFSWay(row, colPO);
            //go down
            var down = DFSWay(rowPO, column);

            var returnThis = right > down ? down : right;
            DictionaryMemo[$"{row}{column}"] = returnThis;

            return returnThis;
        }

        public void DPWay()
        {
            var (row, col) = (Given2DArray.GetLength(0), Given2DArray.GetLength(1));

            //using the whole grid;
            var twoD = new int[row, col];
            for (int i = row - 1; i >= 0; i--)
            {
                for (int j = col - 1; j <= 0; j--)
                {
                    if (i == row -1 && j == col - 1)
                    {
                        twoD[i, j] = Given2DArray[i, j];
                        continue;
                    }

                    var fromRight = j + 1 < col ? twoD[i, j + 1] : Int32.MaxValue;
                    var fromDown = i+1 < row ? twoD[i +1, j] : Int32.MaxValue;

                    twoD[i, j] = fromRight > fromDown ? fromDown : fromRight;
                }
            }

            //using just two
            var twoD2 = new int[2,Given2DArray.GetLength(1)];

            for (int i = row - 1; i >= 0; i--)
            {
                for (int j = col - 1; j <= 0; j--)
                {
                    if (i == row - 1 && j == col - 1)
                    {
                        //twoD[i, j] = Given2DArray[i, j];
                        twoD2[0, j] = Given2DArray[i, j];
                        continue;
                    }

                    var fromRight = j + 1 < col ? twoD[i, j + 1] : Int32.MaxValue;
                    var fromDown = i + 1 < row ? twoD[i + 1, j] : Int32.MaxValue;

                    twoD2[1, j] = fromRight > fromDown ? fromDown : fromRight;
                }

                //push it down
                for (int j = 0; j < twoD2.GetLength(1); j++)
                {
                    var temp = twoD2[0, j];
                    twoD2[1, j] = temp;
                    twoD2[0, j] = 0;
                }
            }

            //Answer is twoD2[1,0]
        }
    }

    public class MaximumProductSubArray
    {
        public int[] GivenArray { get; set; }

        public MaximumProductSubArray()
        {
            
        }

        public (int, int) DFSWay(int index)
        {
           //base case
           //when finishes up
           if (index >= GivenArray.Length)
           {
               return (1, 1);
           }

           var valueAtThisInd = GivenArray[index];

           if (valueAtThisInd == 0)
           {
               return (1, 1);
           }
           var tuple = DFSWay(index + 1);

           var (multiplywithThisA, multiplywithThisB) =(valueAtThisInd * tuple.Item1,
               valueAtThisInd * tuple.Item2);
           var max = multiplywithThisA > multiplywithThisB ? multiplywithThisA : multiplywithThisB;
           var min = multiplywithThisA > multiplywithThisB ? multiplywithThisB : multiplywithThisA;

           max = valueAtThisInd > max ? valueAtThisInd : max;
           min = valueAtThisInd < min ? valueAtThisInd : min;
           
           return (max, min);

        }
    }

    public class EditDistance
    {
        public string StringA { get; set; }
        public string StringB { get; set; }
        public Dictionary<string, int> MemoizationDict { get; set; }
        public EditDistance()
        {
            MemoizationDict = new Dictionary<string, int>();
        }

        public int AlgorithmnDFS(int startIndex, int startIDest)
        {
            //base case
            //if both out of place;
            if (startIndex > StringA.Length && startIDest > StringB.Length)
            {
                return 0;
            }

            if (startIndex > StringA.Length)
            {
                var remaining = StringB[startIDest..].Length;
                return remaining;
            }

            if (startIDest > StringB.Length)
            {
                var remaining = StringA[startIndex..].Length;
                return remaining;
            }

            var nameInMemo = $"{startIndex}{startIDest}";
            if (MemoizationDict.ContainsKey(nameInMemo))
            {
                return MemoizationDict[nameInMemo];
            }

            var characterHere = StringA[startIndex].ToString();
            var characterToMatch = StringB[startIDest].ToString();
            var isMatch = false;
            if (characterToMatch == characterHere)
            {
                startIndex = startIndex + 1;
                startIDest = startIDest + 1;
                isMatch = true;
            }

            //Insert
            var fromInsert = AlgorithmnDFS(startIndex, startIDest + 1);

            //Delete
            var fromDelete = AlgorithmnDFS(startIndex + 1, startIDest);

            //Replace
            var fromRelace = AlgorithmnDFS(startIndex + 1, startIDest + 1);

            var minimum = Math.Min(fromInsert, Math.Min(fromDelete, fromRelace));

            if (isMatch)
            {
                MemoizationDict[nameInMemo] = minimum;
                return minimum;
            }
            else
            {
                MemoizationDict[nameInMemo] = minimum + 1;
                return minimum + 1;
            }
        }

        public void DPSolution()
        {
            var twoD = new int[StringA.Length + 1, StringB.Length + 1];

            for (int i = 0; i < twoD.GetLength(0); i++)
            {
                twoD[i, 0] = i;
            }

            for (int i = 0; i < twoD.GetLength(1); i++)
            {
                twoD[0, i] = i;
            }


            for (int i = 0; i < twoD.GetLength(0); i++)
            {
                for (int j = 1; j < twoD.GetLength(1); j++)
                {
                    var stringAti = StringA[i];
                    var stringAtj = StringB[j];

                    if (stringAti == stringAtj)
                    {
                        twoD[i, j] = twoD[i - 1, j - 1];
                    }
                    else
                    {
                        var minimum = Math.Min(twoD[i, j - 1], 
                            Math.Min(twoD[i - 1, j], twoD[i-1, j-1]));

                        twoD[i, j] = minimum + 1;
                    }
                }
            }

            Console.WriteLine(@$"Minimum transformation is {twoD[twoD.GetLength(0) - 1,
                twoD.GetLength(1) - 1]}");
        }
    }

    public class BuySellCoolDown
    {
        public int[] GivenStockPrices { get; set; }
        public Dictionary<string, int> MemoDict { get; set; }
        public BuySellCoolDown()
        {
            MemoDict = new Dictionary<string, int>();
        }

        //https://www.youtube.com/watch?v=I7j0F7AHpb8
        //while memoizing make sure it's buying selling memoization rather than sum memoization
        public int DFSAlgorithmn(Stack<int> sum, int index, bool isSold = false)
        {
            //base case
            var valueAtThisInd = GivenStockPrices[index];
            if (index == GivenStockPrices.Length - 1)
            {
                //just sell
                if (sum.Count > 1)
                {
                    var prevVal = sum.Peek();
                    return valueAtThisInd - prevVal;
                }
                else
                {
                    return 0;
                }
            }

            var formemo = "0";
            if (sum.Count > 0)
            {
                formemo = sum.Peek().ToString();
            }

            var key = $"{index}{formemo}";
            if (MemoDict.ContainsKey(key))
            {
                return MemoDict[key];
            }

            var sell = Int32.MinValue;
            int cooldown;
            var buy = Int32.MinValue;

            if (isSold)
            {
                cooldown = DFSAlgorithmn(sum, index + 1);
            }
            else if (sum.Count > 0)
            {
                //sell
                var valueBefore = sum.Pop();
                var profit = valueAtThisInd - valueBefore;

                var sellA = DFSAlgorithmn(sum, index + 1, true);

                sell = profit + sellA;
                sum.Push(valueBefore);
                //cooldown
                cooldown = DFSAlgorithmn(sum, index + 1);
            }
            else
            {
                //buy
                sum.Push(valueAtThisInd);
                buy = DFSAlgorithmn(sum, index + 1);
                sum.Pop();
                //cooldown
                cooldown = DFSAlgorithmn(sum, index + 1);
            }

            var max = Math.Max(sell, Math.Max(cooldown, buy));
            MemoDict.Add(key, max);
            return max;
        }
    }
}
