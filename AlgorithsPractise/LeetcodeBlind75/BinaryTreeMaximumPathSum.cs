using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithsPractise.LeetcodeBlind75
{
    public class BinaryTreeMaximumPathSum
    {
        public NodeLR RootNode { get; set; }

        public int MaxPathSum(NodeLR maxWithThisCenter)
        {
            if (maxWithThisCenter == null)
            {
                return 0;
            }

            var left = MaxPathSum(maxWithThisCenter.Left);
            var right = MaxPathSum(maxWithThisCenter.Right);
            //return Math.Max(Math.Max(left + maxWithThisCenter.Value, right + maxWithThisCenter.Value),
            //    left + right + maxWithThisCenter.Value);
            return Math.Max(maxWithThisCenter.Value, Math.Max(maxWithThisCenter.Value + left,
                Math.Max(maxWithThisCenter.Value + right, maxWithThisCenter.Value + right + left)));
        }
    }

    public class NodeLR
    {
        public NodeLR Left { get; set; }
        public NodeLR Right { get; set; }
        public int Value { get; set; }
    }
}
