using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgorithsPractise.LeetCode_Eric.Phase6
{
    public class ArraysProblems
    {
    }

    public class FindPivot
    {
        public int[] GivenArray { get; set; }

        public void Algorithm()
        {
            var sumArray = new int[GivenArray.Length];
            sumArray[0] = GivenArray[0];

            var allsum = GivenArray.Sum();
            var (iterateOnThis, leftMostPivot) = (1, GivenArray.Length);

            while (iterateOnThis >= GivenArray.Length - 1)
            {
                var valueAtThis = GivenArray[iterateOnThis];
                var sumBeforeThat = sumArray[iterateOnThis - 1];

                var rightSideSum = allsum - valueAtThis - sumBeforeThat;

                if (rightSideSum == sumBeforeThat)
                {
                    leftMostPivot = iterateOnThis;
                    break;
                }

                sumArray[iterateOnThis] = valueAtThis + sumBeforeThat;
                iterateOnThis += 1;
            }
        }

    }

    public class DiagonalTraverse
    {
        public int[,] GivenMatrix { get; set; }

        public DiagonalTraverse()
        {
            
        }

        public void Algorithmn()
        {
            //start with the (0,0)
            //Go down and up until you can't go up or down but  down

            var ans = new List<int>();
            ans.Add(GivenMatrix[0,0]);

            var down = true;
            var (row, column, allRows, allColumns) =
                (0, 0, GivenMatrix.GetLength(0), GivenMatrix.GetLength(1));

            while (row != allRows - 1 && column != allColumns - 1)
            {
                if (down)
                {
                    var (columnP, rowP) = (column + 1, row + 1);
                    var (copyr, copyC) = (row, column);

                    if (columnP < allColumns)
                    {
                        ans.Add(GivenMatrix[row, columnP]);
                        copyC = columnP;
                    }
                    else
                    {
                        ans.Add(GivenMatrix[rowP, column]);
                        copyr = rowP;
                    }

                    var (rowPP, colMM) = (copyr + 1, copyC - 1);
                    //while (copyC >=0 && copyC < allColumns - 1 && copyr >= 0 && copyr < allRows - 1)
                    while (rowP < allColumns && colMM >= 0 )
                    {
                        ans.Add(GivenMatrix[rowPP, colMM]);
                        rowPP += 1;
                        colMM -= 1;
                    }

                    row = rowPP - 1;
                    column = colMM + 1;
                    down = false;
                }
                else
                {
                    var (rowP, columnP) = (row + 1, column + 1);

                    var (rowTS, columnTS) = (row, column);
                    if (rowP < allRows)
                    {
                        rowTS = rowP;
                        ans.Add(GivenMatrix[rowP, column]);
                    }
                    else
                    {
                        columnTS = columnP;
                        ans.Add(GivenMatrix[row, columnP]);
                    }

                    while (columnTS < allColumns - 1 && rowTS >= 0)
                    {
                        ans.Add(GivenMatrix[rowTS, columnTS]);
                        rowTS -= 1;
                        columnTS += 1;
                    }

                    column = columnTS - 1;
                    row = rowTS + 1;
                    down = true;
                }
            }

        }

        //I don't think BFS is possible
        public void AlgorithmnBFS()
        {
            var queue = new Queue<string>();

            queue.Enqueue("0,0");
            queue.Enqueue("D");

            var answers = new List<int>();
            var usedAlready = new HashSet<string>();
            usedAlready.Add("0, 0");
            bool goingDown = false;

            while (queue.Count > 0)
            {
                var value = queue.Dequeue();
                if (value == "D")
                {
                    goingDown = !goingDown;
                    queue.Enqueue("D");
                    continue;
                }

                var (row, column) = (Convert.ToInt32(queue.Dequeue().Split(",")[0]),
                    Convert.ToInt32(queue.Dequeue().Split(",")[1]));

                var val = GivenMatrix[row, column];
                answers.Add(val);
                usedAlready.Add($"{row}, {column}");


            }
        }

        public void AlgorithmnDFS()
        {
            var (rowT, columnT) = (GivenMatrix.GetLength(0), GivenMatrix.GetLength(1)); 
            var used = new HashSet<string>();
            var stack = new Stack<string>();

            var isGoingDown = false;

            stack.Push($"0,0");
            stack.Push("D");
            used.Add("0,0");
            //var numberofTimesBefore = 1;
            var auxiliaryStack = new Stack<string>();
            while (stack.Count > 0)
            {
                var value = stack.Pop();
                //check for D.
                //If yes change the direction and continue;
                //put things on a second stack for upto that number
                //when numberofTimesBefore = 0; switch stack and that other stack and add D at the end

                if (value == "D")
                {
                    if (stack.Count == 0)
                    {
                        break;
                    }
                    isGoingDown = !isGoingDown;
                    continue;
                }

                var splitted = value.Split(",");
                var (row, column) = (Convert.ToInt32(splitted[0]),
                    Convert.ToInt32(splitted[1]));
                var (newrow, newColum) = (row + 1, column + 1);

                if (isGoingDown)
                {
                    if (newColum < columnT)
                    {
                        auxiliaryStack.Push($"{row},{newColum}");
                    }

                    if (newrow < rowT)
                    {
                        auxiliaryStack.Push($"{newrow},{column}");
                    }
                }
                else
                {
                    if (newrow < rowT)
                    {
                        auxiliaryStack.Push($"{newrow},{column}");
                    }

                    if (newColum < columnT)
                    {
                        auxiliaryStack.Push($"{row},{newColum}");
                    }
                }
                if (stack.Count == 0)
                {
                    stack = new Stack<string>(auxiliaryStack);
                    auxiliaryStack.Clear();
                    stack.Push("D");
                }

            }
        }
    }

    public class PascalTriangle
    {
        public int NumberOfRows { get; set; }
        public PascalTriangle()
        {
            
            
        }

        public void Algorithmn()
        {
            var ansList = new List<int[]>();
            ansList.Add(new []{1});

            //go over all number in list that needs to be in ans
            //check for previously added in (answer) at that index and before.

            for (int i = 1; i < NumberOfRows; i++)
            {
                var toadd = new int[i + 1];
                var previouslyAdded = ansList[i];
                for (int j = 0; j <= i; j++)
                {
                    var previous = j == 0 ? 0 : previouslyAdded[j - 1];
                    toadd[j] = previous + previouslyAdded[j];
                }
            }
            //ansLiost is ans
        }
    }

    public class SpiralMatrix
    {
        public int[,] GivenMatrix { get; set; }
        public SpiralMatrix()
        {
            
        }

        public void Algorithmn()
        {
            var (rows, columns) = (GivenMatrix.GetLength(0), GivenMatrix.GetLength(1));
            var (left, right, bottom, top) = (0, columns, rows, 0);
            var list = new List<int>();

            //go left to right then increase top
            //go top to bottom and lower right
            //go right to left and lower bottom
            //go bottom to top and increase left
            while (left > right && top > bottom)
            {
                //go left to right
                for (int i = left; i <= right; i++)
                {
                    list.Add(GivenMatrix[top,i]);
                }

                top += 1;
                for (int i = top; i <= bottom; i++)
                {
                    list.Add(GivenMatrix[i,right]);
                }

                right -= 1;

                for (int i = right; i >= left; i--)
                {
                    list.Add(GivenMatrix[bottom, i]);
                }

                bottom -= 1;

                for (int i = bottom; i >= top; i++)
                {
                   list.Add(GivenMatrix[i, left]); 
                }

                left += 1;
            }
        }

    }

    public class DuplicateZeros
    {
        public int[] GivenArrays { get; set; }
        public DuplicateZeros()
        {
            
        }

        //https://www.youtube.com/watch?v=kyoaNxfQNEc
        public void Algorithmn()
        {
            var (numberOfDupes, iteration) = (0, 0);

            while ((iteration + numberOfDupes) < GivenArrays.Length)
            {
                // make sure dupes plus iteration is not >= Length
                //check to see if it is 0
                //increment dupes

                if (GivenArrays[iteration] == 0)
                {
                    numberOfDupes += 1;
                }
                iteration += 1;
            }

            while (iteration > 0)
            {
                var sumOfIterationAndDupes = iteration + numberOfDupes;
                if (sumOfIterationAndDupes < GivenArrays.Length)
                {
                    if (GivenArrays[iteration] == 0)
                    {
                        //have to be two
                        
                        GivenArrays[sumOfIterationAndDupes] = 0;
                        GivenArrays[sumOfIterationAndDupes - 1] = 0;
                        numberOfDupes--;
                    }
                    else
                    {
                        GivenArrays[sumOfIterationAndDupes] = GivenArrays[iteration];
                    }

                    iteration -= 1;
                }
                else
                {
                    GivenArrays[sumOfIterationAndDupes - 1] = GivenArrays[iteration];
                }
            }

        }
    }

    public class MinimumTimeDifference
    {
        public string[] GivenTimes { get; set; }
        public MinimumTimeDifference()
        {
            
        }
        //todo do it on nlogn time wise. But  the other solution is better.
        public void NlognAlgo()
        {
            //first conver them to minutes
            //sort them on ascending/descending order
            //find the diffrence

            var newArray = new int[GivenTimes.Length];

            for (int i = 0; i < GivenTimes.Length; i++)
            {
                var split = GivenTimes[i].Split(":");
                var hour = Convert.ToInt32(split[0]);
                var minutes = Convert.ToInt32(split[1]);

                var together = hour + minutes;
                newArray[i] = together;
            }

            //sort
            //quick sort
            SortGiven(newArray, 0, newArray.Length - 1);

            var minimum = Int32.MaxValue;
            for (int i = 1; i < newArray.Length; i++)
            {
                var diff = newArray[i] - newArray[i - 1];
                if (diff < minimum)
                {
                    minimum = diff;
                }
            }
            //last case counter clockwise
            var remainingBeforeDayEnds = (24 * 60) - newArray[^1];
            var allTogether = remainingBeforeDayEnds + newArray[0];
            if (allTogether < minimum)
            {
                minimum = allTogether;
            }

            Console.WriteLine("Minimum time is " + minimum);
        }

        //https://www.youtube.com/watch?v=c5ecNf7JM1Q
        public void SortGiven(int[] array, int startIndex, int endIndex)
        {
            if (startIndex >= endIndex)
            {
                return;
            }
            var pivot = array[endIndex];
            var partiotionIndex = startIndex;

            for (int i = startIndex; i < endIndex; i++)
            {
                if (array[i] < pivot)
                {
                    //swap at partition vs ith index
                    (array[i], array[partiotionIndex]) = (array[partiotionIndex], array[i]);
                    partiotionIndex += 1;
                }
            }

            (array[endIndex], array[partiotionIndex]) = (array[partiotionIndex], array[endIndex]);

            SortGiven(array, startIndex, partiotionIndex - 1);
            SortGiven(array, partiotionIndex +1, endIndex);
        }

        public void Algorithmn()
        {
            //bucket sort
            var numbers = 24 * 60;
            var boolArr = new bool[numbers];

            for (int i = 0; i < GivenTimes.Length; i++)
            {
                var split = GivenTimes[i].Split(":");
                var hour = Convert.ToInt32(split[0]) * 60;
                var min = Convert.ToInt32(split[1]);
                var addedTogether = hour + min;

                if (boolArr[addedTogether])
                {
                    //that's 0. as the diffrence is gonna be zero here.
                    break;
                }

                boolArr[addedTogether] = true;
            }

            int? prevVal = null;
            var minimum = Int32.MaxValue;
            for (int i = 0; i < numbers; i++)
            {
                if (boolArr[i])
                {
                    if (prevVal != null)
                    {
                        var diffrence = (int)(i - prevVal);
                        var antiClockWise = (int)(numbers - i + prevVal);
                        var minimum2 = Math.Min(diffrence, antiClockWise);
                        if (minimum2 < minimum)
                        {
                            minimum = minimum2;
                        }
                    }
                    else
                    {
                        prevVal = i;
                    }
                }   
            }

        }
    }
}
 