using System;
using System.Collections.Generic;
using System.Linq;
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

    public class DistinctSubsequences
    {
        public string MasterString { get; set; }
        public string ToMakeString { get; set; }

        public Dictionary<string, List<string>> MemoizationTable { get; set; }
        public DistinctSubsequences()
        {
            MemoizationTable = new Dictionary<string, List<string>>();
        }
        public void Algorithmn()
        {

        }

        public List<string> DFSMaybeMemo(int indexM, int indexT)
        {
            //base cases
            //master done but T is still waiting null
            //master done and T done return empty
            //T done but master index is less than T length return null
            //T done, master index greater than or equal T length return List
            var lengThMaster = MasterString.Length;
            var lengTString = ToMakeString.Length;
            var maximumAllowed = lengThMaster - lengTString;

            //both done
            if (indexM >= lengThMaster && indexT >= lengTString )
            {
                return new List<string>();
            }

            //only T done
            if (indexT >= lengTString)
            {
                //
                if (indexM + 1 >= lengTString)
                {
                    return new List<string>();
                }
                return null;
            }

            //master done!
            if (indexM >= lengTString)
            {
                return null;
            }

            if (MemoizationTable.ContainsKey($"{indexM}{indexT}"))
            {
                return MemoizationTable[$"{indexM}{indexT}"];
            }
            //increasing master keeping Smaller constant
            var increaseMaster = DFSMaybeMemo(indexM + 1, indexT);

            //increasing constant keeping master constant
            var increasingConstant = DFSMaybeMemo(indexM, indexT + 1);
            var returnThis = new List<string>();

            if (increasingConstant != null)
            {
                returnThis.AddRange(increasingConstant);
            }

            if (increaseMaster != null)
            {
                returnThis.AddRange(increaseMaster);
            }

            if (increaseMaster == null && increasingConstant == null)
            {
                returnThis = null;
            }

            if (returnThis != null)
            {
                var addThis = "";
                if (MasterString[indexM] == ToMakeString[indexT])
                {
                    addThis = MasterString[indexM].ToString();
                }
                else
                {
                    addThis = "$" + MasterString[indexM];
                }

                for (int i = 0; i < returnThis.Count; i++)
                {
                    returnThis[i] = addThis + returnThis[i];
                    var splitCount = returnThis[i].Split('$').Length - 1;

                    if (splitCount > maximumAllowed)
                    {
                        //remove this
                        returnThis.RemoveAt(i);
                    }

                }
            }

            MemoizationTable.Add($"{indexM}{indexT}", returnThis);
            return returnThis;
        }
    }

    public class InterleavingStrings
    {
        public string GivenStringA { get; set; }
        public string GivenStringB { get; set; }

        public string MakeThisString { get; set; }
        public bool[,] Matr { get; set; }


        public void Algorithmn()
        {


        }
        public bool DFSAlgo(int indexA, int indexB, int indexMain)
        {
            //base case
            var (lengA, lengB, lengM) = (GivenStringA.Length, GivenStringB.Length, MakeThisString.Length);

            if (indexA >= lengA && indexB >= lengB && indexMain >= lengM)
            {
                return true;
            }

            if ((indexA >= lengA || indexB >= lengB) && indexMain >= lengM)
            {
                return true;
            }

            string vAtA = (indexA < lengA) ? GivenStringA[indexA].ToString() : null;
            string vAtB = (indexB < lengB) ? GivenStringA[indexB].ToString() : null;
            string vAtM = MakeThisString[indexMain].ToString();
            //check value at indexA, indexB and checkValue at indexMain
            var isTrueFromA = false;
            if (vAtA != null)
            {
                if (vAtM == vAtA)
                {
                    isTrueFromA = DFSAlgo(indexA + 1, indexB, indexMain + 1);
                }
            }

            bool istrueFromB = false;
            if (!isTrueFromA)
            {
                if (vAtB != null)
                {
                    if (vAtM == vAtB)
                    {
                        istrueFromB = DFSAlgo(indexA + 1, indexB, indexMain + 1);
                    }
                }
            }

            return isTrueFromA || istrueFromB;
        }

        private void InitializeMatrix()
        {

            Matr = new bool[GivenStringA.Length + 1, GivenStringB.Length + 1];

            for (int i = 0; i < Matr.GetLength(0); i++)
            {
                if (i == 0)
                {
                    Matr[i, 0] = true;
                }
                else
                {
                    var valueAtiMinusOneInd = GivenStringA[i - 1].ToString();
                    var valueAtiMinusOneIndForMain = MakeThisString[i - 1].ToString();
                    if (valueAtiMinusOneIndForMain == valueAtiMinusOneInd)
                    {
                        Matr[i, 0] = Matr[i - 1, 0];
                    }
                    else
                    {
                        Matr[i, 0] = false;
                    }
                }
            }

            for (int i = 0; i < Matr.GetLength(1); i++)
            {
                if (i == 0)
                {
                    Matr[0, i] = true;
                }
                else
                {
                    var valueAtiMinusOneInd = GivenStringB[i - 1].ToString();
                    var valueAtiMinusOneIndForMain = MakeThisString[i - 1].ToString();
                    if (valueAtiMinusOneIndForMain == valueAtiMinusOneInd)
                    {
                        Matr[0, i] = Matr[0, i - 1];
                    }
                    else
                    {
                        Matr[0, i] = false;
                    }
                }
            }

        }
        public bool TabularMethod()
        {
            InitializeMatrix();


            //for each row we put columns first
            for (int i = 1; i < Matr.GetLength(0); i++)
            {
                var valueAtThatRow = GivenStringA[i-1].ToString();
                for (int j = 1; j < Matr.GetLength(1); j++)
                {
                    var valueAtThatCol = GivenStringB[j - 1].ToString();
                    var valueAtThatMain = MakeThisString[j - 1].ToString();

                    var isTrue = false;
                    if (valueAtThatRow == valueAtThatMain)
                    {
                        isTrue = Matr[i - 1, j];
                    }

                    if (!isTrue)
                    {
                        if (valueAtThatMain == valueAtThatCol)
                        {
                            isTrue = Matr[i, j-1];
                        }
                    }

                    Matr[i, j] = isTrue;
                }
            }

            return Matr[GivenStringA.Length - 1, GivenStringB.Length - 1];
        }

    }

    public class WordBreak2
    {
        public string[] GivenStrings { get; set; }
        public string WordToMake { get; set; }

        public Dictionary<int, bool> MemoizationJustForTrueFalse { get; set; }
        public Dictionary<int, List<List<string>>> MemoizationPWP { get; set; }
        public WordBreak2()
        {
            MemoizationJustForTrueFalse = new Dictionary<int, bool>();
            MemoizationPWP = new Dictionary<int, List<List<string>>>();
        }

        public void ALgorithmn()
        {

        }

        //starts with "" and 0;
        //just true or false
        public bool DFSApproach(string upToNow, int startIndex)
        {
            //base case
            if (startIndex >= GivenStrings.Length)
            {
                if (GivenStrings.Contains(upToNow))
                {
                    return true;
                }

                return false;
            }

            var valueAtStartIndex = WordToMake[startIndex].ToString();
            var newStringValue = upToNow + valueAtStartIndex; //this is gonna be "et".

            if (newStringValue.Length == 1)
            {
                if (MemoizationJustForTrueFalse.ContainsKey(startIndex))
                {
                    return MemoizationJustForTrueFalse[startIndex];
                }
            }

            //including the startIndex
            var including = DFSApproach(newStringValue, startIndex + 1);

            if (including)
            {
                if (newStringValue.Length == 1)
                {
                    MemoizationJustForTrueFalse.Add(startIndex, true);
                }
                return true;
            }
            //excluding the startIndex
            var excluding = DFSApproach("", startIndex + 1);

            if (excluding)
            {
                //check if newStringValue  is in the array
                if (GivenStrings.Contains(newStringValue))
                {
                    if (newStringValue.Length == 1)
                    {
                        MemoizationJustForTrueFalse.Add(startIndex, true);
                    }
                    return true;
                }
            }
            if (newStringValue.Length == 1)
            {
                MemoizationJustForTrueFalse.Add(startIndex, false);
            }

            return false;
        }

        //Look rough page 8 behind for logic
        public List<List<string>> DFSApproach2(string upToNow, int startIndex)
        {
            //base case
            if (startIndex >= WordToMake.Length)
            {
                if (GivenStrings.Contains(upToNow))
                {
                    var ret = new List<List<string>>();
                    ret.Add(new List<string>{upToNow});
                    return ret;
                }

                return null;
            }


            var valueHere = WordToMake[startIndex];
            var newString = upToNow + valueHere;

            var returnThis = new List<List<string>>();
            if (GivenStrings.Contains(newString))
            {
                //now go without including
                var withoutIncluding = DFSApproach2("", startIndex + 1);

                if (withoutIncluding != null && withoutIncluding.Count > 0)
                {

                    for (int i = 0; i < withoutIncluding.Count; i++)
                    {
                        withoutIncluding[i].Add(newString);
                    }

                    returnThis.AddRange(withoutIncluding);
                }
            }

            var withIncluding = DFSApproach2(newString, startIndex + 1);
            if (withIncluding != null && withIncluding.Count > 0)
            {
                returnThis.AddRange(withIncluding);
            }

            return returnThis;
        }

        public List<List<string>> DFSApproach3(int startIndex)
        {
            //base case
            if (startIndex >= WordToMake.Length)
            {
                return new List<List<string>>();
            }

            //for each from start to end if string dfs again
            if (MemoizationPWP.ContainsKey(startIndex))
            {
                return MemoizationPWP[startIndex];
            }

            var returnThis = new List<List<string>>();
            for (int i = startIndex; i < WordToMake.Length; i++)
            {
                var iPlus = i + 1;
                var word = WordToMake[startIndex..iPlus];
                if (GivenStrings.Contains(word))
                {
                    var lists = DFSApproach3(iPlus);
                    if (lists != null && lists.Count > 0)
                    {
                        for (int j = 0; j < lists.Count; j++)
                        {
                            lists[j].Add(word);
                        }
                        returnThis.AddRange(lists);
                    }
                }
            }
            MemoizationPWP.Add(startIndex, returnThis);
            return returnThis;
        }

    }

    public class MaximumLenRepeatedSub
    {
        public int[] FirstArray { get; set; }
        public int[] SecondArray { get; set; }

        public int IndexA { get; set; } = Int32.MinValue;
        public int IndexB { get; set; } = Int32.MinValue;
        public Dictionary<string, List<int>> MemoDict { get; set; }
        public MaximumLenRepeatedSub()
        {
            
        }
        public void Algorithmn()
        {

        }

        //public List<List<int>> DFSAL(int indexA, int indexB)
        public void DFSAL(int indexA, int indexB)
        {
            //base case
            if (indexA >= FirstArray.Length || indexB >= SecondArray.Length)
            {
                return;
            }

            var (valA, valB) = (FirstArray[indexA], SecondArray[indexB]);
            //var atThisindex = new List<List<int>>();


            if (MemoDict.ContainsKey($"{indexA}, {indexB}"))
            {
                return;
            }
            if (IndexA != Int32.MinValue && IndexB != Int32.MinValue
                                         && valA != valB)
            {
                //Memoize things here. 
                var listFormemoize = new List<int>();
                while (IndexA < indexA)
                {
                    listFormemoize.Add(FirstArray[indexA]);
                    MemoDict.Add($"{indexA},{indexB}", new List<int>(listFormemoize));
                    IndexA += 1;
                    IndexB += 1;
                }
                IndexA = Int32.MinValue;
                IndexB = Int32.MinValue;
            }

            if (valB == valA)
            {
                IndexA = indexA;
                IndexB = indexB;
                DFSAL(indexA + 1, indexB + 1);
            }
            else
            {
                MemoDict.Add($"{indexA}, {indexB}", null);
                //change left
                DFSAL(indexA + 1, indexB);
                //change right
                DFSAL(indexA, indexB + 1);


            }
        }
    }
}
