using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithsPractise.LeetcodeBlind75
{
    public class AlienDictionary2
    {
        public string[] ArrayOfGivenWords { get; set; }

        public Dictionary<string, HashSet<string>> AdjacencyList { get; set; }

        public Dictionary<string, bool> VisitedSets { get; set; }

        public AlienDictionary2()
        {
            AdjacencyList = new Dictionary<string, HashSet<string>>();
            VisitedSets = new Dictionary<string, bool>();
            ArrayOfGivenWords = new[] { "wrt", "wrf", "er", "ett", "rftt" };
        }

        public void CheckTwoWords()
        {
            //check two words
            for (int i = 0; i < ArrayOfGivenWords.Length - 1; i++)
            {
                var toContinue = true;
                var firstOne = ArrayOfGivenWords[i];
                var secondOne = ArrayOfGivenWords[i + 1];

                var minLength = Math.Min(ArrayOfGivenWords[i].Length, ArrayOfGivenWords[i + 1].Length);
                    for (int j = 0; j < minLength; j++)
                    {
                        if (firstOne[j] != secondOne[j])
                        {
                            var key = firstOne[j].ToString();
                            var value = secondOne[j].ToString();
                            if (AdjacencyList.ContainsKey(key))
                            {
                                AdjacencyList[key].Add(value);
                            }
                            else
                            {
                                AdjacencyList.Add(key, new HashSet<string>{value});
                            }
                        }
                    }
            }
        }

        public string DFS(string alphabet)
        {
            if (VisitedSets.ContainsKey(alphabet))
            {
                if (VisitedSets[alphabet] == true)
                {
                    //loop
                    return null;
                }
                else
                {
                    return "";
                }
            }
            if (AdjacencyList.ContainsKey(alphabet))
            {
                var valuesForthat = AdjacencyList[alphabet];
                VisitedSets.Add(alphabet, true);

                var stringToreturn = "";
                foreach (var eachValue in valuesForthat)
                {
                    var Dfsreturn = DFS(alphabet);
                    if (Dfsreturn == null)
                    {
                        stringToreturn = null;
                        break;
                    }
                    stringToreturn += Dfsreturn;
                }

                VisitedSets[alphabet]  = false;

                return stringToreturn != null ? alphabet + stringToreturn : stringToreturn;
            }
            else
            {
                return alphabet;
            }
        }
    }
}
