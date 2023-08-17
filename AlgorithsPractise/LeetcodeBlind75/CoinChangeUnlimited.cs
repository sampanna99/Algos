using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgorithsPractise.LeetcodeBlind75
{
     public class CoinChangeUnlimited
     {
         public int Amount { get; set; } = 7;
        public int[] Elements { get; set; }

        public List<Stack<int>> ResultOfStacks { get; set; }
        public Dictionary<int, List<Tuple<int, Stack<int>>>> ElementAndCorrespondingList { get; set; }
        public int MinCoin { get; set; } = Int32.MaxValue;
        public CoinChangeUnlimited()
        {
            Elements = new[] { 1, 3, 4, 5 };
            ResultOfStacks = new List<Stack<int>>();
            ElementAndCorrespondingList = new Dictionary<int, List<Tuple<int, Stack<int>>>>();
            //length and all the elements on that.
        }

        public int startWithThis()
        {
            return NumberOfCoins(new Stack<int>(), Amount);
        }
        public int NumberOfCoins(Stack<int> coins, int sumUpto)
        {
            for (int i = 0; i < Elements.Length; i++)
            {
                //mistake here. just debug it
                var remaining = sumUpto - Elements[i];
                coins.Push(Elements[i]);

                if (ElementAndCorrespondingList.ContainsKey(Elements[i]))
                {
                    var allList = ElementAndCorrespondingList[Elements[i]];
                    var atLeastOne = false;
                    for (int j = 0; j < allList.Count; j++)
                    {
                        if (allList[j].Item1 <= coins.Count + 1)
                        {
                            atLeastOne = true;
                        }
                    }

                    if (!atLeastOne)
                    {
                        var newOne = new Stack<int>(coins);
                        //newOne.Push(Elements[i]);
                        var sum = Amount - newOne.Sum();
                        newOne.Push(sum);
                        var length = newOne.Count;
                        //var sumofStack = newOne.Sum() - Elements[i];
                        ElementAndCorrespondingList[Elements[i]].Add
                            (Tuple.Create(length, newOne));
                        if (length < MinCoin)
                        {
                            MinCoin = length;
                        }
                    }

                    coins.Pop();
                    continue;
                }
                if (remaining < 0)
                {
                    //not feasible
                }
                else if (remaining == 0)
                {
                    //exactly feasible
                    // do things and continue.

                    var newOne = new Stack<int>(coins);
                    var length = coins.Count;
                    if (length < MinCoin)
                    {
                        MinCoin = length;
                    }

                    var sumofStack = newOne.Sum() - Elements[i];

                    if (ElementAndCorrespondingList.ContainsKey(sumofStack))
                    {
                        ElementAndCorrespondingList[sumofStack].Add(Tuple.Create(length, newOne));
                    }
                    else
                    {
                        ElementAndCorrespondingList.Add(sumofStack, new List<Tuple<int, Stack<int>>>
                        {
                            Tuple.Create(length, newOne)
                        });
                        //ElementAndCorrespondingList.Add(sumofStack, Tuple.Create(length, newOne));
                    }


                    ResultOfStacks.Add(newOne);
                }
                else
                {
                    NumberOfCoins(coins, remaining);
                }

                coins.Pop();
            }

            return MinCoin;
        }
    }
}
