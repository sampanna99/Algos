using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithsPractise.LeetcodeBlind75
{
    public class AlienDictionary
    {
        public string[] ArrayGiven { get; set; }
        public Dictionary<string, HashSet<string>> Values { get; set; }
        public HashSet<string> ReturnThisString { get; set; }

        public AlienDictionary()
        {
            ArrayGiven = new[] { "wrt", "wrf", "er", "ett", "rftt" };
            Values = new Dictionary<string, HashSet<string>>();
            ReturnThisString = new HashSet<string>();
        }

        public void InitializeDictionaries()
        {
            foreach (var s in ArrayGiven)
            {
                foreach (var schar in s)
                {
                    if (!Values.ContainsKey(schar.ToString()))
                    {
                        Values.Add(schar.ToString(), new HashSet<string>());
                    }   
                }
            }
        }

        public void IterateAddItToDictionaryFirstDiffering()
        {
            for (int i = 1; i < ArrayGiven.Length; i++)
            {
                //find the minumum between two
                var iterateUpto = ArrayGiven[i].Length > ArrayGiven[i - 1].Length
                    ? ArrayGiven[i].Length
                    : ArrayGiven[i - 1].Length;

                for (int j = 0; j < iterateUpto - 1; j++)
                {
                    if (ArrayGiven[i][j] != ArrayGiven[i-1][j])
                    {
                        //Add i- 1 in the dictionary
                        var valueOfThat = Values[ArrayGiven[i - 1][j].ToString()];
                        valueOfThat.Add(ArrayGiven[i][j].ToString());
                    }
                }
            }
        }

        public string FindOneTOStart()
        {
            //return "r";
            string valueToRecurse = "";
            foreach (var value in Values)
            {
                var valFirstToTake = value.Key;
                valueToRecurse = valFirstToTake;
                break;
            }

            return valueToRecurse;

        }

        public string THeactualString(string startWith)
        {
            var Value = Values[startWith];

            if (Value == null || Value.Count == 0)
            {
                //that means it is the dead last.
                return null;
            }

            var firstOne = "";
            foreach (var hashValue in Value)
            {
                firstOne = hashValue;

                THeactualString(hashValue);
                ReturnThisString.Add(hashValue);
            }
            
            return THeactualString(firstOne);


            return "OK";
        }

        public string CorrectOrder()
        {
            InitializeDictionaries();
            IterateAddItToDictionaryFirstDiffering();
            var startWith = FindOneTOStart();
            THeactualString(startWith);
            ReturnThisString.Add(startWith);

            return "";
        }

    }
}
