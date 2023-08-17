using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithsPractise.LeetcodeSolutions
{
    public class NextGreaterElement
    {
        public int[] CircularArray { get; set; }
        public int[] CircularArrayRes { get; set; }
        public Stack<int> Stack { get; set; }

        public NextGreaterElement()
        {
            CircularArray = new[] { 1, 2, 1 };
            Stack = new Stack<int>();
            CircularArrayRes = new int[CircularArray.Length];
        }

        public void Algorithm()
        {
            var length = CircularArray.Length;
            for (int i = 0; i < CircularArray.Length * 2; i++)
            {
                if (Stack.Count != 0)
                {
                    var value = Stack.Peek();
                    if (CircularArray[value] < CircularArray[i % CircularArray.Length])
                    {
                        //pop
                        while (CircularArray[value] < CircularArray[i % length] && Stack.Count != 0)
                        {
                            value = Stack.Pop();
                            CircularArrayRes[value] = CircularArray[i % length];
                        }
                    }
                    else
                    {
                        //push
                        if (i < CircularArray.Length)
                        {
                            Stack.Push(i);
                        }
                    }
                }
                else if(i < CircularArray.Length)
                {
                    Stack.Push(i);
                }
            }

            while (Stack.Count > 0)
            {
                var val = Stack.Pop();
                CircularArrayRes[val] = -1;
            }
        }
    }
}
