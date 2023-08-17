using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithsPractise.LeetcodeBlind75
{
    public class BestTimeToBuyAndSellStock
    {
        public int[] StockPrices { get; set; }
        public int MaxProfit { get; set; }

        public BestTimeToBuyAndSellStock()
        {
            StockPrices = new[] { 7, 1, 5, 3, 6, 4 };
        }

        public void MaxProfitSecured()
        {
            var buyIndex = 0;
            for (int i = 1; i < StockPrices.Length; i++)
            {
                if (StockPrices[buyIndex] > StockPrices[i])
                {
                    buyIndex = i;
                }else if (MaxProfit < (StockPrices[i] - StockPrices[buyIndex]))
                {
                    MaxProfit = StockPrices[i] - StockPrices[buyIndex];
                }
            }

            Console.WriteLine($"The max profit is {MaxProfit}");
        }
    }
}
