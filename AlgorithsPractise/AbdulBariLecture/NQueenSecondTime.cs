using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace AlgorithsPractise.AbdulBariLecture
{
    public class NQueenSecondTime
    {
        public List<List<string>> Results { get; set; }
        public int NumberOfRowsAndColumns { get; set; } = 4;

        public HashSet<int> RowPlusColumn { get; set; }
        public HashSet<int> RowMinusColumn { get; set; }
        public NQueenSecondTime()
        {
            Results = new List<List<string>>();
            RowMinusColumn = new HashSet<int>();
            RowPlusColumn = new HashSet<int>();
        }


        private bool IsViable(HashSet<int> AlreadyInColumn, int rowToPutIn, int ColumnToputin)
        {
            //row + column
            //row - column
            var returnThis = false;
            var minus = rowToPutIn - ColumnToputin;
            var plus = rowToPutIn + ColumnToputin;

            if (!RowMinusColumn.Contains(minus) && !RowPlusColumn.Contains(plus))
            {
                RowMinusColumn.Add(minus);
                RowPlusColumn.Add(plus);

                returnThis = true;
            }

            return returnThis;
        }

        public string NQueen()
        {
            var Hashset = new HashSet<int>();

            DFS(Hashset, 0);
            return "OK";
        }
        private List<List<string>> DFS(HashSet<int> AlreadyInColumn, int rowToPutIn)
        {
            if (AlreadyInColumn.Count == 3)
            {
                //check with the remaining one and return either 
                //which column you're putting the queen four in
                var remainingOne = -1;
                for (int i = 0; i < NumberOfRowsAndColumns; i++)
                {
                    if (!AlreadyInColumn.Contains(i))
                    {
                        remainingOne = i;
                        break;
                    }
                }

                if (IsViable(AlreadyInColumn, rowToPutIn, remainingOne))
                {
                    //for (int i = 0; i < NumberOfRowsAndColumns; i++)
                    //{
                    //    if (!AlreadyInColumn.Contains(i))
                    //    {
                    //        Console.WriteLine("Queen " + (AlreadyInColumn.Count + 1).ToString() +
                    //                          " in " + (i + 1) + "column");
                    //         Results.Add(new List<string>{i.ToString()});
                    //         return Results;
                    //    }
                    //}

                    Console.WriteLine("Queen " + (AlreadyInColumn.Count + 1).ToString() +
                                      " in " + (remainingOne + 1) + "column");
                    Results.Add(new List<string> { remainingOne.ToString() });

                    ResetValues(remainingOne, rowToPutIn);
                    AlreadyInColumn.Remove(remainingOne);


                    return Results;

                }
                else
                {
                    return null;
                }
            }

            var AlReadyInColumn2 = new HashSet<int>();
            for (int i = 0; i < NumberOfRowsAndColumns; i++)
            {
                //AlReadyInColumn2.Add(i);
                if (AlreadyInColumn.Contains(i))
                {
                    continue;
                }

                if (!IsViable(AlreadyInColumn, rowToPutIn, i))
                {
                    continue;
                }

                AlreadyInColumn.Add(i);
                var returnValue = DFS(AlreadyInColumn, rowToPutIn + 1);
                ResetValues(i, rowToPutIn);
                AlreadyInColumn.Remove(i);
                //Reset row plus column and row minus column

                //AlreadyInColumn.Remove(i);
                if (returnValue != null)
                {
                    foreach (var result in Results)
                    {

                        if (!result.Contains(i.ToString()))
                        {
                            Console.WriteLine("Queen " + (AlreadyInColumn.Count + 1).ToString() +
                                              " in " + (i + 1) + "column");
                            result.Add(i.ToString());
                        }
                    }
                }
            }

            return Results;
        }

        private void ResetValues(int columnAdd, int rowAdd)
        {
            var minus = rowAdd - columnAdd;
            var plus = rowAdd + columnAdd;


            RowMinusColumn.Remove(minus);
            RowPlusColumn.Remove(plus);

        }
    }
}
