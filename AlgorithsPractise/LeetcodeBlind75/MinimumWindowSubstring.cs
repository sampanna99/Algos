using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithsPractise.LeetcodeBlind75
{
    public class MinimumWindowSubstring
    {
        public string Stringgiven { get; set; }
        public string ToFind { get; set; }

        public MinimumWindowSubstring()
        {
            Stringgiven = "ADOBECODEBANC";
            ToFind = "ABC";
        }

        public void MinimumWindow()
        {
            var hashset = new HashSet<string>();
            foreach (var each in ToFind)
            {
                hashset.Add(each.ToString());
            }

            var need = hashset.Count;
            var dictionary = new Dictionary<string, int>();
            var (startIndex, endIndex, isValid, longeststart, 
                longestend, have) = (0, 0, false,0,0, 0);

            //while ((endIndex < Stringgiven.Length || ) && 
            //       startIndex < Stringgiven.Length - ToFind.Length)
            //{
                
            //}
            
            while (endIndex < Stringgiven.Length - 1 && !isValid)
            {
                if (need == have)
                {
                    if (longestend - longeststart > endIndex - startIndex)
                    {
                        (longeststart, longestend) = (startIndex, endIndex);
                    }
                    isValid = true;
                    while (startIndex < endIndex && isValid)
                    {
                        var charatfirst = Stringgiven[startIndex].ToString();
                        if (hashset.Contains(charatfirst) && dictionary.ContainsKey(charatfirst))
                        {
                            if (dictionary[charatfirst] == 1)
                            {
                                dictionary.Remove(charatfirst);
                                have -= 1;
                                if (have != need)
                                {
                                    isValid = false;
                                    endIndex += 1;
                                    break;
                                }
                            }
                            else
                            {
                                dictionary[charatfirst] -= 1;
                            }
                        }
                        startIndex += 1;
                    }
                }
                else
                {
                    var charatend = Stringgiven[endIndex].ToString();
                    if (dictionary.ContainsKey(charatend))
                    {
                        dictionary[charatend] += 1;
                    }
                    else
                    {
                        have += 1;
                        dictionary.Add(charatend, 1);
                    }

                    if (have != need)
                    {
                        endIndex += 1;
                    }
                }
                
            }
        }
    }
}
