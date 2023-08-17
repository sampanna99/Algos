using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithsPractise.LeetcodeBlind75
{
    class LongestRepeatingCharacter
    {
        public int NumberOfReplace { get; set; }

        public string Word { get; set; }

        public LongestRepeatingCharacter()
        {
            NumberOfReplace = 2;
            Word = "ABABBA";
        }

        public void GoThroughThemAll()
        {
            var (startIndex, endIndex, longest) = (0, 0, Tuple.Create(Word[0].ToString()
                , 1));
            var longestValid = 0;
            var dictionary = new Dictionary<string, int>();

            while (endIndex < Word.Length)
            {
                var lengthOfSubstring = endIndex - startIndex + 1;
                var wordVal = Word[endIndex].ToString();
                if (dictionary.ContainsKey(wordVal))
                {
                    dictionary[wordVal] += 1;
                }
                else
                {
                    dictionary[wordVal] = 1;
                }


                if ((lengthOfSubstring - longest.Item2) <= NumberOfReplace)
                {
                    //valid
                    if (dictionary[wordVal] > longest.Item2)
                    {
                        longest = Tuple.Create(wordVal, dictionary[wordVal]);
                    }

                    endIndex += 1;
                    if (longestValid < lengthOfSubstring)
                    {
                        longestValid = lengthOfSubstring;
                    }

                }
                else
                {
                    var wordAtStart = Word[startIndex].ToString();
                    dictionary[wordAtStart] -= 1;
                    startIndex += 1;
                }

            }
        }
    }
}
