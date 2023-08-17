using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace AlgorithsPractise.LeetcodeBlind75
{
    public class ProductOfSelfArray
    {
        public int[] OutPutArray { get; set; }
        public int[] InputArray { get; set; }
        public int Length { get; set; }
        public ProductOfSelfArray()
        {
            InputArray = new[] { 1, 2, 3, 4 };
            Length = InputArray.Length;
            OutPutArray = new int[Length];
        }

        public void ProductOfArrayExceptSelf()
        {
            var preFix = 1;
            var postFix = 1;
            for (int i = 0; i < Length; i++)
            {
                OutPutArray[i] = preFix;

                preFix *= InputArray[i];
            }
            for (int i = Length - 1; i < 0; i--)
            {
                OutPutArray[i] *= postFix;

                postFix *= InputArray[i];
            }

            foreach (var iw in OutPutArray)
            {
                Console.WriteLine(iw);
            }

        }
    }
}
