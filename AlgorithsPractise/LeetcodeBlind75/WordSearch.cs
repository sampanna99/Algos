using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithsPractise.LeetcodeBlind75
{
    public class WordSearch
    {
        public string[,] Matrix { get; set; }
        public string Word { get; set; } = "ABCCED";
        public WordSearch()
        {
            Matrix = new string[,]
            {
                { "A", "B", "C", "E" },
                { "S", "F", "C", "S" },
                { "A", "D", "E", "E" }
            };
        }

        public void GetValue()
        {

            for (int i = 0; i < Matrix.GetLength(0); i++)
            {
                for (int j = 0; j < Matrix.GetLength(1); j++)
                {
                    var value = i + "." + j;
                    var hashset = new HashSet<float> {(float)Convert.ToDecimal(value) };
                    DFS(hashset, new Tuple<int, int>(i, j),1);
                }
            }
        }

        private bool DFS(HashSet<float> inThisPath, Tuple<int, int> currentIndex, int whichIndexInWord)
        {
            var floatItem = (float)Convert.ToDecimal(currentIndex.Item1 + "." + currentIndex.Item2);
            if (inThisPath.Contains(floatItem) || currentIndex.Item1 < 0 || currentIndex.Item2 < 0
            || currentIndex.Item1 >= Matrix.GetLength(0) || currentIndex.Item2 >= Matrix.GetLength(1))
            {
                return false;
            }

            if (whichIndexInWord == Word.Length)
            {
                return true;
            }

            if (Word[whichIndexInWord].ToString() != Matrix[currentIndex.Item1, currentIndex.Item2])
            {
                return false;
            }

            var top = DFS(inThisPath, new Tuple<int, int>(currentIndex.Item1 - 1,
                currentIndex.Item2), whichIndexInWord + 1);
            if (top)
            {
                return true;
            }
            var bottom = DFS(inThisPath, new Tuple<int, int>(currentIndex.Item1 + 1,
                currentIndex.Item2), whichIndexInWord + 1);
            if (bottom)
            {
                return true;
            }
            var left = DFS(inThisPath, new Tuple<int, int>(currentIndex.Item1,
                currentIndex.Item2 - 1), whichIndexInWord + 1);
            if (left)
            {
                return true;
            }
            var right = DFS(inThisPath, new Tuple<int, int>(currentIndex.Item1,
                currentIndex.Item2 + 1), whichIndexInWord + 1);
            return right;
        }
    }
}
