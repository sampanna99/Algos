using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithsPractise.LeetcodeSolutions
{
    public class TicTacToe
    {
        public int Size { get; set; } = 3;
        public int[] RowArray { get; set; }
        public int[] ColumnArray { get; set; }
        public int Diagonal { get; set; }
        public int AntiDiagonal { get; set; }
        public TicTacToe()
        {
            RowArray = new int[Size];
            ColumnArray = new int[Size];
        }

        public void Algorithm(int playerVal, int row, int column)
        {
            //if diagonal or antidogonal
            if (row == column)
            {
                Diagonal += playerVal;
            }

            if (row + column + 1 == Size)
            {
                AntiDiagonal += playerVal;
            }


            RowArray[row] += playerVal;
            ColumnArray[column] += playerVal;

            if (Math.Abs(RowArray[row]) == Size ||
                Math.Abs(ColumnArray[column]) == Size ||
                Math.Abs(Diagonal) == Size ||
                Math.Abs(AntiDiagonal) == Size
                )
            {
                //BingPot
                Console.WriteLine($"TicTacToe winner ${playerVal}");
            }
        }

    }
}
