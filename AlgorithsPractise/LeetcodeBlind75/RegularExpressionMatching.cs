using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithsPractise.LeetcodeBlind75
{
    public class RegularExpressionMatching
    {
        public string StringToMatch { get; set; } = "aab";
        public string Pattern { get; set; } = "c*a*b";

        public Dictionary<Tuple<int, int>, bool> Dictionary;
        public RegularExpressionMatching()
        {
            Dictionary = new Dictionary<Tuple<int, int>, bool>();
        }

        public bool MatchRegularExpression(int indexOfString, int indexOfPattern)
        {
            //taking the value if * taking any value . and taking just that

            if (indexOfPattern >= Pattern.Length && indexOfString >= StringToMatch.Length)
            {
                return true;
            }else if (indexOfPattern >= Pattern.Length && indexOfString < StringToMatch.Length)
            {
                return false;
            }

            var tuple = Tuple.Create(indexOfString, indexOfPattern);
            if (Dictionary.ContainsKey(tuple))
            {
                return Dictionary[tuple];
            }
            // if string is 
            var patternVal = Pattern[indexOfPattern];
            var stringToMatchVal = indexOfString >= StringToMatch.Length ?
                StringToMatch[indexOfString] : Char.MinValue;
            char nextVal = '0';
            if (indexOfPattern < Pattern.Length - 1)
            {
                nextVal = Pattern[indexOfPattern + 1];
            }

            if (nextVal != '0')
            {
                if (nextVal == '*')
                {
                    //take or don't take
                    //some checks apply here.

                    var takeingIt = false;
                    if (patternVal == stringToMatchVal)
                    {
                        takeingIt = MatchRegularExpression(indexOfString + 1, indexOfPattern);
                    }

                    if (takeingIt)
                    {
                        Dictionary.Add(Tuple.Create(indexOfString, indexOfPattern), takeingIt);
                        return takeingIt;
                    }
                    var notTakeIt = MatchRegularExpression(indexOfString, indexOfPattern + 2);
                    Dictionary.Add(Tuple.Create(indexOfString, indexOfPattern), notTakeIt);
                    return notTakeIt;
                }
                if (nextVal == '.')
                {
                    //have to take the current value and move
                    var returnVal = false;
                    if (patternVal == stringToMatchVal)
                    {
                        returnVal = MatchRegularExpression(indexOfString + 1, indexOfPattern + 1);
                    }
                    Dictionary.Add(Tuple.Create(indexOfString, indexOfPattern), returnVal);
                    return returnVal;

                }
                else
                {
                    //regular string
                    var returnVal = false;
                    if (patternVal == stringToMatchVal)
                    {
                        returnVal = MatchRegularExpression(indexOfString + 1, indexOfPattern + 1);
                    }
                    Dictionary.Add(Tuple.Create(indexOfString, indexOfPattern), returnVal);
                    return returnVal;
                }
            }
            else
            {
                var returnVal = false;
                if (patternVal == stringToMatchVal)
                {
                    returnVal = MatchRegularExpression(indexOfString + 1, indexOfPattern + 1);
                }
                Dictionary.Add(Tuple.Create(indexOfString, indexOfPattern), returnVal);
                return returnVal;
            }
        }
    }
}
