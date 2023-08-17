using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithsPractise.LeetcodeBlind75
{
    public class OptimalBinarySearchTree
    {
        public Dictionary<string, decimal> KeyProbability { get; set; }
        public decimal[,] Matrix { get; set; }

        public OptimalBinarySearchTree()
        {
            KeyProbability = new Dictionary<string, decimal>();
            Initialize();
            Matrix = new decimal[KeyProbability.Count + 1, KeyProbability.Count + 1];
            Init2();
        }

        private void Initialize()
        {
            KeyProbability.Add("A", 0.213M);
            KeyProbability.Add("B", 0.020M);
            KeyProbability.Add("C", 0.547M);
            KeyProbability.Add("D", 0.100M);
            KeyProbability.Add("E", 0.120M);
        }

        private void Init2()
        {
            for (int i = 1; i < Matrix.GetLength(0); i++)
            {
                switch (i)
                {
                    case 1:
                        Matrix[i, i] = 0.213M;
                        break;
                    case 2:
                        Matrix[i, i] = 0.020M;
                        break;
                    case 3:
                        Matrix[i, i] = 0.547M;
                        break;
                    case 4:
                        Matrix[i, i] = 0.100M;
                        break;
                    case 5:
                        Matrix[i, i] = 0.120M;
                        break;
                }
            }
        }

        public void AlgoStart()
        {
            for (int end = 2; end < KeyProbability.Count + 1; end++)
            {
                var endCopy = end;
                for (int i = 1; i < KeyProbability.Count + 1; i++)
                {
                    if (endCopy < KeyProbability.Count + 1)
                    {
                        Algorithm(i, endCopy);
                        endCopy++;
                    }
                    else
                    {
                         break;
                    }
                }
            }
        }
        public void Algorithm(int start, int end)
        {
            var bestValue = Decimal.MaxValue;
            for (int i = start; i <= end; i++)
            {
                var left = i - 1;
                var right = i + 1;
                decimal add = 0;
                add = start > left ? 0 : Matrix[start, left];
                decimal add2 = right > end ? 0 : Matrix[right, end];
                var whileI = add2 + add;
                if (bestValue > whileI)
                {
                    bestValue = whileI;
                }
            }

            var addThis = 0M;
            for (int i = start; i <= end; i++)
            {
                char recter = (char)(64 + i);
                addThis += KeyProbability[recter.ToString()];
            }

            Matrix[start, end] = bestValue + addThis;
        }
    }
}
