
using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithsPractise.LeetCode_Eric.Phase5
{
    public class DpDecisionMaking
    {

    }

    public class BuyAndSellStock
    {
        public int[] Prices { get; set; }

        public void Algorithmn()
        {
            var (buy, sell, max) = (0, 1, Int32.MinValue);

            while (sell < Prices.Length)
            {
                var buyPrice = Prices[buy];
                var sellPrice = Prices[sell];

                var profit = sellPrice - buyPrice;
                if (profit > max)
                {
                    max = profit;
                }

                if (buyPrice > sellPrice)
                {
                    buy = sell;
                }

                sell += 1;
            }

            Console.WriteLine($"Maximum Profit is {max}");
        }
    }

    public class BuySellStock2
    {
        public int[] Prices { get; set; }

        public BuySellStock2()
        {
            
        }

        public void Algorithmn()
        {
            var (buy, sell) = (0, 1);
            var profitUpto = 0;
            int maxProfit = 0;
            while (sell < Prices.Length)
            {
                var (buyP, sellP) = (Prices[buy], Prices[sell]);
                var profit = sellP - buyP;
                //if (buyP > sellP)
                //{
                //    buy = sell;
                //}

                if (profit < 0 || profit < maxProfit)
                {
                    buy = sell;
                    profitUpto += maxProfit;
                }
                else
                {
                    maxProfit = profit;
                }

                sell += 1;
            }
            Console.WriteLine($"Maximum Profitable is {profitUpto}");
        }
    }

    public class JumpGame
    {
        public int[] GivenArray { get; set; }
        public Dictionary<int, bool> Dictionary { get; set; }
        public JumpGame()
        {
            Dictionary = new Dictionary<int, bool>();
        }

        public bool DFS(int index)
        {
            //base case
            if (index == GivenArray.Length - 1)
            {
                return true;
            }

            if (Dictionary.ContainsKey(index))
            {
                return Dictionary[index];
            }

            var valueAtIn = GivenArray[index];

            var untilNow = false;
            for (int i = 1; i <= valueAtIn; i++)
            {

                var iPlusIndex = i + index;
                if (iPlusIndex >= GivenArray.Length)
                {
                    break;
                }

                
                var ispossible = Dictionary.ContainsKey(iPlusIndex) ? Dictionary[iPlusIndex] :
                    DFS(iPlusIndex);
                if (ispossible)
                {
                    untilNow = true;
                    break;
                }
            }

            Dictionary[index] = untilNow;
            return untilNow;
        }

        public bool Dp()
        {
            var boolDp = new bool[GivenArray.Length];
            boolDp[^1] = true;
            var (findLeast, currentIte) = (GivenArray.Length - 1, GivenArray.Length - 2);

            while (currentIte >= 0)
            {
                var valueHere = GivenArray[currentIte];
                var indexPlusV = valueHere + currentIte;

                if (indexPlusV >= findLeast)
                {
                    findLeast = currentIte;
                    boolDp[currentIte] = true;
                }

                currentIte -= 1;
            }

            return boolDp[0];
        }
    }
}
