using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace AlgorithsPractise.LeetcodeBlind75
{
    public class WordBreak
    {
        public string[] Dictionary { get; set; }

        public string ActualWord { get; set; } = "leetcode";
        public WordBreak()
        {
            Dictionary = new[] { "leet", "code" };
        }

        public void WordBrk()
        {
            FindIfPresent(0, new List<int>());
        }

        public bool FindIfPresent(int nextIndex, List<int> FoundOnthatIndex)
        {
            if (ActualWord.Length - 1 == nextIndex)
            {
                if (!Dictionary.Contains(ActualWord))
                {
                    return FoundUpto(nextIndex, FoundOnthatIndex);
                }
                else
                {
                    return true;
                }
            }
            else
            {
                if (Dictionary.Contains(ActualWord.Substring(0, nextIndex + 1)))
                {
                    FoundOnthatIndex.Add(nextIndex);
                }
                else
                {
                    var foundInThis = FoundUpto(nextIndex, FoundOnthatIndex);
                    if (foundInThis)
                    {
                        FoundOnthatIndex.Add(nextIndex);
                    }
                }
                return FindIfPresent(nextIndex + 1, FoundOnthatIndex);
            }
        }

        private bool FoundUpto(int index, List<int> FoundOnthatIndex)
        {
            var returnThis = false;
            var lastindex = 0;

            foreach (var i in FoundOnthatIndex)
            {
                var length = index - lastindex;
                var substringThere = ActualWord.Substring(lastindex + 1, length);
                if (Dictionary.Contains(substringThere))
                {
                    returnThis = true;
                    break;
                }
            }

            return returnThis;
        }
    }
}
