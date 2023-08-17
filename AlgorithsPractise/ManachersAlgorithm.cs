using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace AlgorithsPractise
{
    //palindrome longest
    public class ManachersAlgorithm
    {
        public string StringToLookAt { get; set; }
        public string StringToLookAtModified { get; set; }

        public ManachersAlgorithm()
        {
            StringToLookAt = "ABABABA";
            StringToLookAtModified = "#";
            foreach (char c in StringToLookAt)
            {
                StringToLookAtModified += c;
            }

            StringToLookAtModified += "@";

            int[] test = new int[StringToLookAtModified.Length];

        }

        public int LongestPalindrome()
        {
            //I need the following
            //center
            //start index
            //end Index for that center


            //start with the first letter in the string

            var bigcenter = 0;
            var bigstartindex = 0;
            var endIndex = 0;

            var lengtharray = new int[StringToLookAtModified.Length];
            var stringToarray = StringToLookAtModified.ToCharArray();

            //i being center
            //for (int i = 0; i < StringToLookAtModified.Length / 2; i++)
            //{


            //    if (StringToLookAtModified[i - 1] == StringToLookAtModified[i + 1])
            //    {
            //        longestTillNow += 2;
            //    }
            //}

            for (int i = 0; i < stringToarray.Length; i++)
            {
                if (i == 0)
                {
                    lengtharray[i] = 1;
                    continue;
                }


                var actualI = i;
                while (endIndex > i)
                {
                    if (i == actualI )
                    {
                        i++;
                        continue;

                    }
                    var difference = i - actualI;
                    var valueAtThatIndex = StringToLookAtModified[actualI - difference];
                    i++;
                }
                //Now check if it extends to the right edge
                for (int j = actualI + 1; j < endIndex; j++)
                {
                    var valueAtActualI = lengtharray[j];
                }


                var startWiththisNum = 1;

                var left = i - startWiththisNum;
                var right = i + startWiththisNum;


                while (i - startWiththisNum >= 0
                       && startWiththisNum < (StringToLookAtModified.Length / 2)
                       && stringToarray[left] == stringToarray[right])
                {
                    lengtharray[i] = right - left + 1;
                }

                if (lengtharray[i] <= 0)
                {
                    lengtharray[i] = 1;
                }
            }

            return 0;

        }
    }
}
