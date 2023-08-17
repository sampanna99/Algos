using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithsPractise
{
    //HARD
    //NOTCOMPLETE
    //https://stackoverflow.com/questions/9468950/cut-a-string-with-a-known-start-end-index
    public class WildCardMatching
    {
        public string Pattern { get; set; }
        public string WordToMatch { get; set; }

        public WildCardMatching()
        {
            Pattern = "?a";
            WordToMatch = "cb";
        }


        private bool[,] initializeMatrixForDP(bool[,] matrix)
        {

            //0,0 is true as ntn in pattern and ntn in word are both matching
            //0,* could get a lil tricky for * as it would be the previous value others all false
            //*,0 is all false
            //https://stackoverflow.com/questions/9404683/how-to-get-the-length-of-row-column-of-multidimensional-array-in-c
            matrix[0, 0] = true;
            //Not needed as it is initialized as false
            //for (int i = 1; i < matrix.GetLength(0); i++)
            //{
            //    matrix[i, 0] = 
            //}
            for (int i = 1; i < matrix.GetLength(1); i++)
            {
                if (Pattern.Substring(i,1) == "*")
                {
                    matrix[0, i] = matrix[0, i - 1];
                }
            }

            return matrix;
        }
        public bool IsMatch()
        {
            var lengthofword = WordToMatch.Length;
            var patternLength = Pattern.Length;

            //to cover for the case when no pattern is given and no letter in word
            bool[,] matrixForPatternAndWOrd = new bool[lengthofword + 1, patternLength + 1];



            return false;
        }
    }
}
