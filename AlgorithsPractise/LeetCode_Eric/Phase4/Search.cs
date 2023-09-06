using System;
using System.Collections.Generic;
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

    }
}
