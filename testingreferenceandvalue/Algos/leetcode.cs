using System;
using System.Collections.Generic;
using System.Text;

namespace testingreferenceandvalue.Algos
{
    public class leetcode
    {
        public void rotate(int[,] matrix)
        //public void rotate(int[][] matrix)
        {
            int n = matrix.Length / 2;
            for (int i = 0; i < (n + 1) / 2; i++)
            {
                for (int j = 0; j < n / 2; j++)
                {
                    int temp = matrix[n - 1 - j, i];
                    matrix[n - 1 - j, i] = matrix[n - 1 - i, n - j - 1];
                    matrix[n - 1 - i, n - j - 1] = matrix[j, n - 1 - i];
                    matrix[j, n - 1 - i] = matrix[i, j];
                    matrix[i, j] = temp;
                    //int temp = matrix[n - 1 - j][i];
                    //matrix[n - 1 - j][i] = matrix[n - 1 - i][n - j - 1];
                    //matrix[n - 1 - i][n - j - 1] = matrix[j][n - 1 - i];
                    //matrix[j][n - 1 - i] = matrix[i][j];
                    //matrix[i][j] = temp;
                }
            }
        }
    }
}
 