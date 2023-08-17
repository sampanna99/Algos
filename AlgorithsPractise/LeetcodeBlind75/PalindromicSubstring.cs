using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithsPractise.LeetcodeBlind75
{
    public class PalindromicSubstring
    {
        public string StringToGet { get; set; }
        public int NumberOfPalindrome { get; set; }
        public PalindromicSubstring()
        {
            StringToGet = "aaab";
        }

        public string GetNumberOfSubstring()
        {
            for (int i = 0; i < StringToGet.Length - 1; i++)
            {
                //odd
                //NumberOfPalindrome += 1;
                IncreaseNumberOfPalindrome(i, i);
                //even
                if (i+1 < StringToGet.Length && StringToGet[i] == StringToGet[i + 1])
                {
                    //NumberOfPalindrome += 1;
                    IncreaseNumberOfPalindrome(i, i+1);
                }
            }

            Console.WriteLine($"Number of palindromic substring is {NumberOfPalindrome}");
            return "OK";
        }

        private void IncreaseNumberOfPalindrome(int stratIndexA, int startIndexB)
        {
            while (startIndexB <= StringToGet.Length - 1 && stratIndexA >= 0)
            {
                //check if they are equal
                if (StringToGet[stratIndexA] == StringToGet[startIndexB])
                {
                    NumberOfPalindrome += 1;
                }
                else
                {
                  break;  
                }

                startIndexB += 1;
                stratIndexA -= 1;
            }
        }
    }
}
