using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithsPractise.LeetCode_Eric.Phase6
{
    public class HashTables
    {
        public class SubarraySumEqualsK
        {
            public int[] GivenArray { get; set; }

            public int SumToMake { get; set; }
            public SubarraySumEqualsK()
            {
                
            }

            public void Algorithmn()
            {
                //go through to create a prefix sum add it to the hash

                var i = 0;
                var numberOfSums = 0;
                var sumUpto = new Dictionary<int, int>();
                sumUpto.Add(0,1);

                var sumPref = 0;
                while (i < GivenArray.Length)
                {
                    var value = GivenArray[i];
                    var totalSUm = sumPref + value;
                    var atotalThere = 
                        sumUpto.ContainsKey(totalSUm) ? sumUpto[totalSUm] += 1 : sumUpto[totalSUm] = 1;
                    var remaining = totalSUm - SumToMake;
                    if (sumUpto.ContainsKey(remaining))
                    {
                        numberOfSums += sumUpto[remaining];
                    }
                }

            }
        }
    }
}
