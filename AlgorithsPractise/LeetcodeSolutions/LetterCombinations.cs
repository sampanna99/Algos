using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithsPractise.LeetcodeSolutions
{
    public class LetterCombinations
    {
        public Queue<string> OutputList2 { get; set; }
        public string[] NumsToAlphabet { get; set; }
        public string NumberCombination { get; set; } = "23";
        public LetterCombinations()
        {
            NumsToAlphabet = new[] { "0", "1", "abc", "def", "ghi", "jkl", "mno", "pqrs", "tuv", "wxyz" };
            OutputList2 = new Queue<string>();
            OutputList2.Enqueue("");
        }

        public void Algorithmn()
        {
            for (int i = 0; i < NumberCombination.Length; i++)
            {
                var outputList = OutputList2.Dequeue();
                var length = outputList.Length;

                while (OutputList2.Peek().Length == length)
                {
                    var getValueForNum = NumsToAlphabet[(int)NumberCombination[i]];

                    for (int j = 0; j < getValueForNum.Length; j++)
                    {
                        OutputList2.Enqueue(outputList + getValueForNum[j]);
                    }
                }
            }
        }
    }
}
