using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithsPractise
{
    public class NQueensBacktracking
    {
        public int[] ColumnArray { get; set; }
        public int Size { get; set; }

        public HashSet<int> RowPlusColumn { get; set; }
        public HashSet<int> RowMinusColumn { get; set; }
        public NQueensBacktracking()
        {
            //var ds = new Tuple<int, int>(1, 2);
            //var dss = Tuple.Create(1, 2);
            //var aa = new List<Tuple<int, int>>();
            Size = 4;
            ColumnArray = new int[Size];
            Array.Fill(ColumnArray, -10);
            RowPlusColumn = new HashSet<int>();
            RowMinusColumn = new HashSet<int>();

            //var dsa = new Dictionary<string, string>();
            //dsa.Add("abc", "abc");
            //dsa.Add("abc", "def"); //boom you can't


            //var ds = new HashSet<string>();

            //ds.Add("anc");
            //ds.Add("anc");
            //ds.Add("anc");
            //ds.Add("ds");
            //RowPlusColumn.Add(1);
            //RowPlusColumn.Add(1);
            //var ds = new Tuple<string, int>("ds", 1);
            //var aa = new List<Tuple<string, int>>();
 
        }

        public void NqueensBacktrack()
        {
            //DoesExist(0,0);
            DoesExoists2(0);
        }
        public void DoesExist(int row , int column, int nopassThisColumn = 10)
        {
            if (row > 3)
            {
                return;
            }

            //var changedclolm = column > 3 ? column - Size : column;
            bool foundPlaceToadd = false;
            for (int i = column; i < column + 4; i++)
            {
                var changedColumn = i;
                if (i > 3)
                {
                    changedColumn = i - 4;
                }

                //this is to make sure it doesn't place in the same place.
                //if (changedColumn - row == -1 && i > 3)
                //{
                //    break;
                //}

                if (nopassThisColumn != 10 && changedColumn >= nopassThisColumn)
                {
                    break;
                }


                if (!RowPlusColumn.Contains(row + changedColumn) &&
                    !RowMinusColumn.Contains(row - changedColumn) &&
                    ColumnArray[changedColumn] == -10)
                {
                    ColumnArray[changedColumn] = row;

                    if (Array.IndexOf(ColumnArray, -10) == -1)
                    {
                        Console.WriteLine("boom found");
                    }
                    RowPlusColumn.Add(row + changedColumn);
                    RowMinusColumn.Add(row - changedColumn);
                    foundPlaceToadd = true;
                    break;
                }
                else
                {
                    //Console.WriteLine(RowPlusColumn.Contains(row + changedColumn));
                    //Console.WriteLine(RowMinusColumn.Contains(row - changedColumn));
                    continue;
                }
            }

            if (!foundPlaceToadd)
            {
                //remove from the ColumnArray
                var indexof = Array.IndexOf(ColumnArray, row - 1);

                ColumnArray[indexof] = -10;

                var columnThatcouldBechanged = indexof + 1;

                if (columnThatcouldBechanged >= 4)
                {
                    columnThatcouldBechanged = columnThatcouldBechanged - 4;
                }

                RowPlusColumn.Remove(row - 1 + indexof);
                RowMinusColumn.Remove(row - 1 - indexof);


                DoesExist(row - 1, columnThatcouldBechanged, indexof);
            }
            DoesExist(row + 1, 0);
            //DoesExist(row + 1, column + 1);
            RowPlusColumn.Clear();
            RowMinusColumn.Clear();
            Array.Fill(ColumnArray, -10);
        }

        public void DoesExoists2(int row)
        {
            if (row > 3)
            {
                return;
            }



            for (int i = 0; i < Size; i++)
            {
                var column = i;
                if (!RowPlusColumn.Contains(row + column) &&
                    !RowMinusColumn.Contains(row - column) &&
                    ColumnArray[column] == -10)
                {
                    ColumnArray[column] = row;

                    if (Array.IndexOf(ColumnArray, -10) == -1)
                    {
                        Console.WriteLine("boom found");
                    }
                    RowPlusColumn.Add(row + column);
                    RowMinusColumn.Add(row - column);

                    DoesExoists2(row + 1);

                    RowPlusColumn.Remove(row + column);
                    RowMinusColumn.Remove(row - column);
                    ColumnArray[column] = -10;

                    //RowPlusColumn.Clear();
                    //RowMinusColumn.Clear();
                    //Array.Fill(ColumnArray, -10);


                }
                else
                {
                    continue;
                }

            }
        }

    }
}
