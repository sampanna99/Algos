using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithsPractise.LeetcodeSolutions
{
    public class ThreeSum
    {
        public int[] ArrayOfNum { get; set; }
        public int Sum { get; set; } = 0;

        public ThreeSum()
        {
            ArrayOfNum = new[] { -1, 0, 1, 2, -1, -4 };
        }


        public void Algorithm()
        {
            SortIt(0, ArrayOfNum.Length - 1);
            var listOfResults = new List<List<int>>();

            for (int i = 0; i < ArrayOfNum.Length - 1; i++)
            {
                if (ArrayOfNum[i] != ArrayOfNum[i - 1])
                {
                    //see if it makes the sum
                    var low = i + 1;
                    var high = ArrayOfNum.Length - 1;
                    var sumRemaining = Sum - ArrayOfNum[i];

                    while (low < high)
                    {
                        if (ArrayOfNum[low] + ArrayOfNum[high] == sumRemaining)
                        {
                            listOfResults.Add(new List<int> { ArrayOfNum[i], ArrayOfNum[low], ArrayOfNum[high] });


                            while (low < high && (ArrayOfNum[low] == ArrayOfNum[low + 1]))
                            {
                                low++;
                            }

                            while (low < high && (ArrayOfNum[high] == ArrayOfNum[high - 1]))
                            {
                                high--;
                            }
                            low++;
                            high--;
                        }
                        else if(ArrayOfNum[low] + ArrayOfNum[high] > sumRemaining)
                        {
                            high--;
                        }
                        else
                        {
                            low++;
                        }

                    }
                }
            }
        }

        public void SortIt(int startIndex, int endIndex)
        {
            if (startIndex < endIndex)
            {
                var findThepartitionLocation = MidLocationWhichIsSorted(startIndex, endIndex);
                SortIt(startIndex, findThepartitionLocation - 1);
                SortIt(findThepartitionLocation + 1, endIndex);
            }
        }

        private int MidLocationWhichIsSorted(int startIndex, int endIndex)
        {
            var theValue = ArrayOfNum[endIndex];
            var partitionIndex = startIndex;

            while (startIndex < endIndex)
            {
                if (ArrayOfNum[startIndex] < theValue)
                {
                    //swap
                    (ArrayOfNum[partitionIndex], ArrayOfNum[startIndex]) = 
                        (ArrayOfNum[startIndex], ArrayOfNum[partitionIndex]);

                    partitionIndex++;
                }

                startIndex++;
            }

            (ArrayOfNum[endIndex], ArrayOfNum[partitionIndex]) =
                (ArrayOfNum[partitionIndex], ArrayOfNum[endIndex]);

            return partitionIndex;
        }
    }
}
