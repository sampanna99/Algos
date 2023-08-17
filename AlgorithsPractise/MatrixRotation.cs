using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithsPractise
{
    public class MatrixRotation
    {
        public int[,] Matrix { get; set; }
        public MatrixRotation()
        {
            this.Matrix = initializeMatrix();

        }

        private int[,] initializeMatrix()
        {
            //int[,] array = new int[2, 4] { { 1, 2, 3, 4 }, { 5, 6, 7, 8 } };

            //int[,] array2Da = new int[4, 2] { { 1, 2 }, { 3, 4 }, { 5, 6 }, { 7, 8 } };

            int[,] matrix1 = new int[4,4]
            {
                { 1, 2, 3, 4 }, {5,6,7,8 }, {9,10,11,12}, {13,14,15,16}
            };
            return matrix1;
        }

        public void RotateMatrix()
        {
            for (int i = 0; i < 4; i++)
            {

                for (int j = 0; j < 4; j++)
                {
                    if (j == i)
                    {
                        continue;
                    }

                    if (j > i)
                    {
                        break;
                    }

                    var matrixIj = Matrix[i, j];
                    var matrixJi = Matrix[j, i];

                    Matrix[i, j] = matrixJi;
                    Matrix[j, i] = matrixIj;
                }
            }

            //now need to swap the first column to last second to second last and so forth


            foreach (var matr in Matrix)
            {
                Console.WriteLine(matr);
            }
        }

    }
}
