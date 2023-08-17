using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithsPractise.LeetcodeBlind75
{
    public class MinimumInRotatedArray
    {
        public int[] IntNums { get; set; }

        public MinimumInRotatedArray()
        {
            IntNums = new[] { 3, 4, 5, 1, 2 };
        }

        public void Minimum(int [] array)
        {
            var midVal = (array.Length + 1) / 2;
            var index = midVal - 1;

            if (array.Length == 2)
            {
                Console.WriteLine($"The minimum value is: {Math.Min(array[0], array[1])}");
                return;
            }
            //if (index == 0)
            //{
            //    Console.WriteLine("Found and value is " + array[index]);
            //}
            else
            {
                if (array[0] > array[index])
                {
                    //go left
                    var newarra = array[0..index];
                    Minimum(newarra);
                }else if (array[^1] < array[index])
                {
                    //go right
                    var newarra = array[index..^1];
                    Minimum(newarra);
                }
            }
        }
    }
}
