using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgorithsPractise.LeetcodeBlind75
{
    public class GroupAnagrams
    {
        public string[] ArrayOfStrings { get; set; }

        public GroupAnagrams()
        {
            ArrayOfStrings = new[] { "eat", "tea, tan", "ate", "nat", "bat" };
        }

        public void GetAnagrams()
        {
            var dictionary = new Dictionary<string, List<string>>();


            foreach (var arrayOfString in ArrayOfStrings)
            {
                var getSorted = GetSorted(arrayOfString);

                if (dictionary.ContainsKey(getSorted))
                {
                    dictionary[getSorted].Add(arrayOfString);
                }
                else
                {
                    dictionary.Add(getSorted, new List<string>{arrayOfString});
                }
            }

            //https://stackoverflow.com/questions/197059/convert-dictionary-values-into-array
            var returnThis = dictionary.Values.ToArray();
        }

        //quickSort
        private string GetSorted(string valueToSort)
        {
            //
            var characterArray = valueToSort.ToCharArray();
            var length = characterArray.Length;
            var (mid, remainder) = (length / 2, length % 2);
            QuickSort(characterArray, 0, characterArray.Length - 1);

            return new string(characterArray);
        }

        private void QuickSort(char[] arrayOfChar, int startIndex, int endIndex)
        {
            if (startIndex == endIndex || startIndex < endIndex)
            {
                return;
            }

            var partitionIndex = GetPartitionIndex(arrayOfChar, startIndex, endIndex);
            QuickSort(arrayOfChar, startIndex, partitionIndex - 1);
            QuickSort(arrayOfChar, partitionIndex - 1, endIndex);
        }

        private int GetPartitionIndex(char[] array, int startIndex, int EndIndex)
        {
            var pivot = array[EndIndex];
            var partitionIndex = startIndex;

            for (int i = startIndex; i < EndIndex - 1; i++)
            {
                if ((int)pivot > (int)array[i])
                {
                    //swap with partition Index
                    //var temp = array[partitionIndex];
                    //array[partitionIndex] = array[i];
                    //array[i] = temp;

                    (array[partitionIndex], array[i]) = (array[i], array[partitionIndex]);
                    partitionIndex += 1;
                }
            }
            (array[partitionIndex], array[EndIndex]) = (array[EndIndex], array[partitionIndex]);
            return partitionIndex;

        }

    }
}
