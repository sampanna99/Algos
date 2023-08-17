using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithsPractise.LeetcodeBlind75
{
    public class JumpGame
    {
        public int[] ArrayGiven { get; set; }
        public Dictionary<int, bool> Dictionary { get; set; }
        public JumpGame()
        {
            ArrayGiven = new[] { 2, 3, 1, 1, 4 };
            Dictionary = new Dictionary<int, bool>();
        }

        //Brute FOrce
        public bool DFS(int index)
        {
            if (index == ArrayGiven.Length - 1)
            {
                Dictionary[index] = true;
                return true;
            }

            bool isViable = false;

            if (Dictionary.ContainsKey(index))
            {
                return Dictionary[index];
            }
            for (int i = 1; i < ArrayGiven[index]; i++)
            {
                var val = DFS(index + i);
                if (val)
                {
                    isViable = true;
                    break;
                }
            }

            Dictionary[index] = isViable;
            return isViable;
        }

        //Greedy. Start from last and go to first
        public bool Greedy()
        {
            var goalPost = ArrayGiven.Length - 1;
            var returnValue = true;
            //var goalPost = ArrayGiven[^1];
            for (int i = ArrayGiven.Length - 2; i <= 0; i--)
            {
                if (i + ArrayGiven[i] >= ArrayGiven[goalPost])
                {
                    goalPost = i;
                }
                else
                {
                    returnValue = false;
                    break;
                }
            }

            return returnValue;
        }

    }
}
