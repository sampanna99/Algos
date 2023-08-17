using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithsPractise.LeetCode_Eric.Phase1
{
    public class SlidingWindows
    {

    }

    //eric programming
    public class MinimumSizeSubarray
    {
        public int[] ArrayGiven { get; set; }
        public int Target { get; set; }
        public MinimumSizeSubarray()
        {
            ArrayGiven = new[] { 2, 3, 1, 2, 4, 3 };
            Target = 7;
        }

        public void Algorithmn()
        {
            var minimumNumberNeeded = Int32.MaxValue;
            var (firstPointer, secondPointer, sum) = (0, 0, 0);

            while (firstPointer <= secondPointer && secondPointer < ArrayGiven.Length)
            {
                sum += ArrayGiven[secondPointer];
                if (sum >= Target)
                {
                    sum -= ArrayGiven[firstPointer];
                    firstPointer += 1;
                    var diffrence = secondPointer - firstPointer + 1;
                    if (diffrence < minimumNumberNeeded)
                    {
                        minimumNumberNeeded = diffrence;
                    }
                }
            }

        }
    }

    //leetcode 159
    public class LongestSubstringAtMostTwoDistinctChar
    {
        public string GivenString { get; set; }
        public int MaximumGiven { get; set; }
        public Dictionary<string, int> Dictionary { get; set; }
        public LongestSubstringAtMostTwoDistinctChar()
        {
            GivenString = "eceba";
            Dictionary = new Dictionary<string, int>();
            MaximumGiven = 2;
        }

        public void Algorithmn()
        {
            var maxLength = Int32.MinValue;
            var (i, startVal) = (0, 0);
            while (i < GivenString.Length)
            {
                var stringValue = GivenString[i].ToString();
                if (Dictionary.ContainsKey(stringValue))
                {
                    Dictionary[stringValue] += 1;
                }
                else
                {
                    Dictionary[stringValue] = 1;
                }

                if (Dictionary.Count <= 2)
                {
                    var lengthBetween = i - startVal + 1;

                    if (lengthBetween > maxLength)
                    {
                        maxLength = lengthBetween;
                    }
                }
                else
                {
                    var stingAtStart = GivenString[startVal].ToString();

                    if (Dictionary[stingAtStart] > 1)
                    {
                        Dictionary.Remove(stingAtStart);


                    }
                    else
                    {
                        Dictionary[stingAtStart] -= 1;
                    }

                    startVal += 1;
                }

                i += 1;
            }
        }
    }

    public class LongestSubstringKDistinct
    {
        public string GivenString { get; set; }
        public int Kvalue { get; set; }
        public Dictionary<string, int> NumberOfTimes { get; set; }

        public LongestSubstringKDistinct()
        {
            GivenString = "eceba";
            Kvalue = 2;
            NumberOfTimes = new Dictionary<string, int>();
        }
        public void Algorithmn()
        {
            var (i, startIndex, longestSubstring) = (0, 0, Int32.MinValue);
            while (i < GivenString.Length)
            {
                var stringAtI = GivenString[i].ToString();
                if (NumberOfTimes.ContainsKey(stringAtI))
                {
                    NumberOfTimes[stringAtI] += 1;
                }
                else
                {
                    NumberOfTimes[stringAtI] = 1;
                }

                if (NumberOfTimes.Count > Kvalue)
                {
                    startIndex += 1;
                    var valueatThatLocation = NumberOfTimes[stringAtI];

                    if (valueatThatLocation > 1)
                    {
                        NumberOfTimes[stringAtI] -= 1;
                    }
                    else
                    {
                        NumberOfTimes.Remove(stringAtI);
                    }
                }

                if (NumberOfTimes.Count < Kvalue)
                {
                    var longestOne = i - startIndex + 1;
                    if (longestSubstring < longestOne)
                    {
                        longestSubstring = longestOne;
                    }
                }

                i += 1;
            }
        }
    }

    public class MaxConsecutiveOnesWithOneFlip
    {
        public int[] ArrayOfInt { get; set; }
        public int MostFlipPermitted { get; set; }

        public MaxConsecutiveOnesWithOneFlip()
        {
            ArrayOfInt = new[] { 1, 0, 1, 1, 0 };
            MostFlipPermitted = 1;
        }

        public void Algorithmn()
        {
            var (firstPointer, secondPointer, maxConsecute, numberFlipped) = (0, 0, 0, 0);

            while (secondPointer < ArrayOfInt.Length)
            {
                if (ArrayOfInt[secondPointer] == 1)
                {
                    maxConsecute += 1;
                    secondPointer += 1;
                }
                else if (numberFlipped < MostFlipPermitted)
                {
                    numberFlipped += 1;
                    maxConsecute += 1;
                    secondPointer += 1;
                }
                else
                {
                    if (ArrayOfInt[firstPointer] == 0)
                    {
                        maxConsecute -= 1;
                    }
                    firstPointer += 1;
                }

                if (firstPointer > secondPointer)
                {
                    secondPointer = firstPointer;
                }

                var val = secondPointer - firstPointer + 1;
                if (maxConsecute < val)
                {
                    maxConsecute = val;
                }
            }
        }

    }
    public class LongestRepeatingCharacter
    {
        public string GivenString { get; set; }
        public int Flipped { get; set; }
        public Dictionary<string, int> DictionaryOfWords { get; set; }

        public LongestRepeatingCharacter()
        {
            GivenString = "AABABBA";
            Flipped = 2;
            DictionaryOfWords = new Dictionary<string, int>();
        }

        ///This way is for 0s and 1s and one of them being constant for ex: number of 1s with 0s that
        /// could be replaced. So we didn't use dictionary here
        public void Algorithmn()
        {
            var (firstPointer, secondPointer, startIndex, endIndex, 
                flippedNum, maxLength) = (0,0,0,0,0, 0);
            while (GivenString.Length > secondPointer + 1)
            {
                if (secondPointer + 1 < GivenString.Length)
                {
                    if (GivenString[secondPointer] == GivenString[secondPointer + 1])
                    {
                        secondPointer += 1;
                        endIndex = secondPointer + 1;
                    }else if (flippedNum < Flipped)
                    {
                        flippedNum += 1;
                        endIndex = secondPointer + 1;
                    }
                    else
                    {
                        //issue here.
                        if (GivenString[firstPointer] != GivenString[secondPointer])
                        {
                            flippedNum -= 1;
                        }
                        firstPointer += 1;
                        startIndex = firstPointer;
                    }
                }
                else
                {
                    
                }

                secondPointer += 1;
            }
        }

        public void Algorithmn1()
        {

            var (firstPointer, secondPointer, startIndex, endIndex,
                flippedNum, maxLengthOfMostRepeated, flippedChar) = (0, 0, 0, 0, 0, 0, "");

            while (secondPointer < GivenString.Length)
            {
                var name = GivenString[secondPointer].ToString();
                if (DictionaryOfWords.ContainsKey(name))
                {
                    DictionaryOfWords[name] += 1;
                }
                else
                {
                    DictionaryOfWords[name] = 1;
                }

                if (maxLengthOfMostRepeated < DictionaryOfWords[name])
                {
                    maxLengthOfMostRepeated = DictionaryOfWords[name];
                }

                var checkTosee = secondPointer - firstPointer + 1 - maxLengthOfMostRepeated;

                if (checkTosee > Flipped)
                {
                    var firstOne = GivenString[firstPointer].ToString();
                    //now remove
                    if (DictionaryOfWords[firstOne] == maxLengthOfMostRepeated)
                    {
                        if (DictionaryOfWords[firstOne] > 1)
                        {
                            DictionaryOfWords[firstOne] -= 1;
                        }
                        else
                        {
                            DictionaryOfWords.Remove(firstOne);
                        }

                        //now new highest
                        var max = 0;
                        foreach (var dictionaryOfWord in DictionaryOfWords)
                        {
                            if (dictionaryOfWord.Value > max)
                            {
                                max = dictionaryOfWord.Value;
                            }
                        }

                        maxLengthOfMostRepeated = max;

                    }
                    else
                    {
                        if (DictionaryOfWords[firstOne] > 1)
                        {
                            DictionaryOfWords[firstOne] -= 1;
                        }
                        else
                        {
                            DictionaryOfWords.Remove(firstOne);
                        }
                    }
                    firstPointer += 1;
                }

                secondPointer += 1;

            }
        }

    }

    public class PermutationOfAString
    {
        public string String1 { get; set; }
        public string String2 { get; set; }
        public Dictionary<string, int> DString1 { get; set; }
        public Dictionary<string, int> DString2 { get; set; }

        public PermutationOfAString()
        {
            DString1 = new Dictionary<string, int>();
            DString2 = new Dictionary<string, int>();
            String1 = "abc";
            String2 = "baxyzabc";
        }
        public void Algorithmn()
        {
            for (int i = 0; i < String1.Length; i++)
            {
                var val = String1[i].ToString();
                if (DString1.ContainsKey(val))
                {
                    DString1[val] += 1;
                }
                else
                {
                    DString1[val] = 1;
                }
            }

            var (firstPointer, secondPointer, firstStringLen, firstTime, matches,
                    matchneeded, answer) =
                (0,0, 0,true, 0, 0, false);
            while (secondPointer < String2.Length)
            {
                var val = String2[secondPointer].ToString();
                if (firstStringLen < String1.Length)
                {
                    if (DString2.ContainsKey(val))
                    {
                        DString2[val] += 1;
                    }
                    else
                    {
                        DString2[val] = 1;
                    }
                }
                else
                {
                    if (firstTime)
                    {
                        matchneeded = DString1.Count;
                        foreach (var kv in DString1)
                        {
                            if (DString2.ContainsKey(kv.Key) && DString2[kv.Key] == kv.Value)
                            {
                                matches += 1;
                            }
                        }
                    }
                    else
                    {
                        if (matchneeded == matches)
                        {
                            answer = true;
                            break;
                        }
                    }
                }
            }
        }
    }

    public class MinimumWindow
    {
        public string GivenString { get; set; }
        public string GivenString1 { get; set; }
        public MinimumWindow()
        {
            GivenString = "ADOBECODEBANC";
            GivenString1 = "ABC";
        }

        public void Algorithmn()
        {
            var dictionaryForSmall = new Dictionary<string, int>();
            for (int i = 0; i < GivenString1.Length; i++)
            {
                var word = GivenString1[i].ToString();
                if (dictionaryForSmall.ContainsKey(word))
                {
                    dictionaryForSmall[word] += 1;
                }
                else
                {
                    dictionaryForSmall[word] = 1;
                }
            }

            var dictionaryForBig = new Dictionary<string, int>();
            var (firstPointer, secondPointer, answerLength, matchNeeded, matches) = 
                (0,0, Int32.MaxValue, dictionaryForSmall.Count, 0);

            while (secondPointer < GivenString.Length)
            {

                //check if it is still match
                var valueAtSecondPointer = GivenString[secondPointer].ToString();
                if (matches < matchNeeded)
                {
                    if (dictionaryForSmall.ContainsKey(valueAtSecondPointer))
                    {
                        //add
                        var changeThematchBy = AdjustTheDict(valueAtSecondPointer, true, dictionaryForBig
                            , dictionaryForSmall);
                        matches += changeThematchBy;
                    }

                    if (matches >= matchNeeded)
                    {
                        var length = secondPointer - firstPointer + 1;
                        if (length < answerLength)
                        {
                            answerLength = length;
                        }

                        //firstPointer += 1; //not this
                    }
                    else
                    {
                        secondPointer += 1;
                    }
                }
                else
                {
                    //

                    var valueAtfirstPointer = GivenString[firstPointer].ToString();

                    if (dictionaryForSmall.ContainsKey(valueAtfirstPointer))
                    {
                        var valueTochangeMatch =
                            AdjustTheDict(valueAtfirstPointer, false, dictionaryForBig, dictionaryForSmall);
                        matches += valueTochangeMatch;
                    }
                    firstPointer += 1; //yes this

                    if (matches >= matchNeeded)
                    {
                        var length = secondPointer - firstPointer + 1;
                        if (length < answerLength)
                        {
                            answerLength = length;
                        }
                    }

                }
            }
        }

        private int AdjustTheDict(string changedString, bool isAdd, Dictionary<string, int> secondDict,
            Dictionary<string, int> firstDict)
        {
            var valueOnFir = firstDict[changedString];
            var valueOnsecOriginal = secondDict[changedString];
            var isEqualOriginal = valueOnFir <= valueOnsecOriginal;

            if (isAdd)
            {
                if (secondDict.ContainsKey(changedString))
                {
                    secondDict[changedString] += 1;
                }
                else
                {
                    secondDict[changedString] = 1;
                }
            }
            else
            {
                if (secondDict[changedString] > 1)
                {
                    secondDict[changedString] -= 1;
                }
                else
                {
                    secondDict.Remove(changedString);
                }
            }
            var valueOnSec = secondDict.ContainsKey(changedString) ? secondDict[changedString]
                    : 0;

            if (isEqualOriginal)
            {
                return valueOnSec >= valueOnFir ? 0 : -1;
            }
            else
            {
                return valueOnSec >= valueOnFir ? 1 : 0;
            }
        }
    }
}
