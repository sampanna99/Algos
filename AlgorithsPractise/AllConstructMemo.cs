using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithsPractise
{
   public class AllConstructMemo
    {
        public string Word { get; set; }
        public string[] ArrayOfWords { get; set; }
        public AllConstructMemo()
        {
            Word = "purple";
            ArrayOfWords = new string[] { "purp", "p", "ur", "le", "purpl" };
        }

        public List<List<string>> GetAllConstruct(string inputThatIasaSentRecursive)
        {
            if (inputThatIasaSentRecursive == null)
            {
                inputThatIasaSentRecursive = Word;
            }

            if (inputThatIasaSentRecursive == "")
            {
                return null;
            }
            var result = new List<List<string>>();

            foreach (var arrayOfWord in ArrayOfWords)
            {
                if (inputThatIasaSentRecursive.IndexOf(arrayOfWord) == 0)
                {
                    var Suffix = inputThatIasaSentRecursive.Substring(arrayOfWord.Length);
                    var suffixways = GetAllConstruct(Suffix);

                    //var newList = new List<string>();

                    if (suffixways == null)
                    {
                        
                        var newList = new List<string>();
                        newList.Add(arrayOfWord);

                        result.Add(newList);
                    }
                    else
                    {
                        foreach (var onEachList in suffixways)
                        {
                            onEachList.Add(arrayOfWord);
                            result.Add(onEachList);
                        }

                    }

                }

            }

            return result;
        }
    }
}
