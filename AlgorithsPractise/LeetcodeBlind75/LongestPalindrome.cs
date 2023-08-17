 using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithsPractise.LeetcodeBlind75
{
    public class LongestPalindrome
    {
        public string StringGiven  { get; set; }

        public LongestPalindrome()
        {
            StringGiven = "babad";
        }

        public void LongestPalindromeAlgo()
        {
            //for odd
            var i = 0;
            var (left, right, longestString) = (i,i, "");
            FillMaximum(i, left, right, ref longestString); //odd
            FillMaximum(i, left, right + 1, ref longestString); //even
            Console.WriteLine($"Longest palindrome is {longestString}");

        }

        private string FillMaximum(int i, int left, int right, ref string longestString)
        {
            while (i < StringGiven.Length)
                //while (i < StringGiven.Length && left >= 0 && right < StringGiven.Length)
            {
                if (left >= 0 && right < StringGiven.Length && StringGiven[left] == StringGiven[right])
                {
                    if (longestString.Length > (right - left + 1))
                    {
                        longestString = StringGiven[left..right];
                        //longestString = StringGiven.Substring(left,)
                    }
                    left -= 1;
                    right += 1;

                }
                else
                {
                    i += 1;
                }
            }

            return longestString;
        }
    }
}


//