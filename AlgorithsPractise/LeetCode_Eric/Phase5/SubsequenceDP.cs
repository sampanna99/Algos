using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace AlgorithsPractise.LeetCode_Eric.Phase5
{
    public class SubsequenceDP
    {

    }

    public class LongestIncreasingSubs
    {
        public int[] GivenArray { get; set; }
        public Dictionary<int, List<int>> Memoization { get; set; }


        public LongestIncreasingSubs()
        {
             
        }

        public void ALgorithmn()
        {

        }

        public void DPTabular()
        {
            var array = new int[GivenArray.Length, GivenArray.Length];

            //initilaization
            for (int i = 0; i < GivenArray.Length; i++)
            {
                array[i, i] = 1;
            }

            for (int i = GivenArray.GetLength(0) - 2; i >= 0; i--)
            {
                //column
                for (int j = i + 1; j < GivenArray.GetLength(1); j++)
                {
                    //get value starting at i ending at j
                    var beforeNumberOfI = array[i, j - 1];
                    var beforeActNumber = GivenArray[j - 1];
                    if (GivenArray[j] > beforeActNumber)
                    {
                        array[i, j] = Math.Max(1 + beforeNumberOfI, array[i + 1, j]);
                    }
                    else
                    {
                        array[i, j] = Math.Max(beforeNumberOfI, array[i+1, j]);
                    }

                }
            }
        }

        public List<int> DFSWithActualValues(int index, int prevVal)
        {
            //base case
            if (index >= GivenArray.Length)
            {
                return new List<int>();
            }

            if (Memoization.ContainsKey(index))
            {
                return Memoization[index];
            }
            var returnThisList = new List<int>();
            if (GivenArray[index] > prevVal)
            {
                //including index
                returnThisList = DFSWithActualValues(index + 1, GivenArray[index]);
                returnThisList.Add(index);
            }

            var notInc = DFSWithActualValues(index + 1, prevVal);
            if (returnThisList.Count >= notInc.Count)
            {
                Memoization[index] = returnThisList;
                return returnThisList;
            }
            else
            {
                Memoization[index] = notInc;
                return notInc;
            }

            //not including index

        }

    }

    public class LongestPalindromicSubs
    {
        public string GivenString { get; set; }
        public int MaximumLength { get; set; }
        public LongestPalindromicSubs()
        {
            
        }

        public void Algorithmn()
        {

        }

        private bool PaliCheck(string stringToCheck)
        {
            return false;
        }

        ///can't be memoized as it uses values from before at the end.;
        ///I figured out that for memoization gotta return starting or after that point.
        ///
        public int RecursiveMethod(int addOrdontAddInd, string stringFormedUpto, int paliBeforeForNA)
        {
            //base case when it overflows
            if (addOrdontAddInd >= GivenString.Length)
            {
                //return;

                var isPali = PaliCheck(stringFormedUpto);
                if (isPali)
                {
                    return stringFormedUpto.Length;
                }
            }

            //add first; see if it is pali; and recurse
            var addingfrombefore = stringFormedUpto + GivenString[addOrdontAddInd];
            var paliLength = 0;
            if (PaliCheck(addingfrombefore))
            {
                paliLength = addingfrombefore.Length;
                if (addingfrombefore.Length > MaximumLength)
                {
                    MaximumLength = addingfrombefore.Length;
                    
                }
            }
            var adding = RecursiveMethod(addOrdontAddInd + 1, addingfrombefore, paliLength);
            //dont add; pali length is from before; recurse;
            var notadding = RecursiveMethod(addOrdontAddInd + 1, stringFormedUpto, paliBeforeForNA);

            return adding > notadding ? adding : notadding;
        }
    }


    public class LongestCommonSubseq
    {
        public string StringA { get; set; }
        public string StringB { get; set; }

        public Dictionary<string, string> IndexesValuesDic { get; set; }
        public LongestCommonSubseq()
        {
            IndexesValuesDic = new Dictionary<string, string>();
        }

        public void Algorithmn()
        {

        }

        //commenting this out because I wantedc to practise memoization as well.
        //public void DFSRecurse(int indexA, int indexB, int maxBefore)
        public string DFSRecurse(int indexA, int indexB)
        {
            //base case
            if (indexA >= StringA.Length || indexB >= StringB.Length)
            {
                return "";
            }
            //keep adding to left; right constant
            if (IndexesValuesDic.ContainsKey($"{indexA}{indexB}"))
            {
                return IndexesValuesDic[$"{indexA}{indexB}"];
            }

            var strL = DFSRecurse(indexA + 1, indexB);

            //keep adding to right; left constant
            var strR = DFSRecurse(indexA, indexB + 1);

            //if they are equal
            var leftVal = StringA[indexA].ToString();
            var rightVal = StringB[indexB].ToString();

            string returnthis = strL.Length > strR.Length ? strL : strR;
            if (leftVal == rightVal)
            {
                returnthis = leftVal + returnthis;
            }
            IndexesValuesDic.Add($"{indexA}{indexB}", returnthis);
            return returnthis;

        }

    }


    public class MaximumSubarray
    {
        public int[] Nums { get; set; }

        public Dictionary<int, List<int>> DictionaryForMemoization { get; set; }
        public MaximumSubarray()
        {
            DictionaryForMemoization = new Dictionary<int, List<int>>();
        }

        //def better soln with other but I am trying out brute. Tbh it's On2 solution. Pretty good.
        public List<int> BruteForceDFSWithMemo(int index, int prevValue)
        {
            //base case
            if (index >= Nums.Length)
            {
                return new List<int>();
            }

            //including the index

            if (DictionaryForMemoization.ContainsKey(index))
            {
                return DictionaryForMemoization[index];
            }
            var valueAtInd = Nums[index];
            var getincluding = new List<int>();
            if (valueAtInd > prevValue)
            {
                //continue this path of including
                 getincluding = BruteForceDFSWithMemo(index + 1, valueAtInd);
                 getincluding.Add(index);
            }

            //excluding the index
            var excluding = BruteForceDFSWithMemo(index + 1, prevValue);

            if (excluding.Count > getincluding.Count)
            {
                return excluding;
            }
            else
            {
                return getincluding;
            }
        }
    }
}
