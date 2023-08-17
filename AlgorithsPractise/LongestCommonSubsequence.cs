using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithsPractise
{
    //MEDIUM
    //NOTCXOMPLETE

    public class LongestCommonSubsequence
    {

        public string FristString { get; set; }
        public string SecondeString { get; set; }

        public LongestCommonSubsequence()
        {
            FristString = "acde";
            SecondeString = "acef";
        }





        //not optimizing the space
        public string LongestCommonsequence()
        {
            var firstLength = FristString.Length;
            var secondLength = SecondeString.Length;

            int[,] matrix = new int[firstLength + 1, secondLength + 1];

            matrix = initializeFIrstFewscenarios(matrix, firstLength, secondLength);

            //row
            for (int i = 1; i <= firstLength; i++)
            {
                //column
                for (int j = 1; j <= secondLength; j++)
                {
                    if (FristString[i] == SecondeString[j])
                    {
                        matrix[i, j] = matrix[i - 1, j - 1] + 1;
                    }else
                    {
                        matrix[i, j] = Math.Max(matrix[i, j - 1], matrix[i - 1, j]);
                    }
                }
            }

            return "OK";
        }


        private int[,] initializeFIrstFewscenarios(int[,] matrix, int firstLength, int secondLength)
        {
            //if non is included the length is all 0

            for (int i = 0; i <= firstLength; i++)
            {
                matrix[i, 0] = 0;
            }

            for (int i = 0; i <= secondLength; i++)
            {
                matrix[0, i] = 0;
            }

            return matrix;

        }
    }

}
