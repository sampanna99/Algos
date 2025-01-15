using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace AlgorithsPractise.LeetCode_Eric.Phase4._2ndTime
{
    public class Search
    {

        public void Algorithmn()
        {
            var dsfa = ("a", "d");

            var ew = Convert.ToInt32('1');

            var stack = new Stack<string>();
            stack.Push("da");
            stack.Push("da1");
            var stack2 = new Stack<string>(stack);
            var lis = stack.ToArray();
            var newLis = new List<string>(stack);
            newLis.Add("dsa");
            newLis.Add("dsa1");
            newLis.Add("dsa2");
            newLis.RemoveAt(newLis.Count);
            newLis[^1] = "dfw";

            IList<IList<int>> fw = new List<IList<int>>();
            //IList<IList<int>> fw = new List<IList<int>>();

            fw.Add(new int[4]);
            List<int[]> fse = new List<int[]>();
            fse.Add(new int[5]);
            var sa = int.Parse('1'.ToString());
            var sa1 = Convert.ToInt32('2');
            var list = new String[]{"sdfa"};
            var hash = new HashSet<string>(list);
        }
    }

    public class NumberOfIslands
    {
        public int[,] MatrixGiven { get; set; }
        public HashSet<string> VisitedOnes { get; set; }
        //private const string Language = "ds";
        public NumberOfIslands()
        {
            
        }

        public void Algorithmn()
        {
            //foreach island place
            var (row, col) = (MatrixGiven.GetLength(0), MatrixGiven.GetLength(1));
            var total = 0;
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    var rowCol = $"{row}, {col}";
                    if (!VisitedOnes.Contains(rowCol) && MatrixGiven[row,col] == 1)
                    {
                        total += 1;
                    }
                }
            }
        }

        private void DFS(int row, int col)
        {
            //base case
            var (rowR, colR) = (MatrixGiven.GetLength(0), MatrixGiven.GetLength(1));
            if (row >= rowR || col >= colR)
            {
                return;
            }


            var valueHere = MatrixGiven[row, col];
            if (valueHere == 0)
            {
                return;
            }

            VisitedOnes.Add($"{row}, {col}");

            var (rP, rM, cP, cM) = (row + 1, row - 1, col + 1, col - 1);

            DFS(rP,col);
            DFS(rM,col);
            DFS(row,cP);
            DFS(row, cM);
        }
    }

    public class DistinctIslands
    {
        public int[,] GivenMatrix { get; set; }
        public HashSet<string> HashOfAll { get; set; }
        public HashSet<string> Visited { get; set; }
        public Tuple<int, int> BaseCase { get; set; }
        public StringBuilder ValueToAddHash { get; set; }
        public DistinctIslands()
        {
            ValueToAddHash = new StringBuilder();
        }

        public void Algorithmn()
        {
            var (rows, colums) = (GivenMatrix.Length, GivenMatrix.Length);
            
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < colums; j++)
                {
                    var thisOne = $"{i},{j}";
                    if (!Visited.Contains(thisOne))
                    {
                        //Go over left right up and down
                        BaseCase = new Tuple<int, int>(i, j);
                        DFS(i,j);
                        HashOfAll.Add(ValueToAddHash.ToString());
                        ValueToAddHash.Clear();
                    }
                }
            }
        }

        private void DFS(int row, int column)
        {
            //base case
            
            //check if in Visited

            //
            var valueHere = GivenMatrix[row, column];
            if (valueHere != 1)
            {
                return;
            }

            var (rP, rM, cP, cM) = (row + 1, row - 1, column + 1, column - 1);

            var valHere = $"{row},{column}";
            Visited.Add(valHere);
            var (rV, cV) = (BaseCase.Item1 - row, BaseCase.Item2 - column);
            ValueToAddHash.Append($"{rV}, {cV}");

            DFS(rP, column);
            DFS(rM, column);
            DFS(row, cP);
            DFS(rP, cM);
        }
    }


    //Better
    public class SurroundedRegions
    {
        public string[,] GivenMatrix { get; set; }
        public List<Tuple<int, int>> ConvertTheseToX { get; set; }
        public Dictionary<string, bool> AlreadyVisited { get; set; }
        public SurroundedRegions()
        {
            
        }

        public void Algorithmn()
        {
            //go from left to right all of it

            var (rows, columns) = (GivenMatrix.GetLength(0), GivenMatrix.GetLength(1));
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    var valueHere = GivenMatrix[i, j];
                    if (valueHere == "O")
                    {
                        var canBeconverted =CanChangeDFS(i, j);

                        if (canBeconverted)
                        {
                            foreach (var tuple in ConvertTheseToX)
                            {
                                GivenMatrix[tuple.Item1, tuple.Item2] = "X";
                            }
                        }
                        
                    }
                }
            }
        }

        private bool CanChangeDFS(int row, int col)
        {
            var (rows, columns) = (GivenMatrix.GetLength(0), GivenMatrix.GetLength(1));
            //base case. I think would never hit
            if (row >= rows || col >= columns)
            {
                return false;   
            }

            var key = $"{row},{col}";

            if (AlreadyVisited.ContainsKey(key))
            {
                return AlreadyVisited[key];
            }
            var valueHere = GivenMatrix[row, col];
            //when it's value is X
            if (valueHere == "X")
            {
                return true;
            }

            //when the value is O. Go 4 dir
            //check if it's the edge;
            if (row >= rows - 1 || col >= columns - 1)
            {
                AlreadyVisited[key] = false;
                return false;
            }
            ConvertTheseToX.Add(Tuple.Create(row, col));
            var (rP, rM, cP, cM) = (row + 1, row - 1, col + 1, col - 1);
            var rPR =  CanChangeDFS(rP, col);
            var rPM = CanChangeDFS(rM, col);
            var cPR = CanChangeDFS(row, cP);
            var cPM = CanChangeDFS(row, cM);
            var returnThis = false;

            if (rPM && rPR && cPR && cPM)
            {
                returnThis = true;
            }


            AlreadyVisited.Add(key, returnThis);
            return returnThis;
        }
    }

    //myself
    public class WordLadder
    {
        public string[] GivenStrings { get; set; }
        public string StartString { get; set; }
        public string EndString { get; set; }

        public bool IsPossible { get; set; } = false;
        public HashSet<string> GivenStringHash { get; set; }
        public void Algorithmn()
        {
            //var charArr = StartString.ToCharArray();
            
            //Hash all given array of strings
            foreach (var givenString in GivenStrings)
            {
                GivenStringHash.Add(givenString);
            }
            //change a char and hash it.
            DFS(StartString, new HashSet<string>());
        }

        private void DFS(string checkThisString, HashSet<string> previouslyUsed)
        {
            //base case
            if (checkThisString == EndString)
            {
                IsPossible = true;
                return;
            }

            if (IsPossible)
            {
                return;
            }

            var lengthOfStr = checkThisString.Length;
            for (int i = 0; i < lengthOfStr; i++)
            {
                //chage the value at ith index and DFS
                var iPlus = i + 1;
                for (int j = 'a'; j <= 'z'; j++)
                {
                    var newString = checkThisString[0..iPlus] + j + checkThisString[iPlus..lengthOfStr];

                    if (GivenStringHash.Contains(newString) && !previouslyUsed.Contains(newString))
                    {
                        previouslyUsed.Add(newString);
                        DFS(newString, previouslyUsed);
                        previouslyUsed.Remove(newString);
                    }
                }
            }
        }
    }

    public class WordLadderAgain
    {
        public string[] GivenWords { get; set; }
        public string StartString { get; set; }
        public string EndString { get; set; }
        public HashSet<string> GivenWordHash { get; set; }
        public HashSet<string> PatternHash { get; set; }
        public WordLadderAgain()
        {
            GivenWordHash = new HashSet<string>();
            PatternHash = new HashSet<string>();
        }
        public IList<string> LetterCombinsations(string digits)
        {
            //var ans = new List<string>();
            var ans = new string[4];

            return ans;
        }
        public void Algorithmn()
        {

            //take care of what level it is.

            //have a hash of GivenWords
            foreach (var givenWord in GivenWords)
            {
                GivenWordHash.Add(givenWord);
            }

            //from start Add to the queue that could be changed after replacing one char
            var queue = new Queue<string>();
            queue.Enqueue(StartString);

            var length = queue.Count;
            var numberOfsteps = 0;
            while (queue.Count > 0)
            {
                numberOfsteps += 1;
                //go over the queue until that length and do the same as above 
                for (int i = 0; i < length; i++)
                {
                    var deque = queue.Dequeue();
                    if (deque == EndString)
                    {
                        break;
                    }
                    //Now find all the words from that hash ny removing a character and add it to the queue
                    AddToQueue(queue, deque);
                }
                length = queue.Count;
            }
            //when found return
        }

        private void AddToQueue(Queue<string> queue, string stringToCheck)
        {
            //Now change a character and add it to the queue and remove from the hash as well.
            var length = stringToCheck.Length;
            for (int i = 0; i < stringToCheck.Length; i++)
            {
                //Ignore things at i
                var iPlus = i + 1;
                var pattern = stringToCheck[i..iPlus] + "*" + stringToCheck[iPlus..length];
                //find from the hash;

                var copyOfHash = new HashSet<string>(GivenWordHash);
                foreach (var eachHash in copyOfHash)
                {
                    //remove at the ith index
                    var patternEachWordHash = eachHash[i..iPlus] + "*" + 
                                              stringToCheck[iPlus..length];
                    if (patternEachWordHash == pattern)
                    {
                        queue.Enqueue(eachHash);
                        GivenWordHash.Remove(eachHash);
                    }
                }
            }
        }


    }

    public class SolutionFindAllConcatenatedWordsInADict
    {

        public IList<string> Answers { get; set; }
        public HashSet<string> Hashes { get; set; }
        public IList<string> FindAllConcatenatedWordsInADict(string[] words)
        {
            //hash the given things
            Hashes = new HashSet<string>(words);
            Answers = new List<string>();
            // break on each letter
            foreach (var item in words)
            {
                var value = DFS(item, 0);
                if (value) Answers.Add(item);
            }
            //left part (also right part) if it's in the hash excluding the iterating word then add to the list
            return Answers;
        }

        private bool DFS(string word, int startInd)
        {
            //base case;
            var wordLength = word.Length;
            if (startInd >= wordLength)
            {
                return true;
            }

            var returnVal = false;
            for (int i = startInd; i < wordLength; i++)
            {
                //split it after each i
                var iPlus = i + 1;
                var leftWord = word[startInd..iPlus];
                if (leftWord != word && Hashes.Contains(leftWord))
                {
                    //go right
                    var rightWord = word[iPlus..];
                    var righty = DFS(word, iPlus);
                    // var righty = DFS(rightWord,iPlus);

                    if (righty)
                    {
                        //Now add it to the list. Only if the word is in the hash.
                        // if(Hashes.Contains(word)){
                        //     Answers.Add(word);
                        // }
                        returnVal = true;
                        break;
                    }
                }
            }
            return returnVal;
        }
    }



    public class SolutionAccountsMerge
    {
        private int[] arry;
        private IList<IList<string>> _accounts;
        public IList<IList<string>> AccountsMerge(IList<IList<string>> accounts)
        {
            //each email in account points to an index of the array; do this for all
            //Also have the same number of array for disjoint info
            var length = accounts.Count;
            _accounts = accounts;
            arry = new int[length];
            Array.Fill(arry, -1);
            var dict = new Dictionary<string, int>();

            for (int j = 0; j < length; j++)
            {
                // go through each email;
                var total = accounts[j];
                for (int i = 0; i < total.Count; i++)
                {
                    if (i == 0)
                    {
                        continue;
                    }
                    if (dict.ContainsKey(total[i])) //total i means the memail
                    {
                        //that means do the disjoint magic here
                        var val = dict[total[i]];
                        DisjointUnion(val, j);
                    }
                    else
                    {
                        dict.Add(total[i], j);
                    }
                }
            }
            //Now go through the array and Findthat have -ve and Merge;
            //foreach arry while merging oldIndex --> newIndex;
            var arryL = arry.Length;
            var newAccount = new List<HashSet<string>>();
            var oldToNew = new Dictionary<int, int>();
            var newToOld = new Dictionary<int, int>();

            for (int i = 0; i < arryL; i++)
            {
                var valHere = arry[i];
                var realPar = i;
                if (valHere >= 0)
                {
                    realPar = FindParent(arry, i);
                }
                if (oldToNew.ContainsKey(realPar))
                {
                    var findWhichOne = oldToNew[realPar]; //gives you index of new List
                    AddToTheListFromOld(i, newAccount[findWhichOne]);
                }
                else
                {
                    //add it and map it
                    oldToNew.Add(realPar, newAccount.Count);
                    newToOld.Add(newAccount.Count, realPar);
                    var hash = new HashSet<string>();
                    newAccount.Add(hash);
                    AddToTheListFromOld(i, hash);
                }
            }
            // so now newAccount go over each and convert them into list
            var actualNewAccounts = new List<IList<string>>();
            // foreach(var account in newAccount){
            //     var each = new List<string>(account);
            //     each.Sort();
            //     actualNewAccounts.Add(each);
            // }
            for (int i = 0; i < newAccount.Count; i++)
            {
                var findName = _accounts[newToOld[i]][0];
                var each = new List<string> { findName };
                var each1 = new List<string>(newAccount[i]);
                // each1.Sort();
                QuickSort(0, each1.Count - 1, each1);
                each.AddRange(each1);
                actualNewAccounts.Add(each);
            }
            return actualNewAccounts;
        }

        private void AddToTheListFromOld(int oldInd, HashSet<string> inThisList)
        {
            var valsAtOld = _accounts[oldInd];

            for (int i = 1; i < valsAtOld.Count; i++)
            {
                inThisList.Add(valsAtOld[i]);
            }
        }
        private void DisjointUnion(int original, int newFound) //Index of E and itself
        {

            ////think about when the original also points to the other one;
            //var totalVal = arry[newFound];
            //var absVal = Math.Abs(totalVal);

            //var totalValO = arry[original];

            //var (realOriginal, index) = (totalValO, original);

            //while (realOriginal > 0)
            //{
            //    index = realOriginal;
            //    realOriginal = arry[realOriginal];
            //}
            //var absValO = Math.Abs(realOriginal);

            ////could union on the big one but for the sake just union on original one;
            //var totalRank = absVal + absValO;
            //arry[newFound] = index;
            //arry[index] = -totalRank;
            var first =FindParent(arry, original);
            var second = FindParent(arry, newFound); //could be itself;
            arry[newFound] = first;
            arry[second] = first;
        }
        private int FindParent(int[] array, int index)
        {
            var valHere = array[index];
            if (valHere < 0)
            {
                return index;
            }
            //else
            //{
            //    //do a while loop

            //    return valHere;
            //}

            while (valHere >= 0)
            {
                index = valHere;

                valHere = array[valHere];

            }

            return index;
        }


        private void QuickSort(int start, int end, List<string> givenStrings)
        {
            //base case;
            if (end <= start)
            {
                return;
            }

            var partitionInd = FindPartition(start, end, givenStrings);
            QuickSort(start, partitionInd - 1, givenStrings);
            QuickSort(partitionInd + 1, end, givenStrings);
        }

        private int FindPartition(int start, int end, List<string> givenStrings)
        {
            var lastOne = givenStrings[end];
            var (stInd, partInd) = (start, start);
            while (stInd < end)
            {
                //check if this is smaller than end. If yes, partInd +1 and swap stInd with partition
                var isSmaller = IsSmaller(givenStrings[stInd], givenStrings[end]);
                if (isSmaller)
                {
                    (givenStrings[stInd], givenStrings[partInd]) = (givenStrings[partInd], givenStrings[stInd]);
                    partInd += 1;
                }
                stInd += 1;
            }
            //last and partition Swap
            (givenStrings[end], givenStrings[partInd]) = (givenStrings[partInd], givenStrings[end]);
            return partInd;
        }
        private bool IsSmaller(string stringToCheck, string toCheckWith)
        {
            var (first, second) = (0, 0);
            var isSmaller = true;

            while (first < stringToCheck.Length && second < stringToCheck.Length)
            {
                var (valF, valS) = ((int)stringToCheck[first], (int)toCheckWith[second]);
                if (valF < valS)
                {
                    break;
                }
                else if (valF > valS)
                {
                    isSmaller = false;
                }
                first += 1;
                second += 1;
            }
            return isSmaller;
        }

    }

    public class SolutionSudokuDamnWorks
    {
        private bool _isSolved;
        private char[][] _board;
        public void SolveSudoku(char[][] board)
        {
            _isSolved = false;
            _board = board;
            //Go through each column and row make sure it's good
            //3* 3 grid on 9 * 9
            // on above, 0-3 0-3, Find the rows aka 0 * 3 + 0 to 0*3 + 2; other ex: 1*3 + 0 -- 1*3 + 2;

            //true for rows false for columns;
            // CheckRowsAndColums(board, true);
            // CheckRowsAndColums(board, false);

            // for(int i = 0; i < 3; i++){
            //     for (j= 0; j<3; j++){
            //         var validate = ValidateTheMethod(board, i, j);
            //         if(!validate){
            //             break;
            //         }
            //     }
            // }


            //Real solution.
            // Find each numbner that could go in there. pass that in and move on.
            //For each number  
            //if no number could go in
            BackTrack(0, 0);
        }
        private void BackTrack(int row, int col)
        {
            IList<IList<string>> da = new List<IList<string>>();
            var aa = new int[3][]; //how many in the main
            var returnThis = true;
            for (int i = row; i < 9; i++)
            {
                for (int j = col; j < 9; j++)
                {
                    var valHere = _board[i][j];
                    if (valHere == '.')
                    {
                        //what if there aren't no numbers to put.
                        var allPossibleNums = FindAllPossibleNums(i, j);
                        if (allPossibleNums.Count == 0)
                        {
                            returnThis = false;
                            break;
                        }
                        //tried all and none of them work.
                        var triedAllAndPutOne = false;
                        foreach (var eachNum in allPossibleNums)
                        {
                            //fill with that num and Backtrack
                            _board[i][j] = eachNum;
                            triedAllAndPutOne = true;
                            BackTrack(i, j + 1);
                            if (!_isSolved)
                            {
                                _board[i][j] = '.';
                                triedAllAndPutOne = false;
                            }
                            else
                            {
                                break;
                            }
                        }
                        if (!triedAllAndPutOne)
                        {
                            returnThis = false;
                            break;
                        }
                        if (_isSolved)
                        {
                            break;
                        }
                    }
                }

                if (_isSolved || !returnThis)
                {
                    break;
                }

                col = 0;
            }
            if (returnThis)
            {
                _isSolved = true;
            }
            // return returnThis;
        }
        private HashSet<char> FindAllPossibleNums(int row, int col)
        {
            var hashchar = new HashSet<char>();
            for (int i = 1; i <= 9; i++)
            {
                hashchar.Add(Convert.ToChar(i.ToString()));
            }
            RemoveFromRowOrCol(row, col, hashchar, true);
            RemoveFromRowOrCol(row, col, hashchar, false);
            //do the 3 by 3 grid
            RemoveFromThreeByThree(row, col, hashchar);
            return hashchar;
        }
        private void RemoveFromRowOrCol(int row, int col, HashSet<char> hash, bool fromRow)
        {
            for (int i = 0; i < 9; i++)
            {
                var val = '.';
                if (fromRow)
                {
                    val = _board[row][i];
                }
                else
                {
                    val = _board[i][col];
                }
                if (val != '.')
                {
                    if (hash.Contains(val))
                    {
                        hash.Remove(val);
                    }
                }
            }
        }
        private void RemoveFromThreeByThree(int row, int col, HashSet<char> hash)
        {
            //find where does it fit in another 3* 3 
            var (multR, multC) = (row / 3, col / 3);
            var (rowS, rowE, colS, colE) = (multR * 3 + 0, multR * 3 + 2, multC * 3 + 0, multC * 3 + 2);
            for (int i = rowS; i <= rowE; i++)
            {
                for (int j = colS; j <= colE; j++)
                {
                    var valH = _board[i][j];
                    if (valH != '.' && hash.Contains(valH))
                    {
                        hash.Remove(valH);
                    }
                }
            }
        }
    }

    public class SolutionNQueenWorks
    {
        
        private int _totalNum;
        private IList<IList<string>> _answers;
        public IList<IList<string>> SolveNQueens(int n)
        {
            //put on a 0-n // 0-n
            _totalNum = n;
            _answers = new List<IList<string>>();
            DFS(0, new Stack<Tuple<int, int>>());
            //var ab = _answers ?? new List<IList<string>>() ?? null;

            return _answers;
        }

        private void DFS(int row, Stack<Tuple<int, int>> allPrevs)
        {
            //if the row is n-1; then found
            if (row >= _totalNum)
            {
                var newLis = new List<Tuple<int, int>>(allPrevs);
                var listOfStr = new List<string>();

                for (var k = newLis.Count - 1; k >= 0; k--)
                {
                    var (r, c) = (newLis[k].Item1, newLis[k].Item2);
                    StringBuilder strToAdd = new StringBuilder();
                    for (int i = 0; i < _totalNum; i++)
                    {
                        if (i == c)
                        {
                            strToAdd.Append("Q");
                        }
                        else
                        {
                            strToAdd.Append(".");
                        }
                    }
                    var actualStr = strToAdd.ToString();
                    listOfStr.Add(actualStr);
                }
                // foreach(var eachO in newLis){
                //     var (r,c) = (eachO.Item1, eachO.Item2);
                //     StringBuilder strToAdd = new StringBuilder();
                //     for(int i = 0; i< _totalNum; i++){
                //         if(i == c){
                //             strToAdd.Append("Q");
                //         }else{
                //             strToAdd.Append(".");
                //         }
                //     }
                //     var actualStr = strToAdd.ToString();
                //     listOfStr.Add(actualStr);
                // }
                _answers.Add(listOfStr);
            }
            var allPrevList = new List<Tuple<int, int>>(allPrevs);
            var allFeasable = AllColumnsThatIsFeasable(row, allPrevList);
            foreach (var eachIn in allFeasable)
            {
                var column = eachIn;
                allPrevs.Push(new Tuple<int, int>(row, column));
                DFS(row + 1, allPrevs);
                allPrevs.Pop();
            }
        }
        // private HashSet<int> AllColumnsThatIsFeasable(int row, List<Tuple<int, int>> allPrevs){
        //     var allFeasable = new HashSet<int>(Enumerable.Range(0, _totalNum).ToList());
        //     //remove colmns
        //     foreach(var each in allPrevs){
        //         var (rowH, colH) = (each.Item1, each.Item2);
        //         var (add, subtract) = (rowH + colH, Math.Abs(colH-rowH));
        //         if(allFeasable.Contains(colH))allFeasable.Remove(colH);
        //         if(allFeasable.Contains(add))allFeasable.Remove(add);
        //         if(allFeasable.Contains(subtract))allFeasable.Remove(subtract);
        //     }   

        //     //now for that row fo over each hash;
        //     var newList = new HashSet<int>(allFeasable);
        //     foreach(var val in newList){
        //         //row that and column
        //         var diff = Math.Abs(val - row);
        //         var sum = Math.Abs(val + row);
        //         if(diff < _totalNum && !allFeasable.Contains(diff))
        //         {
        //                 //that meas it has been removed;
        //                 if(allFeasable.Contains(val))allFeasable.Remove(val);
        //         }
        //         if(sum < _totalNum && !allFeasable.Contains(sum)){
        //                 //that meas it has been removed;
        //             if(allFeasable.Contains(val))allFeasable.Remove(val);
        //         }
        //     }

        //     return allFeasable;
        // }
        private HashSet<int> AllColumnsThatIsFeasable(int row, List<Tuple<int, int>> allPrevs)
        {
            var allFeasable = new HashSet<int>(Enumerable.Range(0, _totalNum).ToList());

            var dontAddSubs = new HashSet<int>();
            var dontAddSubs2 = new HashSet<int>();

            foreach (var each in allPrevs)
            {
                var (rowH, colH) = (each.Item1, each.Item2);
                var (add, subtract) = (rowH + colH, colH - rowH);
                //   var (add, subtract) = (rowH + colH, Math.Abs(colH - rowH));

                if (allFeasable.Contains(colH)) allFeasable.Remove(colH);
                dontAddSubs.Add(add);
                dontAddSubs2.Add(subtract);
            }
            var substitube = new HashSet<int>(allFeasable);
            foreach (var eachO in substitube)
            {
                var add = row + eachO;
                // var sub = Math.Abs(row - eachO);
                var sub = eachO - row;
                if (dontAddSubs.Contains(add)) allFeasable.Remove(eachO);
                if (dontAddSubs2.Contains(sub)) allFeasable.Remove(eachO);
            }
            return allFeasable;
        }
    }


    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;

        
    }
    /**
     * Definition for a binary tree node.
     * public class TreeNode {
     *     public int val;
     *     public TreeNode left;
     *     public TreeNode right;
     *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
     *         this.val = val;
     *         this.left = left;
     *         this.right = right;
     *     }
     * }
     */
    public class SolutionReconstructItinerary
    {
        private Dictionary<string, SortedSet<string>> _allAirports;
        private int _length;
        private List<string> ans;
        public IList<string> FindItinerary(IList<IList<string>> tickets)
        {
            _allAirports = new Dictionary<string, SortedSet<string>>();

            var totalAirp = 0;
            foreach (var eachPair in tickets)
            {
                var (first, second) = (eachPair[0], eachPair[1]);
                if (_allAirports.ContainsKey(first))
                {
                    _allAirports[first].Add(second);
                }
                else
                {
                    totalAirp += 1;
                    _allAirports[first] = new SortedSet<string>() { second };
                }
            }
            var keys = new List<string>(_allAirports.Keys);
            keys.Sort();
            _length = tickets.Count;
            ans = new List<string>();
            //Sort all in dictionary
            var anewOne = new Dictionary<string, SortedSet<string>>(_allAirports);

            //anewOne["JFK"].Remove("ATL"); //= new SortedSet<string>();

            var listw = new List<string>() { "abc", "def" };
            var newO = new List<string>(listw);
            newO.Remove("abc");

            //var newList = JsonConvert.DeserializeObject<Dictionary<string, SortedSet<string>>>
            //    (_allAirports?.ToString());

            var seriStr = JsonConvert.SerializeObject(anewOne);
            var newList = JsonConvert.DeserializeObject<Dictionary<string, SortedSet<string>>>
                (seriStr);
            //newList["JFK"].Remove("ATL");

            foreach (var key in keys)
            {
                var stc = new Stack<string>();
                stc.Push(key);
                var dfs = DFS(key, stc);
                if (dfs)
                {
                    ans.Reverse();
                    break;
                }
                _allAirports = new Dictionary<string, SortedSet<string>>(newList);
            }
            return ans;
        }

        private bool DFS(string airport, Stack<string> allAirports)
        {
            //base case;
            if (allAirports.Count == _length + 1)
            {
                ans = new List<string>(allAirports);
                return true;
            }
            //find all routes from airport
            ///thought: instead of new, could send the same instance; just make sure to remove and later add;
            var returnVal = false;
            if (!_allAirports.ContainsKey(airport)) return false;
            var getTheall = _allAirports[airport];
            var all = new List<string>(getTheall);
            foreach (var airportConn in all)
            {
                allAirports.Push(airportConn);
                getTheall.Remove(airportConn);
                var withThis = DFS(airportConn, allAirports);
                allAirports.Pop();
                // getTheall.Add()
                if (withThis)
                {
                    returnVal = true;
                    break;
                };
            }
            return returnVal;
        }
    }

    public class SolutionNetworkDelayTime
    {
        private int _NumberOfNodes;
        private int _StartNode;
        private Dictionary<int, List<Tuple<int, int>>> _AdjacencyList;
        public int NetworkDelayTime(int[][] times, int n, int k)
        {
            _NumberOfNodes = n;
            _StartNode = k;
            _AdjacencyList = new Dictionary<int, List<Tuple<int, int>>>();
            IList<IList<string>> dsa = new List<IList<string>>();
            //Create an adjacency List. Done.
            //from the start do BFS and go to all. Update the minimum array
            foreach (var item in times)
            {
                var (start, end, distance) = (item[0], item[1], item[2]);
                if (_AdjacencyList.ContainsKey(start))
                {
                    _AdjacencyList[start].Add(new Tuple<int, int>(end, distance));
                }
                else
                {
                    _AdjacencyList[start] = new List<Tuple<int, int>> { new Tuple<int, int>(end, distance) };
                }
            }
            var array = new int[n];
            Array.Fill(array, -1);
            //second in tuple is length from start node;
            var queue = new Queue<Tuple<int, int>>();
            queue.Enqueue(new Tuple<int, int>(k, 0));
            while (queue.Count > 0)
            {
                var deque = queue.Dequeue();
                //find all from that node. Special case if already visited.
                var lengthFromStart = deque.Item2;
                var node = deque.Item1;
                // if(!_AdjacencyList.ContainsKey(node)) break;
                // array[dest] = valueFromStartIncl; //maybe this one there.

                //what if there are no adjacent nodes from that
                if (array[node - 1] != -1)
                {
                    if (array[node - 1] > lengthFromStart)
                    {
                        array[node - 1] = lengthFromStart;
                    }
                }
                else
                {
                    array[node - 1] = lengthFromStart;
                }

                if (!_AdjacencyList.ContainsKey(node))
                {
                    continue;
                }
                foreach (var eachVal in _AdjacencyList[node])
                {
                    //check if already visited and if it is, only add if smaller
                    var (dest, value) = (eachVal.Item1, eachVal.Item2);
                    var valueFromStartIncl = lengthFromStart + value;
                    if (array[dest - 1] != -1)
                    {
                        if (array[dest - 1] > valueFromStartIncl)
                        {
                            array[dest - 1] = valueFromStartIncl;
                            queue.Enqueue(new Tuple<int, int>(dest, valueFromStartIncl));
                        }
                    }
                    else
                    {
                        // array[dest] = valueFromStartIncl;
                        array[dest - 1] = valueFromStartIncl;
                        queue.Enqueue(new Tuple<int, int>(dest, valueFromStartIncl));
                    }
                }
            }
            //find the minimum
            var maximum = -1;
            foreach (var eachVal in array)
            {
                if (eachVal == -1)
                {
                    maximum = -1;
                    break;
                }
                if (eachVal > maximum)
                {
                    maximum = eachVal;
                }
            }
            return maximum;
        }

    }

    public class SolutionTransformOneWordToAnother
    {
        private Dictionary<string, HashSet<string>> _parentChild;
        private Dictionary<string, HashSet<string>> _oneAway;

        private IList<string> _wordList;
        private IList<IList<string>> _ans;
        private HashSet<string> _alreadyTraversed;
        private int _totalLengthOFBig;
        private string _endWord;
        public IList<IList<string>> FindLadders(string beginWord, string endWord, IList<string> wordList)
        {
            _parentChild = new Dictionary<string, HashSet<string>>();
            _oneAway = new Dictionary<string, HashSet<string>>();

            _wordList = wordList;
            _endWord = endWord;
            _ans = new List<IList<string>>();
            //Queue for BFS
            //parent to child
            //DFS
            var queue = new Queue<string>();
            queue.Enqueue(beginWord);
            // var alreadytraversed = new HashSet<string>(){beginWord};
            _alreadyTraversed = new HashSet<string>();
            var arbitaryQ = new Queue<string>();
            var length = 0;
            var auxiliaryHashSetAlreadyT = new HashSet<string>() { beginWord };

            while (queue.Count > 0)
            {
                var deque = queue.Dequeue();
                if (deque == endWord)
                {
                    //though behind is that I don't need to find parent child once found the word. // maybe not as it wants all. may change the logic
                    //maybe breaking is fine;
                    length += 1;
                    break;
                }
                var findAll = FindAllChangableWords(deque);
                // var arbitaryQ = new Queue<string>();
                foreach (var word in findAll)
                {
                    if (_alreadyTraversed.Contains(word))
                    {
                        continue;
                    }
                    arbitaryQ.Enqueue(word);
                    // alreadytraversed.Add(word);
                    auxiliaryHashSetAlreadyT.Add(word);
                    if (_parentChild.ContainsKey(deque))
                    {
                        _parentChild[deque].Add(word);
                    }
                    else
                    {
                        _parentChild[deque] = new HashSet<string>() { word };
                    }
                }
                if (queue.Count == 0)
                {
                    length += 1;
                    _alreadyTraversed.UnionWith(auxiliaryHashSetAlreadyT);
                    auxiliaryHashSetAlreadyT.Clear();
                    queue = arbitaryQ;
                    arbitaryQ = new Queue<string>();
                    //arbitaryQ.Clear();
                }
            }
            _totalLengthOFBig = length;
            DFS(beginWord, new Stack<string>());
            //var liss = new List<string>() { "dwe", "" };
            //liss.Reverse();
            var auxiliary = new List<IList<string>>();
            foreach (var val in _ans)
            {
                auxiliary.Add(val.Reverse().ToList());
            }
            //return _ans;
            return auxiliary;
        }
        private HashSet<string> FindAstrick(string word)
        {
            if (_oneAway.ContainsKey(word))
            {
                return _oneAway[word];
            }
            var hashset = new HashSet<string>();

            for (int i = 0; i < word.Length; i++)
            {
                var iPlus1 = i + 1;
                var atIndexi = word[0..i] + "*" + word[iPlus1..];
                hashset.Add(atIndexi);
            }
            _oneAway[word] = hashset;
            return hashset;
        }
        private HashSet<string> FindAllChangableWords(string word)
        {
            var hashset = FindAstrick(word);
            // _oneAway[word] = hashset;
            var returnHash = new HashSet<string>();
            foreach (var wordG in _wordList)
            {
                if (wordG == word || _alreadyTraversed.Contains(wordG))
                {
                    continue;
                }
                // if(!hashset.Contains(wordG)){

                // }
                if (FindAstrick(wordG).Intersect(hashset).Count() > 0)
                {
                    returnHash.Add(wordG);
                }
            }
            return returnHash;
        }
        private void DFS(string word, Stack<string> prevWords)
        {
            //base case;
            var leng = prevWords.Count;
            if (leng >= _totalLengthOFBig - 1)
            {
                if (leng == _totalLengthOFBig - 1 && word == _endWord)
                {
                    prevWords.Push(word);
                    _ans.Add(new List<string>(prevWords));
                    prevWords.Pop();
                    return;
                }
                else
                {
                    return;
                }
            }

            if (!_parentChild.ContainsKey(word))
            {
                return;
            }

            var allChild = _parentChild[word];
            prevWords.Push(word);
            foreach (var wordE in allChild)
            {
                DFS(wordE, prevWords);
            }
            prevWords.Pop();
        }
    }

    public class SolutionCriticalConnections
    {
        private int[] _Low;
        private int[] _ParentNode;
        private IList<IList<int>> _Given;
        private Dictionary<int, HashSet<int>> _Adjacency;
        private int _timer;
        private IList<IList<int>> _Ans;
        private HashSet<int> _AlreadyVisited;
        public IList<IList<int>> CriticalConnections(int n, IList<IList<int>> connections)
        {
            //make sure the low is smaller or equal to be not a critical connections
            _Low = new int[n];
            _ParentNode = new int[n];
            Array.Fill(_ParentNode, -1);

            _Adjacency = new Dictionary<int, HashSet<int>>();
            _Given = connections;
            _Ans = new List<IList<int>>();
            _AlreadyVisited = new HashSet<int>();
            //Create Adjacency
            CreateAdjacency();
            //DFS
            DFS(0);
            return _Ans;
        }
        private void CreateAdjacency()
        {
            foreach (var item in _Given)
            {
                var (start, end) = (item[0], item[1]);
                if (_Adjacency.ContainsKey(start))
                {
                    _Adjacency[start].Add(end);
                }
                else
                {
                    _Adjacency[start] = new HashSet<int>() { end };
                }

                if (_Adjacency.ContainsKey(end))
                {
                    _Adjacency[end].Add(start);
                }
                else
                {
                    _Adjacency[end] = new HashSet<int>() { start };
                }
            }
        }

        //If parent shouldn't even consider
        private void DFS(int node)
        {
            //base case for already visited;
            if (_AlreadyVisited.Contains(node))
            {
                return;
            }
            _timer += 1;
            var discoveryTime = _timer;
            _Low[node] = discoveryTime;
            var all = _Adjacency[node];
            var updateTheMin = discoveryTime;
            _AlreadyVisited.Add(node);
            foreach (var item in all)
            {
                if (_ParentNode[node] == item) continue;
                if (item != 0 && _ParentNode[item] == -1)
                {
                    _ParentNode[item] = node;
                }
                DFS(item);
                //Check the Low of the item here.
                var lowOfItem = _Low[item];
                if (lowOfItem > discoveryTime)
                {
                    _Ans.Add(new List<int> { node, item });
                }
                else
                {
                    updateTheMin = Math.Min(updateTheMin, lowOfItem);
                }
            }
            _Low[node] = updateTheMin;
        }
    }
    public class SolutionPalindromeWithoutStringConversion
    {
        public bool IsPalindrome(int x)
        {
            if (x < 0) return false;
            if (x == 0) return true;
            // var lastOne = x % 10;
            // var baseNum = Math.Floor(Math.Log10(x)) + 1; //10-99 is 2; 0-9 is 1
            // if (baseNum == 1) return true;
            // var baseMinus = baseNum - 1;
            // var tenth = Math.Pow(10, baseMinus);
            // var first = x / tenth;
            var (first, lastOne) = (0, 0);
            var isTrue = true;
            var y = x;
            while (isTrue)
            {
                if (first != lastOne)
                {
                    isTrue = false;
                    break;
                }
                if (y == 0)
                {
                    break;
                }
                lastOne = y % 10;
                var baseNum = Math.Floor(Math.Log10(y)) + 1; //10-99 is 2; 0-9 is 1
                if (baseNum == 1)
                {
                    break;
                };
                var baseMinus = baseNum - 1;
                var tenth = Math.Pow(10, baseMinus);
                first = (int)(y / tenth);

                //remove first from y
                y = (int)(y - first * tenth);

                //remove last from y
                y = y / 10;

                //make sure it didn't remove more than 2 decimal points
                var baseNew = Math.Floor(Math.Log10(y));
                if ((int)(baseMinus - baseNew) > 2)
                {
                    var totalTimes = (int)(baseMinus - baseNew) - 2;
                    var normalContinue = true;
                    for (int i = 0; i < totalTimes; i++)
                    {
                        var getYOut = y % 10;
                        if (getYOut != 0)
                        {
                            normalContinue = false;
                            break;
                        }

                        y /= 10;
                    }

                    if (!normalContinue)
                    {
                        isTrue = false;
                        break;
                    }
                    
                }
            }
            return isTrue;
        }
    }

    public class SolutionLetterCasePermutation
    {
        private string _s;
        private IList<string> _ans;
        public IList<string> LetterCasePermutation(string s)
        {
            // each word change not change. if changed and not changed is the same don't do 2 DFS
            _s = s;
            _ans = new List<string>();
            DFS(0, new StringBuilder());
            return _ans;
        }

        private void DFS(int startIn, StringBuilder st)
        {
            //base case
            if (startIn >= _s.Length)
            {
                _ans.Add(st.ToString());
                return;
            }

            //chanbging it not changing it
            var val = _s[startIn].ToString();
            var valU = val.ToUpper();
            if (val != valU)
            {
                var nc = new StringBuilder();
                nc.Append(st);
                nc.Append(valU);
                DFS(startIn + 1, nc);
            }
            st.Append(val);
            DFS(startIn + 1, st);
        }
    }
    public class SolutionAccountsMerge2
    {
        private Dictionary<string, int> _emailToInd;
        private IList<IList<string>> _accounts;
        private int[] _Union;
        private int _length;
        public IList<IList<string>> AccountsMerge(IList<IList<string>> accounts)
        {
            //each email to an index dictionary
            //if email already in  union
            // at the end one go find which are related and another to put them in an aswer
            _accounts = accounts;
            _length = accounts.Count;
            _Union = new int[_length];
            Array.Fill(_Union, -1);
            _emailToInd = new Dictionary<string, int>();
            CreateDictionary();
            //Now find the related index and add to dict
            var ansDict = new Dictionary<int, SortedSet<string>>();

            for (int i = 0; i < _length; i++)
            {
                var value = _Union[i];
                var index = i;
                if (value > 0)
                {
                    index = FindIndex(i);
                }
                if (!ansDict.ContainsKey(index))
                {
                    ansDict[index] = new SortedSet<string>();
                }
                var leng = _accounts[i].Count;
                for (int j = 0; j < leng; j++)
                {
                    if (j == 0)
                    {
                        // && ansDict[index].Count == 0
                        // ansDict[index
                        continue;
                    }
                    ansDict[index].Add(_accounts[i][j]);
                }
            }
            //now answer
            var ans = new List<IList<string>>();
            //may be do it better 
            foreach (var keyVal in ansDict)
            {
                var (k, v) = (keyVal.Key, keyVal.Value);
                var realA = new List<string>(v);
                realA.Insert(0, _accounts[k][0]);
                ans.Add(realA);
            }
            return ans;
        }
        private int FindIndex(int index)
        {
            var valueAtind = _Union[index];
            while (valueAtind > 0)
            {
                index = valueAtind;
                valueAtind = _Union[index];
            }
            return index;
        }
        private void CreateDictionary()
        {
            for (int i = 0; i < _length; i++)
            {
                var eachA = _accounts[i];
                var len = eachA.Count;
                for (int j = 0; j < len; j++)
                {
                    if (j == 0) continue;
                    var email = eachA[j].ToString();
                    if (_emailToInd.ContainsKey(email))
                    {
                        //Union it
                        UnionIt(_emailToInd[email], i);
                    }
                    else
                    {
                        _emailToInd[email] = i;
                    }
                }
            }
        }
        private void UnionIt(int alreadyAdd, int newO)
        {
            if (alreadyAdd == newO) return;
            //Find the actual index;
            var allValA = FindTheRootParAndInd(alreadyAdd);
            //todo: what if both points to sth else; both positive;
            var allValB = FindTheRootParAndInd(newO);
            //newInd parent is the variable ind;
            var (bigIndex, smallIndex) = allValA.Item1 < allValB.Item1 ? (allValA.Item2, allValB.Item2) : (allValB.Item2, allValA.Item2);
            var total = Math.Abs(allValA.Item1) + Math.Abs(allValB.Item1);
            _Union[smallIndex] = bigIndex;
            _Union[bigIndex] = -total;
        }
        private (int, int) FindTheRootParAndInd(int alreadyAdd)
        {
            var (valueOfAl, ind) = (_Union[alreadyAdd], alreadyAdd);
            while (valueOfAl > 0)
            {
                ind = valueOfAl;
                valueOfAl = _Union[valueOfAl];
            }
            return (valueOfAl, ind);
        }
    }
    public class SolutionLongestConsecutive
    {
        public int LongestConsecutive(int[] nums)
        {
            //IList<IList<string>> daw = new List<IList<string>>()
            var hashSet = new HashSet<int>(nums);
            var total = 0;
            foreach (var value in nums)
            {
                //check if it could be the start one
                if (hashSet.Contains(value - 1))
                {
                    continue;
                }
                // var isStart = true;
                total = 1;
                var val = value;
                while (true)
                {
                    val += 1;
                    if (hashSet.Contains(val))
                    {
                        total += 1;
                    }
                    else
                    {
                        break; 
                    }
                }
            }
            return total;
        }
    }
    public class SolutionSetZeroes
    {
        public void SetZeroes(int[][] matrix)
        {
            // first column represents all that needs to be 0
            var (row, column) = (matrix.Length, matrix[0].Length);
            var firstrowZerod = 1;

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    var val = matrix[i][j];
                    if (i == 0 && val == 0)
                    {
                        firstrowZerod = 0;
                        continue;
                    }
                    if (val == 0)
                    {
                        //column and row
                        matrix[0][j] = 0;
                        matrix[i][0] = 0;
                    }
                }
            }


            for (int i = 1; i < row; i++)
            {
                var valueAtZ = matrix[i][0];
                if (valueAtZ == 0)
                {
                    for (int j = 1; j < column; j++)
                    {
                        matrix[i][j] = 0;
                    }
                }
            }
            //this is column
            for (int j = 0; j < column; j++)
            {
                var valueAtZ = matrix[0][j];
                if (valueAtZ == 0)
                {
                    for (int k = 0; k < row; k++)
                    {
                        matrix[k][j] = 0;
                    }
                }
            }

            //for first row
            if (firstrowZerod == 0)
            {
                //first row should be 0
                for (int i = 0; i < column; i++)
                {
                    // matrix[i][0] = 0;
                    matrix[0][i] = 0;
                }
            }
        }
    }
    public class SolutionMyAtoiChatGpt
    {
        public int MyAtoi(string s)
        {
            if (string.IsNullOrEmpty(s)) return 0;

            int i = 0;
            int total = 0;
            int sign = 1;
            int INT_MAX = 2147483647;
            int INT_MIN = -2147483648;

            // Remove leading whitespaces
            while (i < s.Length && s[i] == ' ')
                i++;

            // Handle sign
            if (i < s.Length && (s[i] == '+' || s[i] == '-'))
            {
                sign = (s[i] == '-') ? -1 : 1;
                i++;
            }

            // Convert number and avoid non-numeric characters
            while (i < s.Length)
            {
                int digit = s[i] - '0';
                if (digit < 0 || digit > 9) break;

                // Check for overflow or underflow
                if (total > (INT_MAX / 10) || (total == INT_MAX / 10 && digit > INT_MAX % 10))
                {
                    return sign == 1 ? INT_MAX : INT_MIN;
                }

                total = total * 10 + digit;
                i++;
            }

            return total * sign;
        }
    }

    public class SolutionUpdateMatrix
    {
        public int[][] UpdateMatrix(int[][] mat)
        {
            //first loop
            var (row, col) = (mat.Length, mat[0].Length);
            var queue = new Queue<Tuple<int, int>>();
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    var valH = mat[i][j];
                    if (valH == 0)
                    {
                        var tuple = new Tuple<int, int>(i, j);
                        queue.Enqueue(tuple);
                    }
                    else
                    {
                        mat[i][j] = -1;
                    }
                }
            }
            //Now deque and go all directions
            while (queue.Count > 0)
            {
                var dequeue = queue.Dequeue();
                var (r, c) = (dequeue.Item1, dequeue.Item2);
                var valAtRC = mat[r][c];
                var valToAdd = valAtRC + 1;
                //go all dir
                var (rP, cP, rM, cM) = (r + 1, c + 1, r - 1, c - 1);
                if (rP < row)
                {
                    CheckAndUpdate(rP, c, mat, valToAdd, queue);
                    // var valH = mat[rP][c];
                    // if(valH < 0){
                    //     // update it with 1
                    //     mat[rp][c] = valToAdd;
                    //     queue.Enqueue(new Tuple<int, int>(rP, c));
                    // }else if(valH > 0){
                    //     mat[rp][c] = Math.Min(mat[rp][c], valToAdd);
                    //     queue.Enqueue(new Tuple<int, int>(rP, c));
                    // }
                }
                if (rM >= 0)
                {
                    CheckAndUpdate(rM, c, mat, valToAdd, queue);
                }

                if (cM >= 0)
                {
                    CheckAndUpdate(r, cM, mat, valToAdd, queue);
                }
                if (cP < col)
                {
                    CheckAndUpdate(r, cP, mat, valToAdd, queue);
                }
            }
            return mat;
        }

        private void CheckAndUpdate(int row, int col, int[][] mat, int valToAdd, Queue<Tuple<int, int>> queue)
        {
            var rP = row;
            var c = col;
            var valH = mat[rP][c];
            if (valH == 0) return;
            if (valH < 0)
            {
                // update it with 1
                mat[rP][c] = valToAdd;
                queue.Enqueue(new Tuple<int, int>(rP, c));
            }
            else if (valH > 0)
            {

                var min = Math.Min(valH, valToAdd);
                if (min < valH)
                {
                    mat[rP][c] = Math.Min(valH, valToAdd);
                    queue.Enqueue(new Tuple<int, int>(rP, c));
                }
            }
        }
    }
    public class SolutionCombinationSum2
    {
        private int[] _candidates;
        private IList<IList<int>> _ans;
        public IList<IList<int>> CombinationSum2(int[] candidates, int target)
        {
            Array.Sort(candidates);
            _candidates = candidates;
            _ans = new List<IList<int>>();
            //DFS and take not take but skip the same values
            var stackTS = new Stack<int>();
            DFS(0, stackTS, target);
            // DFS(1, stackTS, target);

            return _ans;
        }

        private void DFS(int index, Stack<int> values, int sumToMake)
        {
            //base case
            if (sumToMake == 0)
            {
                _ans.Add(new List<int>(values.Reverse()));
                return;
            }

            if (sumToMake < 0 || index >= _candidates.Length)
            {
                return;
            }

            var value = _candidates[index];
            var remSum = sumToMake - value;

            //Take
            values.Push(value);
            var indexToG = index + 1;
            DFS(index + 1, values, remSum);
            // DFS(indexToG, values, remSum);      

            //Not Take
            var val = _candidates.Length > indexToG ? _candidates[indexToG] : 51;
            while (val == value && val != 51)
            {
                indexToG += 1;
                val = _candidates.Length > indexToG ? _candidates[indexToG] : 51;
            }
            values.Pop();
            DFS(indexToG, values, sumToMake);
        }
    }


    public class SolutionCountOFRangeSum
    {
        private int _lower;
        private int _upper;
        private int ans;
        private int ans2;

        public int CountRangeSum(int[] nums, int lower, int upper)
        {
            //merge sort and add the sum while merging
            _lower = lower;
            _upper = upper;
            var getPrefix = PrefixSumRet(nums);
            MergeSortAlgo(getPrefix);
            return ans2;
        }

        private Int64[] PrefixSumRet(int[] arr)
        {
            var length = arr.Length;
            var ansArr = new Int64[length + 1];
            for (var i = 0; i < length; i++)
            {
                ansArr[i + 1] = ansArr[i] + arr[i];
            }
            return ansArr;
        }
        private void MergeSortAlgo(Int64[] arr)
        {
            var length = arr.Length;
            if (length == 1)
            {
                if (arr[0] >= _lower && arr[0] <= _upper)
                {
                    ans += 1;
                }
                return;
            }
            if (length == 0)
            {
                return;
            }
            var mid = length / 2;
            // var mP = mid + 1;
            var mP = mid;

            var leftarr = arr[..mP];
            var rightarr = arr[mP..];
            MergeSortAlgo(leftarr);
            MergeSortAlgo(rightarr);
            //do the logic here;

            //MergeFunction to merge to arr;
            MergeFunc(leftarr, rightarr, arr);
            UpdateAns2(leftarr, rightarr);
        }

        private void UpdateAns2(Int64[] left, Int64[] right)
        {
            foreach (var valN in left)
            {
                var lowerB = valN + _lower;
                var upperB = valN + _upper;

                //find the lower index on right
                //find the upper index on right

                var low = FindInd(right, true, lowerB);
                if (low == -1)
                {
                    continue;
                }
                var high = FindInd(right, false, upperB);
                if (high == -1)
                {
                    continue;
                }
                var total = high - low + 1;
                ans2 += total;
            }
        }
        private int FindInd(Int64[] right, bool findLow, Int64 upperOrLower)
        {
            var returnT = -1;
            var length = right.Length;
            var (low, high) = (0, length - 1);
            while (low <= high)
            {
                var mid = low + (high - low) / 2;
                var valAtM = right[mid];
                if (findLow)
                {
                    if (valAtM >= upperOrLower)
                    {
                        returnT = mid;
                        high = mid - 1;
                    }
                    else
                    {
                        low = mid + 1;
                    }
                    // if(returnT != -1 && mid < returnT){
                    //     returnT = mid;
                    // }
                }
                else
                {
                    if (valAtM <= upperOrLower)
                    {
                        returnT = mid;
                        low = mid + 1;
                    }
                    else
                    {
                        high = mid - 1;
                    }
                    // if(returnT != -1 && mid > returnT){
                    //     returnT = mid;
                    // }
                }
            }
            return returnT;
        }

        private void MergeFunc(Int64[] leftarr, Int64[] rightarr, Int64[] arr)
        {
            var (leftL, rightL) = (leftarr.Length, rightarr.Length);
            var (l, r, arV) = (0, 0, 0);
            while (l < leftL && r < rightL)
            {
                var valAtL = leftarr[l];
                var valAtR = rightarr[r];
                if (valAtL < valAtR)
                {
                    arr[arV] = valAtL;
                    l += 1;
                }
                else
                {
                    arr[arV] = valAtR;
                    r += 1;
                }
                arV += 1;
            }
            var (remaining, start) = r < rightL ? (rightarr, r) : (leftarr, l);
            var lR = remaining.Length;
            while (start < lR)
            {
                arr[arV] = remaining[start];
                arV += 1;
                start += 1;
            }
        }
    }

    public class SolutionFindMedianSorted
    {
        //Chatgpt solution
        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            // Ensure nums1 is the smaller array
            if (nums1.Length > nums2.Length)
            {
                var temp = nums1;
                nums1 = nums2;
                nums2 = temp;
            }

            int m = nums1.Length, n = nums2.Length;
            int start = 0, end = m;
            //int start = 0, end = m - 1;


            while (start <= end)
            {
                int partition1 = start + (end  - start) / 2;
                int partition2 = (m + n + 1) / 2 - partition1;

                int maxLeft1 = partition1 == 0 ? Int32.MinValue : nums1[partition1 - 1];
                int minRight1 = partition1 == m ? Int32.MaxValue : nums1[partition1];

                int maxLeft2 = partition2 == 0 ? Int32.MinValue : nums2[partition2 - 1];
                int minRight2 = partition2 == n ? Int32.MaxValue : nums2[partition2];

                if (maxLeft1 <= minRight2 && maxLeft2 <= minRight1)
                {
                    // Found the correct partition
                    if ((m + n) % 2 == 0)
                    {
                        return (Math.Max(maxLeft1, maxLeft2) + Math.Min(minRight1, minRight2)) / 2.0;
                    }
                    else
                    {
                        return Math.Max(maxLeft1, maxLeft2);
                    }
                }
                else if (maxLeft1 > minRight2)
                {
                    end = partition1 - 1;  // Move left
                }
                else
                {
                    start = partition1 + 1;  // Move right
                }
            }

            throw new ArgumentException("Input arrays are not sorted.");
        }
    }
    public class SolutionPartitionEqualSubsetSum
    {

        private int[] _nums;
        private bool[,] _knacpsackArr;

        private int FindSum()
        {
            var sum = 0;
            foreach (var nu in _nums)
            {
                sum += nu;
            }
            return sum;
        }
        public bool CanPartition(int[] nums)
        {
            _nums = nums;
            var sum = FindSum();

            if (sum % 2 == 1) return false;
            // Find sum and find half
            // do a knapsack
            var half = sum / 2;
            var length = _nums.Length;
            _knacpsackArr = new bool[length + 1, half + 1];
            FillInitial();
            var (row, column) = (_knacpsackArr.GetLength(0), _knacpsackArr.GetLength(1));
            for (var i = 1; i < row; i++)
            {
                var valueHere = _nums[i - 1];
                for (var j = 1; j < column; j++)
                {
                    //value to make is j;
                    if (valueHere > j)
                    {
                        //get it from above
                        _knacpsackArr[i, j] = _knacpsackArr[i - 1, j];
                    }
                    else
                    {
                        //if true above then true; if not
                        if (_knacpsackArr[i - 1, j])
                        {
                            _knacpsackArr[i, j] = true;
                        }
                        else
                        {
                            //subtract valuehere
                            var subtract = j - valueHere;
                            _knacpsackArr[i, j] = _knacpsackArr[i - 1, subtract];
                        }
                    }
                }
            }
            return _knacpsackArr[row - 1, column - 1];
        }
        private void FillInitial()
        {
            //when the sum is 0; when you have 0 items;
            var row = _knacpsackArr.GetLength(0);
            for (var i = 0; i < row; i++)
            {
                _knacpsackArr[i, 0] = true;
            }
        }
    }    //public class Solution
    //{
    //    public int MyAtoi(string s)
    //    {
    //        //for each string character by character check to see if it's between 0-9 akas 'val' - '0'
    //        int total = 0;
    //        var isNeg = false;
    //        var numStarted = false;
    //        foreach (var character in s)
    //        {
    //            var value = character - '0';
    //            //case for whitespace or 
    //            if (character == '-')
    //            {
    //                if (numStarted) break;
    //                isNeg = true;
    //                continue;
    //            }
    //            if (value < 0)
    //            {
    //                if (numStarted) break;
    //                continue;
    //            }
    //            if (value > 9)
    //            {
    //                break;
    //            }
    //            numStarted = true;
    //            var dsa = total * 10;
    //            total = total * 10 + value;
    //        }
    //        return isNeg ? -total : total;
    //    }
    //}
    public class SolutionFindDuplicate
    {
        public int FindDuplicate(int[] nums)
        {
            //Floyd's cycle 
            var ans = Int32.MaxValue;
            var length = nums.Length;
            var (firstP, secondP) = (nums[0], nums[0]);
            var breakk = true;
            while (breakk)
            {
                firstP = nums[firstP];
                secondP = nums[nums[secondP]];
                if (firstP == secondP)
                {
                    break;
                }
            }

            return firstP;
        }
    }
    public class SolutionAddBinary
    {
        public string AddBinary(string a, string b)
        {
            //go from right to left
            var (lenA, lenB) = (a.Length, b.Length);
            var bigOne = lenA > lenB ? lenA : lenB;
            var carry = 0;
            var ans = new StringBuilder();
            for (int i = 0; i < bigOne; i++)
            {
                var iP = i + 1;
                var valA = i < lenA ? Convert.ToInt16(a[lenA - iP].ToString()) : 0;
                var valB = i < lenB ? Convert.ToInt16(b[lenB - iP].ToString()) : 0;
                var total = valA + valB + carry;
                var location = ans.Length == 0 ? 0 : ans.Length - 1;

                if (total > 1)
                {
                    var remainder = total % 2;
                    ans.Insert(location, remainder);
                    carry = 1;
                }
                else
                {
                    ans.Insert(location, total);
                    carry = 0;
                }
            }
            if (carry != 0)
            {
                ans.Insert(0, carry);
            }
            return ans.ToString();
        }
    }
}
