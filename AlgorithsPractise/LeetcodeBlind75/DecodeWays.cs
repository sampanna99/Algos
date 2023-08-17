using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgorithsPractise.LeetcodeBlind75
{
    //A little bit remaining.
    public class DecodeWays
    {
        public string Number { get; set; }
        public Dictionary<string, List<string>> AllPossible { get; set; }
        public DecodeWays()
        {
            Number = "2263";
            AllPossible = new Dictionary<string, List<string>>();
        }


        public void AllDecodedValues()
        {
            var ans = AllValues(new Stack<string>());
        }
        public List<string> AllValues(Stack<string> valuesUpUntil)
        {
            //This line below should be changed as valuesUpUntil.Count isn't correct
            var valTostartfrom = GetCound(valuesUpUntil);
            if (valTostartfrom == Number.Length)
            {
                return new List<string>(valuesUpUntil);
            }

            valuesUpUntil.Push(Number[valTostartfrom].ToString());
            var stringwithAll = valuesUpUntil.ToArray();
            stringwithAll.Reverse();
            var oneIncuded = new List<string>();
            var stringForKey = String.Concat(stringwithAll);

            if (AllPossible.ContainsKey(stringForKey))
            {
                oneIncuded = AllPossible[stringForKey];
            }
            else
            {
                //check for pointer. oneIncluded is changed down. so this would be bad. Taken care of.
                oneIncuded = AllValues(valuesUpUntil);
                AllPossible[stringForKey] = new List<string>(oneIncuded);
            }
            valuesUpUntil.Pop();

            var twoIncluded = new List<string>();
            if (Number.Length - 1 <= valTostartfrom + 1)
            {
                //check if feasable

                var substring = Convert.ToInt32(Number.Substring(valTostartfrom, 2));
                if (substring <= 26)
                {
                    valuesUpUntil.Push(substring.ToString());
                    twoIncluded = AllValues(valuesUpUntil);
                }
            }
            oneIncuded.AddRange(twoIncluded);
            return oneIncuded;
        }

        private int GetCound(Stack<string> valuesUpUntil)
        {
            var length = 0;
            foreach (var vUU in valuesUpUntil)
            {
                length += vUU.Length;
            }

            return length;
        }
    }
}
