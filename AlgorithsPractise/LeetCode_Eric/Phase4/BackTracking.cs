using System;
using System.Collections.Generic;
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
}