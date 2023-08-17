using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithsPractise.LeetcodeBlind75
{
    public class LongfestSubstringWithoutRepeating
    {
        public string Substring { get; set; }

        public HashSet<string> ForDupes { get; set; }
        public LongfestSubstringWithoutRepeating()
        {
            Substring = "abcabcbb";
            ForDupes = new HashSet<string>();
        }

        //sliding window techniquew
        public void FindLongestSub()
        {
            var startIndex = 0;
            var longest = 0;
            for (int i = 0; i < Substring.Length; i++)
            {
                var endIndex = i;
                var charTostr = Substring[i].ToString();

                while (ForDupes.Count > 0)
                {
                    if (ForDupes.Contains(charTostr))
                    {
                        var valueAtStarIn = Substring[startIndex].ToString();

                        ForDupes.Remove(valueAtStarIn);
                        startIndex = startIndex + 1;
                    }
                    else
                    {
                        break;
                    }
                }

                var value = endIndex - startIndex + 1;
                if ((value) > longest)
                {
                    longest = value;
                }
            }

            Console.WriteLine($"The longest subsequence is {longest}");
        }

    }
}
