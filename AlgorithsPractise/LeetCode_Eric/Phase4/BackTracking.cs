using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace AlgorithsPractise.LeetCode_Eric.Phase4
{
    public class BackTracking
    {
    }

    //https://www.youtube.com/watch?v=0snEunUacZY
    public class CombinationsPhoneNumber
    {
        public string WordGiven { get; set; } = "23";
        public Dictionary<string, List<string>> Dictionary { get; set; }
        public List<string> Answers { get; set; }
        public CombinationsPhoneNumber()
        {
            Answers = new List<string>();
            Dictionary = new Dictionary<string, List<string>>();
        }

        public void Algorithmn()
        {
            DFSBacktracking(0, "");
        }

        public void DFSBacktracking(int charIndex, string untilNow)
        {
            //base case
            if (charIndex == WordGiven.Length)
            {
                Answers.Add(untilNow);
            }
            //go over all
            var val = Dictionary[WordGiven[charIndex].ToString()];

            var plusOne = charIndex + 1;
            for (int i = 0; i < val.Count; i++)
            {
                var untilNowMod = untilNow + val[i];
                DFSBacktracking(plusOne, untilNowMod);
            }

        }
    }

    //https://www.youtube.com/watch?v=s9fokUqJ76A
    public class GenerateParenthesis
    {
        public int NumberOfParenthesis { get; set; } = 3;
        public List<string> Answers { get; set; }

        public GenerateParenthesis()
        {
            Answers = new List<string>();
        }

        public void Algorithmn()
        {

        }

        public void DFSBacktracking(int numberofFrontUsedc, int numbnerOfBackUsed, string usedUpto)
        {
            //base case
            if (numberofFrontUsedc == NumberOfParenthesis && numbnerOfBackUsed == NumberOfParenthesis)
            {
                Answers.Add(usedUpto);
                return;
            }

            string usedUptochanged = "";
            if (numberofFrontUsedc < NumberOfParenthesis)
            {
                 usedUptochanged = usedUpto + "(";
                DFSBacktracking(numberofFrontUsedc + 1, numbnerOfBackUsed, usedUptochanged);
                if (numbnerOfBackUsed < numberofFrontUsedc)
                {
                    usedUptochanged = usedUpto + ")";
                    DFSBacktracking(numberofFrontUsedc, numbnerOfBackUsed + 1, usedUptochanged);
                }
            }
            else
            {
                //just back 
                usedUptochanged = usedUpto + ")";
                DFSBacktracking(numberofFrontUsedc, numbnerOfBackUsed + 1, usedUptochanged);
            }

        }
    }

    //https://www.youtube.com/watch?v=61tN4YEdiTM
    public class RestoreIpAddresses
    {
        public string GivenString { get; set; } = "010010";
        public List<string> AnswerList { get; set; }
        public RestoreIpAddresses()
        {
            AnswerList = new List<string>();
        }

        public void Algorithmn()
        {
            //go through each of them
            DFSBackTracking(1, -1, "");
        }

        public void DFSBackTracking(int dotNumber, int lastDotLocationAfter, string ipString)
        {
            var addOneToLastDotLocation = lastDotLocationAfter + 1;
            var stringAfterLastDot = GivenString[addOneToLastDotLocation..];

            //base cases
            //when fourth
            if (dotNumber == 4)
            {
                //if (lastDotLocationAfter == GivenString.Length - 1)
                //{
                //    AnswerList.Add(ipString);
                //}
                if (Convert.ToInt32(stringAfterLastDot) <= 255)
                {
                    AnswerList.Add(ipString + stringAfterLastDot);
                }
                return;
            }
            //when 0
            //when greater than 255 
            //when (3 - dot number) + 1 > number of elements left //done in for loop

            var numberleft = 3 - dotNumber;
            var minimumRequired = numberleft + 1;


            //var indexOfLAst = GivenString.IndexOf('.', )

            for (int i = 0; i < (stringAfterLastDot.Length - minimumRequired); i++)
            //for (int i = 0; i < (stringAfterLastDot.Length - minimumRequired) && i < 3; i++)
            {
                var iPlusOne = i + 1;
                var stringappended = stringAfterLastDot[..iPlusOne];

                //doesn't work if . is not the last
                //string appended is just upto that not all
                if (Convert.ToInt32(stringappended) < 255)
                {
                    if (stringappended.StartsWith("0") && stringappended.Length > 1)
                    {
                        continue;
                    }
                    var stringAfterAddingI = ipString + stringappended + ".";
                    //var stringAfterAddingI = ipString + "." + stringappended;
                    DFSBackTracking(dotNumber + 1, lastDotLocationAfter + i + 1, stringAfterAddingI);
                }
            }
        }
    }

    //leetcode 46
    public class PermutationI
    {
        public int[] GivenArray { get; set; }

        public List<List<int>> Answers { get; set; }
        public PermutationI()
        {
            Answers = new List<List<int>>();
        }

        public void Algorithmn()
        {

        }

        public void DFSBacktrack(Stack<int> numberAddedUpToNow, HashSet<int> indexesToAvoid)
        {
            //base case
            if (indexesToAvoid.Count == GivenArray.Length)
            {
                var listToAdd = new List<int>();
                foreach (var i in numberAddedUpToNow)
                {
                    listToAdd.Add(i);
                }
                Answers.Add(listToAdd);
            }
            //var togoover = GivenArray[indexToStartFromArray..];

            for (int i = 0; i < GivenArray.Length; i++)
            {
                if (indexesToAvoid.Contains(i))
                {
                    continue;
                }
                numberAddedUpToNow.Push(GivenArray[i]);
                indexesToAvoid.Add(i);
                DFSBacktrack(numberAddedUpToNow, indexesToAvoid);
                indexesToAvoid.Remove(i);
                numberAddedUpToNow.Pop();
            }
        }
    }

    public class PermutationII
    {
        public int[] GivenArray { get; set; }
        public Dictionary<int, int> DictionaryNumberAndTimes { get; set; }
        public PermutationII()
        {
            DictionaryNumberAndTimes = new Dictionary<int, int>();
            Answers = new List<List<int>>();
        }

        public List<List<int>> Answers { get; set; }
        public void Algorithmn()
        {
            //generate number --> number of times
            foreach (var number in GivenArray)
            {
                if (DictionaryNumberAndTimes.ContainsKey(number))
                {
                    DictionaryNumberAndTimes[number] += 1;
                }
                else
                {
                    DictionaryNumberAndTimes[number] = 1;
                }
            }

            //DFS pass the generated Dictionary and do the magic
            DFSBacktrack(new Stack<int>());
        }

        private void ModifyDictionary(int key, bool isAdd)
        {
            if (isAdd)
            {
                if (DictionaryNumberAndTimes.ContainsKey(key))
                {
                    DictionaryNumberAndTimes[key] += 1;
                }
                else
                {
                    DictionaryNumberAndTimes[key] = 1;
                }
            }
            else
            {
                if (DictionaryNumberAndTimes[key] == 1)
                {
                    DictionaryNumberAndTimes.Remove(key);
                }
                else
                {
                    DictionaryNumberAndTimes[key] -= 1;
                }
            }
        }
        private void DFSBacktrack(Stack<int> uptoStack)
        {

            //base case.
            if (DictionaryNumberAndTimes.Count == 0)
            {
                var ans = new List<int>();
                foreach (var i in uptoStack)
                {
                    ans.Add(i);
                }
            }

            var copiedDictionary = new Dictionary<int, int>(DictionaryNumberAndTimes);
            foreach (var i1 in copiedDictionary)
            {
                uptoStack.Push(i1.Key);
                ModifyDictionary(i1.Key, false);
                DFSBacktrack(uptoStack);
                ModifyDictionary(i1.Key, true);
                uptoStack.Pop();
            }
        }
    }

    public class CombinationSum1
    {
        public int Sum { get; set; }
        public int[] ArrayGiven { get; set; }
        public List<List<int>> Answers { get; set; }
        public CombinationSum1()
        {
            Answers = new List<List<int>>();
        }

        //instead of excluded index just say pprocessedupto index
        public void Algorithmn(Stack<int> allIncludedValues,HashSet<int> excludedIndexes)
        {
            //base
            var sum = 0;
            foreach (var allIncludedValue in allIncludedValues)
            {
                sum += allIncludedValue;
            }

            if (sum == Sum)
            {
                Answers.Add(allIncludedValues.ToList());
                return;
            }
            if (sum > Sum)
            {
                return;
            }

            if (excludedIndexes.Count == ArrayGiven.Length)
            {
                return;
            }
            //
            for (int i = 0; i < ArrayGiven.Length; i++)
            {
                if (excludedIndexes.Contains(i))
                {
                    continue;
                }
                //included
                allIncludedValues.Push(ArrayGiven[i]);
                Algorithmn(allIncludedValues, excludedIndexes);
                allIncludedValues.Pop();
                excludedIndexes.Add(i);
                Algorithmn(allIncludedValues, excludedIndexes);
                excludedIndexes.Remove(i);
                //excluded
            }

        }
    }

    //look in neetcode video
    public class CombinationSum2
    {
        public int[] ArrayGiven { get; set; }
        public int SumUpto { get; set; }
        public List<List<int>> AnsList { get; set; }
        public CombinationSum2()
        {
            AnsList = new List<List<int>>();
        }

        public void Algorithmn()
        {
            Sort(0, ArrayGiven.Length - 1);
            DFSBacktrack(new Stack<int>(), 0, 0);
        }
        private void DFSBacktrack(Stack<int> UptoThis, int indexStarting, int sumUpto)
        {
            //base
            if (sumUpto == SumUpto)
            {
                var ans = new List<int>();
                foreach (var uptoThi in UptoThis)
                {
                    ans.Add(uptoThi);
                }
                AnsList.Add(ans);
                return;
            }

            if (indexStarting >= ArrayGiven.Length)
            {
                return;
            }
            //include
            var addedToSUm = sumUpto + ArrayGiven[indexStarting];

            if (addedToSUm <= SumUpto )
            {
                UptoThis.Push(ArrayGiven[indexStarting]);
                DFSBacktrack(UptoThis, indexStarting + 1, addedToSUm);
            }
            //not include
            UptoThis.Pop();

            var findIndexThatDoesntHave = indexStarting + 1;

            while (findIndexThatDoesntHave < ArrayGiven.Length && ArrayGiven[indexStarting] == 
                ArrayGiven[findIndexThatDoesntHave])
            {
                findIndexThatDoesntHave += 1;
            }
            DFSBacktrack(UptoThis, findIndexThatDoesntHave, sumUpto);
        }

        public void Sort(int startInd, int endEnd)
        {
            //base case
            if (startInd >= endEnd)
            {
                return;
            }

            var findPartitionIndex = FindPartitionIndex(startInd, endEnd);
            Sort(startInd, findPartitionIndex - 1);
            Sort(findPartitionIndex + 1, endEnd);
        }

        public int FindPartitionIndex(int startIndex, int endIndex)
        {
            var random = ArrayGiven[endIndex];

            var (checkIndex, partIndex) = (startIndex, startIndex);
            while (checkIndex < endIndex)
            {
                var valueAtcheckInd = ArrayGiven[checkIndex];

                if (valueAtcheckInd > random)
                {
                    //swap with partition 
                    (ArrayGiven[partIndex], ArrayGiven[checkIndex]) = 
                        (ArrayGiven[checkIndex], ArrayGiven[partIndex]);

                    partIndex += 1;

                    //var tmp = ArrayGiven[partIndex];
                    //ArrayGiven[partIndex] = ArrayGiven[checkIndex];
                    //ArrayGiven[checkIndex] = tmp;

                }

                checkIndex += 1;
            }

            (ArrayGiven[endIndex], ArrayGiven[partIndex]) = (ArrayGiven[partIndex], ArrayGiven[endIndex]);
            return partIndex;
        }
    }

    public class Combination3
    {
        public int SumtoMake { get; set; }
        public int NumberofNumberToUse { get; set; }
        public List<List<int>> AnswerList { get; set; }

        public Combination3()
        {
            AnswerList = new List<List<int>>();
        }

        public void Algorithmn()
        {
            DFSBacktrack(new Stack<int>(), 0, 0, 0);
        }

        private void DFSBacktrack(Stack<int> stack, int indexStarting, int sumToMake, int numbersUsed)
        {
            //base
            if (sumToMake == SumtoMake && numbersUsed == NumberofNumberToUse)
            {
                var answer = new List<int>();
                foreach (var i in stack)
                {
                    answer.Add(i);
                }
                AnswerList.Add(answer);
                return;
            }

            if (numbersUsed >= NumberofNumberToUse || sumToMake > SumtoMake)
            {
                return;
            }

            //include
            var value = indexStarting + 1;
            var actualVal = value + 1;

            var sumAfterAdding = sumToMake + actualVal;

            if (sumAfterAdding <= SumtoMake && numbersUsed + 1 < NumberofNumberToUse)
            {
                stack.Push(actualVal);
                DFSBacktrack(stack, value, sumAfterAdding, numbersUsed + 1);
            }

            stack.Pop();
            //not include
            DFSBacktrack(stack, value, sumToMake, numbersUsed);
        }
    }

    public class Subsets1
    {
        public int[] GivenArray { get; set; }
        public List<int[]> Answer { get; set; }

        public Subsets1()
        {
            Answer = new List<int[]>();
        }

        public void Algorithmn()
        {
            DFSBacktrack(0, new Stack<int>());
        }

        public void DFSBacktrack(int indexToStartFrom, Stack<int> stack)
        {
            //base
            if (indexToStartFrom >= GivenArray.Length)
            {
                var ans = new List<int>(stack).ToArray();
                Answer.Add(ans);
            }
            //include
            stack.Push(GivenArray[indexToStartFrom]);
            DFSBacktrack(indexToStartFrom + 1, stack);
            //not include
            stack.Pop();
            DFSBacktrack(indexToStartFrom, stack);
        }
    }

    public class Subsets2
    {
        public int[] GivenArray { get; set; }
        public Dictionary<int, int> NumberAndNumberOfTimes { get; set; }
        public int[] KeyToArray { get; set; }
        public List<List<int>> Answers { get; set; }
        public Subsets2()
        {
            NumberAndNumberOfTimes = new Dictionary<int, int>();
            Answers = new List<List<int>>();
        }

        private void PutItInADictionary()
        {
            foreach (var i in GivenArray)
            {
                if (NumberAndNumberOfTimes.ContainsKey(i))
                {
                    NumberAndNumberOfTimes[i] += 1;
                }
                else
                {
                    NumberAndNumberOfTimes[i] = 1;
                }
            }
        }
        public void Algorithmn()
        {
            //sort it or put it in a dictionary. Nope sort this sucker
            PutItInADictionary();
            var findJustTheKeys = NumberAndNumberOfTimes.Keys.ToArray();
            KeyToArray = findJustTheKeys;
        }

        //with sortiung
        public void DFSBacktrackSort(Stack<int> numbers, int startWithInd)
        {
            //base
            if (startWithInd >= GivenArray.Length)
            {
                var ans = new List<int>(numbers);
                Answers.Add(ans);
            }
            //include
            var valueAtInd = GivenArray[startWithInd];
            numbers.Push(valueAtInd);
            DFSBacktrackSort(numbers, startWithInd + 1);
            //not include
            numbers.Pop();
            //var findTheindexwhereThereisnone
            var indPlus = startWithInd + 1;
            while (indPlus < GivenArray.Length && GivenArray[indPlus] == valueAtInd)
            {
                indPlus += 1;
            }

            if (indPlus < GivenArray.Length)
            {
                DFSBacktrackSort(numbers, indPlus);
            }
        }
        public void DFSBacktrackDic(Stack<int> numbers, int startWithInd, int prevInclT, int prevInVal)
        {
            //base
            if (startWithInd >= KeyToArray.Length)
            {
                var ans = numbers.ToList();
                Answers.Add(ans);
                return;
            }
            //include
            var valueAtInd = KeyToArray[startWithInd];
            numbers.Push(valueAtInd);

            if (prevInVal == valueAtInd && NumberAndNumberOfTimes[valueAtInd] < prevInclT + 1)
            {
                //now dfs with same
                DFSBacktrackDic(numbers, startWithInd, prevInclT + 1, valueAtInd);
            }
            else
            {
                DFSBacktrackDic(numbers, startWithInd + 1, 1, valueAtInd);
            }

            //not include
            numbers.Pop();
            //var findTheindexwhereThereisnone
            DFSBacktrackDic(numbers, startWithInd + 1, prevInclT, prevInVal);
        }
    }

    public class PalindromePartition
    {
        public List<List<string>> Answers { get; set; }
        public string GivenString { get; set; }
        public PalindromePartition()
        {
            Answers = new List<List<string>>();
        }
        public void Algorithmn()
        {
            DFSBackTrack(new Stack<string>(), 0);
        }
        private bool IsPalindrome(int startAIndex, int endIndex)
        {
            var word = GivenString[startAIndex..endIndex];

            var (i, j, isPal) = (0, word.Length - 1, true);
            while (i < j)
            {
                if (word[i] != word[j])
                {
                    isPal = false;
                    break;
                }

                i += 1;
                j -= 1;
            }

            return isPal;
        }

        public void DFSBackTrack(Stack<string> wordsUpToNow, int startWithThisIndex)
        {
            //baSe case 
            if (startWithThisIndex >= GivenString.Length)
            {
                var ans = wordsUpToNow.ToList();
                Answers.Add(ans);
                return;
            }

            //actual logic
            for (int i = startWithThisIndex; i < GivenString.Length; i++)
            {
                var isPalindrome = IsPalindrome(startWithThisIndex, i);
                if (isPalindrome)
                {
                    wordsUpToNow.Push(GivenString[startWithThisIndex..i]);
                    DFSBackTrack(wordsUpToNow, i + 1);
                    wordsUpToNow.Pop();
                }
            }
        }
    }

    //hard
    //https://www.youtube.com/watch?v=G_UYXzGuqvM
    public class SudokuSolver
    {
        public int[,] Sudoku { get; set; }
        public SudokuSolver()
        {
            
        }

        public void Algorithmn()
        {

        }

        private HashSet<int> FindRemaining(int row, int column)
        {
            var ansHash = new HashSet<int>(Enumerable.Range(1, 10).ToList());
            for (int i = 0; i < Sudoku.GetLength(1); i++)
            {
                if (Sudoku[row, i] == 0)
                {
                    continue;
                }
                ansHash.Remove(Sudoku[row, i]);
            }

            for (int i = 0; i < Sudoku.GetLength(0); i++)
            {
                if (Sudoku[i, column] == 0)
                {
                    continue;
                }

                ansHash.Remove(Sudoku[i, column]);
            }
            //do the matrix test now.
            var (rowModulo, columnModulo) = (row % 3, column % 3);
            var (startR, endR, startC, endC) = 
                (row - rowModulo, row + rowModulo - 2, column - columnModulo, column + columnModulo - 2);

            for (int i = startR; i <= endR; i++)
            {
                for (int j = startC; j <= endC; j++)
                {
                    if (Sudoku[i, j] == 0)
                    {
                        continue;
                    }
                    ansHash.Remove(Sudoku[i,j]);
                }
            }

            return ansHash;
        }
        public void BackTrackDFS(int row, int column)
        {
            //base case


            var firstChangeColumn = false;
            //foreach row
            for (int i = row; i < Sudoku.GetLength(0); i++)
            {
                //foreach column
                if (column >= Sudoku.GetLength(1))
                {
                    column = 0;
                    continue;
                }

                for (int j = column; j < Sudoku.GetLength(1); j++)
                {
                    if (!firstChangeColumn)
                    {
                        column = 0;
                        firstChangeColumn = true;
                    }

                    if (Sudoku[i,j] != 0)
                    {
                        continue;
                    }
                    else
                    {
                        var findRemaining = FindRemaining(i, j);

                        foreach (var i1 in findRemaining)
                        {
                            Sudoku[i, j] = i1;
                            BackTrackDFS(i,j + 1);
                            Sudoku[i, j] = 0;
                        }
                    }
                }
            }

        }
    }

    public class NQueens
    {
        public int NumberOfQueens { get; set; }
        public HashSet<int> PositiveSlope { get; set; }
        public HashSet<int> NegativeSlope { get; set; }
        public int[,] Matrix { get; set; }

        public bool Found { get; set; } = false;
        public NQueens()
        {
            PositiveSlope = new HashSet<int>();
            NegativeSlope = new HashSet<int>();
        }

        public void Algorithmn()
        {

        }

        public void DFSBacktrack(int whichREowToAdd, Stack<int> alreadyAddedColm)
        {
            //base case
            if (whichREowToAdd >= NumberOfQueens)
            {
                //done
                Found = true;
                return;
            }

            for (int i = 0; i < NumberOfQueens; i++)
            {
                if (alreadyAddedColm.Contains(i))
                {
                    continue;
                }

                var posSlop = whichREowToAdd + i;
                var negSlop = whichREowToAdd - i;
                if (!PositiveSlope.Contains(posSlop) && !NegativeSlope.Contains(negSlop))
                {
                    alreadyAddedColm.Push(i);
                    PositiveSlope.Add(posSlop);
                    NegativeSlope.Add(negSlop);
                    Matrix[whichREowToAdd, i] = 1;
                    DFSBacktrack(whichREowToAdd + 1, alreadyAddedColm);
                    if (Found)
                    {
                        return;
                    }

                    alreadyAddedColm.Pop();
                    PositiveSlope.Remove(posSlop);
                    NegativeSlope.Remove(negSlop);
                    Matrix[whichREowToAdd, i] = 0;
                }
            }
        }
    }

    public class ReconstructItinerary
    {
        public string[][] ArrayOfArrays { get; set; }
        public string StartingAirport { get; set; }
        public Dictionary<string, HashSet<string>> AirportConnectionDictionary { get; set; }
        public bool AlreadyFound { get; set; }
        public HashSet<string> AllValuesUsed { get; set; }
        public List<string> Answer { get; set; }
        public ReconstructItinerary()
        {
            AirportConnectionDictionary = new Dictionary<string, HashSet<string>>();
            AllValuesUsed = new HashSet<string>();
            //ArrayOfArrays = new[] { new[] { "fdasfasd" }, new[] { "dadfa", "fdasfas" } };
        }

        private void Initialize()
        {
            Sort();
            for (int i = 0; i < ArrayOfArrays.Length; i++)
            {
                var firstOne = ArrayOfArrays[i][0];
                var secondOne = ArrayOfArrays[i][1];
                if (AirportConnectionDictionary.ContainsKey(firstOne))
                {
                    AirportConnectionDictionary[firstOne].Add(secondOne);
                }
                else
                {
                    AirportConnectionDictionary[firstOne] = new HashSet<string> { secondOne };
                }
            }
        }
        public void Algorithmn()
        {
            Initialize();
            DFSBacktrack(new Stack<string>(), StartingAirport);
        }

        private void Sort()
        {
            //for (int i = startInd; i < EndInd; i++)
            //{
            //    //which word to sort
            //    var indexIfSec = startInTheWord - (ArrayOfArrays[startInd][0].Length - 1);
            //    var (wordToTake, ind) = ArrayOfArrays[startInd][0].Length <= startInTheWord ?
            //        (indexIfSec >= ArrayOfArrays[startInd][1].Length ?
            //                "" : ArrayOfArrays[startInd][1], indexIfSec
            //            ) 
            //        : (ArrayOfArrays[startInd][0], startInTheWord);
            //}


            var (n, nPlus) = (0, 1);
            while (nPlus < ArrayOfArrays.Length)
            {
                var firstWord = String.Join("", ArrayOfArrays[n]);
                var secondWord = String.Join("", ArrayOfArrays[nPlus]);

                var (p, q) = (0, 0);
                while (p < firstWord.Length && q < secondWord.Length)
                {
                    var (wF, wS) = (firstWord[p], secondWord[q]);
                    if (wF > wS)
                    {
                        break;
                    }
                    else if(wF < wS)
                    {
                        (ArrayOfArrays[n], ArrayOfArrays[nPlus]) = 
                            (ArrayOfArrays[nPlus], ArrayOfArrays[n]);
                        break;
                    }

                    (p, q) = (p + 1, q + 1);
                }

                (n, nPlus) = (n + 1, nPlus + 1);
            }

        }
        private void DFSBacktrack(Stack<string> addedUptoNow, string currentlyIn)
        {
            //base
            if (AllValuesUsed.Count == 0)
            {
                var all = addedUptoNow.ToList();
                all.Reverse();
                Answer = all;
                AlreadyFound = true;
            }

            //go through each backtrack
            var findAll = AirportConnectionDictionary[currentlyIn];
            var copyFind = new HashSet<string>(findAll);
            foreach (var each in copyFind)
            {
                var removedFromHash = false;
                addedUptoNow.Push(each);
                findAll.Remove(each);
                if (findAll.Count == 0)
                {
                    AllValuesUsed.Remove(currentlyIn);
                    removedFromHash = true;
                }
                DFSBacktrack(addedUptoNow, each);
                if (AlreadyFound)
                {
                    return;
                }
                addedUptoNow.Pop();
                findAll.Add(each);
                if (removedFromHash)
                {
                    AllValuesUsed.Add(currentlyIn);
                }
            }
        }
    }

    //https://www.youtube.com/watch?v=pfiQ_PS1g8E
    //leetcode 332
    public class WordSearch
    {
        public string Word { get; set; }
        public string[,] Matrix { get; set; }
        public List<string[]> AnsArrays { get; set; }
        public HashSet<string> VisitedHash { get; set; }

        public WordSearch()
        {
            AnsArrays = new List<string[]>();
            VisitedHash = new HashSet<string>();
        }

        public void Algorithmn()
        {
            DFSBacktrack(new Stack<string>(), 0, 0, 0);
        }

        public void DFSBacktrack(Stack<string> allthgings, int index, int row, int column)
        {
            //base case
            if (index >= Word.Length)
            {
                //found it
                var ans = allthgings.ToArray();
                AnsArrays.Add(ans);
                return;
            }
            if (row > Matrix.GetLength(0) || column > Matrix.GetLength(1) || VisitedHash.Contains($"{row}, {column}"))
            {
                return;
            }
            //other
            var characterLooking = Word[index].ToString();
            if (Matrix[row, column] != characterLooking)
            {
                return;
            }

            VisitedHash.Add($"{row}, {column}");
            allthgings.Push(Matrix[row, column]);
            //go right
            DFSBacktrack(allthgings, index +1, row, column + 1);
            DFSBacktrack(allthgings, index +1, row, column - 1);
            DFSBacktrack(allthgings, index +1, row - 1, column);
            DFSBacktrack(allthgings, index +1, row + 1, column);
            VisitedHash.Remove($"{row}, {column}");
            allthgings.Pop();
        }
    }

    //leetcode 79
    //https://www.youtube.com/watch?v=asbcE9mZz_U
    public class WordSearch2
    {
        public Trie TrieDict { get; set; }
        public string[] GivenWord { get; set; }
        public string[,] ChessBoard { get; set; }
        public HashSet<string> AlreadyVisited { get; set; }
        public List<string> Answers { get; set; }
        public WordSearch2()
        {
            TrieDict = new Trie();
            AlreadyVisited = new HashSet<string>();
            Answers = new List<string>();
        }

        private void InitializeTrie()
        {
            foreach (var st in GivenWord)
            {
                var dummy = TrieDict;
                foreach (var s in st)
                {
                    if (dummy.AllOthersThatAreBelow.ContainsKey(s.ToString()))
                    {
                        dummy = dummy.AllOthersThatAreBelow[s.ToString()];
                    }
                    else
                    {
                        dummy.AllOthersThatAreBelow.Add(s.ToString(), new Trie());
                        dummy = dummy.AllOthersThatAreBelow[s.ToString()];
                    }
                }
            }
        }
        public void Algorithmn()
        {
            InitializeTrie();
            DFSBacktrack(TrieDict, 0,0, new Stack<string>());
        }
        public void DFSBacktrack(Trie thisTrie, int row, int column, Stack<string> wordupToNow)
        {
            //base case(if trie has no children or it's the end of the edge)
            if (AlreadyVisited.Contains($"{row}, {column}"))
            {
                return;
            }

            AlreadyVisited.Add($"{row}, {column}");
            


            var (rP, rM, cP, cM, chesRL, chesCL) = 
                (row + 1, row - 1, column + 1, column - 1, ChessBoard.GetLength(0), ChessBoard.GetLength(1));

            var (rowToUse, columnToUse) = (row, column);

            //go down
            if (rP > chesRL)
            {
                //return;
            }
            else
            {
                (rowToUse, columnToUse) = (rP, column);
                DoTheDFS(rowToUse, columnToUse, thisTrie, wordupToNow);
            }

            if (rM < 0)
            {
                //return;
            }
            else
            {
                (rowToUse, columnToUse) = (rM, column);
                DoTheDFS(rowToUse, columnToUse, thisTrie, wordupToNow);
            }

            if (cP > chesCL)
            {
                //return;
            }
            else
            {
                (rowToUse, columnToUse) = (row, cP);
                DoTheDFS(rowToUse, columnToUse, thisTrie, wordupToNow);
            }

            if (cM < 0)
            {
                //return;
            }
            else
            {
                (rowToUse, columnToUse) = (row, cM);
                DoTheDFS(rowToUse, columnToUse, thisTrie, wordupToNow);
            }
        }

        private void DoTheDFS(int row, int col, Trie thisTrie, Stack<string> wordupToNow)
        {
            var wordHere = ChessBoard[row, col];
            if (thisTrie.EndHere)
            {
                var wordreal = wordupToNow.ToList().ToString();
                Answers.Add(wordreal);
            }

            if (TrieDict.AllOthersThatAreBelow.ContainsKey(wordHere))
            {
                wordupToNow.Push(wordHere);
                thisTrie = TrieDict.AllOthersThatAreBelow[wordHere];
                DFSBacktrack(thisTrie, row, col, wordupToNow);
                wordupToNow.Pop();
            }
        }
    }

    public class Trie
    {
        public Trie()
        {
            AllOthersThatAreBelow = new Dictionary<string, Trie>();
        }
        public Dictionary<string, Trie> AllOthersThatAreBelow { get; set; }
        public bool EndHere { get; set; }
        public string CharacterHere { get; set; }
    }


    public class DiffrentWaysToAddParenthesis
    {
        public string GetTheequation { get; set; }
        public DiffrentWaysToAddParenthesis()
        {
            
        }

        public void Algorithmn()
        {
            var splitted = GetTheequation.Split(new []{'-', '*', '+'});
        }

        //not include endIndex
        public List<int> DFSBacktrack(string manipulateString)
        //public void DFSBacktrack(int startInd, int endIndex)
        {
            //base case
            if (manipulateString.Length <= 3)
            {
                var returnThis = new List<int>();
                var computedVal = (int)new DataTable().Compute(manipulateString, null);
                returnThis.Add(computedVal);
                return returnThis;
            }

            //var sa = 2 (char)"*" 3

            var manipulateThis = manipulateString;
            //var manipulateThis = GetTheequation[startInd..endIndex];
            var toReturnOnThis = new List<int>();

            for (int i = 0; i < manipulateThis.Length - 2; i += 2)
            {
                //if last break

                var iPlusO = i + 1;
                var iPlusT = i + 2;
                var firstpart = manipulateThis[..iPlusO];
                var operatorToBeused = manipulateThis[iPlusO..iPlusT];
                var secondPart = manipulateThis[iPlusT..];

                var allFirsts = DFSBacktrack(firstpart);
                var allseconds = DFSBacktrack(secondPart);

                foreach (var allFirst in allFirsts)
                {
                    foreach (var allsecond in allseconds)
                    {
                        var computedVal = (int)new DataTable().Compute(allFirsts + operatorToBeused
                                                                            + allsecond, null);
                        toReturnOnThis.Add(computedVal);
                    }
                }

                //var value = manipulateThis[..iPlusO] + manipulateThis[iPlusO..iPlusT]
                //    + manipulateThis[iPlusT..];


            }

            return toReturnOnThis;
        }
    }

    public class RobotRoomCleaner
    {
        public int[,] RoomDimensions { get; set; }
        public int InitialRow { get; set; }
        public int InitialColumn { get; set; }
        public HashSet<string> AlreadyCleaned { get; set; }
        public int Face { get; set; }
        public RobotRoomCleaner()
        {
            AlreadyCleaned = new HashSet<string>();
        }

        public bool Move(int row, int column)
        {
            if (row > RoomDimensions.GetLength(0) || row < 0 || column > RoomDimensions.GetLength(1)
                || column < 0)
            {
                return false;
            }
            if (RoomDimensions[row, column] == 0)
            {
                return true;
            }

            return false;
        }
        public void MoveLeft() => Console.WriteLine("moved left");
        public void MoveRight() => Console.WriteLine("moved right");
        //public int Foo => innerObj.SomeProp;

        public void Algorithmn()
        {

        }

        public void DFSBacktrack(int row, int col)
        {
            //base case 
            if (AlreadyCleaned.Contains($"{row}, {col}"))
            {
                return;
            }

            AlreadyCleaned.Add($"{row}, {col}");
            //
            var (rP, rM, cP, cM) = (row + 1, row - 1, col + 1, col - 1);
            //go up
            GetDesiredFace(Face, 1);
            if (Move(rM, col))
            {
                DFSBacktrack(rM, col);
            }
            //go right
            GetDesiredFace(Face, 2);
            if (Move(row, col + 1))
            {
                DFSBacktrack(row, col + 1);
            }
            //go down
            GetDesiredFace(Face, 3);
            if (Move(rP, col))
            {
                DFSBacktrack(rP, col);
            }
            //go left
            GetDesiredFace(Face, 4);
            if (Move(row, cM))
            {
                DFSBacktrack(row, cM);
            }

        }

        private void GetDesiredFace(int source, int destination)
        {
            //1 is up, 2 is right, 3 is down and 4 is left

            var difference = destination - source;
            //var difference = Math.Abs(source - destination);

            switch (difference)
            {
                case 0:

                    break;
                case 1:
                    //go right
                    MoveRight();
                break;
                case -1:
                    //go right
                    MoveLeft();
                    break;
                case 2:
                    //go double right
                    MoveRight();
                    MoveRight();
                break;
                case -2:
                    //go double right
                    MoveRight();
                    MoveRight();
                    break;
                case -3:
                    //go left
                    MoveLeft(); 
                    break;
                case 3:
                    //go left
                    MoveRight();
                    break;
            }

            Face = destination;
        }
    }
}