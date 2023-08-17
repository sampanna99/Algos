using System;
using System.Collections.Generic;
using System.Text;

namespace testingreferenceandvalue.MycodeSchool
{
    public class CircularArray
    {

        public int CircularArraySearch(int[] Array, int n, int x)
        {
            int low = 0;
            int high = n - 1;
            while (low <= high)
            {
                int mid = (low + high) / 2;
                if (x == Array[mid]) return mid;
                if (Array[mid] <= Array[high])
                {
                    //that means it is sorted.
                    if (x > Array[mid] && x < Array[high])
                    {
                        low = mid + 1;
                    }
                    else
                    {
                        high = mid - 1;
                    }
                }
                else//(Array[low] <= A[mid]) // no ned to write this as it is implied
                {
                    if (x >= Array[low] && x < Array[mid])
                    {
                        high = mid - 1;
                    }
                    else
                    {
                        low = mid + 1;
                    }
                }
            }
            return -1;
        }
    }
}
