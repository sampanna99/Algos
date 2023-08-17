using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithsPractise.LeetcodeBlind75
{
    public class RotateImage
    {
        public int[,] Matrix { get; set; }

        public RotateImage()
        {
            Matrix = new[,]
            {
                { 5, 1, 9, 11 },
                {2,4,8,10 },
                {13,3,6,7},
                {15,14,12,16}
            };
        }

        public void Rotate()
        {
            var left = 0;
            var right = Matrix.GetLength(1) - 1;
            var top = 0;
            var bottom = Matrix.GetLength(0) - 1;

            while (left < right)
            {
                RotateReally(left, right, bottom, top);
                left += 1;
                right -= 1;
                top += 1;
                bottom -= 1;
            }

        }

        //hard coded BottomIndex
        public void RotateReally(int leftIndex, int rightIndex, int bottomIndex, int topIndex)
        {
            //L-->R
            //B -->T
            //rotate 4 times

            var leftTemp = leftIndex;

            for (int i = 0; i < rightIndex - leftIndex; i++)
            {


                (Matrix[topIndex + i, rightIndex], Matrix[bottomIndex, rightIndex - i],
                        Matrix[bottomIndex - i, leftIndex], Matrix[topIndex, leftIndex + i]) =
                    (Matrix[topIndex, leftIndex + i], Matrix[topIndex + i, rightIndex],
                        Matrix[bottomIndex, rightIndex - i], Matrix[bottomIndex - i, leftIndex]);
            }
        }
    }
}
