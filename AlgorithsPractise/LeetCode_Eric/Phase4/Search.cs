using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace AlgorithsPractise.LeetCode_Eric.Phase4
{
    public class Search
    {
    }

    public class NumberOfIslands
    {
        public int[,] Matrix { get; set; }

        public NumberOfIslands()
        {
            //Matrix = new int[4,5];
        }

        public void Algorithmn()
        {
            //visited set
            //go until the queue is empty
            //repeat for the whole matrix
            var visitedSet = new HashSet<string>();
            var numberOfIslands = 0;
            for (int i = 0; i < Matrix.GetLength(0); i++)
            {
                for (int j = 0; j < Matrix.GetLength(1); j++)
                {
                    if (visitedSet.Contains($"{i}, {j}"))
                    {
                        continue;
                    }
                    else
                    {
                        var value = Matrix[i, j];
                        visitedSet.Add($"{i}, {j}");
                        if (value == 1)
                        {
                            numberOfIslands += 1;
                            var queue = new Queue<Tuple<int, int>>();
                            queue.Enqueue(Tuple.Create(i,j));

                            while (queue.Count > 0)
                            {
                                var deq = queue.Dequeue();
                                //go all 4 dir
                                //go left
                                var leftVal = deq.Item2 - 1;
                                if (leftVal >= 0 && !visitedSet.Contains($"{deq.Item1}, {leftVal}") &&
                                    Matrix[deq.Item1, leftVal] == 1)
                                {
                                    queue.Enqueue(new Tuple<int, int>(deq.Item1, leftVal));
                                }
                                //go right
                                var rightVal = deq.Item2 + 1;
                                if (deq.Item2 < Matrix.GetLength(1) && 
                                    !visitedSet.Contains($"{deq.Item1}, {rightVal}") &&
                                    Matrix[deq.Item1, rightVal] == 1)
                                {
                                    queue.Enqueue(new Tuple<int, int>(leftVal, deq.Item2));
                                }
                                //go top
                                var topVal = deq.Item1 - 1;
                                if (deq.Item1 >= 0 &&
                                    !visitedSet.Contains($"{topVal}, {deq.Item2}") &&
                                    Matrix[topVal, deq.Item2] == 1)
                                {
                                    queue.Enqueue(new Tuple<int, int>(topVal, deq.Item2));
                                }

                                //go down
                                var bottomVal = deq.Item1 + 1;
                                var columnVal = deq.Item2;
                                if (bottomVal < Matrix.GetLength(0) && !visitedSet.Contains
                                    ($"{bottomVal}, {columnVal}") && Matrix[bottomVal, columnVal] == 1)
                                {
                                    queue.Enqueue(new Tuple<int, int>(bottomVal, columnVal));
                                }
                            }
                        }
                    }
                }
            }
        }
    }

    public class NumberOfDistinctIslands
    {
        public int[,] Matrix { get; set; }


        public void Algorithmn()
        {
            var visitedSet = new HashSet<string>();
            var answer = new HashSet<string>();
            var (matrixRowLength, martrixColumnLength) = (Matrix.GetLength(0), Matrix.GetLength(1));
            for (int i = 0; i < Matrix.GetLength(0); i++)
            {
                for (int j = 0; j < Matrix.GetLength(1); j++)
                {
                    if (visitedSet.Contains($"{i}, {j}"))
                    {
                        continue;
                    }

                    //visitedSet.Add($"{i}, {j}");
                    if (Matrix[i,j] == 1)
                    {
                        //now this is the base
                        var queue = new Queue<Tuple<int, int>>();
                        queue.Enqueue(Tuple.Create(i, j));
                        var hashofAns = new StringBuilder();
                        while (queue.Count > 0)
                        {
                            var visitThis = queue.Dequeue();
                            var (xVal, yVal) = (visitThis.Item1, visitThis.Item2);
                            
                            hashofAns.Append($"{xVal - i}{yVal}");
                            visitedSet.Add($"{visitThis.Item1}, {visitThis.Item2}");
                            var (xvalMinusOne, yValMinusOne, xValPlusOne, yValPlusOne) = 
                                (xVal - 1, yVal - 1, xVal + 1, yVal + 1);
                            //go left
                            if (yValMinusOne >= 0 && !visitedSet.Contains($"{xVal}, {yValMinusOne}")
                                              && (Matrix[xVal, yValMinusOne] == 1))
                            {
                                queue.Enqueue(Tuple.Create(xVal, yValMinusOne));
                            }
                            //go right
                            if (yValPlusOne < martrixColumnLength 
                                && !visitedSet.Contains($"{xVal}, {yValMinusOne}")
                                                                && (Matrix[xVal, yValPlusOne] == 1))
                            {
                                queue.Enqueue(Tuple.Create(xVal, yValPlusOne));
                            }

                            //go top
                            if (xvalMinusOne <= 0
                                && !visitedSet.Contains($"{xVal}, {yValMinusOne}")
                                && (Matrix[xvalMinusOne, yVal] == 1))
                            {
                                queue.Enqueue(Tuple.Create(xvalMinusOne, yVal));
                            }

                            //go bottom
                            if (xValPlusOne < matrixRowLength
                                && !visitedSet.Contains($"{xVal}, {yValMinusOne}")
                                && (Matrix[xValPlusOne, yVal] == 1))
                            {
                                queue.Enqueue(Tuple.Create(xValPlusOne, yVal));
                            }

                        }

                        var stringofhashval = hashofAns.ToString();
                        if (!answer.Contains(stringofhashval))
                        {
                            answer.Add(stringofhashval);
                        }

                    }
                }
            }
        }
    }

    public class SurroundedRegions
    {
        public int[,] Matrix { get; set; }

        public SurroundedRegions()
        {
        }

        public void Algorithmn()
        {

            for (int i = 0; i < Matrix.GetLength(0); i++)
            {
                if (i == 0 || i == Matrix.GetLength(0) - 1)
                {
                    //all columns
                    for (int j = 0; j < Matrix.GetLength(1); j++)
                    {
                        if (Matrix[i,j] == 0)
                        {
                            Matrix[i, j] = 1;
                            DFS(i, j);
                        }
                    }
                }
                else
                {
                    //first and last columns
                    var alltoGothrough = new List<int> { 0, Matrix.GetLength(1) - 1 };
                    foreach (var eachColumn in alltoGothrough)
                    {
                        if (Matrix[i, eachColumn] == 0)
                        {
                            Matrix[i, eachColumn] = 1;
                            DFS(i, eachColumn);
                        }

                    }
                }
            }

            for (int i = 0; i < Matrix.GetLength(0); i++)
            {
                for (int j = 0; j < Matrix.GetLength(1); j++)
                {
                    if (Matrix[i, j] == 1)
                    {
                        Matrix[i, j] = 2;
                    }
                }
            }
        }

        public void DFS(int row, int column)
        {
            var (rowPlusOne, columnPlusOne, rowMinusOne, columnMinusOne, matrixCol, matrixRow) = 
                (row + 1, column + 1, row - 1, column - 1, Matrix.GetLength(1), Matrix.GetLength(0));
            //go top
            if (rowMinusOne > 0 && Matrix[rowMinusOne, column] == 0)
            {
                Matrix[rowMinusOne, column] = 1;
                DFS(rowMinusOne, column);
            }
            //go down
            if (rowPlusOne < matrixRow && Matrix[rowPlusOne, column] == 0)
            {
                Matrix[rowPlusOne, column] = 1;
                DFS(rowPlusOne, column);
            }
            //go left 
            if (columnMinusOne > 0 && Matrix[row, columnMinusOne] == 0)
            {
                Matrix[row, columnMinusOne] = 1;
                DFS(row, columnMinusOne);
            }
            //go right
            if (columnPlusOne < matrixCol && Matrix[row, columnMinusOne] == 0)
            {
                Matrix[row, columnMinusOne] = 1;
                DFS(row, columnMinusOne);
            }
        }
    }

    public class PacificAtlanticWaterFlow
    {
        public int[,] Matrix { get; set; }
        public List<string> Answer { get; set; }
        public PacificAtlanticWaterFlow()
        {
            Answer = new List<string>();
        }

        public void Algorithmn()
        {
            var pacificReach = new List<string>();
            var answer = new List<string>();

            for (int j = 0; j < 2; j++)
            {
                if (j == 0)
                {
                    for (int i = 0; i < Matrix.GetLength(1); i++)
                    {
                        Recurse(0, i, true, pacificReach);
                    }
                }
                else
                {
                    for (int i = 1; i < Matrix.GetLength(0); i++)
                    {
                        Recurse(i, 0, true, pacificReach);
                    }
                }
            }

            for (int i = 0; i < 2; i++)
            {
                if (i == 0)
                {
                    for (int j = Matrix.GetLength(0) - 1; j < 0; j--)
                    {
                        Recurse(j, Matrix.GetLength(1) - 1, true, pacificReach);
                    }
                }
                else
                {
                    for (int j = Matrix.GetLength(1) - 2; j < 0; j--)
                    {
                        Recurse(Matrix.GetLength(0) - 1, j, true, pacificReach);
                    }
                }
            }
        }

        public void Recurse(int row, int column, bool isdown, List<string> alreadyVisited)
        {
            if (alreadyVisited.Contains($"{row}, {column}") && isdown)
            {
                return;
            }

            int rowPlusOMinus;
            int columnPlusOMinus;

            if (isdown)
            {
                (rowPlusOMinus, columnPlusOMinus) = (row + 1, column + 1);
            }
            else
            {
                (rowPlusOMinus, columnPlusOMinus) = (row - 1, column - 1);
            }

            if (isdown)
            {
                alreadyVisited.Add($"{row}, {column}");
            }
            else
            {
                if (alreadyVisited.Contains($"{row}, {column}"))
                {
                    Answer.Add($"{row}, {column}");
                }
            }

            //can this row column go to each one
            var valueAtRowCol = Matrix[row, column];
            var valueAtRPOM = Matrix[rowPlusOMinus, column];
            var valueAtRCPOM = Matrix[row,columnPlusOMinus];

            if (valueAtRPOM >= valueAtRowCol)
            {
                Recurse(rowPlusOMinus, column, isdown, alreadyVisited);
            }

            if (valueAtRCPOM >= valueAtRowCol)
            {
                Recurse(row, columnPlusOMinus, isdown, alreadyVisited);
            }
        }

    }

    //https://www.youtube.com/watch?v=mIZJIuMpI2M
    //leetcode 126
    public class WordLadder
    {
        public string BeginWord { get; set; }
        public string EndWord { get; set; }
        public List<string> GivenWord { get; set; }
        public HashSet<string> AlreadyVisited { get; set; }
        public WordLadder()
        {
            AlreadyVisited = new HashSet<string>();
            GivenWord = new List<string>();
        }

        public void Algorithmn()
        {
            var queue = new Queue<string>();
            queue.Enqueue(BeginWord);
            var wordVsLevel = new Dictionary<string, int>();
            var adjacencyList = new Dictionary<string, HashSet<string>>();
            var newsetofwords = new HashSet<String>(GivenWord);
            var level = 0;
            var removeThese = new HashSet<string>();
            while (queue.Count > 0)
            {
                var deque = queue.Dequeue();
                if (!wordVsLevel.ContainsKey(deque))
                {
                    wordVsLevel.Add(deque, 0);
                }

                var olddeque = wordVsLevel[deque];
                if (olddeque != level)
                {
                    level = olddeque;
                    //remove
                    var tolist = new List<string>(removeThese);
                    foreach (var eachr in tolist)
                    {
                        newsetofwords.Remove(eachr);
                    }
                }

                var list = FindWords(newsetofwords, deque);
                adjacencyList[deque] = new HashSet<string>(list);

                var newLevel =  olddeque + 1;

                for (int i = 0; i < list.Count; i++)
                {
                    wordVsLevel.Add(list[i], newLevel);
                    queue.Enqueue(list[i]);
                    removeThese.Add(list[i]);
                }
            }
            //now dfs to find the word
            var stack = new Stack<string>();
            stack.Push(BeginWord);
            var answerstack = new Stack<string>();
            while (stack.Count > 0)
            {
                var stackP = stack.Pop();
                var fildAll = adjacencyList[stackP];

                if (fildAll == null || fildAll.Count == 0)
                {
                    
                }
                else
                {
                    answerstack.Push(stackP);
                    foreach (var f in fildAll)
                    {
                        stack.Push(f);
                    }
                }
            }
        }

        private List<string> DFS(string wordtoStart, HashSet<string> GivenThings, 
            HashSet<string> upUntil, Dictionary<string, HashSet<string>> adjacencyDictionary)
        {
            if (wordtoStart == EndWord)
            {
                upUntil.Add(wordtoStart);
                return new List<string>(upUntil);
            }
            var returnThis = new List<string>();
            if (AlreadyVisited.Contains(wordtoStart))
            {
                return returnThis;
            }
            var allwords = adjacencyDictionary[wordtoStart];
            upUntil.Add(wordtoStart);

            if (allwords.Count > 0)
            {
                var allwordsLi = new List<string>(allwords);
                for (int i = 0; i < allwordsLi.Count; i++)
                {
                     returnThis = DFS(allwordsLi[i], GivenThings, upUntil, adjacencyDictionary);
                    if (returnThis != null && returnThis.Count > 0)
                    {
                        break;
                    }
                }
            }

            upUntil.Remove(wordtoStart);

            return returnThis;
        }

        private List<string> FindWords(HashSet<string> givenWords, string word)
        {
            var returnThis = new List<string>();
            var wordLength = word.Length;
            for (int j = 0; j < word.Length; j++)
            {
                var theword = word[j].ToString();
                var jPlusOne = j + 1;
                for (int i = 'a'; i < 'z'; i++)
                {
                    var iTostr = i.ToString();
                    if (iTostr == theword)
                    {
                        continue;
                    }

                    var wordd = word[0..j] + iTostr + word[jPlusOne..wordLength];
                    if (givenWords.Contains(wordd))
                    {
                        returnThis.Add(wordd);
                        //givenWords.Remove(wordd);
                    }
                }

            }

            return returnThis;
        }

    }

    //https://www.youtube.com/watch?v=85ZAaacgu2c&list=PL1MJrDFRFiKbU7XYNy5WMU2Ci_x3Gbt2S&index=6
    //leetcode 785
    public class IsGraphBipartite
    {
        public int[][] JaggedArrayAdjacency { get; set; }

        public IsGraphBipartite()
        {
            //JaggedArrayAdjacency = new int[3][]; //it seems valid
            JaggedArrayAdjacency = new[]
            {
                new[] {1,2,3},
                //fill the rest later

            };
            //JaggedArrayAdjacency[1] = new int[2]; //it seems valid

        }

        public void Algorithmn()
        {
            var numberofedges = JaggedArrayAdjacency.Length;
            var array = new Int32[numberofedges];
            Array.Fill(array, -1);
            var i = 0;
            bool isbipartite = true;
            while (i < numberofedges)
            {
                if (array[i] == -1)
                {
                    array[i] = 0;
                }
                var values = JaggedArrayAdjacency[i];

                foreach (var value in values)
                {
                    if (array[value] != -1 && array[value] == array[i])
                    {
                        isbipartite = false;
                        break;
                    }

                    array[value] = array[i] == 0 ? 1 : 0;
                }
                i += 1;
            }

            Console.WriteLine($"The graph is {isbipartite}");
        }
    }

    public class CloneGraphDFS
    {
        public List<NodeGraph> AllNodes { get; set; }
        public Dictionary<NodeGraph, NodeGraph> DictinaryOldToNew { get; set; }
        public CloneGraphDFS()
        {
            AllNodes = new List<NodeGraph>();
            DictinaryOldToNew = new Dictionary<NodeGraph, NodeGraph>();
        }

        public void Algorithmn()
        {
            //Issa connected graph so that means I could pass the first node
            DFS(AllNodes[0]);
        }

        private void DFS(NodeGraph nodeToLook)
        {
            //var findAllRelated = AllNodes[nodeToLook.Value];
            if (!DictinaryOldToNew.ContainsKey(nodeToLook))
            {
                DictinaryOldToNew[nodeToLook] = new NodeGraph { Value = nodeToLook.Value,
                    NodeGraphs = new List<NodeGraph>()};
            }

            var newOne = DictinaryOldToNew[nodeToLook];
            foreach (var variable in nodeToLook.NodeGraphs)
            {
                DFS(variable);
                newOne.NodeGraphs.Add(DictinaryOldToNew[variable]);
            }
        }
    }

    public class CloneGraphBFS
    {
        public List<NodeGraph> AllNodes { get; set; }
        public Dictionary<NodeGraph, NodeGraph> DictinaryOldToNew { get; set; }
        public CloneGraphBFS()
        {
            AllNodes = new List<NodeGraph>();
            DictinaryOldToNew = new Dictionary<NodeGraph, NodeGraph>();
        }

        public void Algorithmn()
        {
            foreach (var nodeGraph in AllNodes)
            {
                if (DictinaryOldToNew.ContainsKey(nodeGraph))
                {
                    
                }
                else
                {
                    DictinaryOldToNew[nodeGraph] = new NodeGraph { Value = nodeGraph.Value };
                }

                var referenceToall = DictinaryOldToNew[nodeGraph].NodeGraphs;
                foreach (var nodeGraphNodeGraph in nodeGraph.NodeGraphs)
                {
                    if (!DictinaryOldToNew.ContainsKey(nodeGraphNodeGraph))
                    {
                        DictinaryOldToNew[nodeGraphNodeGraph] = new NodeGraph()
                        {
                            Value = nodeGraphNodeGraph.Value
                        };
                    }
                    referenceToall.Add(DictinaryOldToNew[nodeGraphNodeGraph]);
                }                
            }
        }
    }

    public class ShortestPathInBinaryMatrix
    {
        public int[,] GivenMatrix { get; set; }
        public ShortestPathInBinaryMatrix()
        {
            
        }

        public void Algorithmn()
        {
            var lengthMatrix = new int[GivenMatrix.GetLength(0), GivenMatrix.GetLength(1)];

            //queue creation
            var (row, column) = (0, 0);
            var queue = new Queue<Tuple<int, int>>();
            queue.Enqueue(Tuple.Create(row, column));
            var (rowMatrixL, colMatrixL) = (GivenMatrix.GetLength(0), GivenMatrix.GetLength(1));
            //go over each element and update the new matrix && edge cases
            var length = 0;
            while (queue.Count > 0)
            {
                var deque = queue.Dequeue();
                var (r1, c1) = (deque.Item1, deque.Item2);

                length += 1;


                if (r1 == rowMatrixL - 1 && c1 == colMatrixL - 1)
                {
                    //boom found maybe do somethings and break 
                }

                var (lc1, rc1, ur1, dr1) = (c1-1,c1+1,r1-1,r1+1);

                //go left
                if (lc1 >= 0 && GivenMatrix[row, lc1] == 0)
                {
                    queue.Enqueue(Tuple.Create(row, lc1));
                }

                //go right
                if (rc1 < colMatrixL && GivenMatrix[row, rc1] == 0)
                {
                    queue.Enqueue(Tuple.Create(row, rc1));
                }

                //go down
                if (dr1 < rowMatrixL && GivenMatrix[dr1, column] == 0)
                {
                    queue.Enqueue(Tuple.Create(dr1, column));
                }

                //right upper
                if (ur1 >= 0  && rc1 < colMatrixL && GivenMatrix[ur1, rc1] == 0)
                {
                    queue.Enqueue(Tuple.Create(ur1, rc1));
                }

                //left upper
                if (ur1 >= 0 && lc1 >= 0 && GivenMatrix[ur1, lc1] == 0)
                {
                    queue.Enqueue(Tuple.Create(ur1, rc1));
                }
                //left lower
                if (dr1 < rowMatrixL && lc1 >= 0 && GivenMatrix[dr1, lc1] == 0)
                {
                    queue.Enqueue(Tuple.Create(dr1, lc1));
                }
                //right lower
                if (dr1 < rowMatrixL && rc1 < colMatrixL && GivenMatrix[dr1, rc1] == 0)
                {
                    queue.Enqueue(Tuple.Create(dr1, rc1));
                }
            }
        }
    }

    public class MakingALargeIsland
    {
        public int[,] Matrix { get; set; }
        public MakingALargeIsland()
        {
            
        }

        public void Algorithmn()
        {
            //go over to find the islands
            //when a island is found mark it's length and give it a id
            //go over it and at the end give that id a value
            //Now go over the matrix. Every time there's a zero go over all 4 dirs ans put it in hashmap
            //and add the values to find the big one

            var hashofVisited = new HashSet<string>();
            var matrixId = new int[Matrix.GetLength(0), Matrix.GetLength(1)];
            var id = -1;
            var dictionaryIdVal = new Dictionary<int, int>();
            
            //row
            for (int i = 0; i < Matrix.GetLength(0); i++)
            {
                //column
                for (int j = 0; j < Matrix.GetLength(1); j++)
                {
                    if (hashofVisited.Contains($"{i}, {j}"))
                    {
                        continue;
                    }

                    if (Matrix[i, j] == 1)
                    {
                        var stack = new Stack<Tuple<int, int>>();
                        stack.Push(new Tuple<int, int>(i,j));
                        var value = 0;
                        while (stack.Count > 0)
                        {
                            var popped = stack.Pop();
                            //matrixId[]
                            var (row, column) = (popped.Item1, popped.Item2);
                            var (left, right, top, bottom
                                ) = (column - 1, column + 1, row - 1, row + 1);
                            matrixId[row, column] = id;
                            hashofVisited.Add($"{row}, {column}");
                            value += 1;
                            //go left
                            if (Helper(hashofVisited, row, left))
                            {
                                stack.Push(new Tuple<int, int>(row, left));
                            }
                            //go right
                            if (Helper(hashofVisited, row, right))
                            {
                                stack.Push(new Tuple<int, int>(row, right));
                            }

                            //go top
                            if (Helper(hashofVisited, top, column))
                            {
                                stack.Push(new Tuple<int, int>(top, column));
                            }

                            //go bottom
                            if (Helper(hashofVisited, bottom, column))
                            {
                                stack.Push(new Tuple<int, int>(bottom, column));
                            }
                        }

                        dictionaryIdVal.Add(id, value);
                        id -= 1;
                    }
                }
            }

            var hashofId = new HashSet<int>();
            var largeIsland = Int32.MinValue;

            for (int i = 0; i < Matrix.GetLength(0); i++)
            {
                for (int j = 0; j < Matrix.GetLength(1); j++)
                {
                    if (Matrix[i, j] == 0)
                    {
                        //go over all dirs
                        var (left, right, top, bottom) = (j - 1, j + 1, i - 1, i + 1);
                        if (left >= 0 && matrixId[i,left] != 0)
                        {
                            hashofId.Add(matrixId[i, left]);
                        }

                        if (right < matrixId.GetLength(1) && matrixId[i, right] != 0)
                        {
                            hashofId.Add(matrixId[i, left]);
                        }
                        if (top >= 0 && matrixId[top, j] != 0)
                        {
                            hashofId.Add(matrixId[i, left]);
                        }
                        if (bottom < matrixId.GetLength(0) && matrixId[bottom, j] != 0)
                        {
                            hashofId.Add(matrixId[i, left]);
                        }

                        var val = 0;
                        foreach (var h1 in hashofId)
                        {
                            val += dictionaryIdVal[h1];
                        }

                        if (val > largeIsland)
                        {
                            largeIsland = val;
                        }
                    }


                }
            }
        }

        private bool Helper(HashSet<string> visited, int row, int column)
        {
            if (row >= Matrix.GetLength(0) || row < 0)
            {
                return false;
            }
            
            if (column >= Matrix.GetLength(1) || column < 0)
            {
                return false;
            }

            if (Matrix[row, column] == 0)
            {
                visited.Add($"{row}, {column}");
            }
            if (!visited.Contains($"{row}, {column}"))
            {
                return true;
            }

            return false;
        }

    }
    public class NodeGraph
    {
        public int Value { get; set; }
        public List<NodeGraph> NodeGraphs { get; set; }

        public NodeGraph()
        {
            NodeGraphs = new List<NodeGraph>();
        }
    }
}
