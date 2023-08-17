using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithsPractise
{

    //complete
    //two arrays gets 
    public class MergeSort
    {
        public int[] Array { get; set; }
        public MergeSort()
        {
            Array = new[] { 9, 3, 7, 5, 6, 4, 8, 2 };
        }


        private int[] Merge(int[] left, int [] right, int[] bigArray)
        {
            var lengthOfLeft = left.Length;
            var lengthOfright = right.Length;

            var k = 0;
            var i = 0;
            var j = 0;

            while (i < lengthOfLeft && j < lengthOfright)
            {
                if (left[i] <= right[j])
                {
                    bigArray[k] = left[i];
                    i++;
                }
                else
                {
                    bigArray[k] = right[j];
                    j++;
                }

                k++;
            }

            while (i < lengthOfLeft)
            {
                bigArray[k] = left[i];
                i++;
                k++;
            }
            while (j < lengthOfright)
            {
                bigArray[k] = right[j];
                j++;
                k++;
            }

            return null;
        }



        private void Sort(int [] array)
        {
            var length = array.Length;
            if (length < 2)
            {
                return;
            }

            var mid = Convert.ToInt32(Math.Floor(Convert.ToDouble(length / 2)));

            var leftArray = new int[mid]; //if length = 7; 3 + 1 = 4
            var rightArray = new int[length - mid]; //if length = 7 ; 7-3 = 4 

            for (int i = 0; i < mid; i++)
            {
                leftArray[i] = array[i];
            }

            for (int i = mid; i < length; i++)
            {
                rightArray[i - mid] = array[i];
            }
            //for (int i = 0; i < rightArray.Length; i++)
            //{
            //    rightArray[i] = array[mid + i];
            //}

            Sort(leftArray);
            Sort(rightArray);

            Merge(leftArray, rightArray, array);
        }

        public void DoMergeSort()
        {
            Sort(Array);

            for (int i = 0; i < Array.Length; i++)
            {
                Console.WriteLine(Array[i]);
            }
        }
    }
}
