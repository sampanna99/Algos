using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithsPractise
{
    public class MinimumEditDistance
    {
        public string FirstWord { get; set; }
        public string SecondWord { get; set; }
        public int[,] Matrix { get; set; }

        public MinimumEditDistance()
        {
            this.FirstWord = "abcdef";
            this.SecondWord = "azced";
            this.Matrix = new int[FirstWord.Length, SecondWord.Length];
        }

        private void InitializeThings(int[,] matrix)
        {
            var firstColumnChar = SecondWord[0];
            bool IsChanged = false;
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                if (IsChanged)
                {
                    Matrix[0, i] = Matrix[0, i - 1] + 1;
                }
                if (firstColumnChar == FirstWord[i])
                {
                    if (i == 0)
                    {
                        Matrix[0, i] = 0;
                    }
                    else
                    {
                        Matrix[0, i] = Matrix[0, i - 1];
                    }
                    IsChanged = true;
                }
                else
                {
                    Matrix[0, i] = 0;
                    if (i == 0)
                    {
                        Matrix[0, i] = 1;
                    }
                    else
                    {
                        Matrix[0, i] = Matrix[0, i - 1] + 1;
                    }
                }
            }
        }
        public int MinimumChangesRequired()
        {
            InitializeThings(Matrix);

            for (int i = 1; i < Matrix.GetLength(0); i++)
            {
                for (int j = 0; j < Matrix.GetLength(1); j++)
                {
                    var jVal = j == 0 ? i + 1 : Matrix[i, j - 1];
                    var jValForDiagonal = j == 0 ? i + 1 : Matrix[i - 1, j - 1];

                    if (FirstWord[j] == SecondWord[i])
                    {
                        Matrix[i, j] = jValForDiagonal;
                    }
                    else
                    {
                        Matrix[i, j] = Math.Min(jVal, Math.Min(Matrix[i - 1, j - 1], Matrix[i - 1, j]));

                    }
                }
            }

            return Matrix[Matrix.GetLength(0) - 1, Matrix.GetLength(1) - 1];
        }
    }
}
