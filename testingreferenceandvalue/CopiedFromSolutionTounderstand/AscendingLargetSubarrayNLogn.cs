using System;
using System.Collections.Generic;
using System.Text;

namespace testingreferenceandvalue.CopiedFromSolutionTounderstand
{
    public class AscendingLargetSubarrayNLogn
    {
        public delegate void aaaa();

        public void testdelegate()
        {
            Console.WriteLine("OK");
        }
        public void testdelegate1()
        {
            Console.WriteLine("NotOK");
        }

        public void mainone()
        {
            aaaa fds = testdelegate;
            fds += testdelegate;
            var ddf = new aaaa(testdelegate); //another way
            aaaa ddf1 = () => { Console.WriteLine("Ok"); }; //another way
            aaaa dasdf = testdelegate;
            fds = testdelegate1;
            fds += testdelegate1;
            dasdf.Invoke();
        }

        public aaaa delegatereturntype()
        {
            return () =>
            {
                Console.WriteLine("OK");
            };
        }
        static int CeilIndex(int[] A, int l,
            int r, int key)
        {

            //NumberofItemsintailtable. Unnecessarily complicated. or maybenot as it uses m.
            while (r - l > 1)
            {
                int m = l + (r - l) / 2;

                if (A[m] >= key)
                    r = m;
                else
                    l = m;
            }

            return r;
        }

        public static int LongestIncreasingSubsequenceLength(
            int[] A, int size)
        {

            // Add boundary case, when array size
            // is one

            int[] tailTable = new int[size];
            int len; // always points empty slot
            //int[] A = { 2, 5, 3, 7, 11, 8, 10, 13, 6 };

            tailTable[0] = A[0];
            len = 1;
            for (int i = 1; i < size; i++)
            {
                if (A[i] < tailTable[0])
                    // new smallest value
                    tailTable[0] = A[i];

                else if (A[i] > tailTable[len - 1])

                    // A[i] wants to extend largest
                    // subsequence
                    tailTable[len++] = A[i];

                else

                    // A[i] wants to be current end
                    // candidate of an existing
                    // subsequence. It will replace
                    // ceil value in tailTable
                    tailTable[CeilIndex(tailTable, -1,
                            len - 1, A[i])]
                        = A[i];
            }
            return len;
        }


        //TODO: https://www.youtube.com/watch?v=1RpMc3fv0y4
        //TODO: I like this one better.
        public static void LIS(int [] X)
        {
            //int[] tailTable = new int[size];

            int[] parent = new int[X.Length]; //Tracking the predecessors/parents of elements of each subsequence.
            int [] increasingSub = new int[X.Length + 1]; //Tracking ends of each increasing subsequence.
            int length = 0; //Length of longest subsequence.
            //int[] X = { 3, 1, 5, 0, 6, 4, 9, 10, 7, 0, 20, 13, 11, 12 };

            for (int i = 0; i < X.Length; i++)
            {
                //Binary search
                int low = 1;
                int high = length;
                while (low <= high)
                {
                    decimal aaa = (low + high) / 2;
                    int mid = (int)Math.Ceiling(aaa);
                    //int mid = (int)Math.Ceil((low + high) / 2);

                    if (X[increasingSub[mid]] < X[i])
                        low = mid + 1;
                    else
                        high = mid - 1;
                }

                int pos = low;
                //update parent/previous element for LIS
                parent[i] = increasingSub[pos - 1];
                //Replace or append
                increasingSub[pos] = i;

                //Update the length of the longest subsequence.
                if (pos > length)
                    length = pos;
            }

            //Generate LIS by traversing parent array
            int [] LIS = new int[length];
            int k = increasingSub[length];
            for (int j = length - 1; j >= 0; j--)
            {
                LIS[j] = X[k];
                k = parent[k];
            }


            for (int i = 0; i < length; i++)
            {
                Console.WriteLine(LIS[i]);
            }


        }

        public static void Myself(int[] input)
        {
            //int[] X = { 3, 1, 5, 0, 6, 4, 9 };

            //Array increasingorder = Array.Empty<int>();
            int[] increasingorder = new int[input.Length];
            //int[] increasingorder = new int[]
            //int[] parentchildrelation = new int[input.Length];
            Dictionary<int, int> parentchildrelation = new Dictionary<int, int>();
            int length = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (i == 0)
                {
                    increasingorder[i] = input[i];
                    length++;
                }
                else
                {
                    //check 
                    var indexToputThisAt = FindWheretoPut(input, input[i], increasingorder, length);

                    increasingorder[indexToputThisAt] = input[i];
                    if (length <= indexToputThisAt)
                    {
                        length++;
                    }
                    if (indexToputThisAt == 0)
                    {
                        if (parentchildrelation.ContainsKey(input[i]))
                        {
                            continue;
                        }
                        else
                        {
                            parentchildrelation.Add(input[i], 0);
                        }
                    }
                    else
                    {
                        if (parentchildrelation.ContainsKey(input[i]))
                        {
                            continue;
                        }

                        parentchildrelation.Add(input[i], increasingorder[indexToputThisAt - 1]);

                    }
                }
            }

            Console.WriteLine("Let's Examine");

        }

        private static int FindWheretoPut(int [] input, int whereToPutThis, int [] inregardsToThisArray, int length, int startindex = 0)
        {

            if (length - startindex <= 1)
            {
                // this is breaking case;
                if (whereToPutThis < inregardsToThisArray[length - 1])
                {
                    //put here
                    return startindex;
                }
                else
                {
                    //put in startindex
                    return length;

                }
            }
            decimal des = (startindex + length) / 2;
            var mid = (int)Math.Ceiling(des);
            if (inregardsToThisArray[mid - 1] > whereToPutThis)
            {
                //left
                return FindWheretoPut(input, whereToPutThis, inregardsToThisArray, mid, startindex);
            }
            else
            {
                //right
                return FindWheretoPut(input, whereToPutThis, inregardsToThisArray, length, mid);
            }


            //int putinThisIndex = 0;

            //foreach (var eachItem in inregardsToThisArray)
            //{
            //    if (eachItem > whereToPutThis)
            //    {
            //        putinThisIndex = eachItem;
            //        break;
            //    }
            //}

            //return Array.IndexOf(inregardsToThisArray, putinThisIndex);

        }
    }
}
