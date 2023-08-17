using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace AlgorithsPractise
{
    public class WordLadder
    {

        //COMPLETE
        //BFS.
        public string beginWord { get; set; }

        public string endWord { get; set; }
        public string[] wordList { get; set; }
        public HashSet<string> wordListSet { get; set; }
        public WordLadder()
        {
            beginWord = "hit";
            endWord = "cog";

            wordList = new string[] { "hot", "dot", "dog", "lot", "log", "cog" };
            //var list = new string[] { "hot", "dot", "dog", "lot", "log", "cog" };
            wordListSet = new HashSet<string>(wordList);
        }

        public int shortestDIstance()
        {

            Queue queue = new Queue();
            var depthSizee = 0;

            queue.Enqueue(beginWord);
            var lSize = 0;
            var lsizeCurrentProcessing = 1;
            while (queue.Count != 0)
            {
                //lSize = lSize - 1;
                var deque = queue.Dequeue().ToString();

                if (lsizeCurrentProcessing == 0)
                {
                    depthSizee++;
                    lsizeCurrentProcessing = lSize;
                    lSize = 0;
                    //lSize++;
                }

                lsizeCurrentProcessing--;
                var lengthOfWord = deque.Length;


                for (int j = 0; j < lengthOfWord; j++)
                {
                    var dequeChar = deque[j];
                    for (char i = 'a'; i <= 'z'; i++)
                    {
                        if (i == dequeChar)
                        {
                            continue;
                        }

                        var newWord = "";
                        newWord = deque.Remove(j, 1);
                        newWord = newWord.Insert(j, i.ToString());

                        if (newWord == endWord)
                        {
                            Console.WriteLine("depth at");
                            return 2 + depthSizee;
                            //break here.
                        }
                        if (wordListSet.Contains(newWord))
                        {
                            queue.Enqueue(newWord);
                            wordListSet.Remove(newWord);

                            lSize += 1;
                        }
                    }
                }

            }

            return depthSizee;
        }
    }
}
