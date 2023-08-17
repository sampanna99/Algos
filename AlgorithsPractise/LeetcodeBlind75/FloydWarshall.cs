using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithsPractise.LeetcodeBlind75
{
    public class FloydWarshall
    {
        public int NumberOfVertex { get; set; } = 4;

        public int[,] Matrix { get; set; }
        //public int[][] Matrix { get; set; }

        public FloydWarshall()
        {
            //Matrix = new int[NumberOfVertex][];
            Matrix = new int[NumberOfVertex,NumberOfVertex];
            Initialize();
        }

        private void Initialize()
        {
            Matrix[0, 0] = 0;
            Matrix[1, 1] = 0;
            Matrix[2, 2] = 0;
            Matrix[3, 3] = 0;

            Matrix[0, 1] = 3;
            Matrix[0, 3] = Int32.MaxValue;
            Matrix[0, 4] = 7;

            Matrix[1, 0] = 8;
            Matrix[1, 2] = 2;
            Matrix[1, 3] = Int32.MaxValue;

            Matrix[2, 0] = 5;
            Matrix[2, 1] = Int32.MaxValue;
            Matrix[2, 3] = 1;

            Matrix[3, 0] = 2;
            Matrix[3, 1] = Int32.MaxValue;
            Matrix[3, 2] = Int32.MaxValue;
        }
        public void AlgoAllPairsShoretest()
        {
            for (int k = 0; k < Matrix.GetLength(0); k++)
            {
                for (int i = 0; i < Matrix.GetLength(0); i++)
                {
                    if (i == k)
                    {
                        continue;
                    }
                    for (int j = 0; j < Matrix.GetLength(1); j++)
                    {
                        if (j == k)
                        {
                            continue;
                        }

                        var addingusingThemedium = Matrix[i, k] == Int32.MaxValue || Matrix[k, j] == Int32.MaxValue
                            ? Int32.MaxValue
                            : Matrix[i, k] + Matrix[k, j];
                        Matrix[i, j] = Math.Min(Matrix[i, j], addingusingThemedium);
                    }
                }

            }
        }

    }
}
