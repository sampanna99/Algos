using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;

namespace AlgorithsPractise.LeetCode_Eric.Phase5
{
    public class DpDistinctWays
    {

    }

    public class ZeroOneKnapsack
    {
        public int[,] MatrixIntermediate { get; set; }
        public int WeightAllowed { get; set; }
        public  Tuple<int, int>[] ArrayOfWtValue { get; set; } //item one wt item 2 profit val
        public ZeroOneKnapsack()
        {
            MatrixIntermediate = new int[ArrayOfWtValue.Length + 1, WeightAllowed + 1];
        }

        private void Initialize()
        {
            for (int i = 0; i < MatrixIntermediate.GetLength(0); i++)
            {
                MatrixIntermediate[i, 0] = 0;
            }
            for (int i = 0; i < MatrixIntermediate.GetLength(1); i++)
            {
                MatrixIntermediate[0, i] = 0;
            }
        }
        public void Algorithmn()
        {
            Initialize();

            for (int i = 0; i < MatrixIntermediate.GetLength(0); i++)
            {
                for (int j = 0; j < MatrixIntermediate.GetLength(1); j++)
                {
                    var weightAtThatIndex = ArrayOfWtValue[i].Item1;
                    var profitAtThatIndex = ArrayOfWtValue[i].Item1;

                    if (weightAtThatIndex <= j)
                    {
                        //do the math to find highest
                        MatrixIntermediate[i,j] = Math.Max(profitAtThatIndex + MatrixIntermediate[i - 1, j - weightAtThatIndex]
                            , MatrixIntermediate[i - 1, j - 1]);
                    }
                    else
                    {
                        //get from above
                        MatrixIntermediate[i, j] = MatrixIntermediate[i - 1, j];
                    }
                }
            }

        }
    }

    public class SubsetSum
    {
        //public List<List<int>>[,] Matrix { get; set; }

        public int[,] Matrix { get; set; }
        public int SumToMake { get; set; }
        public int[] GivenArray { get; set; }

        public List<List<int>> AnswersListViaRecurse { get; set; }
        public void Algorithmn()
        {
            AnswersListViaRecurse = new List<List<int>>();
            
        }


        //could use memoization for a sum and index. EWx at index 1 for remaining sum 4;
        //At index 2 for remaining sum 2; and like that
        public List<List<int>> DFSRecurse(int index, int sumBeforeAddingThisIndex, Stack<int> addedVals)
        {


            //base case
            if (index >= GivenArray.Length)
            {
                if (sumBeforeAddingThisIndex == SumToMake)
                {
                    var newList = addedVals.ToList();

                    AnswersListViaRecurse.Add(newList);
                }
            }

            var sumAfter = sumBeforeAddingThisIndex + GivenArray[index];

            //maybe let it roll for scenarios where they want indexes added and there could be 0s;
            //if (sumAfter == SumToMake)
            //{
                
            //}


            var returnThis = new List<List<int>>();
            if (sumAfter <= SumToMake)
            {
                addedVals.Push(GivenArray[index]);
                var vals = DFSRecurse(index + 1, sumAfter, addedVals);
                returnThis.AddRange(vals);
                addedVals.Pop();
            }

            var withoutadding = DFSRecurse(index + 1, sumBeforeAddingThisIndex, addedVals);
            returnThis.AddRange(withoutadding);
            return returnThis;
        }


        private void InitializeTheMatrix()
        {
            Matrix = new int[GivenArray.Length + 1, SumToMake + 1];

            for (int i = 0; i < Matrix.GetLength(0); i++)
            {
                Matrix[i, 0] = 1;
            }

            for (int i = 1; i < Matrix.GetLength(1); i++)
            {
                Matrix[0, i] = 0;
            }
        }
        public void TabularMethodOfDP()
        {
            InitializeTheMatrix();

            for (int i = 1; i < Matrix.GetLength(0); i++)
            {
                var valueAtThisIndex = GivenArray[i];
                for (int j = 1; j < Matrix.GetLength(1); j++)
                {
                    var maxSum = j;
                    if (valueAtThisIndex > maxSum)
                    {
                        //some basic check
                        Matrix[i, j] = Matrix[i - 1, j];
                    }
                    else
                    {
                        //if (valueAtThisIndex == maxSum)
                        //{
                            
                        //}

                        var remainingAfteraddingTheSUm = maxSum - valueAtThisIndex;

                        Matrix[i, j] = Matrix[i - 1, j] + Matrix[i - 1, remainingAfteraddingTheSUm];
                    }
                }
            }

            Console.WriteLine($@"The number of  times is {Matrix[Matrix.GetLength(0) -1,
                Matrix.GetLength(1) - 1]}");
        }
    }


    public class ClimbingStairs
    {
        public ClimbingStairs()
        {
            
        }
    }

    public class UniquePath
    {
        public int[,] ChessBoard { get; set; }

        public int Rows { get; set; }
        public int Columns { get; set; }
        public UniquePath()
        {
            ChessBoard = new int[Rows, Columns];
        }

        //Also could be down using memoization and Recursion
        public void Algorithmn()
        {


            for (int i = Rows - 1; i > 0; i--)
            {
                for (int j = Columns - 1; j > 0; j--)
                {
                    if (i == Rows - 1 && j == Columns - 1)
                    {
                        ChessBoard[i, j] = 1;
                    }
                    else
                    {
                        var goingRight = ChessBoard[i, j + 1];
                        var goingDown = 0;
                        if (i < Rows - 1)
                        {
                            goingDown = ChessBoard[i + 1, j];
                        }

                        ChessBoard[i, j] = goingDown + goingRight;
                    }

                }
            }

            Console.WriteLine($"The answer is {ChessBoard[Rows-1,Columns-1]}");
        }
    }

    public class CombinationSUmIV
    {
        public int[] AllNumberToUse { get; set; }
        public int TargetSum { get; set; }

        public Dictionary<int, int> Memoized { get; set; }
        public CombinationSUmIV()
        {
        }

        public void AlgorithmnDFS()
        {

        }

        public int Algorithmn(int sumUptoNow, Stack<int> valuesAddedUpto)
        {
            //base case only if sum = 0
            if (sumUptoNow >= TargetSum)
            {
                if (sumUptoNow == TargetSum)
                {
                    
                }
            }

            if (Memoized.ContainsKey(sumUptoNow))
            {
                return Memoized[sumUptoNow];
            }

            var alladded = 0;
            for (int i = 0; i < AllNumberToUse.Length; i++)
            {
                var value = AllNumberToUse[i];
                valuesAddedUpto.Push(value);
                var newSum = value + sumUptoNow;

                if (Memoized.ContainsKey(sumUptoNow))
                {
                    alladded += Memoized[newSum];
                }
                else if (newSum >= TargetSum)
                {
                    //found
                    if (newSum == TargetSum)
                    {
                        alladded += 1;
                    }
                }
                else
                {
                    var allbelow = Algorithmn(newSum, valuesAddedUpto);
                    alladded += allbelow;
                }
                valuesAddedUpto.Pop();
            }
            Memoized.Add(sumUptoNow, alladded);

            return alladded;
        }

        public int AlgorithmnTabular()
        {
            var intArr = new int[TargetSum];
            for (int i = 0; i < TargetSum; i++)
            {
                if (i == 0)
                {
                    intArr[i] = 1;
                }

                var allNumberOfTimes = 0;
                for (int j = 0; j < AllNumberToUse.Length; j++)
                {
                    if (i < AllNumberToUse[j])
                    {
                        continue;
                    }

                    //find remaining Dp of
                    var sumToFind = i - AllNumberToUse[j];

                    //get it from the intArr above
                    allNumberOfTimes = intArr[sumToFind];
                }

                intArr[i] = allNumberOfTimes;
            }

            return intArr[^1];
        }
    }

    public class PartitionEqualSubsetSum
    {
        public int[] GivenArray { get; set; }
        public int HalfSum { get; set; }
        public Dictionary<string, bool> Memoization { get; set; }
        public PartitionEqualSubsetSum()
        {
            Memoization = new Dictionary<string, bool>();
        }

        private void CalculateHalfSum()
        {
            var val = 0;

            for (int i = 0; i < GivenArray.Length; i++)
            {
                val += GivenArray[i];
            }

            HalfSum = val;
        }

        public bool DpMethod()
        {
            var hashset = new HashSet<int>();
            var isPossible = false;
            for (int i = 0; i < GivenArray.Length; i++)
            {
                if (isPossible)
                {
                    break;
                }
                var copy = new HashSet<int>(hashset);
                var valueToAdd = GivenArray[i];
                foreach (var eachelementInhash in hashset)
                {
                    var newVal = eachelementInhash + valueToAdd;

                    if (newVal == HalfSum)
                    {
                        isPossible = true;
                        break;
                    }
                    if (!hashset.Contains(newVal))
                    {
                        hashset.Add(newVal);
                    }
                }
                
            }

            return isPossible;
        }
        public bool DFSMemoApproachAlgo(int indexToCheckHere, int SumUpto)
        {
            //base case
            if (indexToCheckHere >= GivenArray.Length)
            {
                return false;
            }

            if (SumUpto >= HalfSum)
            {
                if (SumUpto == HalfSum)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            //Go over next index add it or not add it

            if (Memoization.ContainsKey(indexToCheckHere + " " + SumUpto))
            {
                return Memoization[indexToCheckHere + " " + SumUpto];
            }
            var addingit = SumUpto + GivenArray[indexToCheckHere];
            var adding = DFSMemoApproachAlgo(indexToCheckHere + 1, addingit);
            if (adding)
            {
                Memoization.Add(indexToCheckHere + " " + SumUpto, true);
                return true;
            }
            var notadding = DFSMemoApproachAlgo(indexToCheckHere + 1, SumUpto);
            Memoization.Add(indexToCheckHere + " " + SumUpto, notadding);
            if (notadding)
            {
                return true;
            }

            return false;
        }
    }

    public class DecodeWays
    {
        public string GivenStrnum { get; set; }

        public Dictionary<int, int> Dictionary { get; set; }
        public int LengthOfStr { get; set; }
        public DecodeWays()
        {
            Dictionary = new Dictionary<int, int>();
            LengthOfStr = GivenStrnum.Length;
        }

        public void Algorithmn()
        {

        }

        public int NumberOfWaysDP()
        {
            var intArr = new int[GivenStrnum.Length];

            //first two just get it
            if (Int32.Parse(GivenStrnum[0].ToString()) == 0)
            {
                //break here
                return 0;
            }
            else
            {
                intArr[0] = 1;
            }



            for (int i = 1; i < GivenStrnum.Length; i++)
            {
                if (Int32.Parse(GivenStrnum[i].ToString()) == 0)
                {
                    //check can it be paired with the prev
                    //var prev = GivenStrnum[i - 1].ToString();
                    //var addBothStr = GivenStrnum[i] + GivenStrnum[i - 1].ToString();

                    //var convertToIn = Int32.Parse(addBothStr);

                    //if (convertToIn > 26)
                    //{
                    //    //cannot be both
                    //    break;
                    //}
                    //else
                    //{
                    //    if (i - 2 < 0)
                    //    {
                    //        intArr[i] = 1;
                    //    }
                    //    else
                    //    {
                    //        intArr[i] = 1 + intArr[i - 2];
                    //    }
                    //}

                    var callTwo = WhenTwoNums(i, intArr, true);
                    if (callTwo == 0)
                    {
                        break;
                    }
                    
                }
                else
                {
                    var justOne = intArr[i - 1];
                    var justTwo = WhenTwoNums(i, intArr);
                }
            }

            return intArr[^1];
        }

        private int WhenTwoNums(int i, int[] intArr, bool isZero = false)
        {
            var prev = GivenStrnum[i - 1].ToString();
            var addBothStr = GivenStrnum[i] + GivenStrnum[i - 1].ToString();

            var convertToIn = Int32.Parse(addBothStr);

            if (isZero)
            {
                if (convertToIn < 10)
                {
                    return 0;
                }
            }

            if (convertToIn > 26)
            {
                //cannot be both
                intArr[i] = intArr[i - 1];
                return 0;
            }
            else
            {
                //return 1;





                if (i - 2 < 0)
                {
                    intArr[i] = intArr[i - 1];
                    //intArr[i] = 1;
                    return 1;
                }
                else
                {
                    //intArr[i] = 1 + intArr[i - 2];

                    if (isZero)
                    {
                        intArr[i] = intArr[i - 2] + 1;
                    }
                    else
                    {
                        intArr[i] = intArr[i - 2] + intArr[i - 1];
                    }
                    return intArr[i - 2];
                }
            }
        }

        public int DFSWay(int startIndex)
        {
            //base case
            if (startIndex >= GivenStrnum.Length)
            {
                return 1;
            }


            if (Dictionary.ContainsKey(startIndex))
            {
                return Dictionary[startIndex];
            }
            var addedOne = startIndex + 1;
            var addedTwo = startIndex + 2;
            var getJustOne = GivenStrnum[startIndex..addedOne];
            //Go dfs on added One
            //whatever it returns add whatever you get on added Two

            if (getJustOne == "0")
            {
                return 0;
            }
            var numberOfAddedOne = DFSWay(addedOne);

            //checkbefore
            var numberofAddedTwo = 0;
            if (addedTwo < LengthOfStr)
            {
                var getTwo = GivenStrnum[startIndex..addedTwo];
                numberofAddedTwo = DFSWay(addedTwo);
            }
            var returnThis = numberOfAddedOne + numberofAddedTwo;
            Dictionary.Add(startIndex, returnThis);
            return returnThis;
        }
    }

    public class WordBreak{


        public string GivenString { get; set; }
        public HashSet<string> GivenArrayOfStr { get; set; }
        public Dictionary<int, bool> DictionaryOfSplitThere { get; set; }

        public bool[,] Tabulation { get; set; }
        public WordBreak()
        {
            GivenArrayOfStr = new HashSet<string>();
            DictionaryOfSplitThere = new Dictionary<int, bool>();
        }
        public void Algorithmn()
        {

        }


        //https://www.youtube.com/watch?v=th4OnoGasMU
        public bool DFSAlgo(int indexTostart)
        {
            //base case
            if (indexTostart >= GivenString.Length)
            {
                return true;
            }

            if (DictionaryOfSplitThere.ContainsKey(indexTostart))
            {
                return DictionaryOfSplitThere[indexTostart];
            }
            //Dfs on each remaining indexes starting from there
            var returnThis = false;
            for (int i = indexTostart; i < GivenString.Length; i++)
            {
                var substr = GivenString[indexTostart..i];
                if (GivenArrayOfStr.Contains(substr))
                {
                    var valueRet = DFSAlgo(i + 1);
                    if (!returnThis)
                    {
                        returnThis = valueRet;
                    }
                }
            }
            DictionaryOfSplitThere.Add(indexTostart, returnThis);
            return returnThis;
        }

        public bool TabulationMethod()
        {
            //starting at 2,4 would be 2,3 and 3,4
            for (int i = 0; i < GivenString.Length; i++)
            {
                for (int j = 0; j < Tabulation.GetLength(0); j++)
                {
                    var addThat = j + i;
                    var getStr = GivenString[j..addThat];
                    if (GivenArrayOfStr.Contains(getStr))
                    {
                        Tabulation[j, addThat] = true;
                    }else if (getStr.Length > 1)
                    {
                        //now split after each char

                        for (int k = 0; k < getStr.Length - 1; k++)
                        {
                            var start = j;
                            var end = j + k;
                            
                            var checkA = Tabulation[start, end] && Tabulation[end, addThat];
                            if (checkA)
                            {
                                Tabulation[j, addThat] = true;
                            }
                        }

                    }
                }

            }

            return Tabulation[0, Tabulation.GetLength(1) - 1];
        }
    }

    public class CoinChange2
    {
        public int Amount { get; set; }
        public int[] CoinDimensions { get; set; }

        public List<List<int>> Answers { get; set; }
        public Dictionary<String, List<List<int>>> Dictionary { get; set; }
        public CoinChange2()
        {
            Answers = new List<List<int>>();
            Dictionary = new Dictionary<string, List<List<int>>>();
        }

        public void Algorithmn()
        {

        }

        //I could go with this approach but let me try something else in 2
        public void DFSApproachMemo(int indexOfCoin, int sumBeforeExe, Stack<int> Values)
        {
            //base case
            if (sumBeforeExe == Amount)
            {
                var newList = new List<int>(Values);
                Answers.Add(newList);
                return;
            }

            if (indexOfCoin >= CoinDimensions.Length || sumBeforeExe > Amount)
            {
                return;
            }



            //including that index dfs
            var valueAtInd = CoinDimensions[indexOfCoin];
            var newVal = valueAtInd + sumBeforeExe;
            if (newVal <= Amount)
            {
                Values.Push(CoinDimensions[indexOfCoin]);
                DFSApproachMemo(indexOfCoin, newVal, Values);
                Values.Pop();
            }

            //excluding that index dfs
            DFSApproachMemo(indexOfCoin + 1, sumBeforeExe, Values);
        }

        public List<List<int>> DFSApproachMemo2(int indexOfCoin, int sumBeforeExe)
        {
            //base case;
            if (sumBeforeExe == Amount)
            {
                return new List<List<int>>();
            }
            if (indexOfCoin >= CoinDimensions.Length || sumBeforeExe > Amount)
            {
                return null;
            }

            if (Dictionary.ContainsKey($"{indexOfCoin}, {sumBeforeExe}"))
            {
                return Dictionary[$"{indexOfCoin}, {sumBeforeExe}"];
            }

            var listToReturn = new List<List<int>>();
            for (int i = indexOfCoin; i < CoinDimensions.Length; i++)
            {
                //include
                var adding = CoinDimensions[i];
                var newSum = sumBeforeExe + adding;
                var valuesAfterAdd = Dictionary.ContainsKey($"{i}, {newSum}") ? 
                Dictionary[$"{indexOfCoin}, {sumBeforeExe}"] : DFSApproachMemo2(i, newSum);

                if (valuesAfterAdd != null)
                {
                    for (int j = 0; j < valuesAfterAdd.Count; j++)
                    {
                        valuesAfterAdd[j].Add(adding);
                    }
                    listToReturn.AddRange(valuesAfterAdd);
                }
                //exclude

                var withoudAdd = Dictionary.ContainsKey($"{i + 1}, {sumBeforeExe}") ?
                    Dictionary[$"{i +1}, {sumBeforeExe}"] : DFSApproachMemo2(i + 1, sumBeforeExe);
                if (withoudAdd != null)
                {
                    listToReturn.AddRange(withoudAdd);
                }
            }

            Dictionary.Add($"{indexOfCoin}, {sumBeforeExe}", listToReturn);
            return listToReturn;
        }
    }

    public class UniqueBinarySearchTree
    {
        public int NumberOfNode { get; set; }
        public HashSet<int> TakenAlready { get; set; }
        public HashSet<int> Remaining { get; set; }


        public UniqueBinarySearchTree()
        {
            TakenAlready = new HashSet<int>();
            Remaining = new HashSet<int>();
        }

        public void Algorithmn()
        {

        }

        //leetcode 96
        public void DP()
        {
            var numberOfNodesPerItem = new int[NumberOfNode + 1];


            //initialize first two
            numberOfNodesPerItem[0] = 1;
            numberOfNodesPerItem[1] = 1;

            //then calculate all
            for (int i = 2; i < numberOfNodesPerItem.Length; i++)
            {
                var forTwo = 0;
                for (int j = 0; j < i; j++)
                {
                    var left = j;
                    var right = i - j - 1;
                    forTwo += numberOfNodesPerItem[left] * numberOfNodesPerItem[right];
                }

                numberOfNodesPerItem[i] = forTwo;
            }
        }

        //leetcode95
        //not completed
        public List<NodeThis> RecursiveApproach(HashSet<int> taken, NodeThis node, int prev = 0)
        {
            //base case
            //when taken is done
            if (taken.Count == NumberOfNode)
            {
                //node would be child
                return new List<NodeThis> { node };
            }

            //which one to take. First one is head
            var returnThis = new List<NodeThis>();
            for (int i = 1; i < NumberOfNode + 1; i++)
            {
                if (taken.Contains(1))
                {
                    continue;
                }

                //go left
                taken.Add(i);
                if (i < prev)
                {
                    node.Left.Value = i;
                    
                    var all = RecursiveApproach(taken, node.Left, i);


                    for (int j = 0; j < all.Count; j++)
                    {
                        node.Left = all[j];
                        all[j] = node;
                    }
                    returnThis.AddRange(all);
                }
                else
                {
                    node.Right.Value = i;
                    var allright = RecursiveApproach(taken,node.Right, i);
                    for (int j = 0; j < allright.Count; j++)
                    {
                        node.Right = allright[j];
                        allright[j] = node;
                    }
                    returnThis.AddRange(allright);
                }
                taken.Remove(i);
                //go right
            }

            return returnThis;
        }

        public List<List<string>> RecurseApp2(Queue<string> added, HashSet<int> taken, int max, int min)
        {
            //base case
            if (taken.Count == NumberOfNode)
            {
                return new List<List<string>>
                {
                    added.ToList()
                };
            }

            var returnThis = new List<List<string>>();
            for (int i = 1; i <= NumberOfNode; i++)
            {
                var copy = new Queue<string>(added);
                if (taken.Contains(i))
                {
                    continue;
                }

                if (i < max && i > min)
                {
                    //do the things here

                    taken.Add(i);
                    //go left
                    var fLMax = max > i ? i : max;
                    copy.Enqueue(i.ToString());
                    //added.Enqueue(i.ToString());

                    var left = RecurseApp2(copy, taken, fLMax, min);
                    if (left == null || left.Count == 0)
                    {
                        copy.Enqueue("N");
                    }
                    else
                    {
                        returnThis.AddRange(left);
                    }

                    var fRMin = min < i ? i : min;

                    var right = RecurseApp2(copy, taken, max, fRMin);

                    if (right != null && right.Count > 0)
                    {
                        returnThis.AddRange(right);
                    }

                    taken.Remove(i);
                }


            }

            return returnThis;
        }
    }

    public class ConcatenatedWords
    {
        public string[] GivenStrings { get; set; }

        public ConcatenatedWords()
        {
            
        }


        public void Algorithmn()
        {
            var answerArray = new List<string>();
            foreach (var givenString in GivenStrings)
            {
                var isContains = DFS(givenString, 0, givenString.Length);
                if (isContains)
                {
                    answerArray.Add(givenString);
                }
            }

        }

        //endInd is endInd Plus 1;
        public bool DFS(string givenStr, int stInd, int endInd)
        {
            //base case
            if (stInd >= givenStr.Length)
            {
                return true;
            }

            var returnVal = false;
            for (int i = stInd; i <= endInd; i++)
            {
                //recurse if true break as the answer is true that means the word is present
                

                var iPlus = i + 1;
                var str = givenStr[stInd..iPlus];
                if (str == givenStr)
                {
                    continue;
                }
                if (GivenStrings.Contains(str))
                {
                    var doesitcontain = DFS(givenStr, iPlus, endInd);
                    if (doesitcontain)
                    {
                        returnVal = true;
                        break;
                    }
                }
            }
            return returnVal;

        }
    }
}

    public class NodeThis
    {
        public NodeThis Left { get; set; }
        public NodeThis Right { get; set; }
        //public NodeThis Parent { get; set; }
        public int Value { get; set; }
    }

