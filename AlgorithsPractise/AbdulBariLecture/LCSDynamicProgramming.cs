using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithsPractise.AbdulBariLecture
{
    public class LCSDynamicProgramming
    {
        public string FirstWord { get; set; }
        public string SecondWord { get; set; }

        public int[,] MatrixOfWord { get; set; }

        //1 + LCS(i-1, j-1)
        //max(LCS(i-1, j), LCS[i, j-1)

        public LCSDynamicProgramming()
        {
            FirstWord = "stone";
            SecondWord = "longest";

            //firstword is row and secondword is column
            MatrixOfWord = new int[FirstWord.Length + 1, SecondWord.Length + 1];

        }


        public int FindThemaximumSubstring()
        {
            //no need as everything is 0 when you first initialize an matrix;
            Initialize();

            //row
            for (int i = 1; i < MatrixOfWord.GetLength(0); i++)
            {
                //column
                for (int j = 1; j < MatrixOfWord.GetLength(1); j++)
                {
                    //Now check if they are equal or not
                    if (FirstWord[i - 1] == SecondWord[j - 1])
                    {
                            MatrixOfWord[i, j] = 1 + MatrixOfWord[i - 1, j - 1];

                    }
                    else
                    {
                            MatrixOfWord[i, j] = Math.Max(MatrixOfWord[i - 1, j], MatrixOfWord[i, j - 1]);

                    }
                }
            }
            FindTheWord();
            return 0;
        }

        public string FindTheWord()
        {
            var (i, j) = (FirstWord.Length, SecondWord.Length);
            var stack = new Stack<string>();

            //(i, j) != 00 may not be the best way of doing the while loop.
            while ((i,j) != (0,0))
            {
                var valueofLast = MatrixOfWord[i, j];
                if (valueofLast == 0)
                {
                    break;
                }
                var diagonalValue = MatrixOfWord[i - 1, j - 1];
                var leftSideValue = MatrixOfWord[i, j - 1];
                var topSideValue = MatrixOfWord[i - 1, j];

                //got it from side or top
                if ((valueofLast == leftSideValue ) || (valueofLast == topSideValue))
                {
                    (i, j) = valueofLast == leftSideValue ? (i, j - 1) : (i -1, j);
                }
                else
                {
                    stack.Push(SecondWord[j - 1].ToString());
                    (i, j) = (i - 1, j - 1);
                }
            }

            var returnThis = "";
            while (stack.Count != 0)
            {
                returnThis += stack.Pop();
            }

            return returnThis;
            return "OKAY";
        }
        private void Initialize()
        {
            for (int j = 0; j < 2; j++)
            {
                for (int i = 0; i < MatrixOfWord.GetLength(j); i++)
                {
                    if (j == 0)
                    {
                        MatrixOfWord[i, 0] = 0;
                    }
                    else
                    {
                        MatrixOfWord[0,i] = 0;
                    }
                }

            }
        }
    }
}
