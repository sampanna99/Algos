using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;

namespace AlgorithsPractise
{
    public class CanConstructMemo
    {
        public string Input { get; set; }

        public string[] ArrayOfWords { get; set; }

        public Dictionary<string, bool> Memo { get; set; }
        public CanConstructMemo()
        {
            this.Input = "abcdef";
            this.ArrayOfWords = new string[] { "ab", "abc", "cd", "def", "abcd" };
            Memo = new Dictionary<string, bool>();
        }

        public bool CanConstructThis(string inputThatisSent)
        {
            if (inputThatisSent == null)
            {
                inputThatisSent = Input;
            }
            if (inputThatisSent == "")
            {
                return true;
            }

            if (Memo.ContainsKey(inputThatisSent))
            {
                return Memo[inputThatisSent];
            }

            foreach (var arrayOfWord in ArrayOfWords)
            {
                if (inputThatisSent.IndexOf(arrayOfWord, StringComparison.Ordinal) == 0)
                {
                    var Suffix = inputThatisSent.Substring(arrayOfWord.Length);
                    if (CanConstructThis(Suffix))
                    {
                        Memo.Add(inputThatisSent, true);
                        return true;
                    }

                }
            }
            Memo.Add(inputThatisSent, false);
            return false;
        }
    }
}
