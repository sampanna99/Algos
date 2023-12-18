using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithsPractise.LeetCode_Eric.Phase6
{
    public class StringsAlgos
    {
    }
    public class LongestCommonPrefix
    {
        public string[] ArrayofStrings { get; set; }

        //go through first charachter and subsequent on each of them
        public void Algorithmn()
        {
            //have the answerstring. 
            //go through any oine of them

            StringBuilder answerstring = new StringBuilder();

            for (int i = 0; i < ArrayofStrings[0].Length; i++)
            {
                //GO through that index on all of them
                var (value, allHave) = (ArrayofStrings[0][i], true);

                for (int j = 1; j < ArrayofStrings.Length; j++)
                {
                    if (ArrayofStrings[j].Length <= i)
                    {
                        allHave = false;
                        break;
                    }
                    var valueHere = ArrayofStrings[j][i];
                    if (valueHere == value) continue;
                    allHave = false;
                    break;
                }

                if (allHave)
                {
                    answerstring.Append(value);
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine($"The common character is {answerstring}");
        }
    }

    public class GroupAnagrams
    {
        //prelim thoughts
        //list of tupe<Hashset, List<strings>>
        //for each go over each char and see if already in that hashset if yes add to the tuple
        //if not create a new tuple

        public string[] GivenArray { get; set; }

        public void Algorithmn()
        {
            var listOfTuple = new List<Tuple<HashSet<string>, List<string>>>();

            for (int i = 0; i < GivenArray.Length; i++)
            {
                var theOne = GivenArray[i];

                var auxiliaryHash = new HashSet<string>();
                var hashsetOfndexToSkip = new HashSet<int>();


                var hashsetOfndexToNotSkip = new HashSet<int>();
                for (int j = 0; j < listOfTuple.Count; j++)
                {
                    hashsetOfndexToNotSkip.Add(j);
                }


                for (int j = 0; j < theOne.Length; j++)
                {
                    var charToStr = theOne[j].ToString();
                    auxiliaryHash.Add(charToStr);

                    for (int k = 0; k < listOfTuple.Count; k++)
                    {
                        //todomaybe this
                        if (!hashsetOfndexToNotSkip.Contains(k))
                        {
                            continue;
                        }
                        //todomaybe this

                        //if (hashsetOfndexToSkip.Contains(k))
                        //{
                        //    continue;
                        //}
                        var valueAtK = listOfTuple[k].Item1;
                        if (!valueAtK.Contains(charToStr))
                        {
                            //hashsetOfndexToSkip.Add(k);
                            hashsetOfndexToNotSkip.Remove(k);
                        }
                       
                    }
                }

                if (hashsetOfndexToNotSkip.Count < 1)
                {
                    listOfTuple.Add(new Tuple<HashSet<string>, List<string>>(
                        auxiliaryHash,
                        new List<string> { theOne }
                        ));

                }
                else
                {
                    foreach (var i1 in hashsetOfndexToNotSkip)
                    {
                        var getlistofTupleAtThatIndex = listOfTuple[i1];
                            getlistofTupleAtThatIndex.Item2.Add(theOne);

                            //listOfTuple[i1] = new Tuple<HashSet<string>, List<string>>(
                            //    getlistofTupleAtThatIndex.Item1,
                            //    getlistofTupleAtThatIndex.Item2
                            //);
                            //break
                    }
                }

                //if (hashsetOfndexToSkip.Count < listOfTuple.Count)
                //{
                //    listOfTuple.Add(new Tuple<HashSet<string>, List<string>>(
                //        auxiliaryHash,
                //        new List<string>{theOne}
                //        ));
                //}
                //else
                //{

                //}
            }
        }

        public void AlgoUsingSort()
        {
            //Sort each character in the array
            //after sorting go over each one and add it to the group

            var sortedArray = new string[GivenArray.Length];

            for (int i = 0; i < GivenArray.Length; i++)
            {
                var stringToSort = GivenArray[i];
                var sortTheString = SortIt(stringToSort, 0, stringToSort.Length);
                sortedArray[i] = sortTheString;
            }

            //do the rest here.
            var dictionary = new Dictionary<string, List<string>>();

            for (int i = 0; i < sortedArray.Length; i++)
            {
                var value = sortedArray[i];

                if (dictionary.ContainsKey(value))
                {
                    dictionary[value].Add(GivenArray[i]);
                }
                else
                {
                    dictionary.Add(value, new List<string>{GivenArray[i]});
                }
            }

            var jaggedArray = new string[dictionary.Count][];
            var l = 0;
            foreach (var dicVal in dictionary)
            {
                var value = new List<string>(dicVal.Value);
                var toArray = value.ToArray();
                jaggedArray[l] = toArray;
                l += 1;
            }
        }

        public void AlgoUsingBucketSortaThing()
        {
            //for each word go over char and put it ia bucket
            //after each word go through a -> z and create a key and add that word in there if key doesn;t

            var arrayOfChar = new string[26];
            var diction = new Dictionary<string, List<string>>();
            foreach (var eachitem in GivenArray)
            {
                foreach (var character in eachitem)
                {
                    var index = character - 'a';
                    arrayOfChar[index] += 1;
                }
                //create the key
                var key = new StringBuilder();
                for(var i = 0; i < arrayOfChar.Length; i++)
                {
                    var character = (char)(i + 'a');
                    key.Append(character);
                    key.Append(arrayOfChar[i]);
                }

                var keyToStr = key.ToString();
                if (diction.ContainsKey(keyToStr))
                {
                    diction[keyToStr].Add(eachitem);
                }
                else
                {
                    diction[keyToStr] = new List<string> { eachitem };
                }

            }

            var newArrayForAns = new string[diction.Count][];
            var k = 0;
            foreach (var dictinaryVal in diction)
            {
                newArrayForAns[k] = dictinaryVal.Value.ToArray();
            }
        }

        public string SortIt(string tosort, int startInd, int endInde)
        {
            if (startInd >= endInde)
            {
                return tosort;
            }
            //find the partition
            //sort left 
            //sort right
            var findPartitionIndex = PartitionIndex(tosort, startInd, endInde);
            SortIt(findPartitionIndex.Item2, startInd, findPartitionIndex.Item1 - 1);
            var secondHalf = SortIt(findPartitionIndex.Item2, findPartitionIndex.Item1 + 1, endInde);
            //check this with the left
            return secondHalf;
            //check this with the right
        }

        private (int, string) PartitionIndex(string toSort, int startIndex, int endIndex)
        {
            var stringBuiolder = new StringBuilder(toSort);
            var findThePartition = toSort[endIndex];

            var (partitionIndex, startInd) = (startIndex, startIndex);

            while (endIndex > startInd)
            {
                var charAtStartInd = toSort[startInd];
                if (charAtStartInd >= findThePartition)
                {
                    //swap with at the partitionIndex0
                    (stringBuiolder[partitionIndex], stringBuiolder[startInd]) =
                        (stringBuiolder[startInd], stringBuiolder[partitionIndex]);
                    partitionIndex += 1;
                }

                startInd += 1;
            }
            (stringBuiolder[partitionIndex], stringBuiolder[endIndex]) =
                (stringBuiolder[endIndex], stringBuiolder[partitionIndex]);
            return (partitionIndex, stringBuiolder.ToString());

        }

    }

    public class ReorderDataInLogFiles
    {
        public string[] GivenArrayOfStrings { get; set; }
        public ReorderDataInLogFiles()
        {
            
        }

        public void Algorithmn()
        {
            //Maybe noit Quick or Merge Sort
            //Bubble sort typa thing
            //1st create two arrays for let and dig
            //compare each char in the second index of it. and swap if smaller. go for length - 1 passes
            //now it's sorted. add two lists together

            var listForLog = new List<string>();
            var listForDig = new List<string>();

            for (int i = 0; i < GivenArrayOfStrings.Length; i++)
            {
                if (GivenArrayOfStrings[i].ToUpper().StartsWith("D"))
                {
                    listForDig.Add(GivenArrayOfStrings[i]);
                }
                else
                {
                    listForLog.Add(GivenArrayOfStrings[i]);
                }
            }

            for (int i = 0; i < listForLog.Count; i++)
            {
                var masterspl = listForLog[i].Split(" ", 2);
                var split = masterspl[1];

                for (int j = i + 1; j < listForLog.Count; j++)
                {
                    var masterspl2 = listForLog[j].Split(" ", 2);

                    var split2 = masterspl2[1];

                    var (k, l,first) = (0, 0, "");
                    while (k < split.Length || l < split2.Length)
                    {

                        if (k >= split.Length)
                        {
                            first = split;
                            break;
                        }
                        if (l >= split2.Length)
                        {
                            first = split2;
                            break;
                        }
                        if (k != l)
                        {
                            if (string.IsNullOrWhiteSpace(split[k].ToString()))
                            {
                                //this is first
                                first = split;
                                break;
                            }
                            else if(string.IsNullOrWhiteSpace(split2[l].ToString()))
                            {

                                first = split2;
                                break;
                            }
                            else
                            {
                                first = split[k] > split2[l] ? split2 : split;
                            }
                        }

                        k += 1;
                        l += 1;
                    }

                    //Now check if both are exactly the same. in that case legographical oreder by first st
                    if (first == "")
                    {
                        //Now sort out 
                        var (sortA, sortB) = (masterspl[0], masterspl2[0]);
                    }
                }
            }
        }
    }
}
